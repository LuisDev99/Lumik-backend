using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;

namespace Assistant.Core.Services
{
    public class RecipeService : BaseService<Recipe>, IRecipe
    {
        public RecipeService(IRepository<Recipe> recipeRepository) : base(recipeRepository)
        {
        }
    }
}
