using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.S2
{
    public partial class DangKySC2G : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private DataTable info;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["msisdn"] != null)
                {
                    pnlThongBao.Visible = true;
                    if (lang == "1")
                    {
                        ltrTitle.Text = "Thống kê cặp số";
                        ltrThongBao.Text = "Giới thiệu";
                        ltrThongBaoNoiDung.Text = "Cung cấp dự đoán kết quả  xổ số <b> " + info.Rows[0]["company_name"].ToString().Replace("XS", "") + " </b> nhanh chóng, chính xác, thuận tiện. Tư vấn và nhận định cặp số sẽ về trong ngày hiện tại.Đăng ký một lần nhận tin mãi mãi <br/> Miễn phí 7 lần trả KQ đầu tiên";
                    }
                    else
                    {
                        ltrTitle.Text = "Thong ke cap so";
                        ltrThongBao.Text = "Gioi Thieu";
                        ltrThongBaoNoiDung.Text =
                            "Cung cap du doan ket qua xo so <b> " + AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", "")) + " </b> nhanh chong, chinh xac, thuan tien. Ket qua se duoc gui ngay toi khach hang sau khi mo thuong. Dang ky mot lan nhan tin mai mai <br/> Mien phi 7 lan tra KQ dau tien";
                    }
                }
                else
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = "Thống kê cặp số";
                        ltrSMS.Text = "Cung cấp dự đoán kết quả  xổ số <b> " + info.Rows[0]["company_name"].ToString().Replace("XS", "") + " </b> nhanh chóng, chính xác, thuận tiện. Tư vấn và nhận định cặp số sẽ về trong ngày hiện tại.Đăng ký một lần nhận tin mãi mãi <br/> Miễn phí 7 lần trả KQ đầu tiên.<br/>Vui lòng truy cập bằng <b> 3G/GPRS </b> hoặc : <br/> SOẠN TIN :  <b> DK SC " + info.Rows[0]["company_comment"] + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                    else
                    {
                        ltrHuongdan.Text = "Thong ke cap so";
                        ltrSMS.Text = "Cung cap du doan ket qua xo so <b> " + AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", "")) + " </b> nhanh chong, chinh xac, thuan tien. Ket qua se duoc gui ngay toi khach hang sau khi mo thuong. Dang ky mot lan nhan tin mai mai <br/> Mien phi 7 lan tra KQ dau tien.<br/>Vui long truy cap bang <b> 3G/GPRS </b> hoac : <br/> SOAN TIN : <b> DK SC " + AppEnv.CheckLang(info.Rows[0]["company_comment"].ToString()) + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                }

            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                Session["S2_Sc_Result_2G"] = "1";
                Response.Redirect(UrlProcess.GetS2RegisterResultSoiCauUrl2G(lang, width.ToString(), id.ToString()));
            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode");
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");
                string message = string.Format(AppEnv.GetSetting("S2DK_SC"), info.Rows[0]["company_comment"]);
                string msisdn = Session["msisdn"].ToString();

                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                string[] arrResult = reResult.Split('|');
                
                if (arrResult.Length > 0)
                {
                    if (arrResult[0] == "1")
                    {
                        Session["S2_Sc_Result_2G"] = "1";
                    }
                    else if (arrResult[0] == "0")
                    {
                        Session["S2_Sc_Result_2G"] = "0";
                    }
                    Response.Redirect(UrlProcess.GetS2RegisterResultSoiCauUrl2G(lang, width.ToString(), id.ToString()));
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