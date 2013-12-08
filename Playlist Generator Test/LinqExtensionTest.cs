using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class LinqExtensionTest {
        [TestMethod]
        public void TestCountNullValues() {
            Assert.AreEqual(0, new string[1].CountValues().Count);
        }

        [TestMethod]
        public void TestCountValues() {
            var c = new[] { 1, 2, 3, 1, 3, 3 }.CountValues();
            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(2, c[1]);
            Assert.AreEqual(1, c[2]);
            Assert.AreEqual(3, c[3]);
        }
    }
}
