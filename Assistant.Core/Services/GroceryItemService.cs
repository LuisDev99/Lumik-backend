using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Services
{
    public class GroceryItemService : BaseService<GroceryItem>, IGroceryItem
    {        
        public GroceryItemService(IRepository<GroceryItem> groceryItemRepository)
            : base(groceryItemRepository)
        {
        }        
    }
}
