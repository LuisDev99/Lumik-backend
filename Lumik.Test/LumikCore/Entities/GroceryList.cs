using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class GroceryList : BaseEntity
    {

        public GroceryList()
        {
            GroceryItems = new List<GroceryItem>();
        }

        public string Name { get; set; }                

        public int UserID { get; set; }

        public User User { get; set; }

        public ICollection<GroceryItem> GroceryItems { get; set; }
    }
}
