using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Linq;
namespace WapXzone_VNM.P3.UserControl
{
    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string linkdown { get; set; }
        public string views { get; set; }
        public string time { get; set; }
        public string description { get; set; }
        public int is_hot { get; set; }
        public int is_top { get; set; }
        public string posted_date { get; set; }
        public string linkfile { get; set; }
    }

    public class Controller
    {
        public static List<Data> GetDataRandom(int start, int limit)
        {
            XElement xmlData = XElement.Load("http://hotclip.tv/api?f=getRand&start=" + start + "&limit=" + limit + "&format=xml").Element("videos");
            List<Data> data = (from q in xmlData.Elements("item")
                               select new Data
                               {
                                   id = Convert.ToInt32(q.Element("id").Value),
                                   name = q.Element("name").Value,
                                   image = q.Element("image").Value,
                                   linkdown = q.Element("linkdown").Value,
                                   views = q.Element("views").Value,
                                   time = q.Element("time").Value,
                                   description = q.Element("description").Value,
                                   is_hot = Convert.ToInt32(q.Element("is_hot").Value),
                                   is_top = Convert.ToInt32(q.Element("is_top").Value),
                                   posted_date = q.Element("posted_date").Value,
                               }).ToList();

            return data;
        }

        public static List<Data> GetDataNew(int start, int limit)
        {
            XElement xmlData = XElement.Load("http://hotclip.tv/api?f=getNew&start=" + start + "&limit=" + limit + "&format=xml").Element("videos");
            List<Data> data = (from q in xmlData.Elements("item")
                               select new Data
                               {
                                   id = Convert.ToInt32(q.Element("id").Value),
                                   name = q.Element("name").Value,
                                   image = q.Element("image").Value,
                                   linkdown = q.Element("linkdown").Value,
                                   views = q.Element("views").Value,
                                   time = q.Element("time").Value,
                                   description = q.Element("description").Value,
                                   is_hot = Convert.ToInt32(q.Element("is_hot").Value),
                                   is_top = Convert.ToInt32(q.Element("is_top").Value),
                                   posted_date = q.Element("posted_date").Value,
                               }).ToList();

            return data;
        }

        public static List<Data> GetDataTop(int start, int limit)
        {
            XElement xmlData = XElement.Load("http://hotclip.tv/api?f=getTop&start=" + start + "&limit=" + limit + "&format=xml").Element("videos");
            List<Data> data = (from q in xmlData.Elements("item")
                               select new Data
                               {
                                   id = Convert.ToInt32(q.Element("id").Value),
                                   name = q.Element("name").Value,
                                   image = q.Element("image").Value,
                                   linkdown = q.Element("linkdown").Value,
                                   views = q.Element("views").Value,
                                   time = q.Element("time").Value,
                                   description = q.Element("description").Value,
                                   is_hot = Convert.ToInt32(q.Element("is_hot").Value),
                                   is_top = Convert.ToInt32(q.Element("is_top").Value),
                                   posted_date = q.Element("posted_date").Value,
                               }).ToList();

            return data;
        }

        public static List<Data> GetDataHot(int start, int limit)
        {
            XElement xmlData = XElement.Load("http://hotclip.tv/api?f=getHot&start=" + start + "&limit=" + limit + "&format=xml").Element("videos");
            List<Data> data = (from q in xmlData.Elements("item")
                               select new Data
                               {
                                   id = Convert.ToInt32(q.Element("id").Value),
                                   name = q.Element("name").Value,
                                   image = q.Element("image").Value,
                                   linkdown = q.Element("linkdown").Value,
                                   views = q.Element("views").Value,
                                   time = q.Element("time").Value,
                                   description = q.Element("description").Value,
                                   is_hot = Convert.ToInt32(q.Element("is_hot").Value),
                                   is_top = Convert.ToInt32(q.Element("is_top").Value),
                                   posted_date = q.Element("posted_date").Value,
                               }).ToList();

            return data;
        }

        public static Data GetDataDetail(int id)
        {
            XElement q = XElement.Load("http://hotclip.tv/api?f=getDetail&id=" + id);
            Data data = new Data();
            data.id = Convert.ToInt32(q.Element("id").Value);
            data.name = q.Element("name").Value;
            data.image = q.Element("image").Value;
            data.linkdown = q.Element("linkdown").Value;
            data.views = q.Element("views").Value;
            data.time = q.Element("time").Value;
            data.description = q.Element("description").Value;
            data.is_hot = Convert.ToInt32(q.Element("is_hot").Value);
            data.is_top = Convert.ToInt32(q.Element("is_top").Value);
            data.posted_date = q.Element("posted_date").Value;
            data.linkfile = q.Element("linkfile").Value;
            return data;
        }
    }
}