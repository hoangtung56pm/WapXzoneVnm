using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Sub
{
    public partial class DK : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Telco = "Other";
            int IsWifi = 1;
            string user_id = "khach";
            if (!Page.IsPostBack)
            {
                if (AppEnv.GetSetting("TestFlag") == "1")
                {
                    Session["telco"] = Constant.T_Vietnamobile;
                    //Session["msisdn"] = "0987765522";
                }
                //Session["msisdn"] = "841866728649";
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                    }
                }

                pnlNoiDung.Visible = true;

                int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                if (id > 0)
                {
                    DataTable tblServices = WapController.S2_94xGetServiceInfo(id);
                    if (tblServices == null || tblServices.Rows.Count < 1)
                    {
                        return;
                    }
                    //if (tblServices.Rows[0]["status"].ToString() != "3")
                    //{
                    //    return;
                    //}


                    string dangkyThanhCong = string.Empty;
                    string doubleDangKy = string.Empty;
                    string tenDichVu = string.Empty;

                    string regisSystax = tblServices.Rows[0]["Register_Syntax"].ToString().Split('|')[0];

                    if (Session["msisdn"] != null && Session["msisdn"].ToString() != "")
                    {
                        Telco = "VNM";
                        IsWifi = 0;
                        user_id = Session["msisdn"].ToString();

                        ltrTieuDe.Text = "Đăng ký " + tblServices.Rows[0]["Product_Name"].ToString();
                        tenDichVu = tblServices.Rows[0]["Product_Name"].ToString();
                        lblTen1.Text = tenDichVu;
                        dangkyThanhCong = tblServices.Rows[0]["Right_Syntax_MT"].ToString();
                        doubleDangKy = tblServices.Rows[0]["Double_Register_MT"].ToString();
                        if (AppEnv.GetSetting("DK1chamVNMtest").ToString() == "1")
                        {
                            pnlConfirm.Visible = false;
                            string result = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", regisSystax);//Andy Service S2_94x   

                            string[] arrResult = result.Split('|');

                            if (arrResult[0] == "1")//DK THANH CONG
                            {
                                ltrNoiDung.Text = dangkyThanhCong;
                            }
                            else if (arrResult[0] == "0")//DOUBE DK
                            {
                                ltrNoiDung.Text = doubleDangKy;
                            }
                            else if (arrResult[0] == "-1")//DK THAT BAI - SAI CU PHAP
                            {
                                ltrNoiDung.Text = "Đăng ký không thành công. Vui lòng thử lại <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                            }

                        }
                        else
                        {
                            pnlConfirm.Visible = true;
                        }

                    }
                    else
                    {
                        Response.Redirect("http://wap.vietnamobile.com.vn/tin-tuc.aspx");
                        //ltrNoiDung.Text = "Hệ thống không xác định được số điện thoại của bạn <br /> Vui lòng truy cập bằng 3G/GPRS <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        //ltrNoiDung.Text = "<font size=3> Để đăng ký dịch vụ " + tblServices.Rows[0]["Service_Name"].ToString() + " của Vietnamobile, Quý Khách vui lòng soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b></font>";
                        //if (id == 800 || id == 812||id==813)
                        //{
                        //    Response.Redirect("/Video/Default.aspx?lang=1&display=home&w=320");
                        //}
                        //else
                        //{
                        //    ltrNoiDung.Text = "<font size=3> Để đăng ký dịch vụ " + tblServices.Rows[0]["Service_Name"].ToString() + " của Vietnamobile, Quý Khách vui lòng soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b></font>";
                        //}

                    }
                    #region Device_Log
                    try
                    {
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
                        //WapController.VmgAds94x_Log_Insert(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, Telco, IsWifi, 1, Request.Url.AbsoluteUri, id.ToString(), HttpContext.Current.Request.UserHostAddress, "0", "MSISDN", Session["msisdn"].ToString(), "Request", 1, id);
                        WapController.VmgAds94x_Log_Insert(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height, Telco, IsWifi, 1, Request.Url.AbsoluteUri, id.ToString(), HttpContext.Current.Request.UserHostAddress, "0", "MSISDN", user_id, "Request", 1, id);
                    }
                    catch (Exception ex)
                    {

                    }
                    #endregion
                }
                else

                {
                    Response.Redirect("http://wap.vietnamobile.com.vn/Wap/Default.aspx?lang=1&w=320"); 
                }


            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Visible = true;
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id > 0)
            {
                DataTable tblServices = WapController.S2_94xGetServiceInfo(id);
                if (tblServices == null || tblServices.Rows.Count < 1)
                {
                    return;
                }
                if (tblServices.Rows[0]["status"].ToString() != "3")
                {
                    return;
                }


                string dangkyThanhCong = string.Empty;
                string doubleDangKy = string.Empty;
                string tenDichVu = string.Empty;

                string regisSystax = tblServices.Rows[0]["Register_Syntax"].ToString().Split('|')[0];

                if (Session["msisdn"] != null && Session["msisdn"].ToString() != "")
                {

                    ltrTieuDe.Text = "Đăng ký " + tblServices.Rows[0]["Product_Name"].ToString();
                    tenDichVu = tblServices.Rows[0]["Product_Name"].ToString();
                    dangkyThanhCong = tblServices.Rows[0]["Right_Syntax_MT"].ToString();
                    doubleDangKy = tblServices.Rows[0]["Double_Register_MT"].ToString();
                    string result = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", regisSystax);//Andy Service S2_94x   

                    string[] arrResult = result.Split('|');

                    if (arrResult[0] == "1")//DK THANH CONG
                    {
                        ltrNoiDung.Text = dangkyThanhCong;
                    }
                    else if (arrResult[0] == "0")//DOUBE DK
                    {
                        ltrNoiDung.Text = doubleDangKy;
                    }
                    else if (arrResult[0] == "-1")//DK THAT BAI - SAI CU PHAP
                    {
                        ltrNoiDung.Text = "Đăng ký không thành công. Vui lòng thử lại <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }

                }
                else
                {
                    ltrNoiDung.Text = "Hệ thống không xác định được số điện thoại của bạn <br /> Vui lòng truy cập bằng 3G/GPRS <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                }
            }
        }
    }
}