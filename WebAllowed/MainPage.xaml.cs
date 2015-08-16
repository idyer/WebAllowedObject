using System;
using WebAllowed.Api;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebAllowed
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Messenger _messenger = new Messenger();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.webView.Navigate(new Uri("http://localhost:59535/index.html"));

            this.webView.ScriptNotify += WebView_ScriptNotify;
            this.webView.NavigationStarting += WebView_NavigationStarting;

            _messenger.OnMessageRecieved += Messenger_OnMessageRecieved;
        }

        private void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            this.webView.AddWebAllowedObject("test", _messenger);
        }

        private void Messenger_OnMessageRecieved(object sender, ShowMessageEvent e)
        {
            System.Diagnostics.Debug.WriteLine("Web allowed message recieved " + e.Message);
        }

        private void WebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Script notify message: {0}", e.Value);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.webView.Refresh();
        }
    }
}
