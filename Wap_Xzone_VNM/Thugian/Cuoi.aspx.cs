using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian
{
    public partial class Cuoi : BasePage
    {
        private int width;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                pnlSMS.Visible = true;

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK CUOI");//ANDY Service S2_94x
                    string[] res = value.Split('|');
                    if (res.Length > 0)
                    {
                        ltrHuongdan.Text = lang == "1"
                                ? "Truyện Cười"
                                : "Truyen Cuoi";

                        if (res[0] == "1")//DK THANH CONG
                        {
                            ltrSMS.Text = lang == "1"
                                       ? "Bạn đã đăng ký thành công. Miễn phí trong 7 ngày đầu đăng kí. Truyện cười sẽ được gửi về hàng ngày <br/> Để hủy dịch vụ soạn: <b> HUY CUOI </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                       : "Ban da dang ky thanh cong. Mien phi trong 7 ngay dau dang ki. Truyen cuoi se duoc gui ve hang ngay <br/> De huy dich vu soan: <b> HUY CUOI </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            if (res[1].Trim() == "DoubleRegister")
                            {
                                ltrSMS.Text = lang == "1"
                                    ? "Bạn đã là thuê bao của dịch vụ Truyện cười. Xin cảm ơn <br/> Để hủy dịch vụ soạn tin : <b> HUY CUOI </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                                    : "Ban da la thue bao cua dich vu Truyen cuoi. Xin cam on <br/> De huy dich vu soan tin : <b> HUY CUOI </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                            }
                            else
                            {
                                ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                            }
                        }
                    }
                }
                else
                {
                    ltrHuongdan.Text = lang == "1"
                                           ? "Giới Thiệu"
                                           : "Gioi Thieu";

                    ltrSMS.Text = lang == "1"
                                      ? "Cung cấp cho bạn những mẩu truyện cười nóng hổi nhất. Đăng ký một lần nhận tin mãi mãi <br/> Để đăng ký soạn tin: <b> DK CUOI </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                      : "Cung cap cho ban nhung mau truyen cuoi nong hoi nhat. Dang ky mot lan nhan tin mai mai <br/> De dang ky soan tin: <b> DK CUOI </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";

                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}