using Assistant.Core;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Assistant.Core.Services;

namespace Lumik.Test.TestBuilder
{
    public class UserServiceTestBuilder
    {
        private IRepository<User> _userRepository;
        private IRepository<GroceryList> _baseGroceryListRepository;

        public UserService Build()
        {
            _userRepository = GetDefaultUserBaseRepository().Object;

            return new UserService(_userRepository, _baseGroceryListRepository);
        }

        public Mock<IRepository<User>> GetDefaultUserBaseRepository()
        {
            var mock = new Mock<IRepository<User>>();

            mock.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User
                {
                    UserName = "Emely",
                    Email = "emely@1"
                });

            return mock;
        }
    }
}
