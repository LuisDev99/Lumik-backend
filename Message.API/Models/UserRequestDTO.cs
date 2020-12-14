using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.API.Models
{
    public class UserRequestDTO
    {
        public string Token { get; set; }

        public string Command { get; set; }
    }
}
