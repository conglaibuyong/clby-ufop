using System.Collections.Generic;
using System.Diagnostics;

namespace clby_ufop.Core.Misc
{

    [DebuggerStepThrough]
    public static class DictionaryExtensions
    {
        public static string TryGetString<T, K>(this Dictionary<T, K> d, T key, string defaultValue = null)
        {
            var v = defaultValue;
            if (d.ContainsKey(key))
            {
                v = d[key]?.ToString() ?? defaultValue;
            }
            return v;
        }

        public static bool TryGetBoolean<T, K>(this Dictionary<T, K> d, T key, bool defaultValue = false)
        {
            var v = defaultValue;
            if (d.ContainsKey(key))
            {
                bool.TryParse(d[key]?.ToString(), out v);
            }
            return v;
        }

        public static int TryGetInt32<T, K>(this Dictionary<T, K> d, T key, int defaultValue = 0)
        {
            if (d.ContainsKey(key))
            {
                var v = d[key];
                int intValue = defaultValue;
                int.TryParse(v?.ToString(), out intValue);
                return intValue;
            }
            return defaultValue;
        }


    }

}
