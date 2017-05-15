using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising.Lib;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap
{
    public partial class RegisterAll : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msisdn;
            string Telco = "Other";
            int IsWifi = 1;
            if (!Page.IsPostBack)
            {
              
                int type = ConvertUtility.ToInt32(Request.QueryString["type"]);
                int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                string transactionID = Request.QueryString["transactionID"];
                int is3g = 0;

                msisdn = MobileUtils.GetMSISDN(out is3g);
                #region Device_Log
                if (Application["wurflFileProcessor"] == null)
                {
                    string s_path = HttpContext.Current.Request.MapPath("..\\WURFL_Data\\wurfl.xml");
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
                //BasePage.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height);
                #endregion
                #region Redirect to VNM
                if (string.IsNullOrEmpty(transactionID))
                {
                    //int is3g = 0;
                    msisdn = MobileUtils.GetMSISDN(out is3g);
                    //msisdn = msisdn != "" ? msisdn : "841864950687";
                    string uniqueID = WapController.UnixTimeStampUTC().ToString();
                    #region Log nhận diện SDT

                    if (msisdn != "")
                    {
                        Telco = "VNM";
                        IsWifi = 0;
                    }
                    //WapController.VmgAds94x_Log_Insert(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, Telco, IsWifi, 1, Request.Url.AbsoluteUri, id.ToString(), HttpContext.Current.Request.UserHostAddress, type.ToString(), "MSISDN", msisdn, "Request", 1, id);
                    //WapController.VmgAds94x_Log_Insert(HttpContext.Current.Request.UserAgent, uniqueID, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, Telco, IsWifi, 1, "http://wap.vietnamobile.com.vn/wap/registerall.aspx?type=3&id=13", id.ToString(), "113.185.25.115", type.ToString(), "MSISDN", msisdn, "Request", 1, id);
                    #endregion
                     
                    //dang ky 949
                    if (!string.IsNullOrEmpty(msisdn))
                    {
                        //string uniqueID = WapController.UnixTimeStampUTC().ToString();
                        if (type == 1)
                        {
                            //visport
                            WapController.WapRegisterConfirm_Insert(uniqueID, msisdn, 1, -1, "Dịch vụ Visport", "Dịch vụ Visport");
                            string url = RedirectToTelco(msisdn, "Dịch vụ Visport", "979", "5000", "Dịch vụ Visport", "01", "1", "http://visport.vn", uniqueID);
                            Response.Redirect(url);

                        }
                        else if (type == 2)
                        {
                            //game portal
                            WapController.WapRegisterConfirm_Insert(uniqueID, msisdn, 2, -2, "Dịch vụ Gameportal", "Dịch vụ Gameportal");
                            string url = RedirectToTelco(msisdn, "Dịch vụ Gameportal", "2288", "10000", "Dịch vụ Gameportal", "07", "1", "http://vmgame.vn/", uniqueID);
                            Response.Redirect(url);

                        }
                        else
                        {
                            
                            if (id > 0)
                            {
                                DataTable tblServices = WapController.S2_94xGetServiceInfo(id);
                                if (tblServices == null || tblServices.Rows.Count < 1)
                                {
                                    return;
                                }
                                string ProductName = tblServices.Rows[0]["Product_Name"].ToString();
                                string Price = tblServices.Rows[0]["Charging_Price"].ToString();
                                int PeriodLength = ConvertUtility.ToInt32(tblServices.Rows[0]["PeriodLength"].ToString());
                                string NoChargeLength = tblServices.Rows[0]["NoChargeLength"].ToString();
                                WapController.WapRegisterConfirm_Insert(uniqueID, msisdn, 3, id, ProductName, ProductName);
                                string url = RedirectToTelco(msisdn, ProductName, "949", Price, ProductName, PeriodLength == 7 ? "07" : "01", NoChargeLength, "http://wap.vietnamobile.com.vn", uniqueID);
                               
                                Response.Redirect(url);
                            }
                        }
                    }
                }
                else
                {
                    //Lấy thông tin khác hàng theo transactionID và đăng ký dịch vụ tương ứng                
                    DataTable dt = WapController.WapRegisterConfirm_GetInfo(transactionID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int Service_type = ConvertUtility.ToInt32(dt.Rows[0]["Type"].ToString());
                        if (Service_type == 1)
                        {
                            Response.Redirect("http://visport.vn/Wap/DangKy.aspx");
                        }
                        else if (Service_type == 2)
                        {
                            Response.Redirect("http://vmgame.vn/home/landing?pk=DK");
                        }
                        else
                        {
                            if (msisdn != "")
                            {
                                msisdn = "VNM";
                                IsWifi = 0;
                            }
                            //WapController.VmgAds94x_Log_Insert(HttpContext.Current.Request.UserAgent, transactionID.ToString(), _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, Telco, IsWifi, 1, Request.Url.AbsoluteUri, id.ToString(), HttpContext.Current.Request.UserHostAddress, type.ToString(), "REGISTER", msisdn, "Request", 1, id);
                            int Service_ID = ConvertUtility.ToInt32(dt.Rows[0]["Service_ID"].ToString());
                            Response.Redirect("http://wap.vietnamobile.com.vn/sub/DK.aspx?id=" + Service_ID);
                        }

                    }

                }
                #endregion
                                
            }
        }
        public static string RedirectToTelco(string msisdn, string serviceName, string shortcode, string price, string desc, string validity, string freetrial, string baseURL,string transactionID)
        {
            string url = "http://vas.vietnamobile.com.vn?cpname=vmg&msisdn=" + msisdn + "&serviceName=" + serviceName + "&shortcode=" + shortcode + "&price=" + price + "&desc=" + desc + "&validity=" + validity + "&freetrial=" + freetrial + "&baseURL=" + baseURL + "&callbackURL=http://wap.vietnamobile.com.vn/Wap/RegisterAll.aspx?transactionID="+ transactionID + "";
            return url;
        }
        

        protected void btnReg_Click(object sender, EventArgs e)
        {

        }
    }
}