using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuntingBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textbox1_Keydown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                navigate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigate();
        }
        
        private void navigate()
        {
            if(!textBox1.StartsWith("http://"))
            {
                textBox1 = "http://"+textBox1.Text;
            }
            webBrowser1.Navigate(textBox1.Text);
        }
    }
}
