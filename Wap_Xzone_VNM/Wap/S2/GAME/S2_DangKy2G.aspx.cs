using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.GAME
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

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), AppEnv.GetSetting("S2DK_Game"));
                    if (value == "1")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = "GAME HOT";
                            ltrSMS.Text =
                                "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY GAME </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = "GAME HOT";
                            ltrSMS.Text =
                                "Ban da la thue bao cua dich vu GAME HOT tuan. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY GAME </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                    }
                    else
                    {

                        if (AppEnv.GetSetting("94x_Confirm_Flag") == "1")
                        {
                            #region Confirm

                            pnlThongBao.Visible = true;
                            if (lang == "1")
                            {
                                ltrThongBao.Text = "Xác Nhận";
                                ltrThongBaoNoiDung.Text =
                                    "Bạn có đồng ý đăng ký dịch vụ Game Hot của Vietnamobile hay không (miễn phí đăng ký) ?";

                            }
                            else
                            {
                                ltrThongBao.Text = "Xac Nhan";
                                ltrThongBaoNoiDung.Text =
                                    "Ban co dong y dang ky dich vu Game Hot cua Vietnamobile hay khong (mien phi dang ky) ?";
                            }

                            #endregion
                        }
                        else
                        {
                            #region Non Confirm

                            if (AppEnv.GetSetting("S2Test") == "1")
                            {
                                pnlSMS.Visible = false;
                                pnlThongBao.Visible = false;

                                pnlNoiDung.Visible = true;

                                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                            : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 va thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                            }
                            else
                            {
                                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                                string requestId = AppEnv.GetSetting("S2RequestID");
                                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                                string message = AppEnv.GetSetting("S2DK_Game");
                                string msisdn = Session["msisdn"].ToString();

                                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                                string[] arrResult = reResult.Split('|');

                                if (arrResult.Length > 0)
                                {
                                    if (arrResult[0] == "1")
                                    {
                                        pnlSMS.Visible = false;
                                        pnlThongBao.Visible = false;

                                        pnlNoiDung.Visible = true;

                                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                                    : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 va thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                                    }
                                    else
                                    {
                                        pnlThongBao.Visible = false;
                                        pnlSMS.Visible = false;

                                        pnlNoiDung.Visible = true;

                                        ltrNoiDung.Text = lang == "1" ? "Đăng ký không thành công. Vui lòng thử lại" : "Dang ky khong thanh cong. Vui long thu lai";
                                    }
                                }
                            }

                            #endregion
                        }

                    }
                }
                else
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Thông Báo";
                        ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK GAME gửi " + AppEnv.GetSetting("S2ShortCode") + " (miễn phí đăng ký)";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong Bao";
                        ltrSMS.Text = "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK GAME gui " + AppEnv.GetSetting("S2ShortCode") + " (mien phi dang ky)";
                    }
                }

            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                pnlSMS.Visible = false;
                pnlThongBao.Visible = false;

                pnlNoiDung.Visible = true;

                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 va thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = AppEnv.GetSetting("S2DK_Game");
                string msisdn = Session["msisdn"].ToString();

                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                string[] arrResult = reResult.Split('|');

                if (arrResult.Length > 0)
                {
                    if (arrResult[0] == "1")
                    {
                        pnlSMS.Visible = false;
                        pnlThongBao.Visible = false;

                        pnlNoiDung.Visible = true;

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                    : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 va thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        pnlSMS.Visible = false;

                        pnlNoiDung.Visible = true;

                        ltrNoiDung.Text = lang == "1" ? "Đăng ký không thành công. Vui lòng thử lại" : "Dang ky khong thanh cong. Vui long thu lai";
                    }
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