using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class AlbumDetail : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected string lang;
        protected string width;
        private int albumID;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            albumID = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (!IsPostBack)
            {
                //start category list
                int totalrecord = 0;
                DataTable dtCat = MusicController.GetItemByAlbumWithPagingHasCache(albumID, Session["telco"].ToString(),
                                                                                   curpage, pagesize, out totalrecord);
                rptMusic.DataSource = dtCat;
                rptMusic.DataBind();

                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;
                Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" +
                                       Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" +
                                       Request.QueryString["id"];
                Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" +
                                     Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" +
                                     Request.QueryString["id"] + "&cpage=";
                DataTable albumInfo = MusicController.GetAlbumByIDHasCache(albumID);
                if (albumInfo.Rows.Count > 0)
                {
                    if (lang == "1")
                    {
                        ltrAlbumName.Text = albumInfo.Rows[0]["AlbumNameUnicode"].ToString() ;
                    }
                    else
                    {
                        ltrAlbumName.Text = albumInfo.Rows[0]["AlbumName"].ToString() ;
                    }
                }
            }
    }
    }
}