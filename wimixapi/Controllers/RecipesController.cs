using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wimixapi.DataModels;
using wimixapi.Models;
using wimixapi.Services;

namespace wimixapi.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly IWimixDataService _wimixDataService;
        public RecipesController(IWimixDataService dataService)
        {
            _wimixDataService = dataService;
        }

        // GET api/values/5
        [HttpGet("drinks/{id}")]
        public Recipe GetDrink(int id)
        {
            return _wimixDataService.GetRecipe(id);
        }

        [HttpGet("drinks/")]
        public IEnumerable<Recipe> GetDrinks()
        {
            return _wimixDataService.GetRecipes();
        }

        // POST api/values
        [HttpPost("drinks/")]
        public IEnumerable<Recipe> GetFilteredDrinks([FromBody]IEnumerable<long> ingredients)
        {
            var zobrists = getZobrists(ingredients);

            return _wimixDataService.GetRecipes(zobrists);

        }

        [HttpGet("ingredients/")]
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _wimixDataService.GetIngredients();
        }

        public IEnumerable<long> getZobrists(IEnumerable<long> keys)
        {
            var zobrists = new List<long>();
            long zobristKey = 0;
            for (int i = 0; i < 1 << keys.Count(); i++)
            {
                for(int j = 0; j < keys.Count(); j++)
                {
                    if( (i & (1 << j)) > 0)
                    {
                        zobristKey ^= keys.ElementAt(j);
                    }
                }
                zobrists.Add(zobristKey);
                zobristKey = 0;
            }
            //We do not need the empty member of the power set
            zobrists.Remove(0);
            return zobrists;
        }
    }
}
