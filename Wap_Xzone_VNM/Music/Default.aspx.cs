using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;
using System.Configuration;


namespace WapXzone_VNM.Music
{
    public partial class Default : BasePage
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
                    plContent.Controls.Add(LoadControl("UserControl/NewsHot.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/MusicHome.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "style":
                    plContent.Controls.Add(LoadControl("UserControl/Style.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "artist":
                    plContent.Controls.Add(LoadControl("UserControl/Artist.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "album":
                    plContent.Controls.Add(LoadControl("UserControl/Album.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "byalb":
                    plContent.Controls.Add(LoadControl("UserControl/AlbumDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "byart":
                    plContent.Controls.Add(LoadControl("UserControl/ArtistDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "bysty":
                    plContent.Controls.Add(LoadControl("UserControl/StyleDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "newest":
                    plContent.Controls.Add(LoadControl("UserControl/List.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                    //
                case "mdt":
                    plContent.Controls.Add(LoadControl("UserControl/MusicDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    break;
                case "sr":
                    plContent.Controls.Add(LoadControl("UserControl/SearchResult.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "news":
                    plContent.Controls.Add(LoadControl("UserControl/NewsList.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;
                case "ndt":
                    plContent.Controls.Add(LoadControl("UserControl/NewsDetail.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                    Session["LastMusicURL"] = Request.RawUrl;
                    break;                
            }
        }
    }
}
