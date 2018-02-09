using System.Collections.Generic;
using wimixapi.Models;

namespace wimixapi.Services
{
    public interface IWimixDataService
    {
        IEnumerable<Recipe> GetRecipes();
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<Recipe> GetRecipes(IEnumerable<long> zobristKeys);
        Recipe GetRecipe(int id);
    }
}