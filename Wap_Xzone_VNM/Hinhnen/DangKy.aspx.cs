using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen
{
    public partial class DangKy : BasePage
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
                    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK HNEN");//ANDY Service S2_94x
                    string[] res = value.Split('|');
                    if (res.Length > 0)
                    {
                        ltrHuongdan.Text = lang == "1" ? "Hình Nền" : "Hinh Nen";
                        if (res[0] == "1")//DK THANH CONG
                        {
                            ltrSMS.Text = lang == "1" 
                                ? "Bạn đã đăng ký thành công dịch vụ Hình Nền cua VNM. <br/> MIỄN PHÍ trong 7 ngày đầu đăng ký. Hình Nền HOT sẽ được gửi về máy hàng ngày. <br/> <b> HUY HNEN </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                : "Ban da dang ky thanh cong dich vu Hinh Nen cua VNM. <br/> MIEN PHI trong 7 ngay dau dang ky. Hinh Nen HOT se duoc gui ve may hang ngay. <br/> <b> HUY HNEN </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            if (res[1].Trim() == "DoubleRegister")
                            {
                                ltrSMS.Text = lang == "1" 
                                    ? "Bạn đã là thuê bao của dịch vụ Hình Nền HOT. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY HNEN </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                                    : "Ban da la thue bao cua dich vu Hinh Nen HOT. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY HNEN </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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
                    ltrHuongdan.Text = lang == "1" ? "Giới Thiệu" : "Gioi Thieu";

                    ltrSMS.Text = lang == "1"
                            ? "Cung cấp cho bạn những Hình nền hot và nóng hổi nhất. Đăng ký một lần nhận tin mãi mãi <br/> Để đăng ký soạn tin : <b> DK HNEN </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                            : "Cung cap cho ban nhung Hinh nen hot va nong hoi nhat. Dang ky mot lan nhan tin mai mai <br/> De dang ky soan tin : <b> DK HNEN </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}