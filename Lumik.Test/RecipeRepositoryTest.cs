using Assistant.Core.Entities;
using Lumik.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lumik.Test
{
    public class RecipeRepositoryTest
    {
        [Theory]
        [InlineData("CocaCola")]
        public void ComplexFindRecipes_ReturnResults_Succeds(string itemName)
        {
            // arrange
            var fakeRecipeRepository = new FakeRecipeRepository();

            // act
            var recommendedRecipes = fakeRecipeRepository.FindRecipesByIngredients(new List<GroceryItem>
            {
                new GroceryItem
                {
                    Name = itemName,
                }
            });

            // assert
            Assert.NotNull(recommendedRecipes);
            Assert.NotEmpty(recommendedRecipes);
            Assert.Equal("TestRecipe1", recommendedRecipes.ElementAt(0).Name);
        }

        [Theory]
        [InlineData("InvalidCocaCola")]
        public void ComplexFindRecipes_ReturnResults_Fails(string itemName)
        {
            // arrange
            var fakeRecipeRepository = new FakeRecipeRepository();

            // act
            var recommendedRecipes = fakeRecipeRepository.FindRecipesByIngredients(new List<GroceryItem>
            {
                new GroceryItem
                {
                    Name = itemName,
                }
            });

            // assert
            Assert.Empty(recommendedRecipes);
        }
    }
}
