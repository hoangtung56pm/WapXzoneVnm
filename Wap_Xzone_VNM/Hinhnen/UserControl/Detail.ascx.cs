using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Hinhnen.UserControl
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
                if (ConvertUtility.ToInt32(Request.QueryString["g"]) == 1)
                    txtSoDienThoaiTang.Focus();
                //Detail
                DataTable dtDetail = HinhNenController.GetWallpaperDetailByIDHasCache(Session["telco"].ToString(), id);
                catid = ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]);
                lnkCateChannel.NavigateUrl = UrlProcess.GetWallpaperCategoryUrl(lang.ToString(), width, catid.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetWallpaperHomeUrl(lang.ToString(), width);
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
                        ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang + price + Resources.Resource.wDonViTien;
                        lnkTai.Text = "<span class=\"bold\">"+ Resources.Resource.wTaiVe + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang;
                        ltrCungTheLoai.Text = Resources.Resource.hnHinhCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["WTitle"].ToString();
                        ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang_KD + price + Resources.Resource.wDonViTien_KD;
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang_KD;
                        ltrCungTheLoai.Text = Resources.Resource.hnHinhCungTheLoai_KD;
                    }
                    lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrl(lang.ToString(), width, dtDetail.Rows[0]["W_WItemID"].ToString(), catid.ToString());
                    //lnkTai.NavigateUrl = "../Download.aspx?id=" + dtDetail.Rows[0]["W_WItemID"].ToString() + "&catid=" + catid.ToString() + "&lang=" + lang + "&w=" + width;
                    //WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    //ws.GenerateAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 120, 120);
                    //imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 120, 120).Replace("~", "");

                    if (dtDetail.Rows[0]["WThumnail"].ToString().LastIndexOf(".gif") > 0)
                    {
                        WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                        imgDetail.ImageUrl = preurl + ws.GetAvatarGif(dtDetail.Rows[0]["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 120, 120);
                    }
                    else
                    {
                        WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                        ws.GenerateAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 120, 120);
                        imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["WThumnail"].ToString(), 120, 120).Replace("~", "");
                    }
                    
                    //Other wallpaper
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catid, 0, pagesize, tpage, out totaltopdownload);
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptTopdownload_ItemDataBound);
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

        protected void btnTang_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("SendGift.aspx?id=" + Request.QueryString["id"] + "&catid=" + Request.QueryString["catid"] + "&sdt=" + txtSoDienThoaiTang.Text.Trim() + "&lang=" + lang + "&w=" + width);
            Response.Redirect(UrlProcess.GetWallpaperSendGiftUrl(lang.ToString(), width, Request.QueryString["id"], txtSoDienThoaiTang.Text.Trim(), catid.ToString()));
            
        }       
    }
}