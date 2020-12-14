using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities
{
    public class UserCommand
    {
        public string Token { get; set; }

        public string UserID { get; set; }

        public string Command { get; set; }
    }
}
