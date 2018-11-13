/**
* @file
* @author
* Justin Lange 2018
* @version 1.0
*
*
* @section DESCRIPTION
* Customer Maintenance Form for SportPro System
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
    public partial class frmCustomerMaintenance : Form
    {
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            { 
                try
                {
                    this.customersBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.techSupportDataSet1);
                }
                catch (DBConcurrencyException)
                {
                    MessageBox.Show("A concurrency error occurred. The row was not updated.", "Concurrency Exception", MessageBoxButtons.OK);
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    this.customersBindingSource.CancelEdit();
                    this.statesBindingSource.CancelEdit();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Server error #" + ex.Number + ":" + ex.Message, ex.GetType().ToString());
                }
            }
        }

        /**
         * Check to see if all input is valid
         */
        private bool IsValidData()
        {
            if (customersBindingSource.Count > 0)
            {
                return IsPresent(nameTextBox, "Name") &&
                       IsPresent(addressTextBox, "Address") &&
                       IsPresent(cityTextBox, "City") &&
                       IsPresent(stateComboBox, "State") &&
                       IsPresent(zipCodeTextBox, "Zip Code");
            }
            else
                return true;

        }

        /**
         * Check to see if the required data has been entered into the form
         */
        private bool IsPresent(Control control, string name)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(name + " is a required field.", "Entry Error");
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(name + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private void frmCustomerMaintenance_Load(object sender, EventArgs e)
        {
            /**
             * Bind format and unformat functions to the Zip Code Text Box
             */
            Binding b = zipCodeTextBox.DataBindings["Text"];
            b.Format += FormatZipCode;
            b.Parse += UnformatZipCode;

            try
            {
                this.statesTableAdapter.Fill(this.techSupportDataSet1.States);
                stateComboBox.SelectedIndex = -1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error #" + ex.Number + ";" + ex.Message, ex.GetType().ToString());
            }
        }

        /**
         * Function to format the zip code with a dash after the first 5 digits
         */
        private void FormatZipCode(object sender, ConvertEventArgs e)
        {
            if (e.Value.GetType().ToString() == "System.String")
            {
                string s = e.Value.ToString();

                if (IsInt64(s))
                {
                    if (s.Length == 9)
                    {
                        e.Value = s.Substring(0, 5) + "-" +
                                  s.Substring(5, 4);
                    }
                }
            }
        }

        /**
         * Function to unformat the zip code, removing the dash after the first 5 digits
         */
        private void UnformatZipCode(object sender, ConvertEventArgs e)
        {
            if (e.Value.GetType().ToString() == "System.String")
            {
                string s = e.Value.ToString();
                e.Value = s.Replace("-", "");
            }
        }

        /**
         * Function to see if a string can be properly converted to an integer
         */
        public bool IsInt64(string s)
        {
            try
            {
                Convert.ToInt64(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /**
         * Fill by CustomerID Button Event Handler
         */
        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int CustomerID = Convert.ToInt32(customerIDToolStripTextBox.Text);
                this.customersTableAdapter.FillByCustomerID(this.techSupportDataSet1.Customers, CustomerID);

                if (customersBindingSource.Count == 0)
                    MessageBox.Show("No Customer found with this ID. Please Try again.", "Customer Not Found", MessageBoxButtons.OK);
            }
            catch (FormatException)
            {
                MessageBox.Show("Customer ID must be an integer.", "Entry Error", MessageBoxButtons.OK);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        /**
         * Cancel Edit Button Click Event
         */
        private void bindingNavigatorCancelEdit_Click(object sender, EventArgs e)
        {
            this.customersBindingSource.CancelEdit();
            this.statesBindingSource.CancelEdit();
        }
    }
}
