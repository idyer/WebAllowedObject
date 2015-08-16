using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAllowed.Api
{
    public sealed class ShowMessageEvent
    {
        public string Message { get; set; }

        public ShowMessageEvent(string msg)
        {
            this.Message = msg;
        }
    }
}
