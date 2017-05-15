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

namespace WapXzone_VNM.Music.UserControl
{
    public partial class Event_Music : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int catID = 139;
        private int lang;
        private string width;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if (lang == 0)
            {
                ltrTieude.Text = "Nhac chuong Olympic 2012";
                lnkXemthem.Text = "Xem them » ";
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("ringtoneprice") + Resources.Resource.wDonViTien_KD + "/nhac chuong)";
            }
            else
            {
                ltrTieude.Text = "Nhạc chuông Olympic 2012";
                lnkXemthem.Text = "Xem thêm » ";
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("ringtoneprice") + Resources.Resource.wDonViTien + "/nhạc chuông)";
            }
            lnkXemthem.NavigateUrl = UrlProcess.GetMusicByAlbumUrl(lang.ToString(), width, catID.ToString());
           
            //Sự kiện
            int totalrecord = 0;
            DataTable dtHottest = WapXzone_VNM.Library.Component.Music.MusicController.GetRandomItemByAlbumWithPaging(catID, "vietnamobile");
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptHottest.DataBind();
            //Paging1.totalrecord = totalrecord;
            //Paging1.pagesize = pagesize;
            //Paging1.numberpage = pagenumber;
            //Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&e=" + Request.QueryString["e"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"];
            //Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&e=" + Request.QueryString["e"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"] + "&b=";

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
            lnkTenAnh.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_MItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString()) + "&g=1"; 
        }       
    }
}