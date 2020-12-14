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

        public async Task<string> AddElementToList(GroceryItem newItem)
        {            
            //Figure out the grocery list ID
            var groceryList = await _assistantAPIClient.GetGroceryListByNameAsync(newItem.Name);

            if(groceryList == null)
            {
                return $"Looks like you haven't created the grocery list {newItem.Name}. I can't add sorry";
            }

            var result = _assistantAPIClient
                            .AddGroceryItemAsync(new AddGroceryItem
                            {
                                Name = newItem.Name,
                                GroceryListID = groceryList.Id
                            });

            return "Element Added";
        }

        public async Task<string> CreateEvent(Event newEvent)
        {
            return "Event Created";
        }

        public async Task<string> CreateList(GroceryList newList)
        {
            return "List created";
        }

        public async Task<string> DeleteList(GroceryList groceryList)
        {
            return "List deleted";
        }

        public async Task<string> FindRecipeForUser(User user)
        {
            return "Pan con frijoles";
        }

        public async Task<string> GetAllGroceryListsForUser(User user)
        {
            return "No lists found for you";
        }

        public async Task<string> RemoveElementFromToList(GroceryItem groceryItem)
        {
            return "Element removed";
        }

        public async Task<string> ShowListItems(GroceryList list)
        {
            return "OJO PERRO BRAVO!";
        }

        private void CallToAPI()
        {

        }
    }
}
