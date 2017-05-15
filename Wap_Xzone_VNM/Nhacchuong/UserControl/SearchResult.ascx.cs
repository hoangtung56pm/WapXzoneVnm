using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Nhacchuong.UserControl
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;        
        private string key;
        protected void Page_Load(object sender, EventArgs e)
        {            
            width = Request.QueryString["w"];
            key = Request.QueryString["key"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {   
                if (lang == 1)
                {
                    ltrTenChuyenMuc.Text = "KẾT QUẢ TÌM KIẾM";
                }               
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = RTController.GetAllWap_RingTone_ItemByKey(Session["telco"].ToString(), key, pagesize, curpage, out totalrecord);
            rptResult.DataSource = dtCat;
            rptResult.ItemDataBound += new RepeaterItemEventHandler(rptResult_ItemDataBound);
            rptResult.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&id=" + Request.QueryString["id"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&id=" + Request.QueryString["id"] + "&cpage=";
            if (totalrecord == 0) Paging1.Visible = false;
            //end category list
            if (lang == 1)
            {
                ltrCount.Text = "Tìm thấy " + totalrecord + " nhạc chuông";
            }
            else
            {
                ltrCount.Text = "Tim thay " + totalrecord + " nhac chuong";
            }
            
        }
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
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