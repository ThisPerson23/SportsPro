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
    public partial class frmIncidentsByProduct : Form
    {
        public frmIncidentsByProduct()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet2C);

        }

        private void frmIncidentsByProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet2C.Incidents' table. You can move, or remove it, as needed.
            this.incidentsTableAdapter.Fill(this.techSupportDataSet2C.Incidents);
            // TODO: This line of code loads data into the 'techSupportDataSet2C.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.techSupportDataSet2C.Products);

        }
    }
}
