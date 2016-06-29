using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuntingBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string homepage = "http://bing.com";

        public MainWindow()
        {
            InitializeComponent();

            webBrowser1.Navigate(homepage);
        }
      
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                navigate();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            navigate();
        }

        private void navigate()
        {
            goButton.IsEnabled = false;
            urlBar.IsEnabled = false;

            if (!urlBar.Text.StartsWith("http://")) {
                urlBar.Text = "http://" + urlBar.Text;
            }
            else
            {

            }

            webBrowser1.Navigate(urlBar.Text);
        }

        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            goButton.IsEnabled = true;
            urlBar.IsEnabled = true;
            urlBar.Text = webBrowser1.Source.AbsoluteUri;

            if (webBrowser1.Source.AbsoluteUri.StartsWith("https://"))
            {
                urlBar.Background = Brushes.LightGreen;
            }
            else
            {
                urlBar.Background = Brushes.White;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser1.CanGoBack) 
            {
                webBrowser1.GoBack();
            }
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }
    }
}
