using System;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class VideoHome : System.Web.UI.UserControl
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
            DataTable dtHottest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 3, -1, (int)Constant.Video.Topdownload, pagesize, curpage, out totalrecord);
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptHottest.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";
            
            //Mới nhất
            DataTable dtLatest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 1,  -1,(int)Constant.Video.Lastest,pagesize, tpage, out totalrecord);
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
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else 
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            lnkXem.NavigateUrl = "../View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~","");
        }       
    }
}