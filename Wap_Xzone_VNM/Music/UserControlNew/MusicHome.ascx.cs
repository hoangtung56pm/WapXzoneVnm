using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class MusicHome : System.Web.UI.UserControl
    {
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtCat = Library.Component.Video.VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), 6, 0, (int)Constant.Video.Category, 10, 1, out totalrecord);
                Random rnd = new Random();
                while (dtCat.Rows.Count > 3)
                {
                    dtCat.Rows.RemoveAt(rnd.Next(0, dtCat.Rows.Count));
                    dtCat.AcceptChanges();
                }

                rptClipNhac.DataSource = dtCat;
                rptClipNhac.ItemDataBound += rptClipNhac_ItemDataBound;
                rptClipNhac.DataBind();

                rptMusicMoiNhat.DataSource = MusicController.GetItemTopHasCache(Session["telco"].ToString(), 5);
                rptMusicMoiNhat.DataBind();

                rptMusicHotThang.DataSource = MusicController.GetItemTopByAlbumHasCache(3, Session["telco"].ToString(), 5);
                rptMusicHotThang.DataBind();

                rptTopCaSy.DataSource = MusicController.GetArtistTopHasCache(5);
                rptTopCaSy.DataBind();

                rptTheLoai.DataSource = MusicController.GetStyleTopHasCache(5);
                rptTheLoai.DataBind();

                DataTable dtAlbum = MusicController.GetAlbumHotHasCache(Session["telco"].ToString());
                
                DataSet dsFirst = ConvertUtility.SplitDataTable(dtAlbum,3);
                DataTable dt1 = dsFirst.Tables[0];
                DataSet dsSecond = ConvertUtility.SplitDataTable(dsFirst.Tables[1], 3);
                DataTable dt2 = dsSecond.Tables[0];

                rptAlbum1.DataSource = dt1;
                rptAlbum1.DataBind();

                rptAlbum11.DataSource = dt1;
                rptAlbum11.DataBind();

                rptAlbum2.DataSource = dt2;
                rptAlbum2.DataBind();

                rptAlbum22.DataSource = dt2;
                rptAlbum22.DataBind();
            }
        }

        protected void rptClipNhac_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal)e.Item.FindControl("litBlank");
                if (lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}