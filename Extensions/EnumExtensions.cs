using System;
using System.Linq;
using System.Web.Mvc;

namespace Illumination.Core.Extensions
{
    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum: struct, IComparable
        {
            if(!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { ID = e, Name = e.ToString() };

            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}