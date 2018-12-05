/**
* @file
* @author
* Justin Lange 2018
* @version 1.0
*
*
* @section DESCRIPTION
* SportsPro System Application - Assignment 3 - Incidents By Product Form
*
*
*
*
* @section LICENSE
*
*
* Copyright 2018
* Permission to use, copy, modify, and/or distribute this software for
* any purpose with or without fee is hereby granted, provided that the
* above copyright notice and this permission notice appear in all copies.
*
* THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
* WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
* ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
* WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
* ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
* OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*
* @section Academic Integrity
* I certify that this work is solely my own and complies with
* NBCC Academic Integrity Policy (policy 1111)
*/

using System;
using System.Windows.Forms;

namespace SportsProSystem_JustinLange
{
    public partial class frmIncidentsByProduct : Form
    {
        public frmIncidentsByProduct()
        {
            InitializeComponent();
        }

        /**
         * Load handler for the IncidentsByProduct form
         */
        private void frmIncidentsByProduct_Load(object sender, EventArgs e)
        {
            this.incidentsTableAdapter.Fill(this.techSupportDataSet2C.Incidents);
            this.productsTableAdapter.Fill(this.techSupportDataSet2C.Products);
        }

        /**
         * Handler for CellContentClick of the incidents DataGridView Control
         * Gets the customerID of the row that was clicked, and sets it as the Tag property of the new customer info window
         */
        private void incidentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int customerId = Convert.ToInt32(incidentsDataGridView.Rows[e.RowIndex].Cells[7].Value);

            Form customerForm = new frmCustomer();
            customerForm.Tag = customerId.ToString();
            customerForm.StartPosition = FormStartPosition.CenterScreen;
            customerForm.Show();
        }
    }
}
