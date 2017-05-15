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
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private static string preurl;
        private string keyWord;
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            keyWord = Server.HtmlDecode(ConvertUtility.ToString(Request.QueryString["key"]));
            type = ConvertUtility.ToInt32(Request.QueryString["type"]).ToString();
                        
            //start category list
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            int totalrecord = 0;
            DataTable dtCat = MusicController.SearchMusicItem(Session["telco"].ToString(), keyWord, type, curpage, pagesize, out totalrecord); 
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&type=" + Request.QueryString["type"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&type=" + Request.QueryString["type"] + "&cpage=";
        
            if (lang == "1")
            {
                ltrAlbumName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + keyWord + "</span>";
                switch (type)
                {
                    case "1":
                        ltrMota.Text = "Tìm theo tên bài hát<br />";
                        break;
                    case "2":
                        ltrMota.Text = "Tìm theo tên ca sỹ<br />";
                        break;
                }
                ltrSobai.Text = "Số kết quả: " + totalrecord.ToString();                    
            }
            else
            {
                ltrAlbumName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + keyWord + "</span>";
                switch (type)
                {
                    case "1":
                        ltrMota.Text = "Tim theo ten bai hat<br />";
                        break;
                    case "2":
                        ltrMota.Text = "Tim theo ten ca sy<br />";
                        break;
                }
                ltrSobai.Text ="So ket qua: " + totalrecord.ToString();
                ltrKetQua.Text = "KET QUA TIM KIEM";
            }                
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrBaihat = (Literal)e.Item.FindControl("ltrBaihat");
            Literal ltrTheLoai = (Literal)e.Item.FindControl("ltrTheLoai");            
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            if (lang == "1")
            {
                ltrBaihat.Text = "<a href=\"" + UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"bold\">" + curData["SongNameUnicode"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistNameUnicode"].ToString() + "</span></a>";
                ltrTheLoai.Text = Resources.Resource.wTheLoai + "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black\">" + curData["StyleNameUnicode"].ToString() + "</span></a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"black\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                ltrBaihat.Text = "<a href=\"" + UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"bold\">" + curData["SongName"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistName"].ToString() + "</span></a>";
                ltrTheLoai.Text = Resources.Resource.wTheLoai_KD + "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black\">" + curData["StyleName"].ToString() + "</span></a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"black\">" + Resources.Resource.wTang_KD + "</span>";
            }            
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_MItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString()) + "&g=1"; 
        }        
    }
}