using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Thethao.UserControl
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
                lnkThongKeDacBiet.Text= "Thong ke dac biet";
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
            lnkThongKeDacBiet.NavigateUrl = UrlProcess.GetCompetitionUrl(lang.ToString(), width, "tkdb");
            lnkKQNgay.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "kqtdhn", width);
            lnkLTDNgay.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "ltdhn", width);
            lnkLTD.NavigateUrl = UrlProcess.GetCompetitionUrl(lang.ToString(), width, "ltd");
            lnkKQTD.NavigateUrl = UrlProcess.GetCompetitionUrl(lang.ToString(), width, "kqtd");
            lnkBXH.NavigateUrl = UrlProcess.GetCompetitionUrl(lang.ToString(), width, "bxh");

            lnkNhac.NavigateUrl = UrlProcess.GetMusicByAlbumUrl(lang.ToString(), width, "52");
            lnkVideo.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang.ToString(), width, "11");
            lnkAnh.NavigateUrl = UrlProcess.GetWallpaperCategoryUrl(lang.ToString(), width, "11");
        }        
    }
}