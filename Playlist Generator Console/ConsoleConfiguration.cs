using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Options;

namespace PlaylistGenerator {
    class ConsoleConfiguration : Configuration {
        private PlaylistContext currentContext;

        public OptionSet Options { get; private set; }

        private ConsoleConfiguration() : base() {
            CreatePlaylistContext();
        }

        public ConsoleConfiguration(IEnumerable<string> args) : this() {
            Options = CreateOptionSet();
            Options.Parse(args);
        }

        void CreatePlaylistContext(string directory = null) {
            //Reuse current context when directory not set.
            if (currentContext != null && currentContext.Directory == null)
                currentContext.Directory = directory;

            //Create new context when no context or directory already set.
            else Contexts.Add(currentContext = new PlaylistContext(directory));
        }

        OptionSet CreateOptionSet() {
            return new OptionSet() {
                //Default handler.
                { "<>", v => CreatePlaylistContext(v) },
                { "e|extension=", "Add files with the specified file extension", v => currentContext.FileExtension = v }
            };
        }
    }
}