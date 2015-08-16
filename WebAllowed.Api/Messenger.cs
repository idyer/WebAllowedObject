using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace WebAllowed.Api
{
    [AllowForWeb]
    public sealed class Messenger //: IAgileObject
    {
        public event EventHandler<ShowMessageEvent> OnMessageRecieved;

        public void ProcessMessage(string msg)
        {
            ShowMessageEvent e = new ShowMessageEvent(msg);

            Windows.System.Threading.ThreadPool.RunAsync(
               (IAsyncAction action) =>
               {
                   if (OnMessageRecieved != null)
                   {
                       OnMessageRecieved(this, e);
                   }
               });
        }

        public int GetVal()
        {
            return 123;
        }
    }
}
