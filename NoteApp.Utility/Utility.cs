using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Utility
{
    public class Utility
    {
        public static T Convert<T>(object value)
        {
            if(value == null || value == DBNull.Value)
            {
                return default(T);
            }

            if (string.IsNullOrEmpty(value.ToString().Trim()))
            {
                return default(T);
            }

            var type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            object retVal = null;

            if (type.IsEnum)
            {
                retVal = Enum.Parse(type, value.ToString());
            }
            else
            {
                retVal = System.Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
            }

            return (T)retVal;
        }
    }
}
