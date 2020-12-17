using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using Chat.Core.Interfaces;
using Chat.Core.Interfaces.Intents;
using System;
using System.Threading.Tasks;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Core.Handler
{
    internal class RecipeIntent : BaseIntent
    {
        public RecipeIntent(IAssistantRepository assistantRepository)
            : base(assistantRepository)
        {
        }

        public override async Task<string> Act(UserIntent userIntention)
        {
            switch(userIntention.IntentData.Intent)
            {
                case Intent.FindRecipes:
                    return await _assistantRepository.FindRecipesForGroceryList(new GroceryList
                    {
                        Name = userIntention.IntentData.Entities[JsonEntitiesNameConstants.LIST_NAME].ToString(),
                    });

                default:
                    return "I am sorry, You tried to do something with a recipe but I just can't figure out what it is";
            }
        }
    }
}