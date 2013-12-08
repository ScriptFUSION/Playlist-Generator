using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace PlaylistGenerator {
    static class AssemblyExtension {
        public static T GetCustomAttribute<T>(this Assembly a) {
            return a.GetCustomAttributes<T>().First();
        }

        public static T[] GetCustomAttributes<T>(this Assembly a) {
            return (T[])a.GetCustomAttributes(typeof(T), false).Cast<T>();
        }
    }
}
