using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.HoangDao;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using System.Globalization;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Hoangdao.UserControl
{
    public partial class Boivui_Trangdau : System.Web.UI.UserControl
    {
        private string width;
        private string lang;
        private int ngay;
        private int thang;
        private string price;
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        private string messageReturn = string.Empty;
        private string opr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {             
            cipher = Request.QueryString["link"];
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];

            lnkBoqua.NavigateUrl = UrlProcess.GetHoangdaoBoiVuiUrl(lang, width, "boqua");
            if (lang == "1")
            {
                ltrGia.Text = "Phí dịch vụ: Bói ngày " + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien
                    + ", bói tuần " + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien
                    + ", bói tháng " + ConfigurationSettings.AppSettings.Get("hoangdaothangprice") + Resources.Resource.wDonViTien;
                
            }
            else
            {
                ltrTieude.Text = "Ban se vui that la vui, hay buon oi la sau? Se that bai hay thanh cong ruc ro? Relax mot teo voi <b>Boi vui</b> cua <b>XFUN</b> ban nhe.";
                ltrHuongdan.Text = "Nhap ngay sinh theo mau, roi bam nut boi theo Ngay - Tuan - Thang";                                
                ltrGia.Text = "Phi dich vu: Boi ngay " + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien_KD
                    + ", boi tuan " + ConfigurationSettings.AppSettings.Get("hoangdaoprice") + Resources.Resource.wDonViTien_KD
                    + ", boi thang " + ConfigurationSettings.AppSettings.Get("hoangdaothangprice") + Resources.Resource.wDonViTien_KD;
            }
            if (Session["transactionid_old"] != null)
            {// Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                {// Thanh toán thành công >> trả nội dung
                    HienthiHoangDao(ConvertUtility.ToInt32(Request.QueryString["l"]), ConvertUtility.ToInt32(Request.QueryString["id"]), true);
                }
                else
                {// Thanh toán không thành công >> thông báo lỗi
                    HienthiHoangDao(ConvertUtility.ToInt32(Request.QueryString["l"]), ConvertUtility.ToInt32(Request.QueryString["id"]), false);
                }
                Session["transactionid_old"] = null;
            }
        }

        protected void btnNgay_Click(object sender, ImageClickEventArgs e)
        {
            DateTime vTime = DateTime.Now;
            thang = ConvertUtility.ToInt32(txtThang.Text.Trim());
            if (thang > 0 && thang < 13)
            {
                ngay = ConvertUtility.ToInt32(txtNgay.Text.Trim());
                int vSoNgay = DateTime.DaysInMonth(vTime.Year, thang);
                if (ngay > 0 && ngay <= vSoNgay)
                {
                    int type = CungHoangDao(ngay.ToString() + "/" + thang.ToString());
                    Session["HodaType"] = type.ToString();
                    string ngayThang = "";
                    if (vTime.Day < 10)
                        ngayThang = "0" + vTime.Day.ToString();
                    else
                        ngayThang = vTime.Day.ToString();
                    if (vTime.Month < 10)
                        ngayThang += "0" + vTime.Month.ToString();
                    else
                        ngayThang += vTime.Month.ToString();
                    DataTable dtDetail = HoangdaoController.GetByTypeAndDateHasCache(type, ngayThang);
                    if (dtDetail.Rows.Count > 0)
                    {
                        if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                        {
                            HienthiXacnhan(1, (int)dtDetail.Rows[0]["ID"]);
                        }
                    }
                }
            }            
        }

        protected void btnTuan_Click(object sender, ImageClickEventArgs e)
        {
            DateTime vTime = DateTime.Now;
            thang = ConvertUtility.ToInt32(txtThang.Text.Trim());
            if (thang > 0 && thang < 13)
            {
                ngay = ConvertUtility.ToInt32(txtNgay.Text.Trim());
                int vSoNgay = DateTime.DaysInMonth(vTime.Year, thang);
                if (ngay > 0 && ngay <= vSoNgay)
                {
                    int type = CungHoangDao(ngay.ToString() + "/" + thang.ToString());
                    Session["HodaType"] = type.ToString();
                    int week = (int)((vTime.Day + 6) / 7);
                    if (week == 5) week = 4;
                    DataTable dtDetail = HoangdaoController.GetByTypeAndMonthAndWeekHasCache(type, vTime.Month.ToString(), week.ToString());
                    if (dtDetail.Rows.Count > 0)
                    {
                        HienthiXacnhan(2, (int)dtDetail.Rows[0]["ID"]);
                    }
                }
            }
        }

        protected void btnThang_Click(object sender, ImageClickEventArgs e)
        {
            DateTime vTime = DateTime.Now;
            thang = ConvertUtility.ToInt32(txtThang.Text.Trim());
            if (thang > 0 && thang < 13)
            {
                ngay = ConvertUtility.ToInt32(txtNgay.Text.Trim());
                int vSoNgay = DateTime.DaysInMonth(vTime.Year, thang);
                if (ngay > 0 && ngay <= vSoNgay)
                {
                    int type = CungHoangDao(ngay.ToString() + "/" + thang.ToString());
                    Session["HodaType"] = type.ToString();
                    DataTable dtDetail = HoangdaoController.GetByTypeAndMonthHasCache(type, vTime.Month.ToString());
                    if (dtDetail.Rows.Count > 0)
                    {
                        HienthiXacnhan(3, (int)dtDetail.Rows[0]["ID"]);
                    }
                }
            }
        }

        protected void btnXacnhan_Click(object sender, EventArgs e)
        {
            try
            {
                switch (btnXacnhan.CommandName)
                {
                    case "1":
                        price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
                        break;
                    case "2":
                        price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
                        break;
                    case "3":
                        price = ConfigurationSettings.AppSettings.Get("hoangdaothangprice");
                        break;
                }
                
                switch (Session["telco"].ToString())
                {       
                    case "Vietnamobile":
                        WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                        //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "Tu vi", Request.QueryString["id"].ToString());
                        messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "", "");

                        if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                        {// Thanh toán thành công >> trả nội dung                                    
                            HienthiHoangDao(ConvertUtility.ToInt32(btnXacnhan.CommandName), ConvertUtility.ToInt32(Session["hodaID"]), true);
                        }
                        else
                        {// Thanh toán không thành công >> thông báo lỗi
                            HienthiHoangDao(ConvertUtility.ToInt32(Session["HodaType"]), ConvertUtility.ToInt32(btnXacnhan.CommandName), false);
                        }
                        break;                      
                }
            }
            catch (Exception ex)
            {
                log4net.ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("----------Lỗi charging----------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug(ex.ToString());
                logger.Debug("----------Lỗi charging----------------------");
            }            
        }

        protected void HienthiHoangDao(int level, int id, bool thucHien)
        {
            pnlNoidung.Visible = true;
            pnlXacnhan.Visible = false;             
            DateTime vTime = DateTime.Now;
            if (thucHien)
            {
                int type;
                DataTable dtDetail;
                switch (level.ToString())
                {
                    case "1":
                        dtDetail = HoangdaoController.GetHodaDateByIDHasCache(id);
                        if (dtDetail.Rows.Count > 0)
                        {
                            type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                            if (lang =="1")
                            {
                                ltrKieuboi.Text = "HOÀNG ĐẠO THEO NGÀY";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + dtDetail.Rows[0]["WapContent"].ToString();
                            }
                            else
                            {
                                ltrKieuboi.Text = "HOANG DAO THEO NGAY";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString());
                            }
                        }
                        break;
                    case "2":
                        dtDetail = HoangdaoController.GetHodaWeekByIDHasCache(id);
                        if (dtDetail.Rows.Count > 0)
                        {
                            type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                            if (lang == "1")
                            {
                                ltrKieuboi.Text = "HOÀNG ĐẠO THEO TUẦN";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + dtDetail.Rows[0]["WapContent"].ToString();
                            }
                            else
                            {
                                ltrKieuboi.Text = "HOANG DAO THEO TUAN";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString());
                            }
                        }
                        break;
                    case "3":
                        dtDetail = HoangdaoController.GetHodaMonthByIDHasCache(id);
                        if (dtDetail.Rows.Count > 0)
                        {
                            type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                            if (lang == "1")
                            {
                                ltrKieuboi.Text = "HOÀNG ĐẠO THEO THÁNG";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + dtDetail.Rows[0]["WapContent"].ToString();
                            }
                            else
                            {
                                ltrKieuboi.Text = "HOANG DAO THEO THANG";
                                ltrNoidung.Text = "<b>Cung " + HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")</b><br />" + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString());
                            }
                        }
                        break;
                }
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString() + level.ToString(), "Hoang dao: level:" + level + " - id:" + id.ToString(), 17);
            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    ltrKieuboi.Text = Resources.Resource.wThongBao;
                    ltrNoidung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    ltrKieuboi.Text = Resources.Resource.wThongBao_KD;
                    ltrNoidung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString() + level.ToString(), "Hoang dao: level:" + level + " - id:" + id.ToString(), 17, messageReturn);                
            }
            //log charging                                 
            log4net.ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Hoang dao - parameter: " + price + " - level:" + level + " - id:" + id.ToString());
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }

        protected void HienthiXacnhan(int level, int hodaID)
        {
            if (Session["telco"].ToString() == "Mobifone")
            {
                if (level == 3) price = ConfigurationSettings.AppSettings.Get("hoangdaothangprice");
                else price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
                string content = Session["cpid"].ToString() + "&" + Constant.hoangdao + level.ToString() + hodaID.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                //Response.Write(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
            }
            else if (Session["telco"].ToString() == "Undefined")
            {
                pnlTrangdau.Visible = false;
                pnlNoidung.Visible = true;
                if (lang == "1")
                {
                    ltrKieuboi.Text = Resources.Resource.wHuongDan;
                    switch (level.ToString())
                    {
                        case "1":
                            ltrNoidung.Text = "Soạn tin <b>HRD &lt;dd*mm&gt;</b> gửi <b>8279</b> để xem hoàng đạo theo ngày. Ví dụ bạn sinh ngày 07 tháng 11, soạn: HRD 07*11 gửi 8279" + Resources.Resource.wChon3G;
                            break;
                        case "2":
                            ltrNoidung.Text = "Soạn tin <b>HRW &lt;dd*mm&gt;</b> gửi <b>8279</b> để xem hoàng đạo theo tuần. Ví dụ bạn sinh ngày 07 tháng 11, soạn HRW 07*11 gửi 8279" + Resources.Resource.wChon3G;
                            break;
                        case "3":
                            ltrNoidung.Text = "Soạn tin <b>HRM &lt;dd*mm&gt;</b> gửi <b>8579</b> để xem hoàng đạo theo tháng. Ví dụ bạn sinh ngày 07 tháng 11, soạn: HRM 07*11 gửi 8579" + Resources.Resource.wChon3G;
                            break;
                    }
                }
                else
                {
                    ltrKieuboi.Text = Resources.Resource.wHuongDan_KD;
                    switch (level.ToString())
                    {
                        case "1":
                            ltrNoidung.Text = "Soan tin <b>HRD &lt;dd*mm&gt;</b> gui <b>8279</b> de xem hoang dao theo ngay. Vi du ban sinh ngay 07 thang 11, soan: HRD 07*11 gui 8279" + Resources.Resource.wChon3G_KD;
                            break;
                        case "2":
                            ltrNoidung.Text = "Soan tin <b>HRW &lt;dd*mm&gt;</b> gui <b>8279</b> de xem hoang dao theo tuan. Vi du ban sinh ngay 07 thang 11, soan: HRW 07*11 gui 8279" + Resources.Resource.wChon3G_KD;
                            break;
                        case "3":
                            ltrNoidung.Text = "Soan tin <b>HRM &lt;dd*mm&gt;</b> gui <b>8579</b> de xem hoang dao theo thang. Vi du ban sinh ngay 07 thang 11, soan: HRM 07*11 gui 8579" + Resources.Resource.wChon3G_KD;
                            break;
                    }
                }
            }
            else
            {                
                pnlTrangdau.Visible = pnlNoidung.Visible = false;
                pnlXacnhan.Visible = true;
                btnXacnhan.CommandName = level.ToString();
                Session["hodaID"] = hodaID.ToString();
                ltrXacnhan.Text = Resources.Resource.wXacNhanDichVu + "dịch vụ bói vui hoàng đạo";
                lnkHuy.NavigateUrl = UrlProcess.GetHoangdaoBoiVuiUrl(lang, width, "home");
            }
        }


        protected int CungHoangDao(string ngaySinh)
        {
            DateTime dateFrom;
            DateTime dateTo;
            DateTime dateNgaysinh;
            IFormatProvider culture = new CultureInfo("fr-FR", true);
            dateNgaysinh = DateTime.Parse(ngaySinh + "/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            
            dateFrom = DateTime.Parse("20/01/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("18/02/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <=dateNgaysinh &&  dateNgaysinh <= dateTo) return 11;

            dateFrom = DateTime.Parse("19/02/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("20/03/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 12;

            dateFrom = DateTime.Parse("21/03/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("19/04/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 1;

            dateFrom = DateTime.Parse("20/04/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("20/05/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 2;

            dateFrom = DateTime.Parse("21/05/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("21/06/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 3;

            dateFrom = DateTime.Parse("22/06/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("22/07/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 4;

            dateFrom = DateTime.Parse("23/07/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("22/08/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 5;

            dateFrom = DateTime.Parse("23/08/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("22/09/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 6;

            dateFrom = DateTime.Parse("23/09/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("22/10/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 7;

            dateFrom = DateTime.Parse("23/10/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("21/11/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 8;

            dateFrom = DateTime.Parse("22/11/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("21/12/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 9;

            dateFrom = DateTime.Parse("22/12/2011", culture, DateTimeStyles.NoCurrentDateDefault);
            dateTo = DateTime.Parse("19/01/2012", culture, DateTimeStyles.NoCurrentDateDefault);
            if (dateFrom <= dateNgaysinh && dateNgaysinh <= dateTo) return 10;
            return 0;
        }    
    }
}