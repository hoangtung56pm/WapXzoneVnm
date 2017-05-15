using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music
{
    public partial class DangKy : BasePage
    {
        private int width;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            if (lang == "1")
            {
                ltrHuongdan.Text = "Thông Báo";
                ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK NC gửi " + AppEnv.GetSetting("S2ShortCode") + " (miễn phí đăng ký)";
            }
            else
            {
                ltrHuongdan.Text = "Thong Bao";
                ltrSMS.Text = "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK NC gui " + AppEnv.GetSetting("S2ShortCode") + " (mien phi dang ky)";
            }

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                pnlSMS.Visible = true;

                if (Session["msisdn"] != null)
                {
                    //string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK NC");//ANDY Service S2_94x
                    //string[] res = value.Split('|');
                    //if (res.Length > 0)
                    //{
                    //    ltrHuongdan.Text = lang == "1" ? "Nhạc Chuông HOT" : "Nhac Chuong HOT";
                    //    if (res[0] == "1")//DK THANH CONG
                    //    {
                    //        ltrSMS.Text = lang == "1"
                    //            ? "Bạn đã đăng ký thành công. Nhạc Chuông sẽ được gửi đến điện thoại của bạn vào thứ 2 và thứ 5 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY NC </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //            : "Ban da dang ky thanh cong. Nhac Chuong se duoc gui den dien thoai cua ban vao thu 2 va thu 5 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY NC </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //    }
                    //    else
                    //    {
                    //        if (res[1].Trim() == "DoubleRegister")
                    //        {
                    //            ltrSMS.Text = lang == "1"
                    //                ? "Bạn đã là thuê bao của dịch vụ Nhạc Chuông hàng ngày. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY NC </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                    //                : "Ban da la thue bao cua dich vu Nhac Chuong hang ngay. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY NC </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    //        }
                    //        else
                    //        {
                    //            ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                    //        }
                    //    }
                    //}

                    ltrHuongdan.Text = "Thông Báo";
                    ltrSMS.Text = "Soạn tin: DK NC gửi " + AppEnv.GetSetting("S2ShortCode") + " (miễn phí đăng ký)";
                }
                else
                {
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Thông Báo";
                        ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK NC gửi " + AppEnv.GetSetting("S2ShortCode") + " (miễn phí đăng ký)";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong Bao";
                        ltrSMS.Text = "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK NC gui " + AppEnv.GetSetting("S2ShortCode") + " (mien phi dang ky)";
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