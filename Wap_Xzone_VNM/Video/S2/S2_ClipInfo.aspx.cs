using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.S2
{
    public partial class S2_ClipInfo : System.Web.UI.Page
    {
        protected int width;
        protected string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
        }
    }
}