using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControl
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
            StyleID = Request.QueryString["id"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetItemByStyleHasCache(Session["telco"].ToString(), StyleID, curpage, pagesize, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
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
                        ltrStyleName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + StyleInfo.Rows[0]["StyleNameUnicode"].ToString() + "</span>";
                        ltrSobai.Text = Resources.Resource.wSoBai + totalrecord.ToString();                        
                    }
                    else
                    {
                        ltrStyleName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + StyleInfo.Rows[0]["StyleName"].ToString() + "</span>";
                        ltrSobai.Text = Resources.Resource.wSoBai_KD + totalrecord.ToString();                        
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
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            if (lang == "1")
            {
                ltrBaihat.Text = "<a href=\"" + UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"bold\">" + curData["SongNameUnicode"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistNameUnicode"].ToString() + "</span></a>";                
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"black\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                ltrBaihat.Text = "<a href=\"" + UrlProcess.GetMusicDetailUrl(lang, width, curData["W_MItemID"].ToString()) + "\"><span class=\"bold\">" + curData["SongName"].ToString() + "</span></a> - <a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, curData["ArtistID"].ToString()) + "\"><span class=\"black\">" + curData["ArtistName"].ToString() + "</span></a>";
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"black\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"black\">" + Resources.Resource.wTang_KD + "</span>";
            }            
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_MItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString()) + "&g=1"; 
        }        
    }
}