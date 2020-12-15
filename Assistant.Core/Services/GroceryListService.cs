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
        private readonly IRepository<GroceryItem> _baseGroceryItemRepository;
        private readonly IGroceryListRepository _groceryListRepository;

        public GroceryListService(
            IRepository<GroceryItem> baseGroceryItemRepository,
            IRepository<GroceryList> baseGroceryListRepository, 
            IGroceryListRepository groceryListRepository) 
            : base(baseGroceryListRepository)
        {
            _baseGroceryItemRepository = baseGroceryItemRepository;
            _groceryListRepository = groceryListRepository;
        }

        public ServiceResult<GroceryList> GetGroceryListByName(string name)
        {
            try
            {
                var groceryList = _groceryListRepository.GetGroceryListByNameIncludingDependencies(name);

                if(groceryList == null)
                {
                    return ServiceResult<GroceryList>.NotFoundResult("Grocery list not found");
                }

                return ServiceResult<GroceryList>.SuccessResult(groceryList);
            }catch(Exception)
            {
                return ServiceResult<GroceryList>.ErrorResult("Error while getting grocery list by its name");
            }
        }

        public ServiceResult<GroceryItem> GetGroceryListItemByName(int groceryListID, string itemName)
        {
            try
            {
                var groceryItem = _baseGroceryItemRepository
                    .GetByCondition(item => item.GroceryListID == groceryListID 
                                                && item.Name.ToLower() == itemName.ToLower());

                return ServiceResult<GroceryItem>.SuccessResult(groceryItem);
            }
            catch (Exception)
            {
                return ServiceResult<GroceryItem>.ErrorResult("Error while getting grocery list item by its item name");
            }
        }

        public ServiceResult<IEnumerable<GroceryItem>> GetGroceryListItems(int groceryListID)
        {
            var groceryItems = _baseGroceryItemRepository.Filter(item => item.GroceryListID == groceryListID);

            return ServiceResult<IEnumerable<GroceryItem>>.SuccessResult(groceryItems);
        }



        public ServiceResult<IEnumerable<Recipe>> GetSuggestedRecipes()
        {             
            throw new NotImplementedException();
        }
    }
}
