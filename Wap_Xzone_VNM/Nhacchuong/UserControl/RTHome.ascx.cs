using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using System.Drawing;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Nhacchuong.UserControl
{
    public partial class RTHome : System.Web.UI.UserControl
    {
        private int pagesize = 5;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        private int lang;
        private string width;
        private static string preurl;        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];            
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);            
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
            {
                tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
            }
            int totalrecord = 0;
            if (lang == 0)
            {
                ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat_KD;
                ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat_KD;
            }
            else
            {
                ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat;
                ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat;
            }
            //Tải nhiều nhất
            DataTable dtHottest = RTController.GetAllRingToneByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 4, (int)Constant.RingTone.Topdownload, pagesize, curpage, out totalrecord);
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptHottest.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";
            
            //Mới nhất
            DataTable dtLatest = RTController.GetAllRingToneByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(),17,(int)Constant.RingTone.Lastest, pagesize, tpage, out totalrecord);
            rptLastest.DataSource = dtLatest;
            rptLastest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptLastest.DataBind();

            Paging2.totalrecord = totalrecord;
            Paging2.pagesize = pagesize;
            Paging2.numberpage = pagenumber;
            Paging2.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"];
            Paging2.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&tpage=";
            //Quảng cáo
            if (!IsPostBack)
            {
                var advertisementLevel2 = new VmgPortal.Modules.Adsvertising.Advertisement { Channel = "Home", Position = "GameVT1", Param = 0, Lang = Request.QueryString["lang"], Width = width.ToString() };
                ltrAdvLevel2.Text = advertisementLevel2.GetAds();
            }
        }
        
        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
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