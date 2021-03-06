using System;
using System.Data;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using log4net;

namespace WapXzone_VNM
{
    public partial class _Default : System.Web.UI.MobileControls.MobilePage
    {
        private string width;
        ILog logger = log4net.LogManager.GetLogger("BasePage");
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            User_AgentInfo info = Get_User_Agent_Info();
            width = info.resolution_width;
            if (ConvertUtility.ToInt32(width) == 0 || ConvertUtility.ToInt32(width) >= 480)
            {
                width = ConvertUtility.ToString((int)Constant.DefaultScreen.Standard);
            }
            //query param
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);

            //#region Hai them vao ngay 16/02/2012
            //if (String.IsNullOrEmpty(msisdn) && Session["msisdn"] == null)
            //    msisdn = this.GetVietnamobileMsisdn();
            //#endregion
            Session["is3g"] = is3g;

            #region MSISDN

            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {
                Session["telco"] = Constant.T_Vietnamobile;
                Session["msisdn"] = msisdn;

                WapController.WapUserLog(msisdn, 0, string.Empty, 1);
             
            }
            else
            {
                Session["msisdn"] = null;
                Session["telco"] = Constant.T_Undefined;
            }

            #endregion

            

                //#region Sport Game Hero
                
                //if(AppEnv.isMobileBrowser())
                //{
                //    DataTable dtUrl = WapController.VnmGetUrl();

                //    if (dtUrl != null && dtUrl.Rows[0]["IsLog"].ToString() == "1")
                //    {
                //        if (Session["msisdn"] != null)
                //        {
                //            DataTable dt = WapController.VnmCheckBlackList(Session["msisdn"].ToString());
                //            if (dt.Rows.Count == 0)
                //            {
                //                string resUrl = dtUrl.Rows[0]["ResUrl"].ToString();
                //                Response.Redirect(resUrl);
                //            }
                //        }
                //    }
                //}

                //#endregion
                
            string urlRes = AppEnv.GetSetting("WapDefault") + UrlProcess.GetWapHomeUrl("1", width).Replace("~", "");
            if(AppEnv.isMobileBrowser())
            {
                string model = AppEnv.GetUserAgent();
                if(model == "high")
                {
                    urlRes = AppEnv.GetSetting("WapDefault") + "/trang-chu.aspx";
                    //urlRes = AppEnv.GetSetting("WapDefault") + "/login.aspx";
                }
                else
                {
                    urlRes = AppEnv.GetSetting("WapDefault") + "/Wap/Default.aspx?lang=1&w=320";
                 }
            }
            else
            {
                urlRes = AppEnv.GetSetting("WapDefault") + "/Wap/Default.aspx?lang=1&w=320";  
            }
            logger.Debug(urlRes);
            //urlRes = AppEnv.GetSetting("WapDefault") + "/login.aspx";
            //urlRes = AppEnv.GetSetting("WapDefault") + "/trang-chu.aspx";
            Response.Redirect(urlRes);
            //Response.Redirect("NotFound.aspx");

            //if (ConvertUtility.ToInt32(AppEnv.GetSetting("NewUrl")) == 1)
            //{
            //    Response.Redirect(AppEnv.GetSetting("WapDefault") + UrlProcess.GetWapHomeUrlNew("1", width).Replace("~", ""));
            //}
            //else
            //{
            //    Response.Redirect(AppEnv.GetSetting("WapDefault") + UrlProcess.GetWapHomeUrl("1", width).Replace("~", ""));
            //    //Response.Redirect("showpopup.aspx");
            //}

        }

        //#region Hai them vao ngay 16/02/2011        
        ///// <summary>
        ///// Lay so dien thoai cua nguoi dung di dong
        ///// </summary>
        ///// <returns>Tra ve String.Empty neu ko tim thay</returns>
        //private string GetVietnamobileMsisdn()
        //{
        //    string ipAddress = this.GetClientIPAddress();
        //    string msisdn = "unknown";
        //    if (System.Text.RegularExpressions.Regex.IsMatch(ipAddress, @"^10\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}$"))
        //    {
        //       try
        //        {
        //            WapXzone_VNM.MsisdnService.MsisdnService msidsnService = new WapXzone_VNM.MsisdnService.MsisdnService();
        //            msisdn = msidsnService.GetVietnamobileMsisdn(ipAddress);

        //            logger.Info("--------------------------------------------------");
        //            logger.Info(String.Format("REMOTE_ADDR: {0}", Request.ServerVariables["REMOTE_ADDR"]));
        //            logger.Info(String.Format("REMOTE_HOST: {0}", Request.ServerVariables["REMOTE_HOST"]));
        //            logger.Info(String.Format("HTTP_HOST: {0}", Request.ServerVariables["HTTP_HOST"]));
        //            logger.Info(String.Format("HTTP_X_FORWARDED_HOST: {0}", Request.ServerVariables["HTTP_X_FORWARDED_HOST"]));
        //            logger.Info(String.Format("HTTP_X_FORWARDED_FOR: {0}", Request.ServerVariables["HTTP_X_FORWARDED_FOR"]));
        //            logger.Info("MSISDN: " + msisdn);
        //            logger.Info("IP: " + ipAddress);
        //            logger.Info(String.Format("Current Url: {0}", Request.RawUrl));
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.Error(ex.Message);
        //            logger.Error(ex.StackTrace);
        //        }
        //    }
            
        //    return msisdn == "unknown" ? String.Empty : msisdn;
        //}

        ///// <summary>
        ///// Lay dia chi IP cua client
        ///// </summary>
        ///// <returns>Tra ve String.Empty neu ko tim thay</returns>
        //private string GetClientIPAddress()
        //{
        //    string ipAddress = Request.ServerVariables["REMOTE_ADDR"] ?? Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    return String.IsNullOrEmpty(ipAddress) ? String.Empty : ipAddress;
        //}
        //#endregion

        protected User_AgentInfo Get_User_Agent_Info()
        {
            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
            o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            User_AgentInfo _info = new User_AgentInfo();
            _info.device_os = o_capabilityGetter.getCapability("device_os");
            _info.mobile_browser = o_capabilityGetter.getCapability("mobile_browser");
            _info.resolution_width = o_capabilityGetter.getCapability("resolution_width");
            _info.resolution_height = o_capabilityGetter.getCapability("resolution_height");
            _info.model_name = o_capabilityGetter.getCapability("model_name");
            _info.brand_name = o_capabilityGetter.getCapability("brand_name");
            BasePage.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height);
            return _info;
        }
    }
}