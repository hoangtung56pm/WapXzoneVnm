using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone.VClip.Library;
using WapXzone.VClip.Library.Utilities;
using WapXzone.VClip.Library.Constant;

namespace WapXzone.VClip.Video
{
    public partial class Success : BasePage
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
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; minimum-scale =1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }

        }
    }
}