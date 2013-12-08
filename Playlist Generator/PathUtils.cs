using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace PlaylistGenerator {
    public static class PathUtils {
        public static string[] ExtractFileNames(IEnumerable<string> paths) {
            return paths.Select(p => Path.GetFileName(p)).ToArray();
        }

        public static string[] ExtractFileExtensions(IEnumerable<string> paths) {
            return (
                from p in paths
                where Path.HasExtension(p)
                select Path.GetExtension(p)
            ).ToArray();
        }

        public static Dictionary<string, int> CountFileExtensions(IEnumerable<string> paths) {
            return PathUtils.ExtractFileExtensions(paths).CountValues();
        }

        public static string FindModalFileExtension(IEnumerable<string> paths) {
            return CountFileExtensions(paths).OrderByDescending(p => p.Value).First().Key;
        }

        public static string[] FilterByExtension(IEnumerable<string> paths, string extension) {
            return paths.Where(f => f.EndsWith(extension)).ToArray();
        }
    }
}
