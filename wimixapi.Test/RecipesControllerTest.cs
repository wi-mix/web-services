using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;
using wimixapi.Controllers;

namespace wimixapi.Test
{
    public class RecipesControllerTest
    {
        [Fact]
        public void TestGenerationCombination()
        {
            var keys = generateKeys(4);

            var controller = new RecipesController();

            var combos = controller.getZobrists(keys);

            Assert.Equal(15, combos.Count());

            Assert.Contains(keys[0], combos);
            Assert.Contains(keys[1], combos);
            Assert.Contains(keys[2], combos);
            Assert.Contains(keys[3], combos);

            Assert.Contains(keys[0] ^ keys[1], combos);
            Assert.Contains(keys[0] ^ keys[2], combos);
            Assert.Contains(keys[0] ^ keys[3], combos);
            Assert.Contains(keys[1] ^ keys[2], combos);
            Assert.Contains(keys[1] ^ keys[3], combos);
            Assert.Contains(keys[2] ^ keys[3], combos);

            Assert.Contains(keys[0] ^ keys[1] ^ keys[2], combos);
            Assert.Contains(keys[0] ^ keys[1] ^ keys[3], combos);
            Assert.Contains(keys[1] ^ keys[2] ^ keys[3], combos);
            Assert.Contains(keys[0] ^ keys[2] ^ keys[3], combos);

            Assert.Contains(keys[0] ^ keys[1] ^ keys[2] ^ keys[3], combos);
        }

        public List<long> generateKeys(int len)
        {
            var ret = new List<long>();
            var rngCsp = new RNGCryptoServiceProvider();
            var bytes = new byte[8];
            for(int i = 0; i < len; i++)
            {
                rngCsp.GetBytes(bytes);
                var l = BitConverter.ToInt64(bytes, 0);
                ret.Add(l);
            }
            return ret;
        }
    }
}
