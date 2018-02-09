using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using wimixapi.DataModels;
using wimixapi.Models;

namespace wimixapi.Services
{
    public class WimixDataService : IWimixDataService
    {
        private readonly WimixDataContext _wimixDataContext;
        public WimixDataService (WimixDataContext dataContext)
        {
            _wimixDataContext = dataContext;
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _wimixDataContext.Ingredients.Select(i => new Ingredient(i));
        }

        public Recipe GetRecipe(int id)
        {
            var recipe = _wimixDataContext.Recipes
                                          .Where(r => r.RecipeId == id)
                                          .Include(r => r.RecipeIngredients)
                                          .Include("RecipeIngredients.Ingredient")
                                          .Single();

            return new Recipe(recipe);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _wimixDataContext.Recipes
                                    .Include(r => r.RecipeIngredients)
                                    .Include("RecipeIngredients.Ingredient")
                                    .Select(r => new Recipe(r));
        }

        public IEnumerable<Recipe> GetRecipes(IEnumerable<long> zobristKeys)
        {
            return _wimixDataContext.Recipes
                                    .Where(r => zobristKeys.Contains(r.ZobristKey))
                                    .Include(r => r.RecipeIngredients)
                                    .Include("RecipeIngredients.Ingredient")
                                    .Select(r => new Recipe(r));
        }
    }
}
