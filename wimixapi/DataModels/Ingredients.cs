using System;
using System.Collections.Generic;

namespace wimixapi.DataModels
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        public int IngredientId { get; set; }
        public long ZobristKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
