/**
* @file
* @author
* Justin Lange 2018
* @version 1.0
*
*
* @section DESCRIPTION
* SportsPro System Application - Assignment 3 - Customer Info Form
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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        /**
         * Load handler for the Customer form
         * Sets up bindings for the Zip Code Textbox
         * And fills the textboxes based on customerID
         */
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            Binding b = zipCodeTextBox.DataBindings["Text"];
            b.Format += FormatZipCode;
            b.Parse += UnformatZipCode;

            this.customersTableAdapter.FillByCustomerID(this.techSupportDataSet2C.Customers, Convert.ToInt32(this.Tag));
        }

        /**
         * Function to format the zip code with a hyphen between the first 5 and last 4 digits for readability
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
         * Function to unformat the zip code back to 9 straight digits
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
         * Function to check if a string is a valid integer
         */
        private bool IsInt64(string s)
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
    }
}
