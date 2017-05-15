using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.TinTuc
{
    public partial class DangKy : BasePage
    {
        private int width;
        private string lang;

        private string madichvu;

        protected void Page_Load(object sender, EventArgs e)
        {

            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            madichvu = Request.QueryString["t"];
            madichvu = madichvu.ToUpper().Trim();

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), "DK " + madichvu);
                    if (value == "1")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = "Tin Tức";
                            ltrSMS.Text =
                                "Bạn đã là thuê bao của dịch vụ " + GetName(madichvu) + ". Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY " + madichvu + " </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = "Tin Tuc";
                            ltrSMS.Text =
                                "Ban da la thue bao cua dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY " + madichvu + " </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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
                                    "Bạn có đồng ý đăng ký dịch vụ " + GetName(madichvu) + " của Vietnamobile hay không (miễn phí đăng ký) ?";

                            }
                            else
                            {
                                ltrThongBao.Text = "Xac Nhan";
                                ltrThongBaoNoiDung.Text =
                                    "Ban co dong y dang ky dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + " cua Vietnamobile hay khong (mien phi dang ky) ?";
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

                                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Những thông tin mới nhất sẽ được cập nhật đến bạn hàng ngày. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + madichvu + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                            : "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Nhung thong tin moi nhat se duoc cap nhat den ban hang ngay. <br/> De huy dich vu vui long soan: <b> HUY " + madichvu + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                            }
                            else
                            {
                                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                                string requestId = AppEnv.GetSetting("S2RequestID");
                                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                                string message = "DK " + madichvu;
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

                                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Những thông tin mới nhất sẽ được cập nhật đến bạn hàng ngày. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + madichvu + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                             : "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Nhung thong tin moi nhat se duoc cap nhat den ban hang ngay. <br/> De huy dich vu vui long soan: <b> HUY " + madichvu + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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
                        ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK " + madichvu + " gửi " + AppEnv.GetSetting("S2ShortCode") + " (miễn phí đăng ký)";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong Bao";
                        ltrSMS.Text = "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK " + madichvu + " gui " + AppEnv.GetSetting("S2ShortCode") + " (mien phi dang ky)";
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

                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Những thông tin mới nhất sẽ được cập nhật đến bạn hàng ngày. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + madichvu + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Nhung thong tin moi nhat se duoc cap nhat den ban hang ngay. <br/> De huy dich vu vui long soan: <b> HUY " + madichvu + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = "DK " + madichvu;
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

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Những thông tin mới nhất sẽ được cập nhật đến bạn hàng ngày. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + madichvu + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                             : "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Nhung thong tin moi nhat se duoc cap nhat den ban hang ngay. <br/> De huy dich vu vui long soan: <b> HUY " + madichvu + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Những thông tin mới nhất sẽ được cập nhật đến bạn hàng ngày";
                }
                else
                {
                    ltrNoiDung.Text = "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Nhung thong tin moi nhat se duoc cap nhat den ban hang ngay.";
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

        private string GetName(string input)
        {
            string str = string.Empty;
            input = input.ToUpper();

            if (input == "NONG")
                str = "Tin nóng";
            else if (input == "THETHAO")
                str = "Tin thể thao 24h";
            else if (input == "TONGHOP")
                str = "Tin tổng hợp";
            else if (input == "SAO")
                str = "Tin chuyện của Sao";
            else if (input == "DS")
                str = "Tin sức khỏe đời sống";
            else if (input == "NL")
                str = "Tư vấn người lớn";

            return str;
        }
    }
}