using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using System.Net;
using log4net;

namespace WapXzone_VNM
{
    public partial class m : System.Web.UI.MobileControls.MobilePage
    {     
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            //MsidsnService.MsidsnService ws = new MsidsnService.MsidsnService();
            //string msisdn = string.Empty; 
            //string ipm = HttpContext.Current.Request.UserHostAddress;
            //msisdn = ws.GetVietnamobileMsidsn(ipm);
            //Response.Write("Thuê bao <b>" + msisdn + "</b>, UserHostAddress: " + ipm + "<br />");            
            //if (msisdn == "unknown")
            //{
            //    ipm = HttpContext.Current.Request.Headers.Get("X-Forwarded-For");
            //    msisdn = ws.GetVietnamobileMsidsn(ipm);
            //    Response.Write("Thuê bao <b>" + msisdn + "</b>, X-Forwarded-For: " + ipm + "<br />");
            //}
            //if (msisdn == "unknown")
            //{
            //    ipm = HttpContext.Current.Request.Headers.Get("X-ipaddress");
            //    msisdn = ws.GetVietnamobileMsidsn(ipm);
            //    Response.Write("Thuê bao <b>" + msisdn + "</b>, X-ipaddress: " + ipm + "<br />");
            //}
            //if (msisdn == "unknown")
            //{
            //    ipm = HttpContext.Current.Request.Headers.Get("User-IP");
            //    msisdn = ws.GetVietnamobileMsidsn(ipm);
            //    Response.Write("Thuê bao <b>" + msisdn + "</b>, User-IP: " + ipm + "<br />");
            //}
            Response.Write("<br />xwapmsisdn:" + HttpContext.Current.Request.Headers.Get("X-Wap-MSISDN"));
            Response.Write("<br />Headers:" + HttpContext.Current.Request.Headers.ToString());
            Response.Write("<br />Headers:" + HttpContext.Current.Request.ServerVariables.ToString());
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("UserHostAddress: " + HttpContext.Current.Request.UserHostAddress + "<br />");
            logger.Debug("<p>" + HttpContext.Current.Request.Headers.ToString() + "</p>");
        }
    }
}