using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Tintuc
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
                    plContent.Controls.Add(LoadControl("UserControl/LastestNews.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControl/List.ascx"));
                    break;
                case "nlist":
                    plContent.Controls.Add(LoadControl("UserControl/ListNews.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;
                case "ndetail":
                    plContent.Controls.Add(LoadControl("UserControl/DetailNews.ascx"));
                    break;
                case "search":
                    plContent.Controls.Add(LoadControl("UserControl/SearchResult.ascx"));
                    break;
            }
        }
    }
}
