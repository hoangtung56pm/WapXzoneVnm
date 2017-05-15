using System;
using System.Web.UI;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class TimKiem : System.Web.UI.UserControl
    {
        private int lang;
        private int hotro;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            switch (dgrCategory.SelectedValue)
            {
                case "1":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "0"));
                    break;
                case "2":
                    Response.Redirect(UrlProcess.GetWallpaperSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim()));
                    break;
                case "3":
                    Response.Redirect(UrlProcess.GetGameSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "0"));
                    break;
                case "4":
                    Response.Redirect(UrlProcess.GetAppSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "0"));
                    break;
                case "5":
                    Response.Redirect(UrlProcess.GetVideoSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim()));
                    break;
            }
        }
    }
}