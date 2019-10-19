using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactorioRcon.Forms;
using FactorioLib.Data;
using FactorioLib.Utils;

namespace FactorioRcon.UserControls
{
    public partial class UC_CommandGenerator : UserControl
    {
        private FrmMain frmMain;        
        private UC_InsertCommand insertCmd;
        private UC_RefillOre refillOre;

        public UC_CommandGenerator(FrmMain frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

            _InitPlayers();
            _InitCommands();
            

            ItemFactory itemFactory = new ItemFactory();
            itemFactory.Load("recipedump.txt");
            refillOre = new UC_RefillOre() { Dock = DockStyle.Fill };
            insertCmd = new UC_InsertCommand(itemFactory) { Dock = DockStyle.Fill };
            cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;
            cmbType.SelectedIndex = 0;
            gbParam.Paint += GbParam_Paint;

        }

        private void _InitPlayers()
        {
            foreach (string online_player in frmMain.lstOnline.Items)
                cmbPlayer.Items.Add(online_player);
            if(cmbPlayer.Items.Count > 0)
                cmbPlayer.SelectedIndex = 0;
        }

        private void GbParam_Paint(object sender, PaintEventArgs e)
        {
            Helper.DrawGroupBox(sender as GroupBox, e.Graphics, Color.DarkGreen);
        }
        

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbParam.Controls.Clear();
            switch (cmbType.SelectedIndex)
            {
                case 0: //Insert
                    gbParam.Text = "Item";                    
                    gbParam.Controls.Add(insertCmd);
                    break;
                case 1:
                    gbParam.Text = "Ore";
                    gbParam.Controls.Add(refillOre);
                    break;

            }
        }

        private void _InitCommands()
        {
            cmbType.Items.Add("Insert Item");
            //TODO
            //cmbType.Items.Add("Refill Ore");
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }
        
        private string _Quote(string val)
        {
            return "\"" + val + "\"";
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {            
            string str_cmd = string.Empty;

            Control ctl = gbParam.Controls[0];

            switch(cmbType.SelectedIndex)
            {
                case 0: //item
                    UC_InsertCommand uctl = ctl as UC_InsertCommand;
                    str_cmd = "/c game.players[" + _Quote(cmbPlayer.Text) + "].insert{name=" + _Quote(uctl.cmbItem.Text) + ", count=" + uctl.tbAmount.Value + "}";                    
                    break;
                case 1: //Ore fill
                    
                    break;
            }

            frmMain.SetConsoleText(str_cmd);
            Parent.Controls.Remove(this);
        }
    }
}
