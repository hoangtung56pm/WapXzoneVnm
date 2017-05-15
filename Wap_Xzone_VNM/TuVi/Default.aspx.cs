using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone.Library.UrlProcess;
using WapXzone.Library.Utilities;
using WapXzone.Library.Constant;
using WapXzone.Library;

using System.Configuration;

namespace WapXzone.TuVi
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        private string lang;        
        protected void Page_Load(object sender, EventArgs e)
        {
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
            
            //if (lang == "1")
            //{
            //    lnkLang.Text = Resources.Resource1.Lang_Codau;
            //    lnktoppage.Text = Resources.Resource1.DauTrang;
            //    ltroption.Text = Resources.Resource1.Footer_LuaChon;
            //    lnkHome.Text = Resources.Resource1.home_back;
            //    lnkLang.NavigateUrl = Request.RawUrl.Replace("lang=1", "lang=0");
            //    lnkHome.NavigateUrl = UrlProcess.GetMobilefoneHomeUrl("1");
            //}
            //else
            //{
            //    lnkLang.NavigateUrl = Request.RawUrl.Replace("lang=0", "lang=1");
            //    lnkHome.NavigateUrl = UrlProcess.GetMobilefoneHomeUrl("0");
            //}
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControl/Category.ascx"));
                    break;                
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;           
            }

        }
    }
}
