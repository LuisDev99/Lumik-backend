using Assistant.Core.Entities;
using Assistant.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lumik.Test.Fakes
{
    public class FakeRecipeRepository : IRecipeRepository
    {
        public readonly IEnumerable<Recipe> _recipes;

        public FakeRecipeRepository()
        {
            _recipes = new List<Recipe>
            {
                new Recipe
                {
                    ID = 1,
                    Name = "TestRecipe1",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                        {
                            Name = "CocaCola",
                            ID = 1,
                        }
                    }
                }
            };
        }

        public IEnumerable<Recipe> FindRecipesByIngredients(IEnumerable<GroceryItem> groceryListItems)
        {
            var filteredRecipes = _recipes
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
