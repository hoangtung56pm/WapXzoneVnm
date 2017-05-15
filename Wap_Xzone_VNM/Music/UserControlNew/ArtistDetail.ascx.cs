using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class ArtistDetail : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private string artistID;
        protected void Page_Load(object sender, EventArgs e)
        {

            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            artistID = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetItemByArtistHasCache(Session["telco"].ToString(), artistID, curpage, pagesize, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&cpage=";
            if (!IsPostBack)
            {
                DataTable ArtistInfo = MusicController.GetArtistByIDHasCache(artistID);
                if (ArtistInfo.Rows.Count > 0)
                {
                    if (lang == "1")
                    {
                        ltrArtistName.Text = ArtistInfo.Rows[0]["ArtistNameUnicode"].ToString();
                        ltrSobai.Text = Resources.Resource.wSoBai + totalrecord;
                    }
                    else
                    {
                        ltrArtistName.Text = ArtistInfo.Rows[0]["ArtistName"].ToString();
                        ltrSobai.Text = Resources.Resource.wSoBai_KD + totalrecord;
                    }
                }
            }
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrBaihat = (Literal)e.Item.FindControl("ltrBaihat");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            Literal ltrTheLoai = (Literal)e.Item.FindControl("ltrTheLoai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            if (lang == "1")
            {
                ltrBaihat.Text = "<a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongNameUnicode"] + "</a>";
                ltrTheLoai.Text = "Thể loại:" + "<a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByStyleUrlNew(lang, width, curData["StyleID"].ToString()) + "\">" + curData["StyleNameUnicode"] + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                ltrBaihat.Text = "<a <a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongName"] + "</a>";
                ltrTheLoai.Text = "The loai:" + "<a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByStyleUrlNew(lang, width, curData["StyleID"].ToString()) + "\">" + curData["StyleName"] + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai_KD;
            }
            lnkTai.NavigateUrl = "../DownloadNew.aspx?id=" + curData["W_MItemID"] + "&lang=" + lang + "&w=" + width;            
        }         
    }
}