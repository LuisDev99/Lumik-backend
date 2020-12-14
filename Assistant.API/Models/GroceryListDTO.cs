using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models
{
    public class GroceryListDTO : BaseEntityDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int UserID { get; set; }

        public IEnumerable<GroceryItemDTO> GroceryItems;
    }
}
