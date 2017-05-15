using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game
{
    public partial class S2_KetQua : BasePage
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
                    width = (int) Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width +
                                "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["S2Result"] != null)
                {
                    pnlNoiDung.Visible = true;
                    if (Session["S2Result"].ToString() == "1")
                    {
                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> 940 </b>"
                           : "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 vaf thu 4 hang tuan. <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> 940 </b>";
                    }
                    else
                    {
                        ltrNoiDung.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> 940 </b>"
                           : "Ban da la thue bao cua dich vu Game HOT tuan. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> 940 </b>";
                    }
                    Session["S2Result"] = null;
                }
               
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}