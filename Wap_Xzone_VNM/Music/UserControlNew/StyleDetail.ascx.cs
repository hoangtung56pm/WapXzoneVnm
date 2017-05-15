using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class StyleDetail : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private string StyleID;
        protected void Page_Load(object sender, EventArgs e)
        {

            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            StyleID = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetItemByStyleHasCache(Session["telco"].ToString(), StyleID, curpage, pagesize, out totalrecord);
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
                DataTable StyleInfo = MusicController.GetStyleByIDHasCache(StyleID);
                if (StyleInfo.Rows.Count > 0)
                {
                    if (lang == "1")
                    {
                        ltrStyleName.Text = StyleInfo.Rows[0]["StyleNameUnicode"].ToString();
                        ltrSobai.Text = Resources.Resource.wSoBai + totalrecord;
                    }
                    else
                    {
                        ltrStyleName.Text = StyleInfo.Rows[0]["StyleName"].ToString();
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
            Literal ltrCaSy = (Literal)e.Item.FindControl("ltrCaSy");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            if (lang == "1")
            {
                ltrBaihat.Text = "<a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongNameUnicode"] + "</a>";
                ltrCaSy.Text = "Ca sỹ:" + " <a <a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByArtistUrlNew(lang, width, curData["ArtistID"].ToString()) + "\">" + curData["ArtistNameUnicode"] + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                ltrBaihat.Text = "<a <a class=\"link-non-orange\" href=\"" + UrlProcess.GetMusicDetailUrlNew(lang, width, curData["W_MItemID"].ToString()) + "\">" + curData["SongName"] + "</a>";
                ltrCaSy.Text = "Ca sy:" + " <a <a class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByArtistUrlNew(lang, width, curData["ArtistID"].ToString()) + "\">" + curData["ArtistName"] + "</a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai_KD;
            }
            lnkTai.NavigateUrl = "../DownloadNew.aspx?id=" + curData["W_MItemID"] + "&lang=" + lang + "&w=" + width;
        }        
    }
}