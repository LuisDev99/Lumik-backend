using Chat.Test.TestBuilders;
using System;
using Xunit;
using static Chat.Core.Entities.ShoppingBot;

namespace Chat.Test
{
    public class BotRepositoryTest
    {
        [Theory]
        [InlineData("show me all lists")]
        public async void GetUserIntention_E2E_ReturnsShowListFromCommand_Succeds(string command)
        {
            // arrange
            var builder = new BotRepositoryTestBuilder();
            var botRepository = builder.Build();

            // act
            var intentData = await botRepository.GetUserIntention(command);

            // assert
            Assert.NotNull(intentData);
            Assert.Equal(Intent.GetAllLists, intentData.Intent);
        }

        [Theory]
        [InlineData("Zacarracatelas")]
        public async void GetUserIntention_E2E_ReturnsNoneFromCommand_Succeds_(string command)
        {
            // arrange
            var builder = new BotRepositoryTestBuilder();
            var botRepository = builder.Build();

            // act
            var intentData = await botRepository.GetUserIntention(command);

            // assert
            Assert.NotNull(intentData);
            Assert.Equal(Intent.None, intentData.Intent);
        }
    }
}
