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
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (AppEnv.GetSetting("TestFlag") == "1")
                {
                    Session["telco"] = Constant.T_Vietnamobile;
                    Session["msisdn"] = "0987765522";
                }

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
                //int id = 20;
                if (id > 0)
                {
                    DataTable tblServices = WapController.S2_1119GetServiceInfo(id);
                    if (tblServices == null || tblServices.Rows.Count < 1)
                    {
                        return;
                    }
                    if (tblServices.Rows[0]["status"].ToString() != "1")
                    {
                        return;
                    }


                    string dangkyThanhCong = string.Empty;
                    string doubleDangKy = string.Empty;
                    string tenDichVu = string.Empty;

                    string regisSystax = tblServices.Rows[0]["SubscriptionKeyword"].ToString().Split('|')[0];

                    if (Session["msisdn"] != null && Session["msisdn"].ToString() != "")
                    {

                        ltrTieuDe.Text = "Đăng ký " + tblServices.Rows[0]["ProductName"].ToString();
                        tenDichVu = tblServices.Rows[0]["ProductName"].ToString();
                        dangkyThanhCong = tblServices.Rows[0]["SubscriptionMessage"].ToString();
                        doubleDangKy = tblServices.Rows[0]["DuplicationSubsMessage"].ToString();

                        string result = AppEnv.RegisterService1119(AppEnv.GetSetting("S2ShortCode1119"), "0", Session["msisdn"].ToString(), "DK", regisSystax);//Andy Service S2_94x   

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
}