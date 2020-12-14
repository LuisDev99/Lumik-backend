using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using Assistant.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Services
{
    public class GroceryListService : BaseService<GroceryList>, IGroceryListService
    {
        private readonly IGroceryListRepository _groceryListRepository;

        public GroceryListService(
            IRepository<GroceryList> baseGroceryListRepository, 
            IGroceryListRepository groceryListRepository) 
            : base(baseGroceryListRepository)
        {
            _groceryListRepository = groceryListRepository;
        }

        public ServiceResult<GroceryList> GetGroceryListByName(string name)
        {
            try
            {
                var groceryList = _groceryListRepository.GetGroceryListByNameIncludingDependencies(name);
                return ServiceResult<GroceryList>.SuccessResult(groceryList);
            }catch(Exception)
            {
                return ServiceResult<GroceryList>.ErrorResult("Error while getting grocery list by its name");
            }
        }

        public ServiceResult<IEnumerable<Recipe>> GetSuggestedRecipes()
        {             
            throw new NotImplementedException();
        }
    }
}
