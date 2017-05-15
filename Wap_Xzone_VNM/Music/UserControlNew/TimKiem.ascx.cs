using System;
using System.Web.UI;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
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
                case "0":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "0"));
                    break;
                case "1":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "1"));
                    break;
                case "2":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrlNew(lang.ToString(), width, txtKey.Text.Trim(), "2"));
                    break;
            }
        }
    }
}