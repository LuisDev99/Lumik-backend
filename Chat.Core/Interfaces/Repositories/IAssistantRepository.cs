using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces
{
    public interface IAssistantRepository
    {
        Task<string> FindRecipeForUser(User user);

        Task<string> CreateEvent(Event newEvent);

        Task<string> GetAllGroceryListsForUser(User user);

        Task<string> ShowListItems(GroceryList list);

        Task<string> CreateList(GroceryList newList);

        Task<string> DeleteList(GroceryList groceryList);

        Task<string> AddElementToList(string groceryListName, GroceryItem newItem);

        Task<string> RemoveElementFromToList(GroceryItem groceryItem);
    }
}
