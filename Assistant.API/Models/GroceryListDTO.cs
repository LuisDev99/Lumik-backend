using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models
{
    public class GroceryListDTO : BaseEntityDTO
    {
        public string Name { get; set; }

        public int UserID { get; set; }             
    }
}
