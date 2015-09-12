using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PlaylistGenerator;

namespace PlaylistGeneratorTest {
    [TestClass]
    public class M3UTest {
        [TestMethod]
        public void TestInitialState() {
            var m3u = new M3U();

            Assert.AreEqual(0, m3u.Count);
        }

        [TestMethod]
        public void TestConstructEnumerable() {
            var m3u = new M3U(new[] { "foo", "bar" });

            Assert.AreEqual(2, m3u.Count);
        }

        [TestMethod]
        public void TestAdd() {
            var m3u = new M3U();
            
            m3u.Add("foo");
            Assert.AreEqual(1, m3u.Count);

            m3u.Add("bar");
            Assert.AreEqual(2, m3u.Count);
        }

        [TestMethod]
        public void TestWrite() {
            var stream = new System.IO.MemoryStream(0x40);

            new M3U().Add("foo").Write(stream);
            Assert.AreEqual(3, stream.Length);
        }

        [TestMethod]
        public void TestToString() {
            var m3u = new M3U();
            Assert.AreEqual(String.Empty, m3u.ToString());

            m3u.Add("foo");
            Assert.AreEqual("foo\n", m3u.ToString());

            m3u.Add("bar").Add("baz");
            Assert.AreEqual("foo\nbar\nbaz\n", m3u.ToString());
        }
    }
}
