﻿using Assistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IRecipeService : IBaseService<Recipe>
    {
        ServiceResult<IEnumerable<Recipe>> GetRecommendedRecipesForGroceryList(string groceryListName);
    }
}
