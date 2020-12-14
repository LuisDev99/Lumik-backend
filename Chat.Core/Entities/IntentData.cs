using System;
using System.Collections.Generic;
using System.Text;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Core.Entities
{
    public class IntentData
    {
        public Intent Intent { get; set; }

        public IDictionary<string, object> Entities { get; set; }
    }
}
