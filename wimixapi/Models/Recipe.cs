using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wimixapi.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public int RecipeId { get; set; }

    }
}
