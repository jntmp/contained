using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class Loop
    {
        [TestMethod]
        public void LoopSuccess()
        {
            var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            var sum = 0;

            Muzzle.Loop.Each<int>(list, (i) => { sum += i; });

            Assert.AreEqual<int>(sum, list.Sum());
        }

        [TestMethod]
        public void LoopOnIteration()
        {
            var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            var sum = 0;

            var options = new Muzzle.Loop.Options
            {
                OnIteration = (t) => { sum += t; }
            };

            Muzzle.Loop.Each<int>(list, (i) => {  }, options);

            Assert.AreEqual<int>(sum, list.Sum());
        }
    }
}
