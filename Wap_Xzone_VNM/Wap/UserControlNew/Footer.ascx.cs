using System;
using System.Web;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUrl = HttpContext.Current.Request.RawUrl;
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = ConvertUtility.ToInt32(Request.QueryString["w"]).ToString();

            if (Request.QueryString["lang"] == "1")
            {
                litNgonNgu.Text = "<a class=\"link-non-white\" href=\" " + currentUrl.Replace("lang=1","lang=0") + "\"> Không dấu </a>";
            }
            else
            {
                litNgonNgu.Text = "<a class=\"link-non-white\" href=\"" + currentUrl.Replace("lang=0","lang=1") + "\"> Co dau </a>";
            }
        }
    }
}