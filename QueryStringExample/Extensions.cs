using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace QueryStringExample
{
    public static class Extensions
    {
        public static string ToQueryString(this NameValueCollection nvc)
        {
            IEnumerable<string> segments = from key in nvc.AllKeys
                                           from value in nvc.GetValues(key)
                                           select string.Format("{0}={1}",
                                           WebUtility.UrlEncode(key),
                                           WebUtility.UrlEncode(value));

            return "?" + string.Join("&", segments);
        }
    }
}
