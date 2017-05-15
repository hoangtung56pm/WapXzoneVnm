using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 6;
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
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&type=" + Request.QueryString["type"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&type=" + Request.QueryString["type"] + "&cpage=";

            if (lang == "1")
            {
                ltrAlbumName.Text = keyWord;
                switch (type)
                {
                    case "1":
                        ltrMota.Text = "Tìm theo tên bài hát<br />";
                        break;
                    case "2":
                        ltrMota.Text = "Tìm theo tên ca sỹ<br />";
                        break;
                }
                ltrSobai.Text = "Số kết quả: " + totalrecord;
            }
            else
            {
                ltrAlbumName.Text = keyWord;
                switch (type)
                {
                    case "1":
                        ltrMota.Text = "Tim theo ten bai hat<br />";
                        break;
                    case "2":
                        ltrMota.Text = "Tim theo ten ca sy<br />";
                        break;
                }
                ltrSobai.Text = "So ket qua: " + totalrecord;
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
            if (lang == "1")
            {
                ltrBaihat.Text = "<a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongNameUnicode"].ToString() + "</a> - <a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicByArtistUrlNew(lang, width, curData["ArtistID"].ToString()) + "\">" + curData["ArtistNameUnicode"].ToString() + "</a>";
                ltrTheLoai.Text = Resources.Resource.wTheLoai + "<a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByStyleUrlNew(lang, width, curData["StyleID"].ToString()) + "\">" + curData["StyleNameUnicode"].ToString() + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                ltrBaihat.Text = "<a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongName"].ToString() + "</a> - <a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicByArtistUrlNew(lang, width, curData["ArtistID"].ToString()) + "\">" + curData["ArtistName"].ToString() + "</a>";
                ltrTheLoai.Text = Resources.Resource.wTheLoai_KD + "<a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByStyleUrlNew(lang, width, curData["StyleID"].ToString()) + "\">" + curData["StyleName"].ToString() + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai_KD;
            }
            lnkTai.NavigateUrl = "../DownloadNew.aspx?id=" + curData["W_MItemID"] + "&lang=" + lang + "&w=" + width;
        }        
    }
}