using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Caching;

namespace WapXzone_VNM.Library.Cache
{
    public class CacheUtility
    {
        // dump out cache list
        public static string DumpCache()
        {
            return DumpCache("");
        }

        public static string DumpCache(string mask)
        {
            StringBuilder sb = new StringBuilder();
            string key = "";


            System.Collections.IDictionaryEnumerator iden = HttpContext.Current.Cache.GetEnumerator();
            while (iden.MoveNext())
            {
                key = iden.Key.ToString();
                if (mask.Length != 0 && key.IndexOf(mask) != -1)
                    sb.AppendFormat("{0}<br />", key);
                if (mask.Length == 0)
                    sb.AppendFormat("{0}<br />", key);
            }
            return sb.ToString();
        }

        // clear all cache items
        public static void ClearCache()
        {
            ClearCache("");
        }

        public static void ClearCache(string mask)
        {
            string key = "";

            System.Collections.IDictionaryEnumerator iden = HttpContext.Current.Cache.GetEnumerator();
            while (iden.MoveNext())
            {
                key = iden.Key.ToString();
                if (mask.Length != 0 && key.IndexOf(mask) != -1)
                    DropCacheItem(key);
                if (mask.Length == 0)
                    DropCacheItem(key);
            }
        }

        // get a cache item
        public static object GetCacheItem(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }

        // drop an existing cache item
        public static void DropCacheItem(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        // add an item to the cache
        public static void SetCacheItem(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
        }

        public static void SetCacheItem(string key, object data, CacheDependency dependencies)
        {
            HttpContext.Current.Cache.Insert(key, data, dependencies);
        }

        public static void SetCacheItem(string key, object data, int seconds)
        {
            HttpContext.Current.Cache.Insert(key, data, null, System.DateTime.Now.AddSeconds(seconds), TimeSpan.Zero);
        }

        public static void SetCacheItem(string key, object data, int seconds, int slidingSeconds)
        {
            if (slidingSeconds > 0)
                HttpContext.Current.Cache.Insert(key, data, null, System.DateTime.MaxValue, TimeSpan.FromSeconds(slidingSeconds));
            else
                HttpContext.Current.Cache.Insert(key, data, null, System.DateTime.Now.AddSeconds(seconds), TimeSpan.FromSeconds(slidingSeconds));
        }
    }
}
