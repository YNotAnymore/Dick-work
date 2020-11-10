using AnyThing.Menu;
using AnyThing.SourceCode;
using AnyThing.SpeedTest;
using BenchmarkDotNet.Running;
using Common.CusAttribute;
using Common.Extension;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.XPath;

namespace AnyThing
{

    [Customer]
    public class Program : IThing
    {

        [return: Customer, Description]
        static async Task Main(string[] args)
        {
            {

                Type type = typeof(Levels);
                FieldInfo[] flds = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

                for (int i = 0; i < flds.Length; i++)
                {
                    dynamic obj = flds[i].GetValue(null);

                    Console.WriteLine(obj.ToString());
                    Console.WriteLine((int)obj);

                }
            }
            {// Benchmark Test
                //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ModulusTest>();
            }
            {// 查看uint 上限
                //uint i = 4294967295; 
                //Console.WriteLine(i);
            }
            {

#if DEBUG
                Console.WriteLine("debug");
#endif

            }

            {

                //Levels level = Levels.Default;

                //level.GetType().GetField(level.ToString());

            }

            { // Regex替换

                //string txt = File.ReadAllText(@"C:\Users\win\Desktop\info.txt");

                //txt = Regex.Replace(txt, "[0-9]+.", string.Empty);

                //txt.Replace("。", "。\n");

                //File.WriteAllText(@"C:\Users\win\Desktop\info-format.txt", txt);

            }

            { // 查看console 流定义
                //Console.WriteLine();

                //TextWriter @out = Console.Out;

                ////+		_stream	{System.ConsolePal.WindowsConsoleStream}	System.IO.Stream {System.ConsolePal.WindowsConsoleStream}
                //Console.WriteLine(@out.GetType().FullName);

            }

            { // 查看元组是否实现hashcode

                //ISet<(int num, int index)> set = new HashSet<(int num, int index)>() {
                //    { (1,1)} ,
                //    { (1,1)} ,
                //};

                //Console.WriteLine(set.Count);

                //Console.WriteLine(JsonConvert.SerializeObject(set));

            }

            { // number To char
                //for (int j = 0; j < 3; j++)
                //{

                //    for (int i = 0; i < 26; i++)
                //    {
                //        StringBuilder builder = new StringBuilder();
                //        builder.Append((char)(j + 'a'));
                //        builder.Append((char)(i + 'a'));
                //        Console.WriteLine(builder + ":" + builder.ToString().ConvertToNumber());
                //    }
                //}

                //Console.WriteLine("zzzzz".ConvertToNumber());

                //Console.WriteLine(12356630.ConvertToLowercase());

                //for (int i = 1; i < 56; i++)
                //{
                //    Console.WriteLine($"{i}:{i.ConvertToLowercase()}");
                //}

            }

            { // decimal 精确度不足..
                //decimal v = 94911150 /(decimal) 94911151;
                //decimal v2 = 94911151 / (decimal)94911152;

                //Console.WriteLine(v == v2);
            }
            { // float 存在无穷大/无穷小的概念...

                //Vector2 vector21 = new Vector2();

                //Vector<(double,double)> vector = new Vector<(double, double)>((0.9d, 0.2d));
                //Vector<(double,double)> vector2= new Vector<(double, double)>((0.9d, 0.2d));

                //Console.WriteLine(vector == vector2);

                //Console.WriteLine(94911150f/ 94911151f); // 1

                //Console.WriteLine(1f/0); // infinity , float/0 => ∞

                //Console.WriteLine(0/2f);

            }
            { // number To char

                //StringBuilder all = new StringBuilder();
                //for (int i = 1; i < 1000; i++)
                //{
                //    StringBuilder builder = new StringBuilder();
                //    int num = i;
                //    if(num <= 26)
                //        builder.Append((char)(((num - 1) % 26) + 'a'));
                //    else
                //    {
                //        builder.Append((char)(((num - 1) % 26) + 'a'));
                //        while (num >= 26)
                //        {
                //            int prev = num;
                //            num /= 26;
                //            builder.Insert(0, (char)((num % 26 + (prev % 26 == 0 ? -1 : 0) - 1) + 'a'));
                //        }
                //    }
                //    Console.WriteLine($"{i}-{builder}");
                //    all.AppendLine($"{i}-{builder}");
                //}
                //var str = all.ToString();
                //Console.WriteLine(str);
            }

            { // number To char
                //int count = 999;
                //for (int i = 0; i < 99; i++)
                //{
                //    int num = count;
                //    StringBuilder builder = new StringBuilder();

                //    if(num > 999)
                //    {
                //        builder.Append((num - 1) % 999 + 1);
                //        builder.Append(((num - 1) / 999).ConvertToLowercase());
                //    }
                //    else
                //    {
                //        builder.Append(num);
                //    }
                //    Console.WriteLine(builder);
                //    count += 999;

                //}
            }

            { // timespan -> string

                //TimeSpan timeSpan = TimeSpan.FromMinutes(120);

                //Console.WriteLine(timeSpan.ToString(@"hh\:mm"));

            }

            //{

            //    await Task.Run(() => { Console.WriteLine("await"); });

            //    Task.Run(() => { Console.WriteLine("wait"); }).Wait();

            //}

            // Benchmark Test
            {
                //BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ForeachTest>();
            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

            await Task.CompletedTask;

        }

        private static void EFExecSqlWithParamter()
        {
            { // ef 参数化构建

                //RelationalTypeMappingSource relationalTypeMappingSource = new RelationalTypeMappingSource();

                //RelationalCommandBuilderDependencies dependencies = new RelationalCommandBuilderDependencies(relationalTypeMappingSource);


                //var build = new RawSqlCommandBuilder(new RelationalCommandBuilderFactory(dependencies)
                //    , new RelationalSqlGenerationHelper(new RelationalSqlGenerationHelperDependencies())
                //    , new ParameterNameGeneratorFactory(new ParameterNameGeneratorDependencies()));

            }
        }

        private static void TestReflector()
        {
            { // 反射测试

                //var type = typeof(Program);

                //type.GetTypeInfo();

                //if(type is IReflectableType reflectableType)
                //{
                //    Console.WriteLine(reflectableType.GetTypeInfo());
                //}

            }
        }

        private static void SearchXpath()
        {
            {
                //XPathDocument xml = new XPathDocument(@"F:\WorkSpace\UA_Foundation\Application\ZeusSys.AdminApi\bin\Debug\netcoreapp3.1\ZeusSys.AdminApi.xml");

                //XPathNavigator navigator = xml.CreateNavigator();

                //StringBuilder builder = new StringBuilder();

                //foreach (var item in typeof(MemberRes).GetProperties())
                //{
                //    var name = $"{UpperToLower(item.Name[0])}{item.Name.Substring(1)}";
                //    var desc = navigator.SelectSingleNode($"doc/members/member[@name='P:ZeusSys.AdminApi.Domain.MemberModule.Response.MemberRes.{item.Name}']/summary")?.Value.Replace('\n', ' ').Trim() ?? name;

                //    builder.AppendLine($"{name}: '{desc}',");
                //}

                //Console.WriteLine(builder);
                //XPathNavigator xPathNavigator = navigator.SelectSingleNode("doc/members/member[@name='P:ZeusSys.AdminApi.ConfigModel.JwtBearerConfig.TokenValidTime']/summary");

                //Console.WriteLine(xPathNavigator.Value);

            }
        }

        private static void TestSortedSetRedis()
        {


            //ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000");

            //Console.WriteLine(connectionMultiplexer.GetType().Name);

            //IDatabase database = connectionMultiplexer.GetDatabase();

            //var key = "history.summary.browse";

            ////database.KeyDelete(key);

            //Console.WriteLine("存活的value:");
            //var sortedSetEntries = database.SortedSetRangeByRankWithScores(key);

            //foreach (var item in sortedSetEntries)
            //{
            //    Console.WriteLine($"{item.Element}-{item.Score}\n");
            //}

            //key = "history.summary.browse.by.facility";

            ////database.KeyDelete(key);

            //Console.WriteLine("存活的value:");
            //sortedSetEntries = database.SortedSetRangeByRankWithScores(key);

            //foreach (var item in sortedSetEntries)
            //{
            //    Console.WriteLine($"{item.Element}-{item.Score}\n");
            //}

            //var key = $"h5.user.token.9b9091a27ae54e59b0344c2e62270286";

            ////for (int i = 0; i < 10; i++)
            ////{
            ////    database.SortedSetAdd(key, i, (DateTime.Now.AddSeconds(2 + i) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            ////}

            ////database.KeyExpire(key, TimeSpan.FromSeconds(5));

            ////// 清空至最后一个                                                                                                                                                                                                                                                                                                                                       
            ////long len = database.SortedSetLength(key);

            ////database.SortedSetRemoveRangeByRank(key, 0, 0);

            ////database.SortedSetRemoveRangeByRank(key, 0, 4);

            //Console.WriteLine("存活的value:");
            //var sortedSetEntries = database.SortedSetRangeByRankWithScores(key);

            //foreach (var item in sortedSetEntries)
            //{
            //    Console.WriteLine($"{item.Element}-{item.Score}\n");
            //}

            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjAxZDJkYzNmMGMyNjRiMzk4MDllNTUwZjQ5MzRkYzA2IiwiVGVhbUlkIjoiZGIwZWNiZjM4NDg0NDRkZTk3OTQyZjEyZGUyYWFhMjIiLCJBdXRoU291cmNlIjoiQ3VzdG9tZSIsIlNvdXJjZSI6IldlYiIsImV4cCI6MTU5Nzk3NDE5MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIn0.TInjfwyuaKPbYKw2bpmjfLnzs0QeIIg_VkeTKLIfjTc";

            //bool result = database.SortedSetScanAsync(key, token).GetAsyncEnumerator().MoveNextAsync().Result;

            //Console.WriteLine(result);

            //for (int i = 0; i < 10; i++)
            //{
            //    double score = (DateTime.Now.AddSeconds(5) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            //    Console.WriteLine("存活的value:");
            //    SortedSetEntry[] sortedSetEntries = database.SortedSetRangeByScoreWithScores(key, score);

            //    foreach (var item in sortedSetEntries)
            //    {
            //        Console.WriteLine($"{item.Element}-{item.Score}");
            //    }
            //    Thread.Sleep(1000);
            //}

            //long v = database.SortedSetLengthByValue(key, "1", "1");

            //Console.WriteLine(v);

            //Console.WriteLine(database.SortedSetRemove(key, "1"));

            //while (true)
            //{

            //    double score = (DateTime.Now.AddSeconds(5) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;

            //    Console.WriteLine(score);

            //    SortedSetEntry[] sortedSetEntries = database.SortedSetRangeByScoreWithScores(key, 0, score);

            //    if (sortedSetEntries == null || sortedSetEntries.Length == 0) continue;

            //    foreach (var item in sortedSetEntries)
            //    {
            //        Console.WriteLine($"{item.Element}-{item.Score}");
            //    }

            //    database.SortedSetRemoveRangeByScore(key, 0, score);

            //    break;

            //}

            //v = database.SortedSetLengthByValue(key, "1", "1");

            //Console.WriteLine(v);

            //Console.WriteLine(database.SortedSetRemove(key,"1"));

            //Console.WriteLine("存活的value:");

            //RedisValue[] redisValues = database.SortedSetRangeByRank(key);

            //foreach (var item in redisValues)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //database.KeyDelete(key);

            Console.WriteLine((DateTime.Now.AddMinutes(3) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);

        }

        private static void GetFileHead()
        {
            { // 查看文件头-》真正的文件类型

                //string path = @"F:\Davis\Data\voice\1.amr";
                //System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                //System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
                //string bx = " ";
                //byte buffer;
                //try
                //{
                //    buffer = r.ReadByte();
                //    bx = buffer.ToString();
                //    buffer = r.ReadByte();
                //    bx += buffer.ToString();
                //}
                //catch (Exception exc)
                //{
                //    Console.WriteLine(exc.Message);
                //}
                //r.Close();
                //fs.Close();
                ////真实的文件类型
                //Console.WriteLine(bx);
                ////文件名，包括格式
                //Console.WriteLine(System.IO.Path.GetFileName(path));
                ////文件名， 不包括格式
                //Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(path));
                ////文件格式
                //Console.WriteLine(System.IO.Path.GetExtension(path));
                //Console.ReadLine();

            }
        }

        private static void AnanlysisUserAgent()
        {
            {// 解析userAgent

                //var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.135 Safari/537.36 Edg/84.0.522.63";

                //userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.1.1 Mobile/15E148 Safari/604.1";

                //var uaParser = Parser.GetDefault();
                //var ParseDevice = uaParser.ParseDevice(userAgent);
                //var ParseUserAgent = uaParser.ParseUserAgent(userAgent);
                //var ParseOS = uaParser.ParseOS(userAgent);

                //var 制造商 = ParseDevice.Brand;
                //var 操作系统 = $"{ParseOS.Family ?? ""}.{ParseOS.Major ?? "0"}.{ParseOS.Minor ?? "0"}.{ParseOS.Patch ?? "0"}";
                //var 浏览器 = $"{ParseUserAgent.Family ?? ""}.{ParseUserAgent.Major ?? "0"}.{ParseUserAgent.Minor ?? "0"}";

                //Console.WriteLine(制造商);
                //Console.WriteLine(操作系统);
                //Console.WriteLine(浏览器);

            }
        }

        private static void TestPaller()
        {
            { // 并发测试

                //ConcurrentDictionary<string, List<string>> dic = new ConcurrentDictionary<string, List<string>>();

                //string key = nameof(key);

                //dic[key] = new List<string>();

                //for (int i = 0; i < 100; i++)
                //{
                //    dic[key].Add(i.ToString());
                //}

                //Parallel.ForEach(Enumerable.Range(0, 100), u =>
                //{
                //    List<string> lists = dic[key];
                //    var value = u.ToString();
                //    lists.Remove(value);
                //});

                //Console.WriteLine(dic[key].Count);

                //Console.WriteLine(string.Join(',', dic[key]));

            }

            {// 并发测试
                //ConcurrentDictionary<string, ISet<string>> dic = new ConcurrentDictionary<string, ISet<string>>();

                //string key = nameof(key);

                //dic[key] = new HashSet<string>();

                //for (int i = 0; i < 100; i++)
                //{
                //    dic[key].Add(i.ToString());
                //}

                //Parallel.ForEach(Enumerable.Range(0, 100), u =>
                //{
                //    dic[key].Remove(u.ToString());
                //});

                //Console.WriteLine(dic[key].Count);

                //List<string> lists = dic[key].ToList();

                //Console.WriteLine(string.Join(',', lists.Where(u => u != null)));
                //Console.WriteLine(string.Join(',', dic[key]));
            }
        }

        private static void GenerateContentTypeMap()
        {
            // ContentType 对照表

            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
            };

            var contentMap = @"
ez,application/andrew-inset
hqx,application/mac-binhex40
cpt,application/mac-compactpro
doc,application/msword
bin,application/octet-stream
dms,application/octet-stream
lha,application/octet-stream
lzh,application/octet-stream
exe,application/octet-stream
class,application/octet-stream
so,application/octet-stream
dll,application/octet-stream
oda,application/oda
pdf,application/pdf
ai,application/postscript
eps,application/postscript
ps,application/postscript
smi,application/smil
smil,application/smil
mif,application/vnd.mif
xls,application/vnd.ms-excel
ppt,application/vnd.ms-powerpoint
wbxml,application/vnd.wap.wbxml
wmlc,application/vnd.wap.wmlc
wmlsc,application/vnd.wap.wmlscriptc
bcpio,application/x-bcpio
vcd,application/x-cdlink
pgn,application/x-chess-pgn
cpio,application/x-cpio
csh,application/x-csh
dcr,application/x-director
dir,application/x-director
dxr,application/x-director
dvi,application/x-dvi
spl,application/x-futuresplash
gtar,application/x-gtar
hdf,application/x-hdf
js,application/x-javascript
skp,application/x-koan
skd,application/x-koan
skt,application/x-koan
skm,application/x-koan
latex,application/x-latex
nc,application/x-netcdf
cdf,application/x-netcdf
sh,application/x-sh
shar,application/x-shar
swf,application/x-shockwave-flash
sit,application/x-stuffit
sv4cpio,application/x-sv4cpio
sv4crc,application/x-sv4crc
tar,application/x-tar
tcl,application/x-tcl
tex,application/x-tex
texinfo,application/x-texinfo
texi,application/x-texinfo
tr,application/x-troff
roff,application/x-troff
man,application/x-troff-man
me,application/x-troff-me
ms,application/x-troff-ms
ustar,application/x-ustar
src,application/x-wais-source
xhtml,application/xhtml+xml
xht,application/xhtml+xml
zip,application/zip
au,audio/basic
snd,audio/basic
mid,audio/midi
midi,audio/midi
kar,audio/midi
mpga,audio/mpeg
mp2,audio/mpeg
mp3,audio/mpeg
aif,audio/x-aiff
aiff,audio/x-aiff
aifc,audio/x-aiff
m3u,audio/x-mpegurl
ram,audio/x-pn-realaudio
rm,audio/x-pn-realaudio
rpm,audio/x-pn-realaudio-plugin
ra,audio/x-realaudio
wav,audio/x-wav
pdb,chemical/x-pdb
xyz,chemical/x-xyz
bmp,image/bmp
gif,image/gif
ief,image/ief
jpeg,image/jpeg
jpg,image/jpeg
jpe,image/jpeg
png,image/png
tiff,image/tiff
tif,image/tiff
djvu,image/vnd.djvu
djv,image/vnd.djvu
wbmp,image/vnd.wap.wbmp
ras,image/x-cmu-raster
pnm,image/x-portable-anymap
pbm,image/x-portable-bitmap
pgm,image/x-portable-graymap
ppm,image/x-portable-pixmap
rgb,image/x-rgb
xbm,image/x-xbitmap
xpm,image/x-xpixmap
xwd,image/x-xwindowdump
igs,model/iges
iges,model/iges
msh,model/mesh
mesh,model/mesh
silo,model/mesh
wrl,model/vrml
vrml,model/vrml
css,text/css
html,text/html
htm,text/html
asc,text/plain
txt,text/plain
rtx,text/richtext
rtf,text/rtf
sgml,text/sgml
sgm,text/sgml
tsv,text/tab-separated-values
wml,text/vnd.wap.wml
wmls,text/vnd.wap.wmlscript
etx,text/x-setext
xsl,text/xml
xml,text/xml
mpeg,video/mpeg
mpg,video/mpeg
mpe,video/mpeg
qt,video/quicktime
mov,video/quicktime
mxu,video/vnd.mpegurl
avi,video/x-msvideo
movie,video/x-sgi-movie
ice,x-conference/x-cooltalk";

            string[] arr = contentMap.Split("\r\n").Select((u) =>
            {

                string[] vs = u.Split(',');

                if (vs.Length == 2)
                {
                    if (!dic.ContainsKey(vs[1]))
                    {
                        dic.Add(vs[1], vs[0]);
                        return $"{{\"{vs[1]}\",\"{vs[0]}\"}}";
                    }
                }
                return string.Empty;

            }).ToArray();

            Console.WriteLine(string.Join("\n,", arr));

        }

        private const int _diff = 'a' - 'A';

        public static char UpperToLower(char c)
        {
            if (c >= 'a')
                return c;
            return (char)(c + _diff);
        }

        private static void TestRedis()
        {
            // test redis get thread error

            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000");

            Console.WriteLine(connectionMultiplexer.GetType().Name);

            StackExchange.Redis.IDatabase database = connectionMultiplexer.GetDatabase();

            Console.WriteLine(database.GetType().Name);

            var key = "test.key";

            //StringBuilder max = new StringBuilder();

            //for (int i = 0; i < 5965220; i++)
            //{
            //    max.Append(Guid.NewGuid().ToString());
            //}

            //var maxStr = max.ToString();

            //bool res = database.StringSet(key, $"{Guid.NewGuid().ToString()}-{maxStr}");

            //Console.WriteLine("set key res : " + res);

            bool flag = true;

            ThreadPool.SetMinThreads(100, 0);

            Parallel.For(0, 200_000, (num) =>
            {
                try
                {
                    if (flag)
                    {
                        //ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000").GetDatabase().StringGet(key);
                    }
                }
                catch (Exception e)
                {

                    flag = false;

                    Console.WriteLine(e.ToString());

                    //Thread.Sleep(3000);

                    //RedisValue redisValue = database.StringGet(key);

                    //Console.WriteLine(redisValue.Length());
                }
            });

        }

        private static void CreateDelegate()
        {
            IThing instance = new Program();

            MethodInfo methodInfo = instance.GetType().GetMethod("Show");

            Delegate @delegate = instance.GetType().GetMethod("Show")
                .CreateDelegate(typeof(Action<string>), instance);

            Action<string> action = (Action<string>)@delegate;

            action("12312");

        }

        public void Show(string str)
        {
            Console.WriteLine(str);
        }

    }

    public interface IThing
    {
        void Show(string str);
    }


}
