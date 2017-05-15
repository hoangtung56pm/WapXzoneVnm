using System;
using log4net;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Wap
{
    public partial class ShowMsisdn : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ipAddress = "unknown";
            string msisdn = "unknown";

            try
            {
                ipAddress = Convert.ToString(Request.ServerVariables["REMOTE_ADDR"]);
            }
            catch
            {

            }

            try
            {
                WapXzone_VNM.MsisdnService.MsisdnService msidsnService = new WapXzone_VNM.MsisdnService.MsisdnService();
                msisdn = msidsnService.GetVietnamobileMsisdn(ipAddress);
            }
            catch
            {

            }


            #region Log
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug(String.Format("REMOTE_ADDR: {0}", Request.ServerVariables["REMOTE_ADDR"]));
            logger.Debug(String.Format("REMOTE_HOST: {0}", Request.ServerVariables["REMOTE_HOST"]));
            logger.Debug(String.Format("HTTP_HOST: {0}", Request.ServerVariables["HTTP_HOST"]));
            logger.Debug(String.Format("HTTP_X_FORWARDED_HOST: {0}", Request.ServerVariables["HTTP_X_FORWARDED_HOST"]));
            logger.Debug("MSISDN: " + msisdn);
            logger.Debug("IP: " + ipAddress);
            logger.Debug(String.Format("Current Url: {0}", Request.RawUrl));
            #endregion

            Response.Write(msisdn);
            Page.Title = msisdn;
        }
    }
}
