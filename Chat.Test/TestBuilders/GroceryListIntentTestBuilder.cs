using Chat.Core.Entities;
using Chat.Core.Entities.APIModels;
using Chat.Core.Intents;
using Chat.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Test.TestBuilders
{
    public class GroceryListIntentTestBuilder
    {
        public GroceryListIntent Build()
        {
            var fakeAssistantRepository = GetDefaultAssistantRepository().Object;

            return new GroceryListIntent(fakeAssistantRepository);
        }

        public UserIntent GenerateFakeUserIntent(Intent intent)
        {
            return new UserIntent
            {
                IntentData = new IntentData
                {
                    Intent = intent,
                    Entities = new Dictionary<string, object>()
                    {
                        { JsonEntitiesNameConstants.LIST_NAME, "Ignore my value" }
                    },
                }
            };
        }

        private Mock<IAssistantRepository> GetDefaultAssistantRepository()
        {
            var mock = new Mock<IAssistantRepository>();

            mock.Setup(x => x.DeleteList(It.IsAny<GroceryList>()))
                .ReturnsAsync("Man are you sure? Well, to late. The list gone bro");

            return mock;
        }
    }
}
