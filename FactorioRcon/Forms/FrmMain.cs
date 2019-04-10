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
        private RconClient _rconClient;
        private List<string>_updateQueue;
        private Dictionary<Tuple<Version, DateTime>, List<string>> _changeLog;
        private object _uq_lock = new object();
        public FrmMain()
        {
            InitializeComponent();
            _changeLog = new Dictionary<Tuple<Version, DateTime>, List<string>>();
            _updateQueue = new List<string>();
            try
            {
                Icon = Icon.FromHandle(Properties.Resources.factorio.GetHicon());
            }
            catch { ShowIcon = false; ShowInTaskbar = false; }
            _rconClient = new RconClient();
            _rconClient.ResponseReceived += Rcon_ResponseReceieved;
            foreach(Control ctl in GetAll(this, typeof(GroupBox)))                
                (ctl as GroupBox).Paint += GroupBox_Paint; //Bind render override

            
            FormClosing += FrmMain_FormClosing;
            
            if (File.Exists("fr.cfg"))
            {
                File.Decrypt("fr.cfg");
                StreamReader reader = new StreamReader("fr.cfg");
                txtHost.Text = reader.ReadLine();
                txtPort.Text = reader.ReadLine();
                txtPassword.Text = reader.ReadLine();
                reader.Close();
            }
            _InitChangeLog();
            KeyPress += FrmMain_KeyPress;
            KeyDown += FrmMain_KeyDown;
            txtClientCmd.KeyDown += TxtClientCmd_KeyDown;
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

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter writer = new StreamWriter("fr.cfg");
            writer.WriteLine(txtHost.Text);
            writer.WriteLine(txtPort.Text);
            
            writer.WriteLine(txtPassword.Text);
            writer.Close();
            File.Encrypt("fr.cfg");
            try
            {
                _rconClient.Disconnect();
            }
            catch { }
        }

        private void Rcon_ResponseReceieved(object sender, RconClient.RconResponseEventArgs rea)
        {
            if(rea.response.ResponseType == FactorioLib.Data.RESPONSE_TYPE.RESPONSE_VALUE)
                Queue_UI_Update("ServerResp," +  rea.response.Message);
        }
        public void Queue_UI_Update(string cmd)
        {
            lock(_uq_lock)
            {
                _updateQueue.Add(cmd);
            }
        }

        //Handler for styling GroupBox borderss
        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = sender as GroupBox;
            UI_Utils.DrawGroupBox(gb, e.Graphics, Color.DarkGreen);
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
            if(!_changeLog.ContainsKey(ver_date))
                _changeLog.Add(ver_date, new List<string>());
            _changeLog[ver_date].Add(note);            
        }
        private void _InitChangeLog()
        {
            AppendChange(new Tuple<Version,DateTime>(new Version(1, 0, 0, 0), new DateTime(2019, 04, 08)), "Initial build, working but UI is unresponsive");
            AppendChange(new Tuple<Version, DateTime>(new Version(1, 0, 0, 1), new DateTime(2019, 04, 09)), "Working command generator, need to revise image aquisition code");
            foreach(Tuple<Version, DateTime> key in _changeLog.Keys)
            {
                rtbChangeLog.AppendText("[" + key.Item1.ToString() + " -- " + key.Item2.ToString("yyyy-MM-dd") + "]\r\n");

                foreach (string note in _changeLog[key])
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
        public string _GetOnlinePlayer()
        {
            string ret = string.Empty;
            if(lstOnline.Items.Count > 0)
                ret = "\"" + (string)lstOnline.Items[0] + "\"";
            return ret;
        }
        public void SetConsoleText(string cmd) { txtClientCmd.Text = cmd; }

        #region Console
        private void BtnCmdGenerator_Click(object sender, EventArgs e)
        {
            UsrCtl_CommandGenerator cg = new UsrCtl_CommandGenerator(this);
            cg.Dock = DockStyle.Fill;
            tabConsole.Controls.Add(cg);
            cg.BringToFront();
        }

        private void _EnableUI()
        {
            tcMain.Enabled = true;
            gbQuickCommand.Enabled = true;
        }
        private void _DisableUI()
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
                int ec = _rconClient.Connect(txtHost.Text, port, txtPassword.Text);
                if (ec < 0)
                {
                    string err_msg = string.Format("Unable to establish a connection to {0}:{1}.", txtHost.Text, port);
                    MessageBox.Show(this, err_msg, "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else //Connection Success
                {
                    btnConnect.Text = "Disconnect";
                    _rconClient.QueueCommand("/p");
                    _EnableUI();
                }
            }
            else //Disconnect
            {
                try
                {
                    _DisableUI();
                    _rconClient.Disconnect();
                    btnConnect.Text = "Connect";
                }
                catch { }
            }
        }
        #endregion

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
            //int ec = _rconClient.SendCommand(txtClientCmd.Text);
            _rconClient.QueueCommand(txtClientCmd.Text);
            int ec = 1;
            if (ec > 0)
            {
                AppendText(rtbServerResp, txtClientCmd.Text + "\r\n", Color.Blue);
                txtClientCmd.Clear();
            }
            else
            {
                //err
                MessageBox.Show(this, "Failed to send command.",
                    "Rcon Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            tmrUpdateUI.Enabled = false; //prevent re-entry
            List<string> queueCopy = new List<string>();
            lock(_uq_lock)
            {
                if (_updateQueue.Count > 0)
                {
                    foreach (string update in _updateQueue)
                        queueCopy.Add((string)update.Clone());
                    _updateQueue.Clear();
                }
            }
            while(queueCopy.Count > 0)
            {
                string[] arr = queueCopy[0].Split(',');
                queueCopy.RemoveAt(0);
                if (arr[0] == "ServerResp")
                {
                    string resp = arr[1];
                    AppendText(rtbServerResp, resp + "\r\n", Color.Red);
                    if(resp.Contains("Players")) //update status tab page
                        _ProcessPlayersStr(resp);
                }
            }
            tmrUpdateUI.Enabled = true;
        }
        private void _ProcessPlayersStr(string str_players)
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
            _rconClient.QueueCommand("/h");
        }

        private void BtnSetDay_Click(object sender, EventArgs e)
        {
            string online_player = _GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _rconClient.QueueCommand(string.Format("/c game.players[{0}].surface.always_day=true", online_player));
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            _rconClient.QueueCommand("/save");
        }
        
        private void BtnClearPollution_Click(object sender, EventArgs e)
        {
            string online_player = _GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _rconClient.QueueCommand(string.Format("/c game.players[{0}].surface.clear_pollution()", online_player));
            }
        }

        private void PbRefresh_Click(object sender, EventArgs e)
        {
            _rconClient.QueueCommand("/p");
        }

        private void BtnPurgeBiters_Click(object sender, EventArgs e)
        {
            string online_player = _GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string cmd = "/c local surface=game.players[" + online_player +"].surface for key, entity in pairs(surface.find_entities_filtered({ force = \"enemy\"})) do  entity.destroy() end";
                _rconClient.QueueCommand(cmd);
            }
        }

        private void BtnPurgeEvolution_Click(object sender, EventArgs e)
        {
            _rconClient.QueueCommand("/c game.forces[\"enemy\"].evolution_factor=0");
        }

        private void BtnResearchAll_Click(object sender, EventArgs e)
        {
            string online_player = _GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _rconClient.QueueCommand("/c game.players[" + online_player + "].force.research_all_technologies()");
            }
        }

        //pending
        private void BtnRefillResources_Click(object sender, EventArgs e)
        {
            string online_player = _GetOnlinePlayer();
            if (string.IsNullOrEmpty(online_player))
            {
                MessageBox.Show(this, "This command requires at least one player online.", "No Players Online", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string cmd = "/c surface = game.players[" + online_player + "].surface for _, ore in pairs(surface.find_entities_filtered({ type = \"" + "iron-ore" + "\"})) do ore.amount = 10000 end";
            _rconClient.QueueCommand(cmd);

            cmd = "/c surface = game.players[" + online_player + "].surface for _, ore in pairs(surface.find_entities_filtered({ type = \"" + "copper-ore" + "\"})) do ore.amount = 10000 end";
            _rconClient.QueueCommand(cmd);

            cmd = "/c surface = game.players[" + online_player + "].surface for _, ore in pairs(surface.find_entities_filtered({ type = \"" + "uranium-ore" + "\"})) do ore.amount = 10000 end";
            _rconClient.QueueCommand(cmd);

            cmd = "/c surface = game.players[" + online_player + "].surface for _, ore in pairs(surface.find_entities_filtered({ type = \"" + "stone" + "\"})) do ore.amount = 10000 end";
            _rconClient.QueueCommand(cmd);

            cmd = "/c surface = game.players[" + online_player + "].surface for _, ore in pairs(surface.find_entities_filtered({ type = \"" + "crude-oil" + "\"})) do ore.amount = 10000 end";
            _rconClient.QueueCommand(cmd);
        }
    }
}
