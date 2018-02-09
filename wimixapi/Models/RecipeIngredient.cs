using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wimixapi.DataModels;

namespace wimixapi.Models
{
    public class RecipeIngredient : Ingredient
    {
        public short Amount { get; set; }

        public byte Order { get; set; }

        public RecipeIngredient(short amount, byte? order, Ingredients i) : base(i)
        {
            Amount = amount;
            Order = order ?? 0;
        }
    }
}
