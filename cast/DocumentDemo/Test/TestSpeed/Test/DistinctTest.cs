using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSpeed.Model;

namespace TestSpeed.Test
{
    public class DistinctTest
    {

        // second
        public static List<TxtModel> SetSolution(List<dynamic> list)
        {
            var txtList = new HashSet<string>();

            foreach (dynamic o in list)
            {
                if (o.Text != null)
                {
                    txtList.Add(o.Text);
                }
            }

            return txtList.Select(u => new TxtModel {Text = u}).ToList();
        }

        // winner
        // 无论数据量多与少，总能保持高效率
        public static List<TxtModel> DictionarySolution(List<dynamic> list)
        {
            var dictionary = new Dictionary<string, TxtModel>();

            foreach (dynamic o in list)
            {
                if (o.Text != null & !dictionary.ContainsKey(o.Text))
                {
                    dictionary.Add(o.Text, new TxtModel() {Text = o.Text});
                }
            }

            return dictionary.Values.ToList();
        }

        // loser~
        public static List<TxtModel> ListSolution(List<dynamic> list)
        {
            var res = new List<TxtModel>();

            foreach (dynamic o in list)
            {
                if (o.Text != null & !res.Exists(u => u.Text.Equals(o.Text)))
                {
                    res.Add(new TxtModel() { Text = o.Text });
                }
            }

            return res;
        }

    }
}