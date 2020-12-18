using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Core.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
