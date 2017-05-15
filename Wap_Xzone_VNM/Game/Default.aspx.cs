using System;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Game
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        private string lang;
        private string plaintext;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = Request.QueryString["lang"];            
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
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
                    plContent.Controls.Add(LoadControl("UserControl/LastestGame.ascx"));
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
