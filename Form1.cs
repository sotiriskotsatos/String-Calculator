using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace String_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void onClick(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        private void Backspace(object sender, EventArgs e)
        {
            textBox1.Text= textBox1.Text.Length > 0?textBox1.Text.Remove(textBox1.Text.Length - 1): textBox1.Text;
        }

        private void Calculate(object sender, EventArgs e)
        {
            textBox1.Text = StringCalc.Calc(String_Splitter.SplitStr(textBox1.Text));
        }

        private void Multipl(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void Div(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void Percentage(object sender, EventArgs e)
        {

            textBox1.Text = double.TryParse(textBox1.Text, out double i) ? (i / 100).ToString() + "%" : "Please use numeric expression with the % operator";
        }

        private void OffButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearText(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
    }
}
