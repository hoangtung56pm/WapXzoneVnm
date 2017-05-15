using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdn_all : Page
    {
        ILog logger = LogManager.GetLogger("getmsisdn_all");
        protected void Page_Load(object sender, EventArgs e)
        {
            string domain = Request.QueryString["p"];
            int is3g = 0;
           
            string msisdn = MobileUtils.GetMSISDN1();

            string url;
            logger.Debug(" ");
            logger.Debug("Domain =" + domain);

            logger.Debug("msisdn =" + msisdn);
            logger.Debug(" ");

            if (!string.IsNullOrEmpty(msisdn) && msisdn != "unknown")
            {
                url = "http://" + domain + "/?msisdn=" + msisdn;
                logger.Debug("URL RESPONSE : " + url);
                Response.Redirect(url);
            }
            else
            {
                url = "http://" + domain + "/?msisdn=unknown";
                Response.Redirect(url);
            }
            //string t = Request.QueryString["t"];

            //if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            //{
            //    Response.Redirect(AppEnv.GetSetting("vsporturl") + des.Des3Encrypt("4|" + msisdn + "||", AppEnv.GetSetting("msisdnkey")) + "&t=" + t);
            //}
            //else
            //{
            //    Response.Redirect(AppEnv.GetSetting("vsporturl") + des.Des3Encrypt("0|||", AppEnv.GetSetting("msisdnkey")) + "&t=" + t);
            //}
        }
    }
}