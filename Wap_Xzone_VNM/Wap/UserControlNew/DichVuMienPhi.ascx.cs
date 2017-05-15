using System;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class DichVuMienPhi : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                width = Request.QueryString["w"];
            }
        }
    }
}