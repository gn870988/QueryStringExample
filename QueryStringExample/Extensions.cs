using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace QueryStringExample
{
    public static class Extensions
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            var segments = from key in nvc.AllKeys
                           from value in nvc.GetValues(key)
                           select 
                           $"{WebUtility.UrlEncode(key)}={WebUtility.UrlEncode(value)}";

            return $"?{string.Join("&", segments)}";
        }
    }
}
