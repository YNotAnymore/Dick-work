using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/25/2021 4:19:35 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class ReflectExt
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propNames">属性名</param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetProp(this object obj, string[] propNames, int index = 0)
        {
            if (index >= propNames.Length) return default;

            object value = obj.GetType().GetProperty(propNames[index])?.GetValue(obj);

            if (value == null) return default;

            if (index == propNames.Length - 1) return value.ToString();

            return GetProp(value, propNames, index + 1);

        }

        /// <summary>
        /// 获取方法对应的全路径[swagger文档注释]
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetFullName(this MethodInfo method)
        {

            var paramStr = string.Join(",", method.GetParameters().Select(u =>
            {

                if (u.ParameterType.IsGenericType)
                {
                    return $"{u.ParameterType.FullName.Substring(0, u.ParameterType.FullName.IndexOf('`'))}{{{string.Join(",", u.ParameterType.GetGenericArguments().Select(x => x.FullName))}}}";
                }

                return u.ParameterType.FullName;
            }));

            return $"{method.DeclaringType.FullName}.{method.Name}({paramStr})";
        }
    }
}
