using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.Tintuc;
using System.Data;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private string display;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = ConvertUtility.ToInt32(Request.QueryString["w"]).ToString();            
            if (!IsPostBack)
            {
                display = ConvertUtility.ToString(Request.QueryString["display"]).ToLower();
                txtKeyword.Text = Server.HtmlDecode(Request.QueryString["key"]);
                string msisdn = ConvertUtility.ToString(Session["msisdn"]);
                if (lang == "1")
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chào <span class=\"pink bold\">khách</span>";
                    else ltrXinChao.Text = "Xin chào thuê bao <span class=\"pink bold\">" + msisdn + "</span>";
                }
                else
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chao <span class=\"pink bold\">khach</span>";
                    else ltrXinChao.Text = "Xin chao thue bao <span class=\"pink bold\">" + msisdn + "</span>";                    
                    lnkTrangChu.Text = "Trang chu";
                    lnkAmNhac.Text = "Am nhac";
                }
                
                lnkTrangChu.NavigateUrl = UrlProcess.GetWapHomeUrl(lang, width);
                lnkAmNhac.NavigateUrl = UrlProcess.GetMusicHomeUrl(lang, width);
                switch (display)
                { 
                    case "news":
                        ltrLienKet.Text = " » <span>Tin Showbiz</span>";
                        break;
                    case "ndt":
                        ltrLienKet.Text = " » <a href=\"" + UrlProcess.GetMusicNewsListUrl(lang, width) + "\" >Tin Showbiz</a>";
                        break;
                    case "album":
                        ltrLienKet.Text = " » <span>Album</span>";
                        break;
                    case "byalb":
                        ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicAlbumUrl(lang, width) + "\" >Album</a>";
                        break;
                    case "artist":
                        ltrLienKet.Text = " » <span>" + (lang == "1" ? "Theo ca sỹ" : "Theo ca sy") + "</span>";
                        break;
                    case "byart":
                        ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicArtistUrl(lang, width) + "\" >" + (lang == "1" ? "Theo ca sỹ" : "Theo ca sy") + "</a>";
                        break;
                    case "style":
                        ltrLienKet.Text = " » <span>" + (lang == "1" ? "Theo thể loại" : "Theo the loai") + "</span>";
                        break;
                    case "bysty":
                        ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicStyleUrl(lang, width) + "\" >" + (lang == "1" ? "Theo thể loại" : "Theo the loai") + "</a>";// » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                        break;
                    case "mdt":
                        ltrLienKet.Text = " » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                        break;
                    case "newest":
                        ltrLienKet.Text = " » <span>" + (lang == "1" ? "Theo thứ tự" : "Theo thu tu") + "</span>";
                        break;
                }

                string type = ConvertUtility.ToInt32(Request.QueryString["type"]).ToString();
                switch (type)
                {
                    case "0":
                        ddlDataType.SelectedIndex = 0;
                        break;
                    case "1":
                        ddlDataType.SelectedIndex = 1;
                        break;
                    case "2":
                        ddlDataType.SelectedIndex = 2;
                        break;                    
                }                
            }            
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            switch (ddlDataType.SelectedValue)
            {
                case "0":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrl(lang, width,txtKeyword.Text.Trim(), "0"));
                    break;
                case "1":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrl(lang, width, txtKeyword.Text.Trim(), "1"));
                    break;
                case "2":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrl(lang, width, txtKeyword.Text.Trim(), "2"));
                    break;
            }
        }
    }
}