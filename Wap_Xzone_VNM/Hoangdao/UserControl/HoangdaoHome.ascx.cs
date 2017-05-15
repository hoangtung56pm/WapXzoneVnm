using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.HoangDao;

namespace WapXzone_VNM.Hoangdao.UserControl
{
    public partial class HoangdaoHome : System.Web.UI.UserControl
    {
        private string width;
        private string lang;
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                cipher = Request.QueryString["link"];
                lang = Request.QueryString["lang"];
                width = Request.QueryString["w"];
                
                if (lang == "1")
                {
                    ltrTieude.Text="TỬ VI";
                    lnkBaoBinh.Text =  "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[1,1] + "</span>";
                    lnkSongNgu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[2, 1] + "</span>";
                    lnkDuongCuu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[3, 1] + "</span>";
                    lnkKimNguu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[4, 1] + "</span>";
                    lnkSongTu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[5, 1] + "</span>";
                    lnkCuGiai.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[6, 1] + "</span>";
                    lnkSuTu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[7, 1] + "</span>";
                    lnkXuNu.Text =  "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[8,1];
                    lnkThienBinh.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[9, 1] + "</span>";
                    lnkBoCap.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[10, 1] + "</span>";
                    lnkNhanMa.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[11, 1] + "</span>";
                    lnkNamDuong.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[12, 1] + "</span>";
                }
                else
                {
                    ltrTieude.Text = "TU VI";
                    lnkBaoBinh.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[1, 0] + "</span>";
                    lnkSongNgu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[2, 0] + "</span>";
                    lnkDuongCuu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[3, 0] + "</span>";
                    lnkKimNguu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[4, 0] + "</span>";
                    lnkSongTu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[5, 0] + "</span>";
                    lnkCuGiai.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[6, 0] + "</span>";
                    lnkSuTu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[7, 0] + "</span>";
                    lnkXuNu.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[8, 0] + "</span>";
                    lnkThienBinh.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[9, 0] + "</span>";
                    lnkBoCap.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[10, 0] + "</span>";
                    lnkNhanMa.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[11, 0] + "</span>";
                    lnkNamDuong.Text = "<span class=\"blue bold\">" + HoangdaoController.CungHoangdao[12, 0] + "</span>";
                }
                lblNgayBaoBinh.Text = HoangdaoController.CungHoangdao[1, 2];
                lblNgaySongNgu.Text = HoangdaoController.CungHoangdao[2, 2];
                lblNgayDuongCuu.Text = HoangdaoController.CungHoangdao[3, 2];
                lblNgayKimNguu.Text = HoangdaoController.CungHoangdao[4, 2];
                lblNgaySongTu.Text = HoangdaoController.CungHoangdao[5, 2];
                lblNgayCuGiai.Text = HoangdaoController.CungHoangdao[6, 2];
                lblNgaySuTu.Text = HoangdaoController.CungHoangdao[7, 2];
                lblNgayXuNu.Text = HoangdaoController.CungHoangdao[8, 2];
                lblNgayThienBinh.Text = HoangdaoController.CungHoangdao[9, 2];
                lblNgayBoCap.Text = HoangdaoController.CungHoangdao[10, 2];
                lblNgayNhanMa.Text = HoangdaoController.CungHoangdao[11, 2];
                lblNgayNamDuong.Text = HoangdaoController.CungHoangdao[12, 2];

                lnkBaoBinh.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width,"1");
                lnkSongNgu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "2");
                lnkDuongCuu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "3");
                lnkKimNguu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "4");
                lnkSongTu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "5");
                lnkCuGiai.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "6");
                lnkSuTu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "7");
                lnkXuNu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "8");
                lnkThienBinh.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "9");
                lnkBoCap.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "10");
                lnkNhanMa.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "11");
                lnkNamDuong.NavigateUrl = UrlProcess.GetHoangdaoTypeUrl(lang, "list", width, "12");
            }
        }
    }
}