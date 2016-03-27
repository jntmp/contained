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
            int result;
            if (!int.TryParse(value.ToString(), out result))
                return defaultVal;
            else
                return result;
        }

        public static decimal Decimal(object value, decimal defaultVal = 0.00m)
        {
            decimal result;
            if (!decimal.TryParse(value.ToString(), out result))
                return defaultVal;
            else
                return result;
        }

        public static Guid Guid_(object value)
        {
            Guid result;
            if (!Guid.TryParse(value.ToString(), out result))
                return Guid.Empty;
            else
                return result;
        }

        public static float Float(object value, float defaultVal = 0.00f)
        {
            float result;
            if (!float.TryParse(value.ToString(), out result))
                return defaultVal;
            else
                return result;
        }

        public static long Long(object value, long defaultVal = 0)
        {
            long result;
            if (!long.TryParse(value.ToString(), out result))
                return defaultVal;
            else
                return result;
        }

        public static DateTime DateTime_(object value, DateTime defaultVal)
        {
            DateTime result;
            if (!DateTime.TryParse(value.ToString(), out result))
                return defaultVal;
            else
                return result;
        }
    }
}
