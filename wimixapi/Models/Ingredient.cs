using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wimixapi.Models
{
    public class Ingredient
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public short Amount { get; set; }

        public int IngredientId { get; set; }
    }
}
