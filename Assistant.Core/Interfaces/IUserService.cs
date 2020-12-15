using Assistant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        ServiceResult<IEnumerable<GroceryList>> GetUserGroceryLists(int userID);
    }
}
