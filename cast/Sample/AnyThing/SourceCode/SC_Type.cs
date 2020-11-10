using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnyThing.SourceCode
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/9/2020 2:10:51 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class SC_Type
    {

        // Enum.GetNames()

        //[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2085:UnrecognizedReflectionPattern",
        //    Justification = "Literal fields on enums can never be trimmed")]
        // This will return enumValues and enumNames sorted by the values.
        private void GetEnumData(Type type,out string[] enumNames, out Array enumValues)
        {
            FieldInfo[] flds = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            object[] values = new object[flds.Length];
            string[] names = new string[flds.Length];

            for (int i = 0; i < flds.Length; i++)
            {
                names[i] = flds[i].Name;
                values[i] = flds[i].GetRawConstantValue()!;
            }

            // Insertion Sort these values in ascending order.
            // We use this O(n^2) algorithm, but it turns out that most of the time the elements are already in sorted order and
            // the common case performance will be faster than quick sorting this.
            IComparer comparer = Comparer<object>.Default;
            for (int i = 1; i < values.Length; i++)
            {
                int j = i;
                string tempStr = names[i];
                object val = values[i];
                bool exchanged = false;

                // Since the elements are sorted we only need to do one comparision, we keep the check for j inside the loop.
                while (comparer.Compare(values[j - 1], val) > 0)
                {
                    names[j] = names[j - 1];
                    values[j] = values[j - 1];
                    j--;
                    exchanged = true;
                    if (j == 0)
                        break;
                }

                if (exchanged)
                {
                    names[j] = tempStr;
                    values[j] = val;
                }
            }

            enumNames = names;
            enumValues = values;
        }

    }
}
