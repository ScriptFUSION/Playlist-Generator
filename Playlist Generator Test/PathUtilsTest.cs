using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class PathUtilsTest {
        [TestMethod]
        public void TestExtractFileNames() {
            var files = PathUtils.ExtractFileNames(new[] {
                @"c:\foo\bar",
                "/foo/bar"
            });
            
            foreach (var file in files)
                Assert.AreEqual("bar", file);
        }

        [TestMethod]
        public void TestExtractFileExtensions() {
            var extensions = PathUtils.ExtractFileExtensions(new[] {
                "foo.bar",
                ".bar",
                "fubar"
            });

            Assert.AreEqual(2, extensions.Length);

            foreach (var extension in extensions)
                Assert.AreEqual(".bar", extension);
        }

        [TestMethod]
        public void TestCountFileExtensions() {
            var extensions = PathUtils.CountFileExtensions(new[] {
                "foo.bar",
                ".bar",
                "fubar"
            });

            Assert.IsTrue(extensions.ContainsKey(".bar"));
            Assert.AreEqual(2, extensions[".bar"]);
        }

        [TestMethod]
        public void TestFindModalFileExtension() {
            var extension = PathUtils.FindModalFileExtension(new[] {
                ".foo", ".bar", ".bar"
            });

            Assert.AreEqual(".bar", extension);
        }

        [TestMethod]
        public void TestFilterByExtension() {
            var extensions = PathUtils.FilterByExtension(new[] {
                ".foo", ".bar", "foo"
            }, "foo");

            Assert.AreEqual(2, extensions.Length);

            foreach (var extension in extensions)
                Assert.IsTrue(extension.EndsWith("foo"));
        }
    }
}
