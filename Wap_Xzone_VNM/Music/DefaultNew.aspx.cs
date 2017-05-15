using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music
{
    public partial class DefaultNew : BasePage
    {
        private int width;
        private string display;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControlNew/NewsHot.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/MusicHome.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "style":
                    plContent.Controls.Add(LoadControl("UserControlNew/Style.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "artist":
                    plContent.Controls.Add(LoadControl("UserControlNew/Artist.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "album":
                    plContent.Controls.Add(LoadControl("UserControlNew/Album.ascx"));
                     plContent.Controls.Add(LoadControl("UserControlNew/ArtistNonPagging.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/StyleNonPagging.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "byalb":
                    plContent.Controls.Add(LoadControl("UserControlNew/AlbumDetail.ascx"));
                     plContent.Controls.Add(LoadControl("UserControlNew/ArtistNonPagging.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/StyleNonPagging.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "byart":
                    plContent.Controls.Add(LoadControl("UserControlNew/ArtistDetail.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "bysty":
                    plContent.Controls.Add(LoadControl("UserControlNew/StyleDetail.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "newest":
                    plContent.Controls.Add(LoadControl("UserControlNew/List.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                //
                case "mdt":
                    plContent.Controls.Add(LoadControl("UserControlNew/MusicDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/ArtistNonPagging.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/StyleNonPagging.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    break;
                case "sr":
                    plContent.Controls.Add(LoadControl("UserControlNew/SearchResult.ascx"));
                    //plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/ArtistNonPagging.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/StyleNonPagging.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "news":
                    plContent.Controls.Add(LoadControl("UserControlNew/NewsList.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "ndt":
                    plContent.Controls.Add(LoadControl("UserControlNew/NewsDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControlNew/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
            }
        }
    }
}