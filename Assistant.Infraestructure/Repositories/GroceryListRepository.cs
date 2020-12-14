using Assistant.Core.Entities;
using Assistant.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Infraestructure.Repositories
{
    public class GroceryListRepository : EntityFrameworkRepository<GroceryList>, IGroceryListRepository
    {
        public GroceryListRepository(AssistantDbContext dbContext) : base(dbContext)
        {
        }

        public GroceryList GetGroceryListByNameIncludingDependencies(string name)
        {
            return _dbContext.GroceryLists
                .Include(list => list.GroceryItems)
                .FirstOrDefault(list => list.Name.ToLower() == name.ToLower());
        }
    }
}
