using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class Album : System.Web.UI.UserControl
    {
        private int pagesize = 5;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                        
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetAlbumHasCache(Session["telco"].ToString(), curpage, pagesize, out totalrecord);
            rptlstCategory.DataSource = dtCat;            
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"]  + "&cpage=";
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrAlbum = (Literal)e.Item.FindControl("ltrAlbum");
            Literal ltrAvatar = (Literal)e.Item.FindControl("ltrAvatar");
            Literal ltrMota = (Literal)e.Item.FindControl("ltrMota");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            Literal ltrSobai = (Literal)e.Item.FindControl("ltrSobai");
            
            if (lang == "1")
            {
                ltrAlbum.Text = "<a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><span class=\"bold\">" + curData["AlbumNameUnicode"].ToString() + "</span></a>";
                if (!string.IsNullOrEmpty(curData["DescriptionUnicode"].ToString()))
                    ltrMota.Text = curData["DescriptionUnicode"].ToString() + "<br />";
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                ltrSobai.Text = Resources.Resource.wSoBai + curData["ItemCount"].ToString();
            }
            else
            {
                ltrAlbum.Text = "<a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><span class=\"bold\">" + curData["AlbumName"].ToString() + "</span></a>";
                if (!string.IsNullOrEmpty(curData["Description"].ToString()))
                    ltrMota.Text = curData["Description"].ToString() + "<br />";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                ltrSobai.Text = Resources.Resource.wSoBai_KD + curData["ItemCount"].ToString();
            } 
            
            if (curData["Avatar"].ToString().LastIndexOf(".gif") > 0)
            {
                WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                ltrAvatar.Text = "<a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><img class=\"thumb-b\" src=\"" + preurl + ws.GetAvatarGif(curData["Avatar"].ToString().Replace("~", "").Replace("thumb_", ""), 60, 60) + "\" alt=\"thumb\"></a>";                
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["Avatar"].ToString(), 60, 60);
                ltrAvatar.Text = "<a href=\"" + UrlProcess.GetMusicByAlbumUrl(lang, width, curData["W_MAlbumID"].ToString()) + "\"><img class=\"thumb-b\" src=\"" + preurl + MultimediaUtility.GetAvatarThumnail(curData["Avatar"].ToString(), 60, 60).Replace("~", "") + "\" alt=\"thumb\"></a>";                
            }
        }        
    }
}