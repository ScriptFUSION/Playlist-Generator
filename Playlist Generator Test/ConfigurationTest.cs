using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class ConfigurationTest {
        [TestMethod]
        public void TestIsValid() {
            var c = new Configuration();
            Assert.IsFalse(c.IsValid());

            var p = new PlaylistContext(); //TODO: mock.
            c.Contexts.Add(p);
            Assert.IsFalse(c.IsValid());

            p.Directory = "foo";
            Assert.IsTrue(c.IsValid());
        }
    }
}
