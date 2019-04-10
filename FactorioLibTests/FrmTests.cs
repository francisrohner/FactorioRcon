using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactorioLibTests
{
    public partial class FrmTests : Form
    {
        public FrmTests()
        {
            InitializeComponent();
            try
            {
                Icon = Icon.FromHandle(Properties.Resources.flask.GetHicon());
            }
            catch { ShowIcon = false; ShowInTaskbar = false; }
        }
    }
}
