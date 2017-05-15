using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Wap
{
    public partial class Lienket : BasePage
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
                case "lk":
                    plContent.Controls.Add(LoadControl("../Wap/UserControl/Links_List.ascx"));
                    break;
            }

        }
    }
}
