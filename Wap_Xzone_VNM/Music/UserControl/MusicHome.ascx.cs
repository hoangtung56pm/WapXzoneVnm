using System;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class MusicHome : System.Web.UI.UserControl
    {
       
        protected string lang;
        protected string width;
        private static string preurl;
        private static int endOfIndex;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            if (!IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtCat = WapXzone_VNM.Library.Component.Video.VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), 31, 0, (int)Constant.Video.Category, 10, 1, out totalrecord);
                Random rnd = new Random();
                while (dtCat.Rows.Count > 3)
                {
                    dtCat.Rows.RemoveAt(rnd.Next(0, dtCat.Rows.Count));
                    dtCat.AcceptChanges();
                }

                rptVideo.DataSource = dtCat;
                rptVideo.ItemDataBound += new RepeaterItemEventHandler(rptVideo_ItemDataBound);
                rptVideo.DataBind();
                lnkVideoTiep.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang, width, "31");

                rptMoiNhat.DataSource = MusicController.GetItemTopHasCache(Session["telco"].ToString(), 5);
                rptMoiNhat.ItemDataBound += new RepeaterItemEventHandler(rptHotThang_ItemDataBound);
                rptMoiNhat.DataBind();
                lnkMoiNhatTiep.NavigateUrl = UrlProcess.GetMusicByOrderUrl(lang, width);

                rptHotThang.DataSource = MusicController.GetItemTopByAlbumHasCache(3, Session["telco"].ToString(), 5);
                rptHotThang.ItemDataBound += new RepeaterItemEventHandler(rptHotThang_ItemDataBound);
                rptHotThang.DataBind();
                lnkHotThangTiep.NavigateUrl = UrlProcess.GetMusicByAlbumUrl(lang, width, "3");

                DataTable dtAlbum = MusicController.GetAlbumHotHasCache(Session["telco"].ToString());
                endOfIndex = dtAlbum.Rows.Count - 1;
                rptAlbumChonloc.DataSource = dtAlbum;
                rptAlbumChonloc.ItemDataBound += new RepeaterItemEventHandler(rptAlbumChonloc_ItemDataBound);
                rptAlbumChonloc.DataBind();
                lnkAlbum.NavigateUrl = UrlProcess.GeMusicAlbumUrl(lang, width);

                rptTopCaSy.DataSource = MusicController.GetArtistTopHasCache(5);
                rptTopCaSy.ItemDataBound += new RepeaterItemEventHandler(rptTopCaSy_ItemDataBound); 
                rptTopCaSy.DataBind();
                lnkCaSy.NavigateUrl = UrlProcess.GeMusicArtistUrl(lang, width);

                rptTheLoai.DataSource = MusicController.GetStyleTopHasCache(5);
                rptTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptTheLoai_ItemDataBound);
                rptTheLoai.DataBind();
                lnkTheLoai.NavigateUrl = UrlProcess.GeMusicStyleUrl(lang, width);
                
                if (lang == "1") 
                {
                    
                }
                else
                {
                    ltrHotThang.Text = "HOT THANG";                    
                    ltrAlbumChonloc.Text = "ALBUM CHON LOC";
                    ltrTopCaSy.Text = "BAI HAT THEO CA SY";
                    ltrTheLoai.Text = "BAI HAT THEO THE LOAI";
                    lnkHotThangTiep.Text = lnkAlbum.Text = lnkCaSy.Text = lnkTheLoai.Text = "» Xem tiep";
                }
            }           
        }

        protected void rptHotThang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrBaihat = (Literal)e.Item.FindControl("ltrBaihat");            
            if (lang == "1")
            {
                ltrBaihat.Text = "<a href=\""+ UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"black bold\">" + curData["SongNameUnicode"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistNameUnicode"].ToString() + "</span></a>";
            }
            else
            {
                ltrBaihat.Text = "<a href=\""+ UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"black bold\">" + curData["SongName"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistName"].ToString() + "</span></a>";
            }
        }

        protected void rptAlbumChonloc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrAvatar = (Literal)e.Item.FindControl("ltrAvatar");
            Literal startDIV = (Literal)e.Item.FindControl("startDIV");
            Literal endDIV = (Literal)e.Item.FindControl("endDIV");

            endDIV.Text = "</div>";
            if (e.Item.ItemIndex % 3 == 0)
            {
                startDIV.Text = "<div class=\"rowcontent\"><div class=\"col1\">";
            }
            if (e.Item.ItemIndex % 3 == 1)
            {
                startDIV.Text = "<div class=\"col2\">";
            }
            if (e.Item.ItemIndex % 3 == 2)
            {
                startDIV.Text = "<div class=\"col3\">";
                endDIV.Text += "</div>";
            }
            if (e.Item.ItemIndex == endOfIndex && (e.Item.ItemIndex % 3 != 2))
            {
                endDIV.Text += "</div>";
            }

            ltrAvatar.Text = "<a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><img height=\"60\" width=\"60\" src=\"" + preurl + curData["Avatar"].ToString().Replace("~","") + "\" style=\"border: medium none;\"></a>";

            if (lang == "1")
            {
                ltrAvatar.Text += "<p><a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><span class=\"black\">" + curData["AlbumNameUnicode"].ToString() + "</span></a></p>";
            }
            else
            {
                ltrAvatar.Text += "<p><a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><span class=\"black\">" + curData["AlbumName"].ToString() + "</span></a></p>";
            }
        }

        protected void rptTopCaSy_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrCaSy = (Literal)e.Item.FindControl("ltrCaSy");
            if (lang == "1")
            {
                ltrCaSy.Text = "<a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black bold\">" + curData["ArtistNameUnicode"].ToString() + "</span></a>";
            }
            else
            {
                ltrCaSy.Text = "<a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black bold\">" + curData["ArtistName"].ToString() + "</span></a>";
            }
        }

        protected void rptTheLoai_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrTheLoai = (Literal)e.Item.FindControl("ltrTheLoai");
            if (lang == "1")
            {
                ltrTheLoai.Text = "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black\">" + curData["StyleNameUnicode"].ToString() + "</span></a>";
            }
            else
            {
                ltrTheLoai.Text = "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black\">" + curData["StyleName"].ToString() + "</span></a>";
            }
        }

        protected void rptVideo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            System.Web.UI.WebControls.Image imgAvatar = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            if (lang == "1")
            {
                lnkTenAnh.Text = "<span class=\"black bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"black bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"black bold\">" + curData["VTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"black bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../../Video/Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkXem.NavigateUrl = "../../Video/View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~", "");
        } 
    }
}