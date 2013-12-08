using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace PlaylistGenerator {
    public class Generator {
        public Configuration Configuration { get; set; }

        public Generator() {}
        public Generator(Configuration config) : this() {
            Configuration = config;
        }

        private PlaylistContext NormalizePlaylistContext(PlaylistContext context) {
            //Create playlist if not present.
            if (context.Playlist == null) {
                //Find files in directory.
                var files = PathUtils.ExtractFileNames(Directory.GetFiles(context.Directory));

                //Select modal file extension if not defined.
                if (context.FileExtension == null)
                    context.FileExtension = PathUtils.FindModalFileExtension(files);

                //Create playlist with files filtered by selected extension.
                context.Playlist = new M3U(PathUtils.FilterByExtension(files, context.FileExtension));
            }

            return context;
        }

        private Generator CreatePlaylistFile(PlaylistContext context) {
            NormalizePlaylistContext(context);

            using (var fs = new FileStream(
                context.FilePath,
                FileMode.Create, //Create or overwrite.
                FileAccess.Write
            ))
                context.Playlist.Write(fs);

            return this;
        }

        public Generator CreatePlaylists() {
            foreach (var playlist in Configuration.Contexts)
                CreatePlaylistFile(playlist);

            return this;
        }
    }
}
