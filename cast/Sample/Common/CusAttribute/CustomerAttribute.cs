using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CusAttribute
{
    [AttributeUsage(validOn: AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class CustomerAttribute : Attribute
    {
    }
}
