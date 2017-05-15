using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlNew
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int tpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int id;
        private int catid;
        private string price;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                //Detail
                DataTable dtDetail = HinhNenController.GetWallpaperDetailByIDHasCache(Session["telco"].ToString(), id);
                catid = ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]);
                lnkCateChannel.NavigateUrl = UrlProcess.GetWallpaperCategoryUrlNew(lang.ToString(), width, catid.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetWallpaperHomeUrlNew(lang.ToString(), width);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    if (catid == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
                        price = ConfigurationSettings.AppSettings.Get("thuphapprice");
                    else
                        price = ConfigurationSettings.AppSettings.Get("wallprice");
                    if (lang == 1)
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        lnkHomeChannel.Text = "HÌNH NỀN";
                        ltrTenAnh.Text = dtDetail.Rows[0]["WTitle_Unicode"].ToString();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        lnkTai.Text = Resources.Resource.wTaiVe;
                        ltrCungTheLoai.Text = Resources.Resource.hnHinhCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["WTitle"].ToString();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        lnkTai.Text = Resources.Resource.wTaiVe_KD;
                        ltrCungTheLoai.Text = Resources.Resource.hnHinhCungTheLoai_KD;
                    }
                    lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(), width, dtDetail.Rows[0]["W_WItemID"].ToString(), catid.ToString());

                    if (dtDetail.Rows[0]["WThumnail"].ToString().LastIndexOf(".gif") > 0)
                    {
                        WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                        imgDetail.ImageUrl = preurl + ws.GetAvatarGif(dtDetail.Rows[0]["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 159, 127);
                    }
                    else
                    {
                        WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                        ws.GenerateAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 159, 127);
                        imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 159, 127).Replace("~", "");
                    }

                    //Other wallpaper
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catid, 0, pagesize, tpage, out totaltopdownload);
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += rptTopdownload_ItemDataBound;
                    rptCungTheLoai.DataBind();
                    Paging1.totalrecord = totaltopdownload;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&tpage=";
                    //end lastest wallpaper
                }
            }

        }
        protected void rptTopdownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            if(e.Item.ItemIndex < 2)
            {
                Literal litBlank = (Literal)e.Item.FindControl("litBlank");
                litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }

            DataRowView curData = (DataRowView)e.Item.DataItem;
            var imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            if (lang == 1)
            {
                lnkTenAnh.Text = curData["WTitle_Unicode"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"];
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                lnkTenAnh.Text = curData["WTitle"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai_KD;
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&catid=" + curData["W_CategoryID"].ToString();
            lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(), width, curData["W_WItemID"].ToString(), curData["W_CategoryID"].ToString());
            if (curData["WThumnail"].ToString().LastIndexOf(".gif") > 0)
            {
                WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                imgAvatar.ImageUrl = preurl + ws.GetAvatarGif(curData["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 82, 66);
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["WThumnail"].ToString(), 82, 66);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["WThumnail"].ToString(), 82, 66).Replace("~", "");
            }
        }
    }
}