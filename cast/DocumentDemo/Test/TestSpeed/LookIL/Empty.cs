using System;
using System.Collections.Generic;
using System.Text;

namespace TestSpeed.LookIL
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 10:15:19
    /// @source : 
    /// @des : 
    /// </summary>
    public class Empty
    {

        public void Show()
        {


            //IL_0001: ldc.i4.0
            //IL_0002: stloc.0
            //IL_0003: br.s IL_0005
            if (true & false)
            {

            }
            //IL_0005: ldc.i4.0
            //IL_0006: stloc.1
            //IL_0007: br.s IL_0009
            if (true && false)
            {

            }

            //          IL_0009: ldc.i4.1
            //IL_000a: stloc.0
            //IL_000b: ldc.i4.0
            //IL_000c: stloc.1
            bool a = true, b = false;

            //           IL_000d: ldloc.0
            // IL_000e: ldloc.1
            // IL_000f: and
            //IL_0010:  stloc.s V_4
            // IL_0012: ldloc.s V_4
            // IL_0014: brfalse.s IL_0018
            // IL_0016: nop

            if (a & b)
            {

            }

            Console.WriteLine("------------");

            if (a && b)
            {

            }


        }

        public void Single(bool a, bool b)
        {

            /*
    // Code size       11 (0xb)
  .maxstack  2
  .locals init (bool V_0)
  IL_0000:  nop
  IL_0001:  ldarg.1
  IL_0002:  ldarg.2
  IL_0003:  and
  IL_0004:  stloc.0
  IL_0005:  ldloc.0
  IL_0006:  brfalse.s  IL_000a
  IL_0008:  nop
  IL_0009:  nop
  IL_000a:  ret
  */

            if (a & b)
            {

            }
        }

        public void Double(bool a, bool b)
        {
            /*
               // Code size       11 (0xb)
  .maxstack  2
  .locals init (bool V_0)
  IL_0000:  nop
  IL_0001:  ldarg.1
  IL_0002:  ldarg.2
  IL_0003:  and
  IL_0004:  stloc.0
  IL_0005:  ldloc.0
  IL_0006:  brfalse.s  IL_000a
  IL_0008:  nop
  IL_0009:  nop
  IL_000a:  ret
  */
            if (a && b)
            {

            }
        }

        public void Single(bool a, bool b, bool c, bool d)
        {
            if (a | b | c | d)
            {

            }
        }

        public void Double(bool a, bool b, bool c, bool d)
        {
            if (a || b || c || d)
            {

            }
        }

    }
}
