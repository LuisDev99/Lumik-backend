using Assistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IGroceryListService : IBaseService<GroceryList>
    {
        public ServiceResult<GroceryList> GetGroceryListByName(string name);

        public ServiceResult<IEnumerable<Recipe>> GetSuggestedRecipes();
    }
}
