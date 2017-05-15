using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.SOICAU
{
    public partial class S2_Result : BasePage
    {
        private int width;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            string id = Request.QueryString["id"];
            string name;
            string code;

            if(id == "0")
            {
                name = "Thủ Đô";
                code = "TD";
            }
            else
            {
                DataTable info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

                name = info.Rows[0]["company_name"].ToString().Replace("XS", "");
                code = info.Rows[0]["company_comment"].ToString();
            }
            

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width +
                                "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["S2Result_SOICAU"] != null)
                {
                    pnlNoiDung.Visible = true;
                    if (Session["S2Result_SOICAU"].ToString() == "1")
                    {
                        if(lang == "1")
                        {
                            ltrTieuDe.Text = "Soi Cầu";
                        }

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công dịch vụ Thống kê cặp số " + name + ". Kết quả sẽ được gửi đến điện thoại của bạn vào 15h các ngày quay thưởng <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY SC " + code + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong dich vu Thong ke cap so " + AppEnv.CheckLang(name) + ". Ket qua se duoc gui den dien thoai cua ban vao 15h cac ngay quay thuong. <br/> De huy dich vu vui long soan: <b> HUY SC " + code + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    }
                    //else
                    //{
                    //    ltrNoiDung.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //        : "Ban da la thue bao cua dich vu Game HOT tuan. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //}
                    Session["S2Result_SOICAU"] = null;
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}