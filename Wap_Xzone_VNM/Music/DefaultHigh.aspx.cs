using System;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Music
{
    public partial class DefaultHigh : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string display;
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
                        plContent.Controls.Add(LoadControl("UserControlHigh/Home.ascx"));
                        break;
                    case "list":
                        plContent.Controls.Add(LoadControl("UserControlHigh/List.ascx"));
                        break;
                    case "detail":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Detail.ascx"));
                        break;
                    case "search":
                        plContent.Controls.Add(LoadControl("UserControlHigh/SearchResult.ascx"));
                        break;
                    case "byalb":
                        plContent.Controls.Add(LoadControl("UserControlHigh/AlbumDetail.ascx"));
                        //plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                        //Session["LastMusicURL"] = Request.RawUrl;
                        break;
                    case "mdt":
                        plContent.Controls.Add(LoadControl("UserControlHigh/MusicDetail.ascx"));
                        //plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                        break;
                    case "album":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Album.ascx"));
                        //plContent.Controls.Add(LoadControl("UserControl/Links.ascx"));
                        //Session["LastMusicURL"] = Request.RawUrl;
                        break;
                    case "artist":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Artist.ascx"));
                        break;
                    case "byart":
                        plContent.Controls.Add(LoadControl("UserControlHigh/ArtistDetail.ascx"));
                        break;
                    case "style":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Style.ascx"));
                        break;
                    case "bysty":
                        plContent.Controls.Add(LoadControl("UserControlHigh/StyleDetail.ascx"));
                        break;
                }
            }
        }
    }
}