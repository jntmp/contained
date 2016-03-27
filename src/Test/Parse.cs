using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Parse
    {
        [TestMethod]
        public void ParseSuccessInt()
        {
            var actual = Muzzle.Parse.Int(1);
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailInt()
        {
            var actual = Muzzle.Parse.Int("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessLong()
        {
            var actual = Muzzle.Parse.Long(1);
            var expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailLong()
        {
            var actual = Muzzle.Parse.Long("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDecimal()
        {
            var actual = Muzzle.Parse.Decimal(1.12m);
            var expected = 1.12m;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailDecimal()
        {
            var actual = Muzzle.Parse.Decimal("abc");
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessFloat()
        {
            var actual = Muzzle.Parse.Float(1.12f);
            var expected = 1.12f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailFloat()
        {
            var actual = Muzzle.Parse.Float("abc", -1f);
            var expected = -1f;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccesGuid()
        {
            var actual = Muzzle.Parse.Guid_("a84145de-e516-4ff3-8769-b8c678b528ca");
            var expected = new Guid("a84145de-e516-4ff3-8769-b8c678b528ca");

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseFailGuid()
        {
            var actual = Muzzle.Parse.Guid_("abc");
            var expected = Guid.Empty;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParseSuccessDateTime()
        {
            var expected = DateTime.Now.Date;
            var actual = Muzzle.Parse.DateTime_(expected, DateTime.MinValue);

            //Assert.IsTrue(DateTime.Compare(actual, expected) == 0);
            Assert.AreEqual<DateTime>(actual, expected);
        }

        [TestMethod]
        public void ParseFailDateTime()
        {
            var actual = Muzzle.Parse.DateTime_("abc", DateTime.MinValue);
            var expected = DateTime.MinValue;

            Assert.AreEqual(actual, expected);
        }
    }
}
