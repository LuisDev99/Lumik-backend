using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models.InsertModels
{
    public class AddGroceryItem
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public int GroceryListID { get; set; }
    }
}
