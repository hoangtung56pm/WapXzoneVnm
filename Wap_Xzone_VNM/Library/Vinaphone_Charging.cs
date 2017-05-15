using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using log4net;
using System.Text;
namespace WapXzone_VNM.Library
{
    public class Vinaphone_Charging
    {
        public static string ReturnChargingResult(string msidsdn, string price)
        {
            ILog logger = log4net.LogManager.GetLogger("File");
            string requestUrl = "http://10.1.10.86:8080/billing/billing";
            logger.Info("----------------------------------------");
            logger.Info("Start call charing: " + requestUrl);
            string[] kq = new string[3];
                try
                {
                    //String xmlString = GetHTTPResponseAsString(new System.Uri(requestUrl));
                    string xmlString = posthttpXml(requestUrl, msidsdn, price);
                    //Parse XML String
                   kq = SplitData(xmlString);
                  
                }
                catch (XmlException e)
                {

                    logger.Info("Error: " + msidsdn + e.ToString());
                }
                return kq[1];
        }
        public static string GetPageAsString(Uri address)
        {
            string result = "";
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());
                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();
            }
            
            return result;
        }
        public static string[] SplitData(string xmlString) {
            ILog logger = log4net.LogManager.GetLogger("File");
            string[] result = new string[3];
            try
            {
               
                
                string msisdn = "";
                string status_code = "";
                string description = "";
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlString);

                XmlNodeList xnList = xml.SelectNodes("VAS");
                foreach (XmlNode xn in xnList)
                {
                    msisdn = xn["SUBID"].InnerText;
                    status_code = xn["ERROR"].InnerText;
                    description = xn["ERROR_DESC"].InnerText;
                }

                //XmlReader oXmlReader = XmlReader.Create(new StringReader(xmlString));
                //XmlDocument doc = new XmlDocument();
                //doc.Load(oXmlReader);
                //XmlNode msisdnnode = doc.SelectSingleNode("VAS/@SUBID");
                //msisdn = msisdnnode.Value;
                //XmlNode statusnnode = doc.SelectSingleNode("VAS/@ERROR");
                //status_code = statusnnode.Value;
                //XmlNode descriptionnode = doc.SelectSingleNode("VAS/@ERROR_DESC");
                //description = descriptionnode.Value;
                result[0] = msisdn;
                result[1] = status_code;
                result[2] = description;

                logger.Info("msisdn response:" + msisdn);
                logger.Info("status response:" + status_code);
                logger.Info("Description response:" + description);
                logger.Info("----------------------------------------");
            }
            catch (Exception ex) {
                logger.Info("Split Charging error: " + ex.ToString());
            }
            return result;
        }
        public static string[] WriteOutData(string xmlString)
        {
            string msisdn = "";
            string status_code = "";
            string description = "";
            string[] kq = new string[3];
            /*
            // Correct xml
                <?xml version="1.0" encoding="utf-8" standalone="yes"?>
                <VAS request_id="20101204121212"  version="1.0">
                    <RPLY name="...">      
                            <SUBID>84xxxxxxxx</SUBID>
                            <ERROR>0</ERROR>
                            <ERROR_DESC>Successfull</ERROR_DESC>       
                    </RPLY>
                </VAS>
             */
            // Create xml document
            XmlReader oXmlReader = XmlReader.Create(new StringReader(xmlString));
            XPathDocument doc = new XPathDocument(oXmlReader);
            // Create navigator  
            XPathNavigator navigator = doc.CreateNavigator();
            // Read Node
            XPathNodeIterator iterator = navigator.Select("VAS/RPLY/SUBID");
            while (iterator.MoveNext())
            {
                XPathNavigator navigator2 = iterator.Current.Clone();
                msisdn = navigator2.Value;
            }
            iterator = navigator.Select("VAS/RPLY/ERROR");
            while (iterator.MoveNext())
            {
                XPathNavigator navigator2 = iterator.Current.Clone();
                status_code = navigator2.Value;
            }
            iterator = navigator.Select("VAS/RPLY/ERROR_DESC");
            while (iterator.MoveNext())
            {
                XPathNavigator navigator2 = iterator.Current.Clone();
                description = navigator2.Value;
            }
            kq[0] = msisdn;
            kq[1] = status_code;
            kq[2] = description;
            return kq;
        }
        public static string GetHTTPResponseAsString(Uri address)
        {
            string result = "";

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();
            }
            ILog logger = log4net.LogManager.GetLogger("File");
            logger.Info(result);
            return result;
        }
        public static string posthttpXml(string url, string msidsdn, string price)
        {
            string responsecontent=string.Empty;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.ContentType = "text/xml";
            req.Method = "POST";
            string data = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\" ?><VAS request_id=\"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\">";
            data += "<REQ name=\"XZONEVMG\" user=\"xzone\" password=\"xzone#xenoz\">";
            data += "<SUBSCRIBER><SUBID>" + msidsdn +  "</SUBID><PRICE>" + price + "</PRICE></SUBSCRIBER></REQ></VAS>";
            //Log Data
            ILog logger = log4net.LogManager.GetLogger("File");
            logger.Info("XML Data Post: " + data);
            //End Log data post
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes("Your Data");
            req.ContentLength = bytes.Length;
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            // Set the ContentLength property of the WebRequest.
            req.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = req.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return responsecontent;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());

            responsecontent = sr.ReadToEnd().Trim();
            logger.Info("Response From VinaGW: " + responsecontent);
            return responsecontent;
        }
    }
}
