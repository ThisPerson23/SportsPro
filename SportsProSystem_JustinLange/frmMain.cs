/**
* @file
* @author
* Justin Lange 2018
* @version 1.0
*
*
* @section DESCRIPTION
* SportsPro System Application - Assignment 3 - Main Form
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /**
         * Exits the application
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Displays a new MainProducts Form
         */
        private void maintainProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form productMaintenance = new frmProductMaintenance();
            productMaintenance.MdiParent = this;
            productMaintenance.Show();
        }

        /**
         * Displays a new MaintainCustomer Form
         */
        private void maintainCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form customerMaintenance = new frmCustomerMaintenance();
            customerMaintenance.MdiParent = this;
            customerMaintenance.Show();
        }

        /**
         * Displays a new IncidentsByProduct Form
         */
        private void displayIncidentsByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form incidentsByProduct = new frmIncidentsByProduct();
            incidentsByProduct.MdiParent = this;
            incidentsByProduct.Show();
        }
    }
}
