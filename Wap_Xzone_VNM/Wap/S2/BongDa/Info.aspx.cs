using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.BongDa
{
    public partial class Info : BasePage
    {
        protected int width;
        protected string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            if (!IsPostBack)
            {
                if (width == 0)
                {
                    width = ConvertUtility.ToInt32(Constant.DefaultScreen.Standard.ToString());
                }

                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
        }
    }
}