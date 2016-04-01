using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mApi = Contained.Api;
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
            var actual = mApi.Parse<int>("1");
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailInt()
        {
            var actual = mApi.Parse<int>("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessLong()
        {
            var actual = mApi.Parse<long>("1");
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailLong()
        {
            var actual = mApi.Parse<long>("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDecimal()
        {
            var actual = mApi.Parse<decimal>("1.12");
            var expected = 1.12m;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailDecimal()
        {
            var actual = mApi.Parse<decimal>("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessFloat()
        {
            var actual = mApi.Parse<float>("1.12");
            var expected = 1.12f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailFloat()
        {
            var actual = mApi.Parse<float>("abc", -1f);
            var expected = -1f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccesGuid()
        {
            var actual = mApi.Parse<Guid>("a84145de-e516-4ff3-8769-b8c678b528ca");
            var expected = new Guid("a84145de-e516-4ff3-8769-b8c678b528ca");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailGuid()
        {
            var actual = mApi.Parse<Guid>("abc");
            var expected = Guid.Empty;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDateTime()
        {
            var val = DateTime.Now.Date;
            var expected = val.ToString();
            var actual = mApi.Parse<DateTime>(expected);

            //Assert.IsTrue(DateTime.Compare(actual, expected) == 0);
            Assert.AreEqual<DateTime>(actual, val);
        }

        [TestMethod]
        public void ParseFailDateTime()
        {
            var actual = mApi.Parse<DateTime>("abc");
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
            list.ForEach(l => mApi.Parse<int>(l));
            sw.Stop();
            TestContext.WriteLine($"ParseOrDefault 1mil: {sw.Elapsed.TotalSeconds} seconds");

            sw.Restart();
            list.ForEach(l =>
            {
                var result = 0;
                int.TryParse(l, out result);
            });
            sw.Stop();
            TestContext.WriteLine($"TryParse 1mil: {sw.Elapsed.TotalSeconds} seconds");

        }
    }
}
