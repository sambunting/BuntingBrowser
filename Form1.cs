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

            toolStripStatusLabel1.Text = "Navigation Started";

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
            toolStripStatusLabel1.Text = "Navigation Complete";
            textBox1.Text = webBrowser1.Url.AbsoluteUri;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0) {
                int percentage = (int)(e.CurrentProgress * 100 / e.MaximumProgress);

                if (percentage <= 100) {
                    toolStripProgressBar1.ProgressBar.Value = percentage;
                }
            }
            else
            {
                toolStripProgressBar1.ProgressBar.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            navigate();
        }
    }
}
