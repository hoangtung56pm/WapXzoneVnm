using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hoangdao
{
    public partial class DefaultNew : BasePage
    {
        private int width;
        private string display;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            if (!IsPostBack)
            {
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                if (Request.QueryString["lang"] == "1")
                {
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
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
                    plContent.Controls.Add(LoadControl("UserControlNew/HoangdaoHome.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControlNew/List.ascx"));
                    break;
            }
        }
    }
}