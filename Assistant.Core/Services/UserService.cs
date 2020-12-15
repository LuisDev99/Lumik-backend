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

        public ServiceResult<IEnumerable<GroceryList>> GetUserGroceryLists(int userID)
        {
            var groceryLists = _baseGroceryListRepository.Filter(list => list.UserID == userID);

            return ServiceResult<IEnumerable<GroceryList>>.SuccessResult(groceryLists);
        }

        public override ServiceResult<User> Insert(User userInfo)
        {
            // Validate if user's username is unique (Is this efficient?)
             var results = _userRepository.Filter(user => user.UserName == userInfo.UserName);

            if(results.ToList().Count > 0)
            {
                return ServiceResult<User>.PetitionDenied($"Usuario {userInfo.UserName} ya existe");
            }

            return base.Insert(userInfo);
        }
    }
}
