using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;

namespace WapXzone_VNM.Xoso.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private string lang;
        private int width;
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            lang = Request.QueryString["lang"];
            if (lang == "1")
            {
                lnk20day.Text = "Kết quả 20 ngày liên tiếp";
                lnksoicau.Text = "Thống kê cặp số";
                lnktructiep.Text = "Kết quả chờ (trực tiếp)";
                lblOthersService.Text = "CÁC DỊCH VỤ";
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "KQ chờ " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien +

                //    ", Thống kê cặp số " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien + 
                    
                //    ", Kết quả 20 ngày " + ConfigurationSettings.AppSettings.Get("xs20price") + Resources.Resource.wDonViTien + ")";                    
            }
            else
            {
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "KQ cho " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien_KD + 
                    
                //    ", Thong ke cap so " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + 
                    
                //    ", Ket qua 20 ngay " + ConfigurationSettings.AppSettings.Get("xs20price") + Resources.Resource.wDonViTien_KD + ")";
            }
            //lnksoicau.NavigateUrl = "../SoiCau.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;
            lnktructiep.NavigateUrl = "../KQCho.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;
            lnk20day.NavigateUrl = "../KQ20N.aspx?id=" + Request.QueryString["id"] + "&lang=" + lang + "&w=" + width;            
        }
    }
}