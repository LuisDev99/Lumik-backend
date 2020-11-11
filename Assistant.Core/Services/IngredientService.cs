using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;

namespace Assistant.Core.Services
{
    public class IngredientService : BaseService<Ingredient>, IIngredient
    {

        public IngredientService(IRepository<Ingredient> ingredientRepository) : base(ingredientRepository)
        {
        }
        
    }
}
