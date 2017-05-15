using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.S2
{
    public partial class S2_Result : System.Web.UI.Page
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

                if (Session["S2Result_Clip"] != null)
                {
                    pnlNoiDung.Visible = true;
                    if (Session["S2Result_Clip"].ToString() == "1")
                    {
                        ltrNoiDung.Text = lang == "1" ? "Bạn đã đăng ký thành công. Video Clip sẽ được gửi đến điện thoại của bạn vào 10h30 hàng ngày <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY CLIP </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                            : "Ban da dang ky thanh cong. Video Clip se duoc gui den dien thoai cua ban vao 10h30 hang ngay. <br/> De huy dich vu vui long soan: <b> HUY CLIP </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    }
                    //else
                    //{
                    //    ltrNoiDung.Text = lang == "1" ? "Bạn đã là thuê bao của dịch vụ Game HOT tuần. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY GAME </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                    //        : "Ban da la thue bao cua dich vu Game HOT tuan. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY GAME </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                    //}
                    Session["S2Result_Clip"] = null;
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}