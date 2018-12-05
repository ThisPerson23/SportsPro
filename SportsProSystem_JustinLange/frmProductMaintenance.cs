/**
* @file
* @author
* Justin Lange 2018
* @version 1.0
*
*
* @section DESCRIPTION
* SportsPro System Application - Assignment 3 - Product Maintenance Form
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsProSystem_JustinLange
{
    public partial class frmProductMaintenance : Form
    {
        public frmProductMaintenance()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            { 
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. The row was not updated.", "Concurrency Exception", MessageBoxButtons.OK);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.productsBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error #" + ex.Number + ":" + ex.Message, ex.GetType().ToString());
            }

        }

        private void frmProductMaintenance_Load(object sender, EventArgs e)
        {
            try
            { 
            this.productsTableAdapter.Fill(this.techSupportDataSet.Products);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error #" + ex.Number + ":" + ex.Message, ex.GetType().ToString());
            }
        }

        /**
         * Custom DataGridView Data Error
         */
        private void productsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            string errorMessage = "A data error occurred.\n" +
                                  "Row:" + row + "\n" +
                                  "Error:" + e.Exception.Message;

            MessageBox.Show(errorMessage, "Data Error");
        }
    }
}
