using System;
using System.ComponentModel;

namespace Utils
{
    public static class EnumUtil
    {
        //public static T ParseEnum<T>(string value)
        //{
        //    return (T)Enum.Parse(typeof(T), value, true);
        //}

        public static string StringValueOf(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }


        public static object EnumValueOf(string value, Type enumType)
        {
            var names = Enum.GetNames(enumType);
            foreach (var name in names)
            {
                if (StringValueOf((Enum) Enum.Parse(enumType, name)).Equals(value))
                {
                    return Enum.Parse(enumType, name, true);
                }
            }
            return Enum.GetName(enumType, 0);
        }
    }
}