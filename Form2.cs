    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DiraryProgram
{
    public partial class Form2 : Form
    {
        bool modified= false;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.ForeColor = colorDialog1.Color;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            button3.Text = textBox1.Font.Name;
            this.ActiveControl = textBox1;
            this.FormClosed += Form2_FormClosed;
            textBox1.KeyDown += TextBox1_KeyDown;
            
            textBox1.Text = DataBase.ReadText(DateTime.Now);

            Timer t = new Timer();
            t.Interval = 1000;
            t.Start();
            t.Tick += T_Tick;


        }

        private void T_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToLongTimeString();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text.Length > 0 && modified)
            {
                DataBase.SaveText(textBox1.Text);
                modified = false;
            }

            this.Owner.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            button3.Font = fontDialog1.Font;
            button3.Text = fontDialog1.Font.Name;
            textBox1.Font = fontDialog1.Font;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
