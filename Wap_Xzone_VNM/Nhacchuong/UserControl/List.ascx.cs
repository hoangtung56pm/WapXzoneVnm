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

namespace WapXzone_VNM.Nhacchuong.UserControl
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int catID;        
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            
            if (!IsPostBack)
            {                
                DataTable catInfo = RTController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                {
                    lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    lnkHomeChannel.Text = "NHẠC";
                }
                else
                    lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
                lnkCateChannel.NavigateUrl = UrlProcess.GetRingToneCategoryUrl(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetRingToneHomeUrl(lang.ToString(), width);
            }
            
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = RTController.GetAllRingToneByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.RingTone.Category, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
            //end category list            
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrCasy = (Literal)e.Item.FindControl("ltrCasy");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["SongNameUnicode"].ToString() + "</span>";
                ltrCasy.Text = Resources.Resource.wCaSy + curData["ArtistNameUnicode"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["SongName"].ToString() + "</span>";
                ltrCasy.Text = Resources.Resource.wCaSy_KD + curData["ArtistName"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkTenAnh.NavigateUrl = UrlProcess.GetRingToneDetailUrl(lang.ToString(), "detail", width, curData["W_RTItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_RTItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetRingToneDetailUrl(lang.ToString(), "detail", width, curData["W_RTItemID"].ToString()) + "&g=1"; 
        }        
    }
}