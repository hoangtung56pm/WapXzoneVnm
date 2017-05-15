using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao
{
    public partial class DefaultNew : BasePage
    {
        private int width;
        private string display;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("../Video/UserControlNew/Video4Bongda.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/Gold.ascx"));
                    break;
                case "newsdetail":
                    plContent.Controls.Add(LoadControl("UserControlNew/BongDaTinTuc.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControlNew/List.ascx"));
                    break;
                case "cgd":
                    plContent.Controls.Add(LoadControl("UserControlNew/Category.ascx"));
                    break;
                case "bxh":
                    plContent.Controls.Add(LoadControl("UserControlNew/BangXepHang.ascx"));
                    break;
                case "ltd":
                    plContent.Controls.Add(LoadControl("UserControlNew/LichThiDau.ascx"));
                    break;
                case "ltdhn":
                    plContent.Controls.Add(LoadControl("UserControlNew/LichThiDauHomNay.ascx"));
                    break;
                case "kqtd":
                    plContent.Controls.Add(LoadControl("UserControlNew/KetQuaThiDau.ascx"));
                    break;
                case "kqtdhn":
                    plContent.Controls.Add(LoadControl("UserControlNew/KetQuaThiDauHomNay.ascx"));
                    break;
                case "tvdb":
                    plContent.Controls.Add(LoadControl("UserControlNew/TuVanDacBiet.ascx"));
                    break;
            }
        }
    }
}