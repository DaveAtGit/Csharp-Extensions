using System;
using CsExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ArrayTests
    {
        int[] array_1;
        int[] array_2;

        [TestInitialize]
        public void TestSetUp()
        {
            array_1 = new int[] { 1, 2, 3, 4 };
            array_2 = new int[] { 5, 6 };
        }

        [TestMethod]
        public void ExtendTest()
        {
            int len1 = array_1.Length;
            int len2 = array_2.Length;

            int[] res = array_1.Extend(array_2);

            Assert.AreEqual(len1 + len2, res.Length);
            for (int i = 0; i < res.Length; ++i)
                Assert.AreEqual(i + 1, res[i]);
        }

        [TestMethod]
        public void ExtendMinimalTest()
        {
            int[] a1 = new int[0];
            int[] a2 = new int[0];
            int[] b = a1.Extend(a2);
            Assert.AreEqual(a1.Length + a2.Length, b.Length);
        }
    }
}
