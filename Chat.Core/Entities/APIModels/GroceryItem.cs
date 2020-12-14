using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Entities.APIModels
{
    public class GroceryItem
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public string GroceryListName { get; set; }

        public int GroceryListID { get; set; }
    }
}
