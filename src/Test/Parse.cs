using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Muzzle;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class Parse
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Parse Types
        [TestMethod]
        public void ParseSuccessInt()
        {
            var actual = "1".ParseOrDefault<int>();
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailInt()
        {
            var actual = "abc".ParseOrDefault<int>();
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessLong()
        {
            var actual = "1".ParseOrDefault<long>();
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailLong()
        {
            var actual = "abc".ParseOrDefault<long>();
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDecimal()
        {
            var actual = "1.12".ParseOrDefault<decimal>();
            var expected = 1.12m;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailDecimal()
        {
            var actual = "abc".ParseOrDefault<decimal>();
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessFloat()
        {
            var actual = "1.12".ParseOrDefault<float>();
            var expected = 1.12f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailFloat()
        {
            var actual = "abc".ParseOrDefault<float>(-1f);
            var expected = -1f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccesGuid()
        {
            var actual = "a84145de-e516-4ff3-8769-b8c678b528ca".ParseOrDefault<Guid>();
            var expected = new Guid("a84145de-e516-4ff3-8769-b8c678b528ca");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailGuid()
        {
            var actual = "abc".ParseOrDefault<Guid>();
            var expected = Guid.Empty;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDateTime()
        {
            var val = DateTime.Now.Date;
            var expected = val.ToString();
            var actual = expected.ParseOrDefault<DateTime>();

            //Assert.IsTrue(DateTime.Compare(actual, expected) == 0);
            Assert.AreEqual<DateTime>(actual, val);
        }

        [TestMethod]
        public void ParseFailDateTime()
        {
            var actual = "abc".ParseOrDefault<DateTime>();
            var expected = DateTime.MinValue;

            Assert.AreEqual(actual, expected);
        }
        #endregion

        [TestMethod]
        public void ParseSpeedTest()
        {
            var list = new List<string>(1000000);
            var rnd = new Random();

            for (int i = 0; i < 1000000; i++)
                list.Add(rnd.Next().ToString());

            var sw = new Stopwatch();

            sw.Start();
            list.ForEach(l => l.ParseOrDefault<int>());
            sw.Stop();
            TestContext.WriteLine($"ParseOrDefault 1mil: {sw.Elapsed.TotalSeconds} seconds");

            sw.Restart();
            list.ForEach(l => {
                var result = 0;
                int.TryParse(l, out result);
            });
            sw.Stop();
            TestContext.WriteLine($"TryParse 1mil: {sw.Elapsed.TotalSeconds} seconds");

        }
    }
}
