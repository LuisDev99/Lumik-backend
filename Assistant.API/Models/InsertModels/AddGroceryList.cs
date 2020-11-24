using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.API.Models.InsertModels
{
    public class AddGroceryList
    {
        public string Name { get; set; }

        public int UserID { get; set; }
    }
}
