using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using Assistant.Core.Interfaces.Repositories;

namespace Assistant.Core.Services
{
    public class RecipeService : BaseService<Recipe>, IRecipeService
    {
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(
            IGroceryListRepository groceryListRepository, 
            IRecipeRepository recipeRepository,
            IRepository<Recipe> baseRecipeRepository)
            : base(baseRecipeRepository)
        {
            _groceryListRepository = groceryListRepository;
            _recipeRepository = recipeRepository;
        }

        public ServiceResult<IEnumerable<Recipe>> GetRecommendedRecipesForGroceryList(string groceryListName)
        {
            var groceryList = _groceryListRepository.GetGroceryListByNameIncludingDependencies(groceryListName);

            if (groceryList == null) 
                return ServiceResult<IEnumerable<Recipe>>.ErrorResult($"Grocery List {groceryListName} does not exists");

            var recipes = _recipeRepository.FindRecipesByIngredients(groceryList.GroceryItems);
            return ServiceResult<IEnumerable<Recipe>>.SuccessResult(recipes);

        }
    }
}
