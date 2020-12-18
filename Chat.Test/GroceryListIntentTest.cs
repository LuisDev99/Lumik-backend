using Chat.Core.Entities;
using Chat.Test.TestBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Test
{
    public class GroceryListIntentTest
    {        
        [Theory]
        [InlineData(Intent.DeleteList)]
        public async void GroceryListIntent_Acts_OnDeleteIntent_Succeds(Intent intent)
        {
            // arrange
            var builder = new GroceryListIntentTestBuilder();
            var groceryListIntentHandler = builder.Build();
            var deleteUserIntent = builder.GenerateFakeUserIntent(intent);

            // act
            var groceryListIntentHandlerReply = await groceryListIntentHandler.Act(deleteUserIntent);

            // assert
            Assert.NotNull(groceryListIntentHandlerReply);
            Assert.Contains("Man are you sure? Well, to late. The list gone bro", groceryListIntentHandlerReply);
        }

        [Theory]
        [InlineData(Intent.None)]
        public async void GroceryListIntent_Acts_OnNoneGroceryListIntent_Succeds(Intent intent)
        {
            // arrange
            var builder = new GroceryListIntentTestBuilder();
            var groceryListIntentHandler = builder.Build();
            var deleteUserIntent = builder.GenerateFakeUserIntent(intent);

            // act
            var groceryListIntentHandlerReply = await groceryListIntentHandler.Act(deleteUserIntent);

            // assert
            Assert.NotNull(groceryListIntentHandlerReply);
            Assert.Equal("I don't know what you tried to do with the grocery list", groceryListIntentHandlerReply);
        }
    }
}
