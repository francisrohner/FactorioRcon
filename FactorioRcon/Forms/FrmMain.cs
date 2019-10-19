using FactorioLib.Data;
using FactorioLib.Network;
using FactorioLib.Utils;
using FactorioRcon.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorioRcon.Forms
{
    public partial class FrmMain : Form
    {
        private RconClient rconClient;
        private List<string> updateQueue;
        private Dictionary<Tuple<Version, DateTime>, List<string>> changeLog;

        private Queue<UIUpdate> uiQueue;
        private object queueLock = new object();

        private List<RconCommand> outgoing = new List<RconCommand>();
        private List<RconResponse> incoming = new List<RconResponse>();

        public FrmMain()
        {
            InitializeComponent();
            changeLog = new Dictionary<Tuple<Version, DateTime>, List<string>>();
            updateQueue = new List<string>();
            try
            {
                Icon = Icon.FromHandle(Properties.Resources.factorio.GetHicon());
            }
            catch { ShowIcon = false; ShowInTaskbar = false; }
            rconClient = new RconClient();
            
            foreach(Control ctl in GetAll(this, typeof(GroupBox)))                
                (ctl as GroupBox).Paint += GroupBox_Paint; //Bind render override

            rconClient.CommandSent += Rcon_CommandSent;
            rconClient.ResponseReceived += Rcon_ResponseReceieved;
            Load += FrmMain_Load;
            FormClosing += FrmMain_FormClosing;         
            KeyDown += FrmMain_KeyDown;
            txtClientCmd.KeyDown += TxtClientCmd_KeyDown;

            InitChangeLog();
            InitGrids();
        }

        private void Rcon_CommandSent(object sender, RconClient.RconCommandEventArgs rea)
        {
            DisplayOutgoing(rea.command);
        }

        private void InitGrids()
        {
            gridIn.DataSource = new BindingSource()
            {
                DataSource = incoming
            };
            gridOut.DataSource = new BindingSource()
            {
                DataSource = outgoing
            };            
        }        

        private void LoadSettings()
        {
            if (File.Exists("fr.cfg"))
            {
                File.Decrypt("fr.cfg");
                StreamReader reader = new StreamReader("fr.cfg");
                txtHost.Text = reader.ReadLine();
                txtPort.Text = reader.ReadLine();
                txtPassword.Text = reader.ReadLine();
                reader.Close();
            }
        }
        private void SaveSettings()
        {
            StreamWriter writer = new StreamWriter("fr.cfg");
            writer.WriteLine(txtHost.Text);
            writer.WriteLine(txtPort.Text);
            writer.WriteLine(txtPassword.Text);
            writer.Close();
            File.Encrypt("fr.cfg");
        }

        private void TxtClientCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                if (!string.IsNullOrEmpty(txtClientCmd.Text))
                    btnSend.PerformClick();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == (Keys.Control | Keys.Enter))
            {
                if(!string.IsNullOrEmpty(txtClientCmd.Text))
                    btnSend.PerformClick();
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();

            try
            {                
                rconClient.Disconnect();
            }
            catch { }
        }

        private void Rcon_ResponseReceieved(object sender, RconClient.RconResponseEventArgs rea)
        {
            DisplayIncoming(rea.response);
            if(rea.response.ResponseType == RconResponse.Type.RESPONSE_VALUE)
                Queue_UI_Update("ServerResp," +  rea.response.Message);
        }
        public void Queue_UI_Update(string cmd)
        {
            lock(queueLock)
            {
                updateQueue.Add(cmd);
            }
        }

        //public void QueueUpdate(RconClient.RconResponseEventArgs args)
        //{
        //    lock(queueLock)
        //    {
        //        args.response.
        //        uiQueue.Enqueue()
        //    }
        //}

        private abstract class UIUpdate
        {
            object payload;
            public abstract void Invoke(FrmMain form);
        }
        public class ResponseUpdate
        {

        }

        //Handler for styling GroupBox borderss
        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            Helper.DrawGroupBox(gb, e.Graphics, Color.DarkGreen);
        }

        //Function from: https://stackoverflow.com/a/3426721
        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        #region About
        
        private void AppendChange(Tuple<Version, DateTime> ver_date, string note)
        {
            if(!changeLog.ContainsKey(ver_date))
                changeLog.Add(ver_date, new List<string>());
            changeLog[ver_date].Add(note);            
        }
        private void InitChangeLog()
        {
            AppendChange(new Tuple<Version,DateTime>(new Version(1, 0, 0, 0), new DateTime(2019, 04, 08)), "Initial build, working but UI is unresponsive");
            AppendChange(new Tuple<Version, DateTime>(new Version(1, 0, 0, 1), new DateTime(2019, 04, 09)), "Working command generator, need to revise image aquisition code");
            foreach(Tuple<Version, DateTime> key in changeLog.Keys)
            {
                rtbChangeLog.AppendText("[" + key.Item1.ToString() + " -- " + key.Item2.ToString("yyyy-MM-dd") + "]\r\n");

                foreach (string note in changeLog[key])
                    rtbChangeLog.AppendText("\t--" + note + "\r\n");
            }


            //Process Changes
            rtbChangeLog.AppendText("");
        }
        private void LLDonate_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=francis.rohner@outlook.com&lc=US&item_name=Donation+for+Factory+Rcon+Development&no_note=0&cn=&currency_code=USD&bn=PP-DonationsBF:btn_donateCC_LG.gif:NonHosted");
        }

        private void PbCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(lblBTCAddress.Text);
            }
            catch
            {
                //Believe it or not Outlook causes issues with this
                MessageBox.Show(this, "Unable to copy text to clipboard, another process may be preventing this.", "Clipboard Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LL_Email_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:citricube@msn.com");
        }
        private void LlGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/francisrohner/FactorioRcon.git");
        }
        #endregion About


        /// <summary>
        /// Get name of first online player with quotations
        /// </summary>
        /// <returns></returns>
        public string GetOnlinePlayer()
        {
            string ret = string.Empty;
            if(lstOnline.Items.Count > 0)
                ret = "\"" + (string)lstOnline.Items[0] + "\"";
            return ret;
        }
        private void BtnCmdGenerator_Click(object sender, EventArgs e)
        {
            UC_CommandGenerator cg = new UC_CommandGenerator(this);
            cg.Dock = DockStyle.Fill;
            tabConsole.Controls.Add(cg);
            cg.BringToFront();
        }        
        public void SetConsoleText(string cmd) { txtClientCmd.Text = cmd; }
        private void EnableUI()
        {
            tcMain.Enabled = true;
            gbQuickCommand.Enabled = true;
        }
        private void DisableUI()
        {
            tcMain.Enabled = false;
            gbQuickCommand.Enabled = false;
        }        

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("Connect"))
            {
                int port;
                if (!int.TryParse(txtPort.Text, out port))
                {
                    MessageBox.Show(this, "Please input a numerical port value.", "Incorrect Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int ec = rconClient.Connect(txtHost.Text, port, txtPassword.Text);
                if (ec < 0)
                {
                    if (ec == (int)ERROR_CODES.INCORRECT_PASSWORD)
                    {
                        MessageBox.Show(this, "Incorrect password supplied.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string errorMsg = $"Unable to establish a connection to {txtHost.Text}:{port}.";
                        MessageBox.Show(this, errorMsg, "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    try
                    {
                        rconClient.Disconnect();
                    }
                    catch { }
                }
                else //Connection Success
                {
                    btnConnect.Text = "Disconnect";
                    SendCommand("/p");
                    EnableUI();
                }
            }
            else //Disconnect
            {
                try
                {
                    DisableUI();
                    rconClient.Disconnect();
                    btnConnect.Text = "Connect";
                }
                catch { }
            }
        }

        public void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {            
            SendCommand(txtClientCmd.Text);            
            AppendText(rtbServerResp, txtClientCmd.Text + "\r\n", Color.Blue);
            txtClientCmd.Clear();
        }
        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            tmrUpdateUI.Enabled = false; //prevent re-entry
            List<string> queueCopy = new List<string>();
            lock(queueLock)
            {
                if (updateQueue.Count > 0)
                {
                    foreach (string update in updateQueue)
                        queueCopy.Add((string)update.Clone());
                    updateQueue.Clear();
                }
            }
            while(queueCopy.Count > 0)
            {
                string[] arr = queueCopy[0].Split(',');
                queueCopy.RemoveAt(0);
                string task = arr.First();
                if (task == "ServerResp")
                {
                    string resp = arr[1];
                    AppendText(rtbServerResp, resp + "\r\n", Color.Red);
                    if(resp.Contains("Players")) //update status tab page
                        ProcessPlayersStr(resp);
                }
                else if(task == "RefreshIncoming")
                {
                    (gridIn.DataSource as BindingSource).CurrencyManager.Refresh();
                }
                else if(task == "RefreshOutgoing")
                {
                    (gridOut.DataSource as BindingSource).CurrencyManager.Refresh();
                }

            }
            tmrUpdateUI.Enabled = true;
        }
        private void ProcessPlayersStr(string str_players)
        {
            lstOffline.Items.Clear();
            lstOnline.Items.Clear();
            string[] lines = str_players.Replace("\r", "").Split('\n');
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Contains("(online)"))
                    lstOnline.Items.Add(lines[i].Replace("(online)", "").Trim());
                else //offline
                    lstOffline.Items.Add(lines[i].Trim());
            }
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            SendCommand("/h");
        }

        private void BtnSetDay_Click(object sender, EventArgs e)
        {
            string onlinePlayer = GetOnlinePlayer();
            if (string.IsNullOrEmpty(onlinePlayer))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SendCommand($"/c game.players[{onlinePlayer}].surface.always_day=true");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SendCommand("/save");
        }
        
        private void BtnClearPollution_Click(object sender, EventArgs e)
        {
            string online_player = GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SendCommand(string.Format("/c game.players[{0}].surface.clear_pollution()", online_player));
            }
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            SendCommand("/p");
        }

        private void BtnPurgeBiters_Click(object sender, EventArgs e)
        {
            string online_player = GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cmd = "/c local surface=game.players[" + online_player +"].surface for key, entity in pairs(surface.find_entities_filtered({ force = \"enemy\"})) do  entity.destroy() end";
                SendCommand(cmd);
            }
        }

        private void BtnPurgeEvolution_Click(object sender, EventArgs e)
        {
            SendCommand("/c game.forces[\"enemy\"].evolution_factor=0");
        }

        private void BtnResearchAll_Click(object sender, EventArgs e)
        {
            string online_player = GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SendCommand("/c game.players[" + online_player + "].force.research_all_technologies()");
            }
        }


        private string SurfaceCommand(string player, string type, int amount)
        {
            return  $"/c surface = game.players[{player}].surface for _, ore in pairs(surface.find_entities_filtered({{ type = \"{type}\"}})) do ore.amount = {amount} end";
        }

        //pending
        private void BtnRefillResources_Click(object sender, EventArgs e)
        {
            string online_player = GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] ores = new[] { "iron-ore", "copper-ore", "stone", "crude-oil", "coal", "uranium-ore" };
            foreach(string ore in ores)
            {
                SendCommand(SurfaceCommand(online_player, ore, 1000));
            }            
        }

        private void DisplayOutgoing(RconCommand cmd)
        {
            outgoing.Add(cmd);
            //(gridOut.DataSource as BindingSource).CurrencyManager.Refresh();
            updateQueue.Add("RefreshOutgoing");
        }
        private void DisplayIncoming(RconResponse resp)
        {
            incoming.Add(resp);
            //(gridIn.DataSource as BindingSource).CurrencyManager.Refresh();
            updateQueue.Add("RefreshIncoming");
        }

        private void SendCommand(string command)
        {
            RconCommand rcmd = new RconCommand(command);            
            rconClient.QueueCommand(rcmd);
        }
    }
}
