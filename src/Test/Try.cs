using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Muzzle;

namespace Test
{
    [TestClass]
    public class Try
    {
        [TestMethod]
        public void TrySuccessInt()
        {
            var test = new Container<int>()
                .Try(() => { return 1 + 2; })
                .Catch(ex => { Console.WriteLine(ex.Message); }
            );
            
            Assert.IsNull(test.Error);
            Assert.IsFalse(test.HasError);
            Assert.AreEqual<int>(3, test.PayLoad);
        }

        [TestMethod]
        public void TrySuccessList()
        {
            var test = new Container<List<String>>()
                .Try(() =>
                {
                    var list = new List<String>();
                    list.Add("123");
                    list.Add("456");
                    list.Add("789");
                    return list;
                })
                .Catch(ex => { Console.WriteLine(ex.Message); }
            );

            Assert.IsNull(test.Error);
            Assert.IsFalse(test.HasError);
            Assert.IsTrue(test.PayLoad.Any());
        }

        [TestMethod]
        public void TryMathFailure()
        {
            int brokenMath = 0;

            var test = new Container<int>()
                .Try(() => { return 10 / brokenMath; })
                .Catch(ex => { Console.WriteLine(ex.Message); }
            );

            Assert.IsNotNull(test.Error);
            Assert.IsTrue(test.HasError);
            Assert.AreEqual<int>(test.PayLoad, default(int));
        }

        [TestMethod]
        public void TryMathSuccessElse()
        {
            int brokenMath = 0;

            var test = new Container<int>()
                .Try(() => { return 10 / brokenMath; })
                .Else(() => { return 10 / 10; })
                .Catch(ex => { Console.WriteLine(ex.Message); });

            Assert.IsNull(test.Error);
            Assert.IsFalse(test.HasError);
            Assert.AreEqual<int>(test.PayLoad, 1);
        }

        [TestMethod]
        public void TryMathFailureElse()
        {
            int brokenMath = 0;
            int elseBroken = 0;

            var test = new Container<int>()
                .Try(() => { return 10 / brokenMath; })
                .Else(() => { return 10 / elseBroken; })
                .Catch(ex => { Console.WriteLine(ex.Message); });

            Assert.IsNotNull(test.Error);
            Assert.IsTrue(test.HasError);
            Assert.AreEqual<int>(test.PayLoad, default(int));
        }
    }
}
