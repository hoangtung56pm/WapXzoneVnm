using System;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.UserControlHigh
{
    public partial class Category : System.Web.UI.UserControl
    {

        //private string lang;
        //private int width;

        protected void Page_Load(object sender, EventArgs e)
        {
            //width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            //lang = Request.QueryString["lang"];
            //if (lang == "1")
            //{
                lnk20day.Text = "Kết quả 20 ngày liên tiếp";
                lnksoicau.Text = "Thống kê cặp số";
                lnktructiep.Text = "Kết quả chờ (trực tiếp)";
                lblOthersService.Text = "CÁC DỊCH VỤ";
                ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "KQ chờ " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien +

                    ", Thống kê cặp số " + AppEnv.GetSetting("kqchoprice") + Resources.Resource.wDonViTien +

                    ", Kết quả 20 ngày " + AppEnv.GetSetting("xs20price") + Resources.Resource.wDonViTien + ")";
            //}
            //else
            //{
            //    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "KQ cho " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien_KD +

            //        ", Thong ke cap so " + AppEnv.GetSetting("kqchoprice") + Resources.Resource.wDonViTien_KD +

            //        ", Ket qua 20 ngay " + AppEnv.GetSetting("xs20price") + Resources.Resource.wDonViTien_KD + ")";
            //}

            //lnksoicau.NavigateUrl = "../SoiCau.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;
            //lnktructiep.NavigateUrl = "../KQCho.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;
            //lnk20day.NavigateUrl = "../KQ20N.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;

            lnktructiep.NavigateUrl = UrlProcess.XoSoChiTiet(ConvertUtility.ToInt32(Request.QueryString["id"]),Constant.XoSo_KqCho_Rewrite);
            lnk20day.NavigateUrl = UrlProcess.XoSoChiTiet(ConvertUtility.ToInt32(Request.QueryString["id"]),Constant.XoSo_Kq20ngay_Rewrite);

        }

    }
}