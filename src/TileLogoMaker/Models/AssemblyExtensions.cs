using System;
using System.Linq;
using System.Reflection;

namespace KatsuYuzu.TileLogoMaker.Models
{
    static class AssemblyExtensions
    {
        public static string GetAttributeValue<T>(this Assembly assembly, Func<T, string> selector)
            where T : Attribute
        {
            var attr = assembly.GetCustomAttributes(typeof(T), true).Cast<T>().FirstOrDefault();
            return (attr == null) ? "" : selector(attr);
        }
    }
}
