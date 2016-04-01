using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mApi = Contained.Api;

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

            mApi.Iterate<int>(list, i => sum += i);
            
            Assert.AreEqual<int>(sum, list.Sum());
        }

        [TestMethod]
        public void LoopOnIteration()
        {
            var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            var sum = 0;

            mApi.Iterate<int>(list, i => { }, t => sum += t);

            Assert.AreEqual<int>(sum, list.Sum());
        }

        [TestMethod]
        public void LoopOnError()
        {
            var list = new List<int>(new int[] { 0 });

            Exception error = null;

            mApi.Iterate<int>(list, 
                i => { var x = 5 / i; }, 
                null, 
                ex => error = ex);

            Assert.IsNotNull(error);
        }


        [TestMethod]
        public void LoopParallel()
        {
            var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            var sum = 0;

            mApi.Iterate<int>(list, i => sum += i, null, null, 3);
            
            Assert.AreEqual<int>(sum, list.Sum());
        }

        [TestMethod]
        public void LoopAll()
        {
            var list = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var sum = 0;

            mApi.Iterate<int>(list, 
                li => sum += li,
                i => Console.WriteLine($"{i} of {list.Count}"),
                ex => Console.WriteLine(ex.Message),
                3);

            Assert.AreEqual<int>(sum, list.Sum());
        }

    }
}
