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
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class MusicDetail : System.Web.UI.UserControl
    {        
        private string lang;
        private string width;        
        private int id;        
        private string price;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            if (!IsPostBack)
            {
                if (ConvertUtility.ToInt32(Request.QueryString["g"]) == 1)
                    txtSoDienThoaiTang.Focus();
                //Detail
                DataTable dtDetail = MusicController.GetItemDetail(Session["telco"].ToString(), id);
                //end detail                
                if (dtDetail.Rows.Count > 0)
                {
                    price = ConfigurationSettings.AppSettings.Get("ringtoneprice");
                    
                    if (lang == "1")
                    {                        
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy + "<a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, dtDetail.Rows[0]["ArtistID"].ToString()) + "\">" + dtDetail.Rows[0]["ArtistNameUnicode"].ToString() + "</a>";
                        ltrNhom.Text = Resources.Resource.wTheLoai + "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, dtDetail.Rows[0]["StyleID"].ToString()) + "\">" + dtDetail.Rows[0]["StyleNameUnicode"].ToString() + "</a>"; 
                        ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;                        
                        lnkTai.Text = "<span class=\"bold\">"+ Resources.Resource.wTaiVe + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang;
                    }
                    else
                    {                        
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongName"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy_KD + "<a href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, dtDetail.Rows[0]["ArtistID"].ToString()) + "\">" + dtDetail.Rows[0]["ArtistName"].ToString() + "</a>";
                        ltrNhom.Text = Resources.Resource.wTheLoai_KD + "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, dtDetail.Rows[0]["StyleID"].ToString()) + "\">" + dtDetail.Rows[0]["StyleName"].ToString() + "</a>";                         
                        ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;                        
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang_KD;
                        lnkQuayLai.Text = "» Quay lai";
                    }
                    if (id == 2843)
                    {
                        if (lang == "1") ltrGiaTai.Text = "Miễn phí";
                        else ltrGiaTai.Text = "Mien phi";
                    }
                    lnkTai.NavigateUrl = "../Download.aspx?id=" + dtDetail.Rows[0]["W_MItemID"].ToString() + "&lang=" + lang + "&w=" + width;
                    lnkQuayLai.NavigateUrl = ConvertUtility.ToString(Session["LastMusicURL"]);
                }
            }            
        }        

        protected void btnTang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SendGift.aspx?id=" + Request.QueryString["id"] + "&sdt=" + txtSoDienThoaiTang.Text.Trim() + "&lang=" + lang + "&w=" + width);
        }
    }
}