using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public int RecipeID { get; set; }

        public Recipe Recipe { get; set; }        
    }
}
