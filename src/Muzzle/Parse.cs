using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzzle
{
    public class Parse
    {
        public static int Int(object value, int defaultVal = 0)
        {
            var result = defaultVal;
            int.TryParse(value.ToString(), out result);
            return result;
        }

        public static decimal Decimal(object value, decimal defaultVal = 0.00m)
        {
            var result = defaultVal;
            decimal.TryParse(value.ToString(), out result);
            return result;
        }

        public static Guid Guid_(object value)
        {
            var result = Guid.Empty;
            Guid.TryParse(value.ToString(), out result);
            return result;            
        }

        public static float Float(object value, float defaultVal = 0.00f)
        {
            var result = defaultVal;
            float.TryParse(value.ToString(), out result);
            return result;
        }

        public static long Long(object value, long defaultVal = 0)
        {
            var result = defaultVal;
            long.TryParse(value.ToString(), out result);
            return result;
        }

        public static DateTime DateTime_(object value, DateTime defaultVal)
        {
            var result = defaultVal;
            DateTime.TryParse(value.ToString(), out result);
            return result;
        }
    }
}
