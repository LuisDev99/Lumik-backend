using Chat.Core.Entities;
using Chat.Core.Helpers;
using Chat.Core.Intents;
using Chat.Core.Interfaces;
using Chat.Core.Interfaces.Intents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Core.Handler
{
    public class IntentHandler : IIntentHandler
    {
        private readonly IAssistantRepository _assistantRepository;

        public IntentHandler(IAssistantRepository assistantRepository)
        {
            _assistantRepository = assistantRepository;
        }

        public async Task<string> HandleUserIntent(UserIntent userIntent)
        {
            userIntent.IntentData.Entities = CleanIntentDataEntitiesValues(userIntent.IntentData.Entities);

            switch (userIntent.IntentData.Intent)
            {
                case Intent.CreateEvent:
                    return await new EventIntent(_assistantRepository).Act(userIntent);

                /* All grocery list related intents */
                case Intent.ShowList:
                case Intent.DeleteList:
                case Intent.CreateList:
                case Intent.GetAllLists:
                case Intent.AddElementToList:
                case Intent.RemoveElementFromList:
                    return await new GroceryListIntent(_assistantRepository).Act(userIntent);

                default:
                    return "I don't know what you tried to say or do men. " + 
                        "Are you sure you are saying a valid command that I understand? " +
                        "Don't waste my CPU cyles";
            }            
        }

        private IDictionary<string, object> CleanIntentDataEntitiesValues(IDictionary<string, object> entities)
        {
            foreach(var (entityKey, entityValue) in entities)
            {
                entities[entityKey] = BotHelper.RemoveGarbageFromString(entityValue.ToString());
            }

            return entities;
        }
    }
}
