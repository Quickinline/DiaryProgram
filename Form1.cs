using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiraryProgram
{
    public partial class Form1 : Form
    {
        bool usrtrue = false;
        bool psswrdtrue = false;
        public Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            if(Username.Text.GetHashCode() == "Quickinline".GetHashCode())
            {
                usrtrue = true;
            }
            else { usrtrue = false; }
            if(usrtrue && psswrdtrue)
            {
                form2 = new Form2();
                form2.Owner = this;
                form2.Show();
                this.Hide();
                Username.Text = string.Empty;
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if(Password.Text.GetHashCode() == "Programing23".GetHashCode())
            {
                psswrdtrue = true;
            }
            else { psswrdtrue = false; }
            if(usrtrue && psswrdtrue)
            {
                form2 = new Form2();
                form2.Owner = this;
                form2.Show();
                this.Hide();
                Password.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Username.KeyDown += Username_KeyDown;
            this.ActiveControl = Username;
            form2.Owner = this;

        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = Password;
                e.SuppressKeyPress = true;
            }
            
        }
    }
}
