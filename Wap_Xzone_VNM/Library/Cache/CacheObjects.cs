using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Xsl;
using System.Xml;
using System.Web.Caching;
using System.Data;
using System.Data.SqlClient;

namespace WapXzone_VNM.Library.Cache
{
    public class CacheObjects
    {
        // handle cached sql data set
        public DataSet GetSqlDataSet(string key, string connection, string query)
        {
            return GetSqlDataSet(key, connection, query, false, 0, 0);
        }

        public DataSet GetSqlDataSet(string key, string connection, string query, bool refresh)
        {
            return GetSqlDataSet(key, connection, query, refresh, 0, 0);
        }

        public DataSet GetSqlDataSet(string key, string connection, string query, bool refresh, int ttlSeconds)
        {
            return GetSqlDataSet(key, connection, query, refresh, ttlSeconds, 0);
        }

        public DataSet GetSqlDataSet(string key, string connection, string query, bool refresh, int ttlSeconds, int slidingSeconds)
        {
            DataSet ds = null;

            try
            {
                if (refresh == false)
                    ds = (DataSet)CacheUtility.GetCacheItem(key);
            }
            catch { }

            if (ds == null)
            {
                try
                {
                    ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("GetSqlDataSet failed.", ex);
                }

                if (slidingSeconds > 0 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, ds, ttlSeconds, slidingSeconds);
                if (slidingSeconds < 1 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, ds, ttlSeconds);
                else
                    CacheUtility.SetCacheItem(key, ds);
            }
            return ds;
        }

        // handle cached xml data set
        public DataSet GetXmlDataSet(string key, string filename)
        {
            return GetXmlDataSet(key, filename, false, true);
        }

        public DataSet GetXmlDataSet(string key, string filename, bool refresh)
        {
            return GetXmlDataSet(key, filename, refresh, true);
        }

        public DataSet GetXmlDataSet(string key, string filename, bool refresh, bool depends)
        {
            DataSet ds = null;

            try
            {
                if (refresh == false)
                    ds = (DataSet)CacheUtility.GetCacheItem(key);
            }
            catch { }

            if (ds == null)
            {
                try
                {
                    ds = new DataSet();
                    ds.ReadXml(filename);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("GetXmlDataSet failed.", ex);
                }

                if (depends == true)
                {
                    CacheDependency cd = new CacheDependency(filename);
                    CacheUtility.SetCacheItem(key, ds, cd);
                }
                else
                    CacheUtility.SetCacheItem(key, ds);
            }
            return ds;
        }

        // handle cached xml document
        public XmlDocument GetXmlDocument(string key, string url)
        {
            return GetXmlDocument(key, url, false, 0, 0);
        }

        public XmlDocument GetXmlDocument(string key, string url, bool refresh)
        {
            return GetXmlDocument(key, url, refresh, 0, 0);
        }

        public XmlDocument GetXmlDocument(string key, string url, bool refresh, int ttlSeconds)
        {
            return GetXmlDocument(key, url, refresh, ttlSeconds, 0);
        }

        public XmlDocument GetXmlDocument(string key, string url, bool refresh, int ttlSeconds, int slidingSeconds)
        {
            XmlDocument xd = new XmlDocument();

            try
            {
                if (refresh == false)
                    xd = (XmlDocument)CacheUtility.GetCacheItem(key);
            }
            catch { }

            if (xd == null)
            {
                try
                {
                    xd = new XmlDocument();
                    xd.Load(url);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("GetXmlDocument failed.", ex);
                }

                if (slidingSeconds > 0 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, xd, ttlSeconds, slidingSeconds);
                if (slidingSeconds < 1 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, xd, ttlSeconds);
                else
                    CacheUtility.SetCacheItem(key, xd);
            }
            return xd;
        }

        // handle cached xsl transform document
        public XslTransform GetXslTransform(string key, string url)
        {
            return GetXslTransform(key, url, false, 0, 0);
        }

        public XslTransform GetXslTransform(string key, string url, bool refresh)
        {
            return GetXslTransform(key, url, refresh, 0, 0);
        }

        public XslTransform GetXslTransform(string key, string url, bool refresh, int ttlSeconds)
        {
            return GetXslTransform(key, url, refresh, ttlSeconds, 0);
        }

        public XslTransform GetXslTransform(string key, string url, bool refresh, int ttlSeconds, int slidingSeconds)
        {
            XslTransform xs = new XslTransform();

            try
            {
                if (refresh == false)
                    xs = (XslTransform)CacheUtility.GetCacheItem(key);
            }
            catch { }

            if (xs == null)
            {
                try
                {
                    xs = new XslTransform();
                    xs.Load(url);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("GetXslTransform failed.", ex);
                }

                if (slidingSeconds > 0 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, xs, ttlSeconds, slidingSeconds);
                if (slidingSeconds < 1 && ttlSeconds > 0)
                    CacheUtility.SetCacheItem(key, xs, ttlSeconds);
                else
                    CacheUtility.SetCacheItem(key, xs);
            }
            return xs;
        }

    }    
}
