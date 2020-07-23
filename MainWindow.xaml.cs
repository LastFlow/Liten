using System;
using System.Windows;
using System.Windows.Input;
using CefSharp;
using CefSharp.Wpf;
    
namespace Liten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   

        public MainWindow()
        {
            //browser props


            var settings = new CefSettings();
            //settings software acceleration
            settings.CefCommandLineArgs.Add("enable-gpu", "1");
            //settings.CefCommandLineArgs.Add("enable-gpu-compositing", "1");
            //settings.CefCommandLineArgs.Add("enable-gpu-rasterization", "1");
            //settings.CefCommandLineArgs.Add("off-screen-rendering-enabled", "1");
            //settings.CefCommandLineArgs.Add("disable-gpu-vsync");

            // Misc
            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0";
            settings.LogFile = "DEBUG.log";
            
            
            


            Cef.Initialize(settings);


            InitializeComponent();
            //initialization window props
            window.SizeChanged += SizeWindowChange;
            window.Left = 0;
            window.Top = 0;
            window.Width = SystemParameters.PrimaryScreenWidth;
            window.Height = SystemParameters.PrimaryScreenHeight - 128;
            TB.Width = window.Width - 256;
            
                      



        }
        void SizeWindowChange(object sender, RoutedEventArgs e)
        {
            //Do not use!!!!!111
            //window.Width = SystemParameters.PrimaryScreenWidth;
            //window.Height = SystemParameters.PrimaryScreenHeight;
            //Browser.Width = window.Width;
            //TB.Width = window.Width;


        }

        private void ChromiumWebBrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            //throw new NotImplementedException();
            Dispatcher.Invoke((Action) (() =>
            {
                TB.Text = e.Url;
                Back.IsEnabled = Browser.CanGoBack;
                Forward.IsEnabled = Browser.CanGoForward;

            }));

            
        }

        void BackBtn(object sender, RoutedEventArgs e)
        {  
            if (Browser.CanGoBack)
            {
                Browser.Back();
            }
        }
        void ForwardBtn(object sender, RoutedEventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.Forward();
            }
        }
        
        void Navigate(object sender, KeyEventArgs e)
        {
            if(e.Key.ToString() == "Return")
            {

                if (!string.IsNullOrWhiteSpace(TB.Text))
                {
                    MessageBox.Show(TB.Text.Substring(4, TB.Text.Length));


                    Browser.Address = TB.Text;
                    
                }
            }
        }
    
    }
}
