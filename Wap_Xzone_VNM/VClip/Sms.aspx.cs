using System;
using WapXzone_VNM.VClip.Library;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.VClip.Video
{
    public partial class Sms : BasePage
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