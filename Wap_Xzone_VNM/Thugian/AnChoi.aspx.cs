using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian
{
    public partial class AnChoi : BasePage
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
                    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK AC");//ANDY Service S2_94x
                    string[] res = value.Split('|');
                    if (res.Length > 0)
                    {
                        ltrHuongdan.Text = lang == "1"
                                ? "Ăn Chơi"
                                : "An Choi";

                        if (res[0] == "1")//DK THANH CONG
                        {
                            ltrSMS.Text = lang == "1"
                                       ? "Bạn đã đăng ký thành công. Hàng ngày hệ thống sẽ gửi cho QK thông tin các địa điểm ăn chơi vào lúc 15h <br/> Để hủy dịch vụ soạn: <b> HUY AC </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                       : "Ban da dang ky thanh cong. Hang ngay he thong se gui cho QK thong tin cac dia diem an choi vao luc 15h <br/> De huy dich vu soan: <b> HUY AC </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            if (res[1].Trim() == "DoubleRegister")
                            {
                                ltrSMS.Text = lang == "1"
                                    ? "Bạn đã là thuê bao của dịch vụ Đọc truyện. Xin cảm ơn <br/> Để hủy dịch vụ soạn tin : <b> HUY AC </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                                    : "Ban da la thue bao cua dich vu Đọc truyện. Xin cam on <br/> De huy dich vu soan tin : <b> HUY AC </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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
                                           ? "Ăn Chơi"
                                           : "An Choi";

                    ltrSMS.Text = lang == "1"
                                     ? "Cung cấp cho bạn những địa điểm ăn chơi mới nhất. Đăng ký một lần nhận tin mãi mãi <br/> Để đăng ký soạn tin: <b> DK AC </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                     : "Cung cap cho ban nhung dia diem an choi moi nhat. Dang ky mot lan nhan tin mai mai <br/> De dang ky soan tin: <b> DK AC </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}