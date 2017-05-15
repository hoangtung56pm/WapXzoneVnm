using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlNew
{
    public partial class LastestNews : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lblTitle.Text = "THƯ GIÃN";
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Truyện cười " + ConfigurationSettings.AppSettings.Get("relaxprice") + Resources.Resource.wDonViTien + ", Sex và cuộc sống " + ConfigurationSettings.AppSettings.Get("relaxsexprice") + Resources.Resource.wDonViTien + ", Gửi lời yêu thương, Cẩm năng tư vấn " + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    lblTitle.Text = "THU GIAN";
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Truyen cuoi " + ConfigurationSettings.AppSettings.Get("relaxprice") + Resources.Resource.wDonViTien + ", Sex va cuoc song " + ConfigurationSettings.AppSettings.Get("relaxsexprice") + Resources.Resource.wDonViTien + ", Gui loi yeu thuong, Cam nang tu van " + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien + ")";
                }
                //
                DataTable tbThueBao = WapController.W4A_Subscriber_GetInfo(ConvertUtility.ToString(Session["msisdn"]), 1);
                if (tbThueBao.Rows.Count > 0)
                {
                    lnkDangKy.NavigateUrl = string.Empty;
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Thuê bao đọc truyện";
                        lnkDangKy.Text = "Hạn sử dụng tới " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        ltrDangKy.Text = "Thue bao doc truyen";
                        lnkDangKy.Text = "Han su dung toi " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }
                }
                else
                {
                    lnkDangKy.NavigateUrl = "../DangKyNew.aspx?lang=" + lang + "&w=" + width;
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Đăng ký gói 30 ngày đọc truyện “tẹt ga”. Giá: " + ConfigurationSettings.AppSettings.Get("relaxtruyenprice") + Resources.Resource.wDonViTien + "/tháng";
                        lnkDangKy.Text = "Đăng ký";
                    }
                    else
                    {
                        ltrDangKy.Text = "Dang ky goi 30 ngay doc truyen “tet ga”. Gia: " + ConfigurationSettings.AppSettings.Get("relaxtruyenprice") + Resources.Resource.wDonViTien_KD + "/thang";
                        lnkDangKy.Text = "Dang ky";
                    }
                }
            }

        }
    }
}