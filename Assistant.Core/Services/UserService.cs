using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;
using System.Linq;


namespace Assistant.Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<GroceryList> _baseGroceryListRepository;

        public UserService(IRepository<User> userRepository, IRepository<GroceryList> baseGroceryListRepository) 
            : base(userRepository)
        {
            _userRepository = userRepository;
            _baseGroceryListRepository = baseGroceryListRepository;
        }

        public ServiceResult<User> GetUserByEmail(string email)
        {
            var user = _userRepository.GetByCondition(user => user.Email.ToLower() == email.ToLower());

            return ServiceResult<User>.SuccessResult(user);
        }

        public ServiceResult<IEnumerable<GroceryList>> GetUserGroceryLists(int userID)
        {
            var groceryLists = _baseGroceryListRepository.Filter(list => list.UserID == userID);

            return ServiceResult<IEnumerable<GroceryList>>.SuccessResult(groceryLists);
        }

        public override ServiceResult<User> Insert(User userInfo)
        {
            // Validate if user's email is unique
             var results = _userRepository.Filter(user => user.Email == userInfo.Email);

            if(results.ToList().Count > 0)
            {
                return ServiceResult<User>.PetitionDenied($"User {userInfo.UserName} already exists");
            }

            return base.Insert(userInfo);
        }
    }
}
