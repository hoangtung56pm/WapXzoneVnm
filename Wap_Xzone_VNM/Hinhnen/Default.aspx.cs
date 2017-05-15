using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;
using System.Configuration;

namespace WapXzone_VNM.Hinhnen
{
    public partial class Default : BasePage
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
                if (width == 0) {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                if (Request.QueryString["lang"] == "1") {
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            
            if(string.IsNullOrEmpty(Request.QueryString["display"])){
                display = "home";
            }else{
                display = Request.QueryString["display"];
            }
              
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControl/WallpaperHome.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControl/List.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;
                case "search":
                    plContent.Controls.Add(LoadControl("UserControl/SearchResult.ascx"));
                    break;
            }            
        }
    }
}
