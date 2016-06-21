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

namespace BuntingBrowser
{
    public partial class Form1 : Form
    {
        public void setSettings(string settings)//Alternatively, use an INI file. There's a good DLL file I could give you to use it instead. Really easy to use and whatnot
        {
            File.WriteAllText(Directory.GetCurrentDirectory()+"user.profile", settings); //Of course, change name to whatever
        }
        
        /* HomeButton Method
        {
            webBrowser1.Navigate(getSettings("home"));
        }
        */
        
        /* HomeButtonSet Methd
        {
            setSettings(webBrowser1.url.toString()); //Of course, fix the .url as it's probably not correct.
        }
        
        */
        
        public string getSettings(string setting)
        {
            if(setting.equals("home"))
            {
                return File.ReadAllText(Directory.GetCurrentDirectory()+"user.profile");
            }
            return "";
        }
        public Form1()
        {
            InitializeComponent();

            webBrowser1.Navigate(homepage);
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
            } else {
            }

            webBrowser1.Navigate(textBox1.Text);
        }

        private void webBrowser1_KeyDown(object sender, KeyEventArgs e)  //Add this in form1.designer
        {
            if(e.KeyCode == Keys.F5)
            {
                webBrowser1.Navigate(webBrowser1.url.toString()); //Fix whatever URL is supposed to be.
                // Try to see if there's a webBrowser1.Refresh or Reload. Obviously I can't tell ATM.
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
            textBox1.Text = webBrowser1.Url.AbsoluteUri;

            if (webBrowser1.Url.AbsoluteUri.StartsWith("https://"))
            {
                textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#AED581");
            }
            else
            {
                textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack) {
                webBrowser1.GoBack();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward) {
                webBrowser1.GoForward();
            }
        }
    }
}
