using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using Chat.Core.Interfaces;
using Chat.Core.Interfaces.Intents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Core.Intents
{
    public class GroceryListIntent : BaseIntent
    {
        public GroceryListIntent(IAssistantRepository assistantRepository) 
            : base(assistantRepository)
        {
        }

        public override async Task<string> Act(UserIntent userIntention)
        {
            var intentData = userIntention.IntentData;

            switch(intentData.Intent)
            {
                case Intent.AddElementToList:
                    return  await _assistantRepository.AddElementToList(new GroceryItem {
                        Name = intentData.Entities["ProductName"].ToString(),
                        Count = 1,       
                        GroceryListName = intentData.Entities["ListName"].ToString(),
                    });

                case Intent.ShowList:
                    return await _assistantRepository.ShowListItems(new GroceryList 
                        { 
                            Name = intentData.Entities["ListName"].ToString() 
                        });

                case Intent.DeleteList:
                    return await _assistantRepository.DeleteList(new GroceryList
                    {
                        Name = intentData.Entities["ListName"].ToString()
                    });

                case Intent.CreateList:
                    return await _assistantRepository.CreateList(new GroceryList
                    {
                        Name = intentData.Entities["ListName"].ToString(),
                        UserID = userIntention.UserID,
                    });

                case Intent.GetAllLists:
                    return await _assistantRepository.GetAllGroceryListsForUser(new User
                    {
                        ID = userIntention.UserID,
                    });

                case Intent.RemoveElementFromList:
                    return await _assistantRepository.RemoveElementFromToList(new GroceryItem
                    {
                        Name = intentData.Entities["ProductName"].ToString(),
                    });

                default:                    
                    return "I don't know what you tried to do with the grocery list";
            }
        }
    }
}
