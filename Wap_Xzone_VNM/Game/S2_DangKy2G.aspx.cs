using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game
{
    public partial class S2_DangKy2G : BasePage
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
                    //string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK GAME");//ANDY Service S2_94x
                    //string[] res = value.Split('|');
                    //if (res.Length > 0)
                    //{
                    //    ltrHuongdan.Text = "GAME HOT";
                    //    if (res[0] == "1")//DK THANH CONG
                    //    {
                    //        ltrSMS.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //                   : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 va thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //    }
                    //    else
                    //    {
                    //        if (res[1].Trim() == "DoubleRegister")
                    //        {
                    //            ltrSMS.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY GAME </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                    //                : "Ban da la thue bao cua dich vu GAME HOT tuan. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY GAME </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    //        }
                    //        else
                    //        {
                    //            ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                    //        }
                    //    }
                    //}

                    ltrHuongdan.Text = "Giới Thiệu";
                    ltrSMS.Text = "SOẠN TIN :  <b> DK GAME </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                }
                else
                {
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Giới Thiệu";
                        ltrSMS.Text = "Cung cấp cho quý khách những game mới và hấp dẫn nhất. Hàng tuần, hệ thống sẽ gửi cho bạn 2 game được nhiều người tải nhất vào thứ 2 và thứ 4. (10000đ/tuần) <br/> Miễn phí trải nghiệm 2 Game HOT đầu tiên <br/>Vui lòng truy cập bằng <b> 3G/GPRS </b> hoặc : <br/> SOẠN TIN :  <b> DK GAME </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Gioi Thieu";
                        ltrSMS.Text = "Cung cap cho quy khach nhung game moi va hap dan nhat. Hang tuan, he thong se gui cho ban 2 game duoc nhieu nguoi tai nhat vao thu 2 va thu 4. (10000d/tuan) <br/> Mien phi trai nghiem 2 Game HOT dau tien <br/>Vui long truy cap bang <b> 3G/GPRS </b> hoac : <br/> SOAN TIN : <b> DK GAME </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}