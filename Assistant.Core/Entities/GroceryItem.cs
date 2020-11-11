using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class GroceryItem : BaseEntity
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public int GroceryListID { get; set; }

        public GroceryList GroceryList { get; set; }        
    }
}
