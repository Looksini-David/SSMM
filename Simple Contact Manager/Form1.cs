using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fixed_Bugs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Block digits from being typed
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Numbers are not allowed in the name.");
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the key
                MessageBox.Show("Only numbers are allowed in the phone number.");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;

            // Bug: Doesn't check if fields are empty

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Enter your name and phone number!");
                return;
            }

            // Simplified phone number validation
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must be 10 digits.");
                return;
            }

            // Add to list if validation passes
            lstDisplay.Items.Add(name + " - " + phone);
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPhone.Clear();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            
                if (lstDisplay.SelectedIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        lstDisplay.Items.RemoveAt(lstDisplay.SelectedIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a contact to delete.");
                }
        }
    }
}
