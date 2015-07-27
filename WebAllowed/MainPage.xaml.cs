using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebAllowed
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.webView.Navigate(new Uri("http://localhost:59535/index.html"));

            this.webView.ScriptNotify += WebView_ScriptNotify;
            this.webView.NavigationStarting += WebView_NavigationStarting;
        }

        private void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Script notify message: {0}", e.Value);
        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            this.webView.AddWebAllowedObject("test", new Messenger());
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.webView.Refresh();
        }
    }

    [AllowForWeb]
    public class Messenger
    {
        public void DoSomething()
        {
            System.Diagnostics.Debug.WriteLine("Web allowed message recieved");
        }
    }
}
