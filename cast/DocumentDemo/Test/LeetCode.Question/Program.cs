using LeetCode.Question.Hard;
using System;
using System.Collections.Generic;
using System.Text;
using Consoles.Tools;
using Newtonsoft.Json;

namespace LeetCode.Question
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            TestBraceExpansionII();

            CountTriplets instance = new CountTriplets();

            System.Console.WriteLine();

            Console.WriteLine(instance.Solution(new[] { 2, 1, 3 }));

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }

        private static void TestBraceExpansionII()
        {
            BraceExpansionII instance = new BraceExpansionII();

            IList<string> res;

            res = instance.Solution("n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["ncaaiawn","ncaan","ncaaown","ncaaxwn","ncaern","ncaian","ncaon","ncawn","ncaxn","ngaaiawn","ngaan","ngaaown","ngaaxwn","ngaern","ngaian","ngaon","ngawn","ngaxn","nhaaiawn","nhaan","nhaaown","nhaaxwn","nhaern","nhaian","nhaon","nhawn","nhaxn","njaaiawn","njaan","njaaown","njaaxwn","njaern","njaian","njaon","njawn","njaxn","nlaaiawn","nlaan","nlaaown","nlaaxwn","nlaern","nlaian","nlaon","nlawn","nlaxn"]
            ShowResult.Show(res);

            res = instance.Solution("a,n{{c,g},{h,j},l}a{{a,{x,ia,o},w},er,a{x,ia,o}w}n");

            //["a,ncaaiawn","a,ncaan","a,ncaaown","a,ncaaxwn","a,ncaern","a,ncaian","a,ncaon","a,ncawn","a,ncaxn","a,ngaaiawn","a,ngaan","a,ngaaown","a,ngaaxwn","a,ngaern","a,ngaian","a,ngaon","a,ngawn","a,ngaxn","a,nhaaiawn","a,nhaan","a,nhaaown","a,nhaaxwn","a,nhaern","a,nhaian","a,nhaon","a,nhawn","a,nhaxn","a,njaaiawn","a,njaan","a,njaaown","a,njaaxwn","a,njaern","a,njaian","a,njaon","a,njawn","a,njaxn","a,nlaaiawn","a,nlaan","a,nlaaown","a,nlaaxwn","a,nlaern","a,nlaian","a,nlaon","a,nlawn","a,nlaxn"]
            ShowResult.Show(res);

            res = instance.Solution("{{a,{x,ia,o},w},er,a{x,ia,o}w}");

            ShowResult.Show(res);//["a","aiaw","aow","axw","er","ia","o","w","x"]

            // next
            res = instance.Solution("{a,{a,{x,ia,o},w}er{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            //["a","aera","aerg","aeria","aern","aero","aeru","aerw","aerx","er","iaera","iaerg","iaeria","iaern","iaero","iaeru","iaerw","iaerx","oera","oerg","oeria","oern","oero","oeru","oerw","oerx","wera","werg","weria","wern","wero","weru","werw","werx","xera","xerg","xeria","xern","xero","xeru","xerw","xerx"]
            ShowResult.Show(res);

            res = instance.Solution("{a{x,ia,o}w,{n,{g,{u,o}},{a,{x,ia,o},w}},er}");

            ShowResult.Show(res);//["a","aiaw","aow","axw","er","g","ia","n","o","u","w","x"]

            res = instance.Solution("{a,b}c{d,e}f");

            ShowResult.Show(res);//["acdf","acef","bcdf","bcef"]

            res = instance.Solution("{a,b}{c,{d,e}}");

            ShowResult.Show(res);//["ac","ad","ae","bc","bd","be"]

            res = instance.Solution("{{a,z},a{b,c},{ab,z}}");

            ShowResult.Show(res);//["a","ab","ac","z"]
        }

        private static void TestLongestDecomposition()
        {
            LongestDecomposition instance = new LongestDecomposition();

            instance.Test(instance.Solution);

            instance.TestCase(100, 10, instance.Solution);
        }

        private static void TestParseBoolExpr()
        {
            ParseBoolExpr instance = new ParseBoolExpr();

            Console.WriteLine(instance.Solution("|(f,&(t,t))") == true);

            instance.Test(instance.Solution);

            Console.WriteLine(instance.Solution("!(&(&(!(&(f)),&(t),|(f,f,t)),&(t),&(t,t,f)))"));

            Console.WriteLine(instance.Solution(
                                  "&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))") ==
                              false);
        }

        private static void TestMyCalendarThree()
        {
            List<int> list = new List<int>() { 1, 2, 3 };
            list.Insert(0, 4);

            MyCalendarThree instance = new MyCalendarThree();

            instance.Test();

            var arr = new[]
            {
                new[] {24, 40},
                new[] {43, 50},
                new[] {27, 43},
                new[] {5, 21},
                new[] {30, 40},
                new[] {14, 29},
                new[] {3, 19},
                new[] {3, 14},
                new[] {25, 39},
                new[] {6, 19}
            };

            //[null,1,1,2,2,3,3,3,3,4,4]

            foreach (var item in arr)
            {
                instance.Book(item[0], item[1]);
            }
        }
    }
}