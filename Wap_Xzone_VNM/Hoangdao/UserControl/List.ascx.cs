using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.Constant;


namespace WapXzone_VNM.Hoangdao.UserControl
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
                    ltrTieude.Text = HoangdaoController.CungHoangdao[type, 1].ToUpper() + " (" + HoangdaoController.CungHoangdao[type, 2] +  ")";                    
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
                lnkHomeChannel.NavigateUrl = UrlProcess.GetHoangdaoHomeUrl(lang.ToString(), width);
                DateTime vTime = DateTime.Now;
                DataTable dtDetail = null;
                //Link ngay
                string ngayThang = "";
                if (vTime.Day < 10)                
                    ngayThang = "0" + vTime.Day.ToString();
                else
                    ngayThang = vTime.Day.ToString();
                if (vTime.Month < 10)                
                    ngayThang += "0" + vTime.Month.ToString();
                else
                    ngayThang += vTime.Month.ToString();
                dtDetail = HoangdaoController.GetByTypeAndDateHasCache(type, ngayThang);                
                if (dtDetail.Rows.Count > 0)
                {                    
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {                 
                        //string content = cpid + "&" + Constant.hoangdao + "1" + dtDetail.Rows[0]["ID"].ToString() + "&" + price + "&" + vmstransactionid;
                        //lnkNgay.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey")));
                        lnkNgay.NavigateUrl = "../Download.aspx?l=1&id=" + dtDetail.Rows[0]["ID"].ToString() + "&lang=" + lang + "&w=" + width;
                        lnkNgay.Text = "<span class=\"blue bold\">" + lnkNgay.Text + "</span>";
                        lnkNgay.Enabled = true;
                    };
                };                
                //Link tuan
                int week = (int)((vTime.Day + 6) / 7);
                if (week == 5) week = 4;
                dtDetail = HoangdaoController.GetByTypeAndMonthAndWeekHasCache(type, vTime.Month.ToString(), week.ToString());                
                if (dtDetail.Rows.Count > 0)
                {                    
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        //string content = cpid + "&" + Constant.hoangdao + "2" + dtDetail.Rows[0]["ID"].ToString() + "&" + price + "&" + vmstransactionid;
                        //lnkTuan.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey")));
                        lnkTuan.NavigateUrl = "../Download.aspx?l=2&id=" + dtDetail.Rows[0]["ID"].ToString() + "&lang=" + lang + "&w=" + width;
                        lnkTuan.Text = "<span class=\"blue bold\">" + lnkTuan.Text + "</span>";
                        lnkTuan.Enabled = true;
                    }                    
                };
                //Link thang
                dtDetail = HoangdaoController.GetByTypeAndMonthHasCache(type, vTime.Month.ToString());                
                if (dtDetail.Rows.Count > 0)
                {                    
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {                        
                        //string content = cpid + "&" + Constant.hoangdao + "3" + dtDetail.Rows[0]["ID"].ToString() + "&" + price + "&" + vmstransactionid;
                        //lnkThang.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey")));
                        lnkThang.NavigateUrl = "../Download.aspx?l=3&id=" + dtDetail.Rows[0]["ID"].ToString() + "&lang=" + lang + "&w=" + width;
                        lnkThang.Text = "<span class=\"blue bold\">" + lnkThang.Text + "</span>";
                        lnkThang.Enabled = true;
                    }
                }
            }
        }
    }
}