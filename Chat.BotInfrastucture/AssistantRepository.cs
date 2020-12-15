using Chat.BotInfrastucture.AssistantAPI;
using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using Chat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chat.BotInfrastucture
{
    public class AssistantRepository : IAssistantRepository
    {
        private readonly AssistantAPIClient _assistantAPIClient;

        public AssistantRepository()
        {
            _assistantAPIClient = new AssistantAPIClient("https://localhost:5003", new HttpClient());
        }

        private async Task<GroceryListDTO> FindGroceryListByName(string groceryListName)
        {
            try
            {
                var groceryList = await _assistantAPIClient.GetGroceryListByNameAsync(groceryListName);
                return groceryList;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<string> AddElementToList(string groceryListName, GroceryItem newItem)
        {
            // Figure out the grocery list ID by it's name            
            var groceryList = await FindGroceryListByName(groceryListName);

            // Check if the grocery list exists
            if (groceryList == null)
            {
                return $"Looks like you haven't created the grocery list {newItem.Name}. I can't add sorry";
            }

            // Add the grocery list item to the list
            await _assistantAPIClient
                            .AddGroceryItemAsync(new AddGroceryItem
                            {
                                Name = newItem.Name,
                                GroceryListID = groceryList.Id
                            });

            return $"Your {newItem.Name} were added to {groceryList.Name}! Anything else?";
        }

        public async Task<string> CreateEvent(Event newEvent)
        {
            return "Event Created";
        }

        public async Task<string> CreateList(GroceryList newList)
        {
            // Check if the list already exists
            var groceryList = await FindGroceryListByName(newList.Name);

            if (groceryList != null)
            {
                return $"Looks like you've created the grocery list {newList.Name}";
            }

            // Create the grocery list
            await _assistantAPIClient.CreateGroceryListAsync(new AddGroceryList
            {
                Name = newList.Name,
                UserID = newList.UserID
            });

            return $"Your list {newList.Name} got created";
        }

        public async Task<string> DeleteList(GroceryList groceryList)
        {
            // Check if the list already exists
            var groceryListResult = await FindGroceryListByName(groceryList.Name);

            if (groceryListResult == null)
            {
                return $"The list you are trying to delete does not exist. Are you ok?";
            }

            // Delete the grocery list
            await _assistantAPIClient.DeleteGroceryListAsync(groceryListResult.Id);

            return $"Man are you sure? Well, to late. The list {groceryList.Name} gone bro";
        }

        public async Task<string> FindRecipeForUser(User user)
        {
            //var userGroceryList = await _assistantAPIClient;

            return "Pan con frijoles";
        }

        public async Task<string> GetAllGroceryListsForUser(User user)
        {
            var userGroceryLists = await _assistantAPIClient.GetUsersGroceryListsAsync(user.ID);

            if (userGroceryLists == null || userGroceryLists.Count == 0)
            {
                return "Looks like you don't have any list :( Try creating one! Just try and I'll do it";
            }

            var stringResponse = "Here are your grocery lists: ";

            foreach (var list in userGroceryLists)
            {
                stringResponse += $"\n\t >>> {list.Name}";
            }

            stringResponse += "\nTry doing something with any grocery list listed above!";

            return stringResponse;
        }

        public async Task<string> RemoveElementFromToList(GroceryItem groceryItem)
        {
            var groceryList = await FindGroceryListByName(groceryItem.GroceryListName);

            if (groceryList == null)
            {
                return $"Looks like you haven't created the list {groceryItem.GroceryListName}" +
                    $", so I can't remove the item {groceryItem.Name}";
            }

            var groceryListItem = await _assistantAPIClient.GetGroceryListItemByNameAsync(groceryList.Id, groceryItem.Name);

            if (groceryListItem == null)
            {
                return $"Looks like the list {groceryList.Name} does not have the product: ${groceryListItem.Name}." +
                    "Are you feeling okay?";
            }

            await _assistantAPIClient.DeleteGroceryItemAsync(new GroceryItemDTO
            {
                Id = groceryListItem.Id,
                GroceryListID = groceryList.Id
            });

            return $"Your {groceryItem.Name}  got rakated from the list {groceryList.Name}";
        }

        public async Task<string> ShowListItems(GroceryList list)
        {
            var groceryList = await FindGroceryListByName(list.Name);

            if (groceryList == null)
            {
                return $"List {list.Name} doesn't even exists men, I can't show you its items";
            }

            var groceryListItems = await _assistantAPIClient.GetGroceryListItemsAsync(groceryList.Id);

            var stringReponse = $"Here are the products that your list {list.Name} has: ";

            foreach (var item in groceryListItems)
            {
                stringReponse += $"\n\t - >>> {item.Name}";
            }

            return stringReponse;
        }
    }
}
