using Assistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Core.Interfaces.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> FindRecipesByIngredients(IEnumerable<GroceryItem> groceryListItems);
    }
}
