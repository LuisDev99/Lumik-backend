using Assistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IGroceryListService : IBaseService<GroceryList>
    {
        ServiceResult<IEnumerable<Recipe>> GetSuggestedRecipes();

        ServiceResult<GroceryList> GetGroceryListByName(string name);

        ServiceResult<GroceryItem> GetGroceryListItemByName(int groceryListID, string itemName);

        ServiceResult<IEnumerable<GroceryItem>> GetGroceryListItems(int groceryListID);
    }
}
