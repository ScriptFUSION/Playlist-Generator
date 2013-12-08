using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class PlaylistContextTest {
        [TestMethod]
        public void TestFileName() {
            var c = new PlaylistContext(new M3U(), "foo");

            Assert.AreEqual("00-foo.m3u", c.FileName);
        }

        [TestMethod]
        public void TestFilePath() {
            var c = new PlaylistContext(new M3U(), "foo");

            Assert.AreEqual(@"foo\00-foo.m3u", c.FilePath);
        }
    }
}
