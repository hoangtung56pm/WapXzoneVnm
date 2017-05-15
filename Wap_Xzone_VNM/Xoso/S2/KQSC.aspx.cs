using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.S2
{
    public partial class KQSC : BasePage
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
                ltrWidth.Text = "<meta content=\"width=" + width +
                                "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["S2_Sc_Result"] != null)
                {
                    pnlNoiDung.Visible = true;
                    if (Session["S2_Sc_Result"].ToString() == "1")
                    {
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = "Thống kê cặp số";
                            ltrNoiDung.Text = "Bạn đã đăng ký thành công. Dự đoán kết quả xổ số <b> " + info.Rows[0]["company_name"].ToString().Replace("XS", "") + " </b> sẽ trả về vào những ngày quay thưởng. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY SC " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            ltrTieuDe.Text = "Thong ke cap so";
                            ltrNoiDung.Text = "Ban da dang ky thanh cong. Du doan ket qua xo so </b>" + AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", "")) + "</b> se tra ve vao nhung ngay quay thuong. <br/> De huy dich vu vui long soan: <b> HUY SC " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                    }
                    else
                    {
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = "Thống kê cặp số";
                            ltrNoiDung.Text = "Bạn đã là thuê bao của dịch vụ soi cầu hàng ngày. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY SC " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            ltrTieuDe.Text = "Thong ke cap so";
                            ltrNoiDung.Text = "Ban da la thue bao cua dich vu soi cau hang ngay. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY SC " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                    }
                    
                    Session["S2_Sc_Result"] = null;
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}