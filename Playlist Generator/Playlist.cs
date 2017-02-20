using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlaylistGenerator {
    public abstract class Playlist {
        public List<string> Paths { get; private set; }

        public abstract string FileExtension { get; }

        public Playlist() {
            Paths = new List<string>();
        }
        public Playlist(IEnumerable<string> paths) : this() {
            Paths.AddRange(paths);
        }

        public int Count {
            get { return Paths.Count; }
        }

        public Playlist Add(string path) {
            Paths.Add(path);

            return this;
        }

        public Playlist Write(Stream stream) {
            var writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Write(ToString());
            writer.Flush();

            return this;
        }

        public override abstract string ToString();
    }
}
