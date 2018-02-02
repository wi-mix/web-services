using System;
using System.Collections.Generic;

namespace wimixapi.DataModels
{
    public partial class Recipes
    {
        public Recipes()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Ordered { get; set; }
        public long ZobristKey { get; set; }

        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
