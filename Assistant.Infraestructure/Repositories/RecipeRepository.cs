using Assistant.Core.Entities;
using Assistant.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Assistant.Infraestructure.Repositories
{
    public class RecipeRepository : EntityFrameworkRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(AssistantDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Recipe> FindRecipesByIngredients(IEnumerable<GroceryItem> groceryListItems)
        {
            // Retrieve all recipes [Massive hack]
            var recipes = _dbContext.Recipes.AsEnumerable()
                .Where(i => i.Ingredients
                    .Where(ing =>
                    {
                        foreach (var item in groceryListItems)
                        {
                            if (ing.Name.ToLower().Contains(item.Name.ToLower()))
                            {
                                return true;
                            } 
                        }

                        return false;
                    }).Any());


            return recipes;
        }
    }
}
