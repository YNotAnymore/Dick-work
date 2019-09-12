using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSpeed.RefData
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/9/10 16:32:23
    /// @source : https://stackoverflow.com/questions/8567992/how-to-modify-method-arguments-using-postsharp
    /// @des : 
    /// </summary>
    [Serializable]
    public class MyAspect : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            string input = (string)args.Arguments[0];

            if (input.Equals("123"))
            {
                args.Arguments.SetArgument(0, " 456");
            }

            args.Proceed();
        }
    }
}
