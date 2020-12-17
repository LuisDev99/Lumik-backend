using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities.APIModels
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
