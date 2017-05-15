using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class BaiHatTheoCaSy : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = MusicController.GetArtistTopHasCache(5);
            if(dt != null && dt.Rows.Count > 0)
            {
                rptTopCaSy.DataSource = dt;
                rptTopCaSy.DataBind();
            }
        }
    }
}