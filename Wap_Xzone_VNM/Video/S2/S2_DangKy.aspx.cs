using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.S2
{
    public partial class S2_DangKy : BasePage
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

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), AppEnv.GetSetting("S2DK_CLIP"));
                    if (value == "1")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = "VIDEO CLIP";
                            ltrSMS.Text =
                                "Bạn đã là thuê bao của dịch vụ Video Clip tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY CLIP </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = "VIDEO CLIP";
                            ltrSMS.Text =
                                "Ban da la thue bao cua dich vu Video Clip tuan. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY CLIP </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = true;
                        if (lang == "1")
                        {
                            ltrThongBao.Text = "Giới Thiệu";
                            ltrThongBaoNoiDung.Text =
                                "Cung cấp cho bạn những clip hot và nóng hổi nhất. Những thông tin mới, đặc sắc sẽ được truyền tải đến cho bạn hàng ngày. Đăng ký một lần nhận tin mãi mãi  <br/> <b> Đặc biệt miễn phí sử dụng 7 ngày đầu tiên cho khách hàng lần đầu đăng ký </b>";

                        }
                        else
                        {
                            ltrThongBao.Text = "Gioi Thieu";
                            ltrThongBaoNoiDung.Text =
                                "Cung cap cho ban nhung clip jot va nong hoi nhat. Nhung thong tin moi, dac sac se duoc truyen tai den cho ban hang ngay. Dang ky mot lan nhan tin mai mai <br/> <b> Dac biet mien phi su dung 7 ngay dau tien cho khach hang lan dau dang ky </b>";
                        }
                    }
                }
                else
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Giới Thiệu";
                        ltrSMS.Text =
                            "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK CLIP gửi " + AppEnv.GetSetting("S2ShortCode");
                    }
                    else
                    {
                        ltrHuongdan.Text = "Gioi Thieu";
                        ltrSMS.Text =
                            "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK CLIP gui" + AppEnv.GetSetting("S2ShortCode");
                    }
                }

            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                Session["S2Result_Clip"] = "1";
                //Session["LastPage"] = Request.RawUrl;
                Response.Redirect("/Video/S2/S2_Result.aspx?lang=" + lang + "&w=" + width);
            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = AppEnv.GetSetting("S2DK_CLIP");
                string msisdn = Session["msisdn"].ToString();

                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                string[] arrResult = reResult.Split('|');

                if (arrResult.Length > 0)
                {
                    if (arrResult[0] == "1")
                    {
                        Session["S2Result_Clip"] = "1";
                    }
                    else if (arrResult[0] == "0")
                    {
                        Session["S2Result_Clip"] = "0";
                    }

                    //Session["LastPage"] = Request.RawUrl;
                    Response.Redirect("/Video/S2/S2_Result.aspx?lang=" + lang + "&w=" + width);
                }
            }
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            pnlNoiDung.Visible = true;
            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần.";
                }
                else
                {
                    ltrNoiDung.Text = "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 vaf thu 4 hang tuan.";
                }
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}