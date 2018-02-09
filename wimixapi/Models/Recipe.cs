using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wimixapi.DataModels;

namespace wimixapi.Models
{
    public class Recipe
    {

        public Recipe(Recipes recipe)
        {
            Ingredients = new List<RecipeIngredient>();
            Name = recipe.Name;
            Description = recipe.Description;
            Key = recipe.RecipeId;
            ZobristKey = recipe.ZobristKey;
            Ordered = recipe.Ordered ?? false;
            Ingredients.AddRange(recipe.RecipeIngredients
                                        .Select(ri => new RecipeIngredient(ri.Amount, ri.Order, ri.Ingredient))
                                );

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public int Key { get; set; }
        public long ZobristKey { get; set; }
        public bool Ordered { get; set; }

    }
}
