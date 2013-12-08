using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistGenerator {
    public class Configuration {
        public List<PlaylistContext> Contexts { get; set; }

        public Configuration() {
            Contexts = new List<PlaylistContext>();
        }

        /// <summary>
        /// Returns a value indicating whether the Configuration is valid.
        /// A Configuration is valid when at least one PlaylistContext is
        /// defined and all PlaylistContextss are valid.
        /// </summary>
        /// <returns>True if Configuration is valid, otherwise false.</returns>
        public bool IsValid() {
            return Contexts.Count > 0 && Contexts.All(c => c.IsValid());
        }
    }
}
