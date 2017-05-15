using System;
using System.Web;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            key = UnicodeUtility.RemoveSpecialCharacter(key);
            key = UnicodeUtility.RemoveHtmlTags(key);
            key = UnicodeUtility.UnicodeToKoDau(key);
            if(!string.IsNullOrEmpty(key))
            {
                key = key.Replace(" ", "+");
                string url = UrlProcess.YoutubeTimKiem(key, 1, "tim-phim");

                HttpContext.Current.RewritePath(url, false);

                Response.Redirect(url);
            }
        }
    }
}