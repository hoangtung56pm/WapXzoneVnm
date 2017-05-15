using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

namespace WapXzone_VNM.Library.Cache
{
    public class DataCaching
    {
        private HttpContext context;

        public DataCaching()
        {
            context = HttpContext.Current;
        }

        public object GetCache(string key)
        {
            return context.Cache.Get(key);
        }

        public void InsertCache(string key, object data, double expireTime)
        {
            if (expireTime == 0) InsertCacheNoExpireTime(key, data);
            else context.Cache.Insert(key, data, null, DateTime.Now.AddMinutes(expireTime), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public void InsertCacheNoExpireTime(string key, object data)
        {
            if (data != null) context.Cache.Insert(key, data);
        }

        public bool RemoveCache(string key)
        {
            if (context.Cache[key] != null)
            {
                context.Cache.Remove(key);
                return true;
            }
            else return false;
        }

        public object GetHashCache(string hashKey, object param)
        {
            Hashtable retVal = (Hashtable)this.GetCache(hashKey);
            if (retVal == null) return null;
            if (retVal[param] == null) return null;
            return retVal[param];
        }

        public void SetHashCache(string hashKey, object param, double expireTime, object data)
        {
            Hashtable retVal = (Hashtable)this.GetCache(hashKey);
            if (retVal == null)
            {
                retVal = new Hashtable();
                retVal[param] = data;
                this.InsertCache(hashKey, retVal, expireTime);
            }
            else if (retVal.ContainsKey(param))
            {
                retVal[param] = data;
            }
            else
            {
                retVal.Add(param, data);
            }
        }
        public void RemoveAll()
        {
            System.Web.Caching.Cache cache = context.Cache;
            IEnumerator ienum = cache.GetEnumerator();
            while (ienum.MoveNext())
            {
                DictionaryEntry dic = (DictionaryEntry)ienum.Current;
                RemoveCache(dic.Key.ToString());
            }
        }
        public ArrayList GetKeys()
        {
            IEnumerator dcEnum = context.Cache.GetEnumerator();
            ArrayList _cacheArray = new ArrayList();
            while (dcEnum.MoveNext())
                if (((DictionaryEntry)dcEnum.Current).Value != null)
                    _cacheArray.Add(((DictionaryEntry)dcEnum.Current).Key.ToString());
            _cacheArray.Sort();
            return _cacheArray;
        }
    }
}
