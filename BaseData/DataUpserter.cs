using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using wimixapi.DataModels;
using wimixapi.Models;
namespace BaseData
{
    internal class DataUpserter
    {
        private WimixDataContext context;
        internal void UpsertBaseData()
        {
            context = new WimixDataContext();
            if (context.Ingredients.Count() < 100)
            {
                upsertIngredients();
            }
            context.RecipeIngredients.RemoveRange(context.RecipeIngredients);
            context.Recipes.RemoveRange(context.Recipes);
            upsertRecipes();
        }

        private void upsertRecipes()
        {
            var recipes = new List<Recipes>();
#if DEBUG
            var path = @".\testrecipe.json";
#else
            var path = @".\recipes.json";
#endif
            using (StreamReader sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();

                recipes = JsonConvert.DeserializeObject<List<Recipes>>(json);
            }
            var rngCsp = new RNGCryptoServiceProvider();
            foreach (var recipe in recipes)
            {
                foreach(var ingredient in recipe.RecipeIngredients)
                {
                    recipe.ZobristKey ^= context.Ingredients.Where(x => x.IngredientId == ingredient.IngredientId).Select(x => x.ZobristKey).Single();
                }
            }
            context.Recipes.AddRange(recipes);

            context.SaveChanges();

        }

        private void upsertIngredients()
        {
            var ingredients = new List<Ingredients>();

            using (StreamReader sr = new StreamReader(@".\ingredients.json"))
            {
                var json = sr.ReadToEnd();

                ingredients = JsonConvert.DeserializeObject<List<Ingredients>>(json);
            }
            var rngCsp = new RNGCryptoServiceProvider();
            foreach (var ingredient in ingredients)
            {
                
                var bytes = new byte[8];
                
                rngCsp.GetBytes(bytes);
                var l = BitConverter.ToInt64(bytes, 0);
                ingredient.ZobristKey = l;
                
                
            }
            context.Ingredients.AddRange(ingredients);

            context.SaveChanges();
            
        }
    }
}