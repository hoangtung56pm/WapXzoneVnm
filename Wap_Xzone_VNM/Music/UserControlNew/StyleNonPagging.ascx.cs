using System;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class StyleNonPagging : System.Web.UI.UserControl
    {
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];
            if (!Page.IsPostBack)
            {
                rptTheLoai.DataSource = MusicController.GetStyleTopHasCache(5);
                rptTheLoai.DataBind();
            }
        }
    }
}