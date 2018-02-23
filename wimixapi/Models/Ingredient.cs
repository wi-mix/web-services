using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wimixapi.DataModels;

namespace wimixapi.Models
{
    public class Ingredient
    {

        public Ingredient(Ingredients i)
        {
            Name = i.Name;
            Description = i.Description;
            Key = i.IngredientId;
            ZobristKey = i.ZobristKey.ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Key { get; set; }
        
        public string ZobristKey { get; set; }
    }
}
