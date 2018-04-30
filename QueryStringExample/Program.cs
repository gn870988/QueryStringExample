using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace QueryStringExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = $"https://www.google.com.tw";

            var nvc = new NameValueCollection
            {
                {"parameter1", "1" },
                {"parameter2", "two" },
                {"parameter3", "中文" }
            };

            // 可用Add方法加入<string, string>
            nvc.Add("parameter4", "測試");

            // ***【補充】***
            // 要在網頁上接受QueryString方法
            // NameValueCollection nvc = Request.QueryString;

            // 【Demo1】網址 + QueryString參數
            Console.WriteLine($"-------------目標網址-------------");
            Console.WriteLine($"{url}{nvc.ToQueryString()}");
            Console.WriteLine($"---------------------------------");
            Console.WriteLine();

            // 接收QueryString參數
            var collection = HttpUtility.ParseQueryString($"{nvc.ToQueryString()}");

            // 拆解QueryString參數
            var all = from key in nvc.AllKeys
                      from value in nvc.GetValues(key)
                      select ($"{key}：{value}");

            // 【Demo2】
            Console.WriteLine($"-------------解析QueryString全部參數-------------");
            Console.WriteLine($"{string.Join("，", all)}");
            Console.WriteLine($"-----------------------------------------------");
            Console.WriteLine();

            // 【Demo3】
            Console.WriteLine($"-------------解析QueryString單參數-------------");
            Console.WriteLine($"{collection.GetKey(0)}：{collection["parameter1"]}");
            Console.WriteLine($"---------------------------------------------");
            Console.WriteLine();

            Console.Read();
        }
    }
}
