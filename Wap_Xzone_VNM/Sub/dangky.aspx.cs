using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Sub
{
    public partial class dangky : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                return;
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
                string madichvu = Request.QueryString["t"];
                string[] codes = madichvu.Split('-');
                string commandCode = codes[0];
                madichvu = madichvu.Replace("-", " ").ToUpper();
                string key = Request.QueryString["k"];

                if (Session["msisdn"] != null && Session["msisdn"].ToString() != "")
                {
                    string partnerName = AppEnv.GetPartnerName(key);
                    if (!string.IsNullOrEmpty(partnerName))
                    {
                        if(AppEnv.GetPartnerSub(partnerName,madichvu) == "1")
                        {
                            ltrTieuDe.Text = "Dịch vụ Sub " + madichvu;

                            string result = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), commandCode.ToUpper(), madichvu);//Andy Service S2_94x   
                            string[] arrResult = result.Split('|');
                            if (arrResult[0] == "1")//DK THANH CONG
                            {
                                ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ <b>" + madichvu + "</b><br /> Để hủy dịch vụ soạn : <b> HUY " + madichvu + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                            }
                            else if (arrResult[0] == "0")//DOUBE DK
                            {
                                ltrNoiDung.Text = "Bạn đã đăng ký dịch vụ <b>" + madichvu + "</b> trước đây <br /> Để hủy dịch vụ soạn : <b> HUY " + madichvu + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                            }
                            else if (arrResult[0] == "-1")//DK THAT BAI - SAI CU PHAP
                            {
                                ltrNoiDung.Text = "Đăng ký không thành công. Vui lòng thử lại <br /> Hoặc soạn tin <b>" + madichvu + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                            }
                        }
                        else
                        {
                            ltrNoiDung.Text = "Mã dịch gói dịch vụ chưa đúng. Vui lòng thử lại";
                        }
                    }
                    else
                    {
                        ltrNoiDung.Text = "Mã đối tác không đúng. Vui lòng thử lại";
                    }
                }
                else
                {
                    ltrNoiDung.Text = "Hệ thống không xác định được số điện thoại của bạn <br /> Vui lòng truy cập bằng 3G/GPRS <br /> Hoặc soạn tin <b>" + madichvu + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                }
            }

        }
    }
}