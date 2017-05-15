using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.THOITIET
{
    public partial class S2_DangKy : BasePage
    {
        private int width;
        private string lang;
        private string regionCode;
        private string regionName;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            regionCode = Request.QueryString["t"];

            regionCode = regionCode.ToUpper();
            regionName = AppEnv.GetRegionName(regionCode);

            

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["msisdn"] != null)
                {
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), String.Format(AppEnv.GetSetting("S2DK_THOITIET"),regionCode));
                    if (value == "1")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = "Thời Tiết";
                            ltrSMS.Text =
                                "Bạn đã là thuê bao của dịch vụ thời tiết " + regionName + ". Xin cảm ơn <br/> Để hủy dịch vụ vui lòng SOẠN TIN : <b> HUY TT " + regionCode + " </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = "Thoi Tiet";
                            ltrSMS.Text =
                                "Ban da la thue bao cua dich vu thoi tiet. Xin cam on <br/> De huy dich vu vui long SOAN TIN : <b> HUY TT " + regionCode +" </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
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
                                    "Bạn có đồng ý đăng ký dịch vụ Thời Tiết " + regionName + " của Vietnamobile hay không (miễn phí đăng ký) ?";

                            }
                            else
                            {
                                ltrThongBao.Text = "<b>Xac Nhan</b>";
                                ltrThongBaoNoiDung.Text =
                                    "Ban co dong y dang ky dich vu Thoi Tiet " + AppEnv.CheckLang(regionName) + " cua Vietnamobile hay khong (mien phi dang ky) ?";
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
                                    ltrTieuDe.Text = "Thời Tiết";
                                }

                                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ thời tiết " + regionName + ".  Dự báo thời tiết sẽ được gửi đến điện thoại của bạn vào 18h ngày hôm trước. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY TT " + regionCode + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                    : "Ban da dang ky thanh cong dich vu thoi tiet " + AppEnv.CheckLang(regionName) + ". Du bao thoi tiet se duoc gui den dien thoai cua ban vao 18h ngay hom truoc. <br/> De huy dich vu vui long soan: <b> HUY TT " + regionCode + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";

                            }
                            else
                            {
                                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                                string requestId = AppEnv.GetSetting("S2RequestID");
                                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                                string message = String.Format(AppEnv.GetSetting("S2DK_THOITIET"), regionCode);
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
                                            ltrTieuDe.Text = "Thời Tiết";
                                        }

                                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ thời tiết " + regionName + ".  Dự báo thời tiết sẽ được gửi đến điện thoại của bạn vào 18h ngày hôm trước. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY TT " + regionCode + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                            : "Ban da dang ky thanh cong dich vu thoi tiet " + AppEnv.CheckLang(regionName) + ". Du bao thoi tiet se duoc gui den dien thoai cua ban vao 18h ngay hom truoc. <br/> De huy dich vu vui long soan: <b> HUY TT " + regionCode + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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
                            "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: DK TT " + regionCode + " gửi " + AppEnv.GetSetting("S2ShortCode");
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong Bao";
                        ltrSMS.Text =
                            "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin DK TT " + regionCode + " gui" + AppEnv.GetSetting("S2ShortCode");
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
                if (lang == "1")
                {
                    ltrTieuDe.Text = "Thời Tiết";
                }

                ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ thời tiết " + regionName + ".  Dự báo thời tiết sẽ được gửi đến điện thoại của bạn vào 18h ngày hôm trước. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY TT " + regionCode + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    : "Ban da dang ky thanh cong dich vu thoi tiet " + AppEnv.CheckLang(regionName) + ". Du bao thoi tiet se duoc gui den dien thoai cua ban vao 18h ngay hom truoc. <br/> De huy dich vu vui long soan: <b> HUY TT " + regionCode + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";

            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = String.Format(AppEnv.GetSetting("S2DK_THOITIET"), regionCode);
                string msisdn = Session["msisdn"].ToString();

                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                string[] arrResult = reResult.Split('|');

                if (arrResult.Length > 0)
                {
                    if (arrResult[0] == "1")
                    {
                        //Session["S2Result_THOITIET"] = "1";

                        pnlSMS.Visible = false;
                        pnlThongBao.Visible = false;

                        pnlNoiDung.Visible = true;
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = "Thời Tiết";
                        }

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ thời tiết " + regionName + ".  Dự báo thời tiết sẽ được gửi đến điện thoại của bạn vào 18h ngày hôm trước. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY TT " + regionCode + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong dich vu thoi tiet " + AppEnv.CheckLang(regionName) + ". Du bao thoi tiet se duoc gui den dien thoai cua ban vao 18h ngay hom truoc. <br/> De huy dich vu vui long soan: <b> HUY TT " + regionCode + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
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