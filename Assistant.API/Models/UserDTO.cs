﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models
{
    public class UserDTO : BaseEntityDTO
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
