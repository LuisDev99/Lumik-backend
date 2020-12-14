using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities
{
    public class UserIntent
    {
        public int UserID { get; set; }

        public IntentData IntentData { get; set; }
    }
}
