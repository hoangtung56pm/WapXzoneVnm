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
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int tpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int id;        
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
                DataTable dtDetail = RTController.GetRingToneDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                lnkCateChannel.NavigateUrl = UrlProcess.GetRingToneCategoryUrl(lang.ToString(), width, dtDetail.Rows[0]["W_RTCategoryID"].ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetRingToneHomeUrl(lang.ToString(), width);
                if (dtDetail.Rows.Count > 0)
                {
                    price = ConfigurationSettings.AppSettings.Get("ringtoneprice");;
                    if (lang == 1)
                    {
                        lnkHomeChannel.Text = "NHẠC";
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy + dtDetail.Rows[0]["ArtistNameUnicode"].ToString();                        
                        if (dtDetail.Rows[0]["AlbumNameUnicode"].ToString() != "unknown")
                            ltrNhom.Text = "Album: " + dtDetail.Rows[0]["AlbumNameUnicode"].ToString();
                        //ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang + price + Resources.Resource.wDonViTien;
                        lnkTai.Text = "<span class=\"bold\">"+ Resources.Resource.wTaiVe + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang;
                        ltrCungTheLoai.Text = Resources.Resource.rNhacCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongName"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy_KD + dtDetail.Rows[0]["ArtistName"].ToString();
                        if (dtDetail.Rows[0]["AlbumName"].ToString() != "unknown")
                            ltrNhom.Text = "Album: " + dtDetail.Rows[0]["AlbumName"].ToString();
                        //ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang_KD + price + Resources.Resource.wDonViTien_KD;
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang_KD;
                        ltrCungTheLoai.Text = Resources.Resource.rNhacCungTheLoai_KD;
                    }
                    lnkTai.NavigateUrl = "../Download.aspx?id=" + dtDetail.Rows[0]["W_RTItemID"].ToString() + "&lang=" + lang + "&w=" + width;                    
                    //Other
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = RTController.GetAllRingToneByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_RTCategoryID"]), 0, pagesize, tpage, out totaltopdownload);
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptTopdownload_ItemDataBound);
                    rptCungTheLoai.DataBind();
                    Paging1.totalrecord = totaltopdownload;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&tpage=";
                }
            }
            
        }
        protected void rptTopdownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void btnTang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SendGift.aspx?id=" + Request.QueryString["id"] + "&sdt=" + txtSoDienThoaiTang.Text.Trim() + "&lang=" + lang + "&w=" + width);
        }
    }
}