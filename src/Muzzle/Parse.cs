using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzzle
{
    public static class Parse
    {
        public static T ParseOrDefault<T>(this string obj, T defaultVal = default(T))
        {
            var result = Activator.CreateInstance<T>();

            var parseMethod = typeof(T).GetMethod("TryParse", new Type[] { typeof(string), typeof(T).MakeByRefType() });

            if (parseMethod == null)
                throw new Exception($"Type {result.GetType().Name} not supported by ParseOrDefault.");

            var parameters = new object[] { obj, null };

            if (!(bool)parseMethod.Invoke(obj, parameters))
                return defaultVal;
            else
                return (T)parameters[1];
        }
    }
}
