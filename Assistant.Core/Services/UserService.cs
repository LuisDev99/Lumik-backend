using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Core.Entities;
using Assistant.Core.Interfaces;

namespace Assistant.Core.Services
{
    public class UserService : BaseService<User>, IUser
    {
        public UserService(IRepository<User> userRepository) : base(userRepository)
        {
        }
    }
}
