using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Services
{
    public class GroceryListService : BaseService<GroceryList>, IGroceryList
    {

        public GroceryListService(IRepository<GroceryList> groceryListRepository) : base(groceryListRepository)
        {
        }

        public IEnumerable<Recipe> GetSuggestedRecipes()
        {             
            throw new NotImplementedException();
        }
    }
}
