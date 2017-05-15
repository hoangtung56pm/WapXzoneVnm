using System;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Hoangdao.UserControlNew
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
                    ltrTieude.Text = "TỬ VI";
                    lnkBaoBinh.Text =  HoangdaoController.CungHoangdao[1, 1] ;
                    lnkSongNgu.Text =  HoangdaoController.CungHoangdao[2, 1] ;
                    lnkDuongCuu.Text =  HoangdaoController.CungHoangdao[3, 1] ;
                    lnkKimNguu.Text =  HoangdaoController.CungHoangdao[4, 1] ;
                    lnkSongTu.Text =  HoangdaoController.CungHoangdao[5, 1] ;
                    lnkCuGiai.Text =  HoangdaoController.CungHoangdao[6, 1] ;
                    lnkSuTu.Text =  HoangdaoController.CungHoangdao[7, 1] ;
                    lnkXuNu.Text =  HoangdaoController.CungHoangdao[8, 1];
                    lnkThienBinh.Text =  HoangdaoController.CungHoangdao[9, 1] ;
                    lnkBoCap.Text =  HoangdaoController.CungHoangdao[10, 1] ;
                    lnkNhanMa.Text =  HoangdaoController.CungHoangdao[11, 1] ;
                    lnkNamDuong.Text =  HoangdaoController.CungHoangdao[12, 1] ;
                }
                else
                {
                    ltrTieude.Text = "TU VI";
                    lnkBaoBinh.Text =  HoangdaoController.CungHoangdao[1, 0] ;
                    lnkSongNgu.Text =  HoangdaoController.CungHoangdao[2, 0] ;
                    lnkDuongCuu.Text =  HoangdaoController.CungHoangdao[3, 0] ;
                    lnkKimNguu.Text =  HoangdaoController.CungHoangdao[4, 0] ;
                    lnkSongTu.Text =  HoangdaoController.CungHoangdao[5, 0] ;
                    lnkCuGiai.Text =  HoangdaoController.CungHoangdao[6, 0] ;
                    lnkSuTu.Text =  HoangdaoController.CungHoangdao[7, 0] ;
                    lnkXuNu.Text =  HoangdaoController.CungHoangdao[8, 0] ;
                    lnkThienBinh.Text =  HoangdaoController.CungHoangdao[9, 0] ;
                    lnkBoCap.Text =  HoangdaoController.CungHoangdao[10, 0] ;
                    lnkNhanMa.Text =  HoangdaoController.CungHoangdao[11, 0] ;
                    lnkNamDuong.Text =  HoangdaoController.CungHoangdao[12, 0] ;
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

                lnkBaoBinh.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "1");
                lnkSongNgu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "2");
                lnkDuongCuu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "3");
                lnkKimNguu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "4");
                lnkSongTu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "5");
                lnkCuGiai.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "6");
                lnkSuTu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "7");
                lnkXuNu.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "8");
                lnkThienBinh.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "9");
                lnkBoCap.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "10");
                lnkNhanMa.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "11");
                lnkNamDuong.NavigateUrl = UrlProcess.GetHoangdaoTypeUrlNew(lang, "list", width, "12");
            }
        }
    }
}