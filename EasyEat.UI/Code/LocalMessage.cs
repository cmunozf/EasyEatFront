using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyEat.UI.Code
{
    public class LocalMessage
    {
        public string Message { get; set; }
        public MessageType Type { get; set; }
    }
    public enum MessageType
    {
        Error,
        Information,
        Warning
    }
}