using System;
using System.Collections.Generic;

namespace wimixapi.DataModels
{
    public partial class RecipeIngredients
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public short Amount { get; set; }
        public byte? Order { get; set; }

        public Ingredients Ingredient { get; set; }
        public Recipes Recipe { get; set; }
    }
}
