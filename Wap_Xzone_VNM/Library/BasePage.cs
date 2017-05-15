using System;
using System.Collections.Generic;
using System.Web;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using System.Net;
using log4net;

namespace WapXzone_VNM.Library
{
    public class BasePage : System.Web.UI.Page
    {

        public int Lang
        {
            get
            {
                return ConvertUtility.ToInt32(Request.QueryString["lang"]);
            }
        }
        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        ILog logger = log4net.LogManager.GetLogger("BasePage");


        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current.Request.UserAgent.ToLower().Contains("midp") && !MobileUtils.IsBlackBerry(HttpContext.Current.Request.UserAgent.ToLower()))
            {
                //Response.CacheControl = "private";
                Response.Charset = "UTF-8";
                //Response.Expires = 0;
                string acceptHeader = Request.ServerVariables["HTTP_ACCEPT"];

                if (acceptHeader.IndexOf("application/vnd.wap.xhtml+xml") != -1)
                {
                    Response.ContentType = "application/vnd.wap.xhtml+xml";
                }
                else if (acceptHeader.IndexOf("application/xhtml+xml") != -1)
                {
                    Response.ContentType = "application/xhtml+xml";
                }
                else
                {
                    Response.ContentType = "text/html";
                }
            }

            if(Session["msisdn"] == null)
            //if (ConvertUtility.ToString(Session["telco"]) == string.Empty)
            {
                int is3g = 0;
                string msisdn = MobileUtils.GetMSISDN(out is3g);
                
                Session["is3g"] = is3g;

                if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                {
                    Session["telco"] = Constant.Constant.T_Vietnamobile;
                    Session["msisdn"] = msisdn;
                }
                else
                {
                    Session["msisdn"] = null;
                    Session["telco"] = Constant.Constant.T_Undefined;
                }
            }
        }

        private string GaAccount;
        private const string GaPixel = "ga.aspx";

        public string GoogleAnalyticsGetImageUrl()
        {   
            //GaAccount = "MO-30173060-1";            

            GaAccount = "MO-52923020-1";    

            System.Text.StringBuilder url = new System.Text.StringBuilder();
            url.Append(GaPixel + "?");
            url.Append("utmac=").Append(GaAccount);

            Random RandomClass = new Random();
            url.Append("&utmn=").Append(RandomClass.Next(0x7fffffff));

            string referer = "-";
            if (Request.UrlReferrer != null
                 && "" != Request.UrlReferrer.ToString())
            {
                referer = Request.UrlReferrer.ToString();
            }
            url.Append("&utmr=").Append(HttpUtility.UrlEncode(referer));

            if (HttpContext.Current.Request.Url != null)
            {
                url.Append("&utmp=").Append(HttpUtility.UrlEncode(Request.Url.PathAndQuery));
            }

            url.Append("&guid=ON");

            return url.ToString();
        }

        public static void AddDevice(string UserAgent, string ModelName, string BrandName, string DeviceOS, string MobileBrowser, string ResolutionWidth, string ResolutionHeight)
        {
            WapXzone_VNM.Library.SQLHelper.SqlHelper.ExecuteNonQuery(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "CP_Device_Insert", UserAgent, ModelName, BrandName, DeviceOS, MobileBrowser, ResolutionWidth, ResolutionHeight);
        }
        
    }
}
