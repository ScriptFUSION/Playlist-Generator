using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace PlaylistGenerator {
    public class PlaylistContext {
        public PlaylistContext() {}

        public PlaylistContext(string directory) : this() {
            Directory = directory;
        }

        public PlaylistContext(Playlist playlist, string directory) : this(directory) {
            Playlist = playlist;
        }

        //PlaylistContext is valid in any Playlist context.
        public static implicit operator Playlist(PlaylistContext o) {
            return o.Playlist;
        }

        public Playlist Playlist { get; set; }

        /// <summary>
        /// Gets or sets the location of the Playlist.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the file extension of files included in Playlist.
        /// </summary>
        public string FileExtension { get; set; }

        public string FileName {
            get {
                return Path.ChangeExtension(
                    String.Format("00-{0}", new DirectoryInfo(Directory).Name.ToLowerInvariant()),
                    Playlist.FileExtension
                );
            }
        }

        public string FilePath {
            get {
                return Path.Combine(Directory, FileName);
            }
        }

        public bool IsValid() {
            //Only Directory is required. Playlist can be inferred from Directory.
            return Directory != null;
        }
    }
}
