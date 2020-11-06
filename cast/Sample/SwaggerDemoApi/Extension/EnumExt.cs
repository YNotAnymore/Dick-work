using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerDemoApi.Extension
{
    public static class EnumExt
    {

        public static string DescribeIntEnum(Type type)
        {
            StringBuilder builder = new StringBuilder();
            foreach (dynamic menu in Enum.GetValues(type))
            {
                builder.AppendLine($"<br/>{(int)menu} - {GetDescription(type, menu.ToString())};");
            }

            return builder.ToString();
        }
        public static string DescribeEnum(Type type)
        {
            StringBuilder builder = new StringBuilder();
            foreach (dynamic menu in Enum.GetValues(type))
            {
                string name = menu.ToString();
                builder.AppendLine($"<br/>{(int)menu}/{name.FirstCharLower()} - {GetDescription(type, name)};");
            }

            return builder.ToString();
        }
        public static string DescribeStrEnum(Type type)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string name in Enum.GetNames(type))
            {
                builder.AppendLine($"<br/>{name.FirstCharLower()} - {GetDescription(type, name)};");
            }

            return builder.ToString();
        }
        public static string GetDescription<T>(this T menu) where T :Enum
        {
            return GetDescription(typeof(T), menu.ToString());
        }
        public static string GetDescription(Type type, string name)
        {
            return type.GetField(name).GetCustomAttribute<DescriptionAttribute>()?.Description ?? name;
        }
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstCharLower(this string str)
        {
            Span<char> names = str.ToCharArray();
            names[0] = char.ToLower(names[0]);
            return new string(names);
        }
    }
}
