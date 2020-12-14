using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities.APIModels
{
    public class GroceryList
    {
        public GroceryList()
        {
            GroceryItems = new List<GroceryItem>();
        }

        public string Name { get; set; }                

        public int UserID { get; set; }

        public ICollection<GroceryItem> GroceryItems { get; set; }
    }
}
