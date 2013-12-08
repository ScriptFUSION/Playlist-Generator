using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class ConsoleTest {
        //This test is important to ensure tests will not affect each other.
        [TestMethod]
        public void TestProgramInvokationCreatesNewGeneratorInstance() {
            Program.Main(new string[0]);
            var g = Program.Generator;

            Program.Main(new string[0]);
            Assert.AreNotSame(g, Program.Generator);
        }

        [TestMethod]
        public void TestFileExtensionOption() {
            Program.Main(new[] { "-e", "foo" });
            Assert.AreEqual("foo", Program.Generator.Configuration.Contexts[0].FileExtension);
        }
    }
}
