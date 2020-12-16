using Assistant.Core.Entities;
using Assistant.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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
            // Retrieve ALL recipes from the db (Horrible)
            var recipes = _dbContext.Recipes.Include(recipe => recipe.Ingredients).ToList();

            // Retrieve all recipes that matches any groceryListItem Name [Massive hack]
            var filteredRecipes = recipes
                .Where(recipe => recipe.Ingredients
                    .Where(ingredient =>
                    {
                        foreach (var item in groceryListItems)
                        {
                            if (ingredient.Name.ToLower().Contains(item.Name.ToLower()))
                            {
                                return true;
                            }
                        }

                        return false;
                    }).ToList().Any()).ToList().Take(5);


            return filteredRecipes;
        }
    }
}
