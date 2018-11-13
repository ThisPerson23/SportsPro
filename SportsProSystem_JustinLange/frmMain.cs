using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsProSystem_JustinLange
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void maintainProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form productMaintenance = new frmProductMaintenance();
            productMaintenance.MdiParent = this;
            productMaintenance.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maintainCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form customerMaintenance = new frmCustomerMaintenance();
            customerMaintenance.MdiParent = this;
            customerMaintenance.Show();
        }
    }
}
