using Lumik.Test.TestBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lumik.Test
{
    public class UserServiceTest
    {
        [Theory]
        [InlineData("emely@1")]
        public void GetUserByEmail_Succeds(string email)
        {
            // arrange
            var builder = new UserServiceTestBuilder();
            var userService = builder.Build();

            // act 
            var service = userService.GetUserByEmail(email);
            var user = service.Result;

            // assert
            Assert.NotNull(user);
            Assert.Equal("emely@1", user.Email);
        }       
    }
}
