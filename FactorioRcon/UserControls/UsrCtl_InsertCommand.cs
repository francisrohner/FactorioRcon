using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactorioLib.Data;
using System.Net;

namespace FactorioRcon.UserControls
{
    public partial class UsrCtl_InsertCommand : UserControl
    {
        private WebClient _client;
        public UsrCtl_InsertCommand(ItemFactory itemFactory)
        {
            InitializeComponent();
            _client = new WebClient();
            foreach(Item item in itemFactory.Items)
                cmbItem.Items.Add(item);
            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
            //Load += UsrCtl_InsertCommand_Load;
            cmbItem.SelectedIndex = 0;
            nudCount.ValueChanged += NudCount_ValueChanged;
            tbAmount.ValueChanged += TbAmount_ValueChanged;
        }

        private void TbAmount_ValueChanged(object sender, EventArgs e)
        {
            nudCount.Value = tbAmount.Value;
        }

        private void NudCount_ValueChanged(object sender, EventArgs e)
        {
            tbAmount.Value = (int)nudCount.Value;
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = cmbItem.SelectedItem as Item;
            item.FetchIcon(_client, out Bitmap bmp);
            pbItem.Image = bmp;
        }
    }
}
