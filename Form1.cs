using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace String_Calculator
{
    public partial class Form1 : Form
    {
        private bool computed;
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
            
        private bool FirstChar(out string errMsg)
        {
            errMsg = "Sequence must start with a number";
            return textBox1.Text.Length <1;
        }
        private void OnClick(object sender, EventArgs e)
        {
            var clicked = (sender as Button).Text;
            if (FirstChar(out string errMsg) && !double.TryParse(clicked, out _))
            {
                MessageBox.Show(errMsg, "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text.Contains("%")|| computed)
                textBox1.Text = string.Empty;
            computed = false;
            textBox1.Text += clicked;
        }

        private void Backspace(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Length > 0 ? textBox1.Text.Remove(textBox1.Text.Length - 1) : textBox1.Text;
        }

        private void Validation(List<string> subStrings,out string errMsg)
        {
            errMsg = string.Empty;
            if (!double.TryParse(subStrings[subStrings.Count-1], out _))
            {
                errMsg = "Sequence must end with a number";
                return;
            }
            else
            {
                for(int i = 0; i < subStrings.Count; i++)
                {
                    var numOrNot = double.TryParse(subStrings[i], out _);
                    if (!numOrNot)
                    {
                        if (!double.TryParse(subStrings[i + 1], out _))
                        {
                            errMsg = "Operator must be followed by a number";
                            return;
                        }
                        else if (subStrings[i].Equals(","))
                        {
                            if (i + 1 < subStrings.Count)
                            {
                                string temp = subStrings[i - 1] + "," + subStrings[i + 1];
                                subStrings[i - 1] = temp;
                                subStrings.RemoveAt(i);
                                subStrings.RemoveAt(i);
                                Validation(subStrings, out errMsg);
                            }
                            else
                            {
                                errMsg = "Comma cannot be followed by comma";
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            computed = true;
            var subStrings = String_Splitter.SplitStr(textBox1.Text).ToList();
            Validation(subStrings, out string errMsg);
            if (errMsg.Length > 0)
            {
                MessageBox.Show(errMsg, "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox1.Text = StringCalc.Calc(subStrings);
        }

        private void Multipl(object sender, EventArgs e)
        {
            if (FirstChar(out string errMsg))
            {
                MessageBox.Show(errMsg, "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (computed)
                textBox1.Text = string.Empty;
            computed = false;
            textBox1.Text += "*";
        }

        private void Div(object sender, EventArgs e)
        {
            if (FirstChar(out string errMsg))
            {
                MessageBox.Show(errMsg, "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (computed)
                textBox1.Text = string.Empty;
            computed = false;
            textBox1.Text += "/";
        }

        private void Percentage(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double i))
                textBox1.Text = (i / 100).ToString() + "%";
            else
            {
                MessageBox.Show("Operator % should be used with numeric expression only", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = string.Empty;
            }
        }

        private void OffButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearText(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
