using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using System.Drawing;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Hinhnen.UserControl
{
    public partial class WallpaperHome : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;        
        //private int price;
        protected void Page_Load(object sender, EventArgs e)
        {
            //price = ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("wallprice"));
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
            DataTable dtHottest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 4, (int)Constant.HinhNen.Topdownload, pagesize, curpage, out totalrecord);
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptHottest.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";
            
            //Mới nhất
            DataTable dtLatest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(),2,(int)Constant.HinhNen.Lastest, pagesize, tpage, out totalrecord);
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
            System.Web.UI.WebControls.Image imgAvatar = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");            
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["WTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else 
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["WTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetWallpaperDetailUrl(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&catid=" + curData["W_CategoryID"].ToString();
            //lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_WItemID"].ToString() + "&catid=" + curData["W_CategoryID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrl(lang.ToString(), width, curData["W_WItemID"].ToString(), curData["W_CategoryID"].ToString());
            lnkTang.NavigateUrl = UrlProcess.GetWallpaperDetailUrl(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&g=1&catid=" + curData["W_CategoryID"].ToString();
            if (curData["WThumnail"].ToString().LastIndexOf(".gif") > 0)
            {
                WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                imgAvatar.ImageUrl = preurl + ws.GetAvatarGif(curData["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 60, 60);
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["WThumnail"].ToString(), 60, 60);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["WThumnail"].ToString(), 60, 60).Replace("~", "");
            }
        }       
    }
}