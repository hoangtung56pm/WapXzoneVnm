using System;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlNew
{
    public partial class QuickMenu : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (lang == 0)
            {
                lnkThongKeDacBiet.Text = "Thong ke dac biet";
                lnkKQNgay.Text = "Ket qua hom nay";
                lnkLTDNgay.Text = "Lich thi dau hom nay";
                lnkLTD.Text = "Lich thi dau";
                lnkKQTD.Text = "Ket qua thi dau";
                lnkBXH.Text = "Bang xep hang";
                lnkNhac.Text = "Nhac chuong";
                //lnkVideo.Text = "Video clip";
                lnkAnh.Text = "Anh dep the thao";

                ltrDuLieuBongDa.Text = "DU LIEU BONG DA";
                ltrGiaiTriBongDa.Text = "GIAI TRI BONG DA";
            }
            lnkThongKeDacBiet.NavigateUrl = UrlProcess.GetCompetitionUrlNew(lang.ToString(), width, "tkdb");
            lnkKQNgay.NavigateUrl = UrlProcess.GetSportHomeUrlNew(lang.ToString(), "kqtdhn", width);
            lnkLTDNgay.NavigateUrl = UrlProcess.GetSportHomeUrlNew(lang.ToString(), "ltdhn", width);
            lnkLTD.NavigateUrl = UrlProcess.GetCompetitionUrlNew(lang.ToString(), width, "ltd");
            lnkKQTD.NavigateUrl = UrlProcess.GetCompetitionUrlNew(lang.ToString(), width, "kqtd");
            lnkBXH.NavigateUrl = UrlProcess.GetCompetitionUrlNew(lang.ToString(), width, "bxh");

            lnkNhac.NavigateUrl = UrlProcess.GetMusicByAlbumUrlNew(lang.ToString(), width, "52");
            lnkVideo.NavigateUrl = UrlProcess.GetVideoCategoryUrlNew(lang.ToString(), width, "11"); ;
            lnkAnh.NavigateUrl = UrlProcess.GetWallpaperCategoryUrlNew(lang.ToString(), width, "11"); ;
        }        
    }
}