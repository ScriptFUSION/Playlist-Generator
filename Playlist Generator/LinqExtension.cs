using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistGenerator {
    public static class LinqExtension {
        public static Dictionary<T, int> CountValues<T>(this IEnumerable<T> values) {
            return values.Aggregate(
                new Dictionary<T, int>(),
                (d, k) => {
                    if (k != null) {
                        if (d.ContainsKey(k)) d[k]++;
                        else d.Add(k, 1);
                    }

                    return d;
                }
            );
        }
    }
}
