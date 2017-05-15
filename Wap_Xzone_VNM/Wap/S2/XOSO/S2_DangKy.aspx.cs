using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.XOSO
{
    public partial class S2_DangKy : BasePage
    {

        private int width;
        private string lang;
        private string id;
        private string name;
        private string code;

        protected void Page_Load(object sender, EventArgs e)
        {

            

            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = Request.QueryString["id"];

            if(id == "0")
            {
                name = "Thủ Đô";
                code = "MB";
            }
            else
            {
                DataTable info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

                if (info.Rows.Count > 0)
                {
                    name = info.Rows[0]["company_name"].ToString().Replace("XS", "");
                    code = info.Rows[0]["company_comment"].ToString();
                }
            }
            
            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), String.Format(AppEnv.GetSetting("S2DK_XS"),code));
                    if (value == "1")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = "Xổ Số";
                            ltrSMS.Text =
                                "Bạn đã là thuê bao của dịch vụ kết quả xổ số " + name + ". Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY " + code + " </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = "Xo So";
                            ltrSMS.Text =
                                "Ban da la thue bao cua dich vu ket qua xo so " + name + ". Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY " + code + " </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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
                                ltrThongBao.Text = "<b>Xác Nhận</b>";
                                ltrThongBaoNoiDung.Text =
                                    "Bạn có đồng ý đăng ký dịch vụ Xổ Số " + name + " của Vietnamobile hay không (miễn phí đăng ký) ?";

                            }
                            else
                            {
                                ltrThongBao.Text = "<b>Xac Nhan</b>";
                                ltrThongBaoNoiDung.Text =
                                    "Ban co dong y dang ky dich vu Xổ Số " + AppEnv.CheckLang(name) + " cua Vietnamobile hay khong (mien phi dang ky) ?";
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
                                if (lang == "1")
                                {
                                    ltrTieuDe.Text = "Xổ Số";
                                }

                                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công kết quả xổ số " + name + ". Kết quả sẽ được gửi đến điện thoại của bạn ngay sau khi quay thưởng <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + code + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                    : "Ban da dang ky thanh cong ket qua xo so " + AppEnv.CheckLang(name) + ". Ket qua se duoc gui den dien thoai cua ban ngay sau khi quay thuong. <br/> De huy dich vu vui long soan: <b> HUY " + code + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";

                            }
                            else
                            {
                                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                                string requestId = AppEnv.GetSetting("S2RequestID");
                                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                                string message = String.Format(AppEnv.GetSetting("S2DK_XS"), code);
                                string msisdn = Session["msisdn"].ToString();

                                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                                string[] arrResult = reResult.Split('|');

                                if (arrResult.Length > 0)
                                {
                                    if (arrResult[0] == "1")
                                    {
                                        //Session["S2Result_XOSO"] = "1";
                                        pnlSMS.Visible = false;
                                        pnlThongBao.Visible = false;

                                        pnlNoiDung.Visible = true;
                                        if (lang == "1")
                                        {
                                            ltrTieuDe.Text = "Xổ Số";
                                        }

                                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công kết quả xổ số " + name + ". Kết quả sẽ được gửi đến điện thoại của bạn ngay sau khi quay thưởng <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + code + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                            : "Ban da dang ky thanh cong ket qua xo so " + AppEnv.CheckLang(name) + ". Ket qua se duoc gui den dien thoai cua ban ngay sau khi quay thuong. <br/> De huy dich vu vui long soan: <b> HUY " + code + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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
                        ltrSMS.Text =
                            "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK " + code + " gửi " + AppEnv.GetSetting("S2ShortCode");
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong Bao";
                        ltrSMS.Text =
                            "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK " + code + " gui" + AppEnv.GetSetting("S2ShortCode");
                    }
                }
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                //Session["S2Result_XOSO"] = "1";
                //string message = String.Format(AppEnv.GetSetting("S2DK_XS"), code);
                //Response.Redirect("S2_Result.aspx?lang=" + lang + "&w=" + width + "&id=" + id);

                pnlSMS.Visible = false;
                pnlThongBao.Visible = false;

                pnlNoiDung.Visible = true;
                if (lang == "1")
                {
                    ltrTieuDe.Text = "Xổ Số";
                }

                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công kết quả xổ số " + name + ". Kết quả sẽ được gửi đến điện thoại của bạn ngay sau khi quay thưởng <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + code + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    : "Ban da dang ky thanh cong ket qua xo so " + AppEnv.CheckLang(name) + ". Ket qua se duoc gui den dien thoai cua ban ngay sau khi quay thuong. <br/> De huy dich vu vui long soan: <b> HUY " + code + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";

            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = String.Format(AppEnv.GetSetting("S2DK_XS"), code);
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
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = "Xổ Số";
                        }

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công kết quả xổ số " + name + ". Kết quả sẽ được gửi đến điện thoại của bạn ngay sau khi quay thưởng <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + code + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong ket qua xo so " + AppEnv.CheckLang(name) + ". Ket qua se duoc gui den dien thoai cua ban ngay sau khi quay thuong. <br/> De huy dich vu vui long soan: <b> HUY " + code + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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