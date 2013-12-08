using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace PlaylistGenerator {
    class Program {
        public static Generator Generator { get; private set; }

        public static int Main(string[] args) {
            WriteBanner();

            //Create generator with configuration based on command-line arguments.
            var config = new ConsoleConfiguration(args);
            Generator = new Generator(config);

            //Create playlists.
            if (config.IsValid()) CreatePlaylists();

            //Write usage instructions.
            else {
                WriteUsage();
                
                return 1;
            }

            return 0;
        }

        static void CreatePlaylists() {
            Generator.CreatePlaylists();

            foreach (var context in Generator.Configuration.Contexts)
                Console.WriteLine(
                   "Wrote {0} {1}s to \"{2}\"",
                   context.Playlist.Count,
                   context.FileExtension.TrimStart('.'),
                   context.FilePath
               );
        }

        static void WriteUsage() {
            Console.WriteLine(
                "Usage: {0} <[option]... <path>>...\n",
                System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName
            );

            ((ConsoleConfiguration)Generator.Configuration).Options.WriteOptionDescriptions(Console.Out);
        }

        static void WriteBanner() {
            var a = Assembly.GetExecutingAssembly();
            var n = a.GetName();

            Console.WriteLine(
                "{0} {1} v{2}.{3}.{4}\n",
                a.GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                n.Name,
                n.Version.Major,
                n.Version.Minor,
                n.Version.Build
            );
        }
    }
}
