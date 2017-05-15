using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.CUOI
{
    public partial class S2_Result : BasePage
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
                ltrWidth.Text = "<meta content=\"width=" + width +
                                "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["S2Result_CUOI"] != null)
                {
                    pnlNoiDung.Visible = true;
                    if (Session["S2Result_CUOI"].ToString() == "1")
                    {
                        if(lang == "1")
                        {
                            ltrTieuDe.Text = "Truyện Cười";
                        }

                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Truyện cười sẽ được gửi đến điện thoại của bạn vào 8h hàng ngày <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY CUOI </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong. Truyen cuoi se duoc gui den dien thoai cua ban vao 8h hang ngay. <br/> De huy dich vu vui long soan: <b> HUY CUOI </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    }
                    //else
                    //{
                    //    ltrNoiDung.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //        : "Ban da la thue bao cua dich vu Game HOT tuan. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //}
                    Session["S2Result_CUOI"] = null;
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}