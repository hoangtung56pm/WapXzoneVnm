using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising.Lib;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.SQLHelper;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Wap
{
    public partial class Login : System.Web.UI.Page
    {
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User_AgentInfo info = Get_User_Agent_Info();
            width = info.resolution_width;
            if (ConvertUtility.ToInt32(width) == 0 || ConvertUtility.ToInt32(width) >= 480)
            {
                width = ConvertUtility.ToString((int)Constant.DefaultScreen.Standard);
            }
            string urlRes = AppEnv.GetSetting("WapDefault") + UrlProcess.GetWapHomeUrl("1", width).Replace("~", "");
            string msisdn = txtSDT.Text.Trim();
            string model = AppEnv.GetUserAgent();
            if (!string.IsNullOrEmpty(msisdn))
            {
                if (validateMobileNumber(msisdn))
                {
                    if (msisdn.StartsWith("0"))
                    {
                        msisdn = msisdn.Replace("0", "84");
                    }
                    if (S2_TTKD_GetUserInfo(msisdn))
                    {

                        Session["msisdn"] = txtSDT.Text.Trim();
                        //vào trang default
                        if (model == "high")
                        {
                            urlRes = AppEnv.GetSetting("WapDefault") + "/login.aspx";
                            Response.Redirect(urlRes);
                        }
                        else
                        {
                            Response.Redirect(urlRes);
                        }


                    }
                    else
                    {
                        //thông báo chưa đăng ký dịch vụ
                        lblAlert.Text = "Thuê bao " + msisdn + " chưa đăng ký dịch vụ, vui lòng xem lại !";
                        litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
                    }
                }
                else
                {
                    lblAlert.Text = "Thuê bao " + msisdn + " không tồn tại, vui lòng xem lại !";
                    litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
                }
            }
            else
            {
                lblsdt.Text = "Bạn chưa nhập số điện thoại, vui lòng xem lại !";
            }
        }
        #region Method
        public static bool validateMobileNumber(String mobile)
        {
            Regex r = new Regex("(\\d{10})|(\\d{11})");
            if (r.IsMatch(mobile))
            {
                return true;
            }
            return false;
        }
        public static bool S2_TTKD_GetUserInfo(string Msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.GetConnectionString("ConnectionString_TTND_Services"), CommandType.Text,
                        String.Format("Select count(1) as count from S2_TTND_Registered_Users where User_id = '" + Msisdn + "' and status = 1"));
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ConvertUtility.ToInt32(ds.Tables[0].Rows[0]["count"]) > 0)
                    {
                        return true;
                    }
                }

            }

            return false;
        }
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
        #endregion
    }
}