using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hoangdao.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {
        private string width;
        private string lang;
        private static string preurl;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        private string price;
        private int type;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
            type = ConvertUtility.ToInt32(Request.QueryString["type"]);

            if (!IsPostBack)
            {
                width = Request.QueryString["w"];
                if (lang == "1")
                {
                    ltrTieude.Text = HoangdaoController.CungHoangdao[type, 1].ToUpper() + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                    lnkNgay.Text = "Hoàng đạo theo ngày";
                    lnkTuan.Text = "Hoàng đạo theo tuần";
                    lnkThang.Text = "Hoàng đạo theo tháng";
                    lnkHomeChannel.Text = "TỬ VI";
                    ltrGiaNgay.Text = ltrGiaTuan.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien + ")";
                    ltrGiaThang.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("hoangdaothangprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    ltrTieude.Text = HoangdaoController.CungHoangdao[type, 0].ToUpper() + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                    lnkNgay.Text = "Hoang dao theo ngay";
                    lnkTuan.Text = "Hoang dao theo tuan";
                    lnkThang.Text = "Hoang dao theo thang";
                    ltrGiaNgay.Text = ltrGiaTuan.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien_KD + ")";
                    ltrGiaThang.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("hoangdaothangprice") + Resources.Resource.wDonViTien_KD + ")";
                }
                lnkHomeChannel.NavigateUrl = UrlProcess.GetHoangdaoHomeUrlNew(lang, width);
                DateTime vTime = DateTime.Now;
                DataTable dtDetail = null;
                //Link ngay
                string ngayThang = "";
                if (vTime.Day < 10)
                    ngayThang = "0" + vTime.Day;
                else
                    ngayThang = vTime.Day.ToString();
                if (vTime.Month < 10)
                    ngayThang += "0" + vTime.Month;
                else
                    ngayThang += vTime.Month.ToString();
                dtDetail = HoangdaoController.GetByTypeAndDateHasCache(type, ngayThang);
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        lnkNgay.NavigateUrl = "../DownloadNew.aspx?l=1&id=" + dtDetail.Rows[0]["ID"] + "&lang=" + lang + "&w=" + width;
                        lnkNgay.Text = lnkNgay.Text;
                        lnkNgay.Enabled = true;
                    }
                }
                //Link tuan
                int week = (int)((vTime.Day + 6) / 7);
                if (week == 5) week = 4;
                dtDetail = HoangdaoController.GetByTypeAndMonthAndWeekHasCache(type, vTime.Month.ToString(), week.ToString());
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        lnkTuan.NavigateUrl = "../DownloadNew.aspx?l=2&id=" + dtDetail.Rows[0]["ID"] + "&lang=" + lang + "&w=" + width;
                        lnkTuan.Text = lnkTuan.Text ;
                        lnkTuan.Enabled = true;
                    }
                };
                //Link thang
                dtDetail = HoangdaoController.GetByTypeAndMonthHasCache(type, vTime.Month.ToString());
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        lnkThang.NavigateUrl = "../DownloadNew.aspx?l=3&id=" + dtDetail.Rows[0]["ID"] + "&lang=" + lang + "&w=" + width;
                        lnkThang.Text = lnkThang.Text;
                        lnkThang.Enabled = true;
                    }
                }
            }
        }
    }
}