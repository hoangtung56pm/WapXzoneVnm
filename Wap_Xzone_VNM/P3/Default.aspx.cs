using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.P3
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            }

            display = Request.QueryString["display"];
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControl/Home.ascx"));
                    break;
                case "new":
                    plContent.Controls.Add(LoadControl("UserControl/New.ascx"));
                    break;
                case "top":
                    plContent.Controls.Add(LoadControl("UserControl/Top.ascx"));
                    break;
                case "hot":
                    plContent.Controls.Add(LoadControl("UserControl/Hot.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;       
                default:
                     plContent.Controls.Add(LoadControl("UserControl/Home.ascx"));
                    break;
            }
        }
    }
}