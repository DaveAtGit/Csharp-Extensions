using System;
using CsExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionTests
{
    [TestClass]
    public class StringTests
    {
        #region Multiply
        const string strEmpty = "";
        const string strOne = "-";
        const string strMultiple = "<plop>";

        [TestMethod]
        public void MultiplyZeroTest()
        {
            int num = 0;
            string[] results = MultiplyDefault(num);
            Assert.AreEqual("", results[0], "Empty with " + num + " failed.");
            Assert.AreEqual("", results[1], "One with " + num + " failed.");
            Assert.AreEqual("", results[2], "Multiple with " + num + " failed.");
        }

        [TestMethod]
        public void MultiplyAverageTest()
        {
            int num = 10;
            string[] results = MultiplyDefault(num);
            Assert.AreEqual("", results[0], "Empty with " + num + " failed.");
            Assert.AreEqual("----------", results[1], "One with " + num + " failed.");
            Assert.AreEqual("<plop><plop><plop><plop><plop><plop><plop><plop><plop><plop>",
                results[2], "Multiple with " + num + " failed.");
        }

        [TestMethod]
        public void MultiplyGreatTest()
        {
            int num = 25;
            string[] results = MultiplyDefault(num);
            Assert.AreEqual("", results[0], "Empty with " + num + " failed.");
            Assert.AreEqual("-------------------------", results[1],
                "One with " + num + " failed.");
            Assert.AreEqual("<plop><plop><plop><plop><plop><plop><plop><plop><plop><plop>"
                + "<plop><plop><plop><plop><plop><plop><plop><plop><plop><plop>"
                + "<plop><plop><plop><plop><plop>", results[2],
                "Multiple with " + num + " failed.");
        }

        private string[] MultiplyDefault(int num)
        {
            return new string[] {
                strEmpty.Multiply(num),
                strOne.Multiply(num),
                strMultiple.Multiply(num)};
        }
        #endregion

        #region Split
        // TODO write tests
        #endregion

        #region Format
        // TODO write tests
        #endregion

        #region ParseToEnum
        // TODO write tests
        #endregion
    }
}
