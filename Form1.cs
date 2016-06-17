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

        private void textBox1_Keydown(object sender, KeyEventArgs e)
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
            button1.Enabled = false;
            textBox1.Enabled = false;

            if (!textBox1.Text.StartsWith("http://"))
            {
                textBox1.Text = "http://" + textBox1.Text;
            }
            
            webBrowser1.Navigate(textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
        }
    }
}
