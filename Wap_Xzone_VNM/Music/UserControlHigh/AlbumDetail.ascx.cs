using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class AlbumDetail : System.Web.UI.UserControl
    {
        private int pagesize = 30;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private static string preurl;
        private int albumID;

        protected void Page_Load(object sender, EventArgs e)
        {
            albumID = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtCat = MusicController.GetItemByAlbumWithPagingHasCache(albumID, AppEnv.CheckSessionTelco(), curpage, pagesize, out totalrecord);
                if(dtCat != null && dtCat.Rows.Count > 0)
                {
                    rptlstCategory.DataSource = dtCat;
                    //rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
                    rptlstCategory.DataBind();
                }
                DataTable albumInfo = MusicController.GetAlbumByIDHasCache(albumID);
                if (albumInfo != null && albumInfo.Rows.Count > 0)
                {
                    ltrAlbumName.Text = albumInfo.Rows[0]["AlbumNameUnicode"].ToString();
                }
            }
        }
    }
}