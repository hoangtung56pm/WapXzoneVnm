using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video
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
                    //string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK VIDEO");//ANDY Service S2_94x
                    //string[] res = value.Split('|');
                    //if (res.Length > 0)
                    //{
                    //    ltrHuongdan.Text = "VIDEO HOT";
                    //    if (res[0] == "1")//DK THANH CONG
                    //    {
                    //        ltrSMS.Text = lang == "1" ? "Bạn đã đăng ký thành công. Video Clip sẽ được gửi đến điện thoại của bạn vào 10h30 hàng ngày <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY VIDEO </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //               : "Ban da dang ky thanh cong. Video Clip se duoc gui den dien thoai cua ban vao 10h30 hang ngay. <br/> De huy dich vu vui long soan: <b> HUY VIDEO </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //    }
                    //    else
                    //    {
                    //        if (res[1].Trim() == "DoubleRegister")
                    //        {
                    //            ltrSMS.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Video Clip tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY VIDEO </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                    //                : "Ban da la thue bao cua dich vu Video Clip tuan. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY VIDEO </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    //        }
                    //        else
                    //        {
                    //            ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                    //        }
                    //    }
                    //}

                    ltrHuongdan.Text = "Giới Thiệu";
                    ltrSMS.Text = "SOẠN TIN :  <b> DK VIDEO </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                   
                }
                else
                {
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Giới Thiệu";
                        ltrSMS.Text = "Cung cấp cho bạn những clip hot và nóng hổi nhất. Những thông tin mới, đặc sắc sẽ được truyền tải đến cho bạn hàng ngày. Đăng ký một lần nhận tin mãi mãi <br/> Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký <br/>Vui lòng truy cập bằng <b> 3G/GPRS </b> hoặc : <br/> SOẠN TIN :  <b> DK VIDEO </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Gioi Thieu";
                        ltrSMS.Text = "Cung cap cho ban nhung clip hot va nong hoi nhat. Nhung thong tin moi, dac sac se duoc truyen tai den cho ban hang ngay. Dang ky mot lan nhan tin mai mai <br/> Dac biet mien phi su dung trong 7 ngay dau tien cho khach hang lan dau dang ky <br/>Vui long truy cap bang <b> 3G/GPRS </b> hoac : <br/> SOAN TIN : <b> DK VIDEO </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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