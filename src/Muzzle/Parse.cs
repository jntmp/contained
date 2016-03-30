using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzzle
{
    internal static class Parsing
    {
        internal static T ParseOrDefault<T>(string val, T defaultVal = default(T))
        {
            var result = Activator.CreateInstance<T>();

            var parseMethod = typeof(T).GetMethod("TryParse", new Type[] { typeof(string), typeof(T).MakeByRefType() });

            if (parseMethod == null)
                throw new Exception($"Type {result.GetType().Name} not supported by ParseOrDefault.");

            var parameters = new object[] { val, null };

            if (!(bool)parseMethod.Invoke(val, parameters))
                return defaultVal;
            else
                return (T)parameters[1];
        }
    }
}
