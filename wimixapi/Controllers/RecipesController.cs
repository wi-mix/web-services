using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wimixapi.Models;

namespace wimixapi.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]IEnumerable<Ingredient> ingredients)
        {
            var zobrists = getZobrists(ingredients.Select(i => i.ZobristKey));

            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
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
