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
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public override ServiceResult<User> Insert(User userInfo)
        {
            // Validate if user's username is unique (Is this efficient?)
             var results = userRepository.Filter(user => user.UserName == userInfo.UserName);

            if(results.ToList().Count > 0)
            {
                return ServiceResult<User>.PetitionDenied($"Usuario {userInfo.UserName} ya existe");
            }

            return base.Insert(userInfo);
        }
    }
}
