using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistGenerator {
    public class M3U : Playlist {
        private const string FILE_EXTENSION = "m3u";

        private string lineFeed = "\n";

        public override string FileExtension {
            get { return FILE_EXTENSION; }
        }

        public M3U() : base() {}
        public M3U(IEnumerable<string> paths) : base(paths) {}

        override public string ToString() {
            return Paths.Aggregate(String.Empty, (a, b) => a + b + lineFeed);
        }
    }
}
