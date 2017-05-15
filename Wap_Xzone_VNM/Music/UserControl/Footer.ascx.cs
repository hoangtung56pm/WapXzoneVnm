using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class Footer : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private string display;
        protected void Page_Load(object sender, EventArgs e)
        {            
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = ConvertUtility.ToInt32(Request.QueryString["w"]).ToString();
            display = ConvertUtility.ToString(Request.QueryString["display"]).ToLower();
            string strTrangchu = string.Empty;
            if (Request.QueryString["lang"] == "1")
            {
                lnkNgonNgu.NavigateUrl = Request.RawUrl.Replace("lang=1", "lang=0");
                strTrangchu = "Trang chủ ";
            }
            else
            {
                lnkNgonNgu.NavigateUrl = Request.RawUrl.Replace("lang=0", "lang=1");
                lnkDauTrang.Text = "Dau trang";
                lnkNgonNgu.Text = "Có dấu";
                ltrHoTro.Text = "Ho tro: 19001255";
                ltrBanquyen.Text = "Bản quyền Vietnamobile";
                strTrangchu = "Trang chu ";
            }
            lnkDauTrang.NavigateUrl = Request.RawUrl + "#";            
            //
            lnkTrangChu.NavigateUrl = UrlProcess.GetWapHomeUrl(lang, width);
            lnkAmNhac.NavigateUrl = UrlProcess.GetMusicHomeUrl(lang, width);
            switch (display)
            {
                case "news":
                    ltrLienKet.Text = " » <span>Tin Showbiz</span>";
                    break;
                case "ndt":
                    ltrLienKet.Text = " » <a href=\"" + UrlProcess.GetMusicNewsListUrl(lang, width) + "\" >Tin Showbiz</a> » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                    break;
                case "album":
                    ltrLienKet.Text = " » <span>Album</span>";
                    break;
                case "byalb":
                    ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicAlbumUrl(lang, width) + "\" >Album</a> » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                    break;
                case "artist":
                    ltrLienKet.Text = " » <span>" + (lang == "1" ? "Theo ca sỹ" : "Theo ca sy") + "</span>";
                    break;
                case "byart":
                    ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicArtistUrl(lang, width) + "\" >" + (lang == "1" ? "Theo ca sỹ" : "Theo ca sy") + "</a> » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                    break;
                case "style":
                    ltrLienKet.Text = " » <span>" + (lang == "1" ? "Theo thể loại" : "Theo the loai") + "</span>";
                    break;
                case "bysty":
                    ltrLienKet.Text = " » <a href=\"" + UrlProcess.GeMusicStyleUrl(lang, width) + "\" >" + (lang == "1" ? "Theo thể loại" : "Theo the loai") + "</a> » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                    break;
                case "mdt":
                    ltrLienKet.Text = " » <span>" + (lang == "1" ? "Chi tiết" : "Chi tiet") + "</span>";
                    break;
            }
        }
    }
}