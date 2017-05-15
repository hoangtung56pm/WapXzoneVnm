using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hoangdao
{
    public partial class DownloadNew : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string level;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;
        private string ProductId;
        private string ProductKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            level = Request.QueryString["l"];
            if (level == "3")
            {
                price = ConfigurationSettings.AppSettings.Get("hoangdaothangprice");
                ProductId = "RELAXADVISESEX";
                ProductKey = "ADVISE_SEX";
            }
            else
            {
                price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
                ProductId = "RELAXADVISEBOOK";
                ProductKey = "ADVISE_BOOK";
            }
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetHoangdaoHomeUrlNew(lang, width.ToString()) +"\" >TỬ VI<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetHoangdaoHomeUrlNew(lang, width.ToString()) + "\" >TU VI<a>";
            string chitietGiaodich = "Hoang dao: level:" + level + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["transactionid_old"] != null)
                {// Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                    messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                    if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                    {// Thanh toán thành công >> trả nội dung
                        HienThiNoiDung(true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false);
                    }
                    Session["transactionid_old"] = null;
                }
                else
                {
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.hoangdao + level + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            switch (level)
                            {
                                case "1":
                                    ltrSMS.Text = "Soạn tin <b>HRD &lt;dd*mm&gt;</b> gửi <b>8279</b> để xem hoàng đạo theo ngày. Ví dụ bạn sinh ngày 07 tháng 11, soạn: HRD 07*11 gửi 8279" + Resources.Resource.wChon3G;
                                    break;
                                case "2":
                                    ltrSMS.Text = "Soạn tin <b>HRW &lt;dd*mm&gt;</b> gửi <b>8279</b> để xem hoàng đạo theo tuần. Ví dụ bạn sinh ngày 07 tháng 11, soạn HRW 07*11 gửi 8279" + Resources.Resource.wChon3G;
                                    break;
                                case "3":
                                    ltrSMS.Text = "Soạn tin <b>HRM &lt;dd*mm&gt;</b> gửi <b>8579</b> để xem hoàng đạo theo tháng. Ví dụ bạn sinh ngày 07 tháng 11, soạn: HRM 07*11 gửi 8579" + Resources.Resource.wChon3G;
                                    break;
                            }
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            switch (level)
                            {
                                case "1":
                                    ltrSMS.Text = "Soan tin <b>HRD &lt;dd*mm&gt;</b> gui <b>8279</b> de xem hoang dao theo ngay. Vi du ban sinh ngay 07 thang 11, soan: HRD 07*11 gui 8279" + Resources.Resource.wChon3G_KD;
                                    break;
                                case "2":
                                    ltrSMS.Text = "Soan tin <b>HRW &lt;dd*mm&gt;</b> gui <b>8279</b> de xem hoang dao theo tuan. Vi du ban sinh ngay 07 thang 11, soan: HRW 07*11 gui 8279" + Resources.Resource.wChon3G_KD;
                                    break;
                                case "3":
                                    ltrSMS.Text = "Soan tin <b>HRM &lt;dd*mm&gt;</b> gui <b>8579</b> de xem hoang dao theo thang. Vi du ban sinh ngay 07 thang 11, soan: HRM 07*11 gui 8579" + Resources.Resource.wChon3G_KD;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = true;
                        if (lang == "1")
                        {
                            ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                            //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                            ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "tử vi hoàng đạo";
                            btnCo.Text = Resources.Resource.btnCo;
                            btnKhong.Text = Resources.Resource.btnKhong;
                        }
                        else
                        {
                            ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                            //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                            ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "tu vi hoang dao";
                            btnCo.Text = Resources.Resource.btnCo_KD;
                            btnKhong.Text = Resources.Resource.btnKhong_KD;
                        }
                    }
                }
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "Tu vi", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), ProductId, ProductKey);

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), ProductId, ProductKey, price, "D", "Tu vi", Request.QueryString["id"]);

                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false);
                    }
                    break;
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            level = Request.QueryString["l"];

            if (thuchien)
            {
                int type;
                DateTime vTime = DateTime.Now;
                DataTable dtDetail = null;
                switch (level)
                {
                    case "1":
                        dtDetail = HoangdaoController.GetHodaDateByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO NGÀY";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["WapContent"].ToString(); }
                        }
                        else
                        {
                            ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO NGAY";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        };
                        break;
                    case "2":
                        dtDetail = HoangdaoController.GetHodaWeekByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO TUẦN";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["WapContent"].ToString(); }
                        }
                        else
                        {
                            ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO TUAN";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        };
                        break;
                    case "3":
                        dtDetail = HoangdaoController.GetHodaMonthByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        if (lang == "1")
                        {
                            ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO THÁNG";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["WapContent"].ToString(); }
                        }
                        else
                        {
                            ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO THANG";
                            lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        };
                        break;
                };
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), level + id.ToString(), "Hoang dao: level:" + level + " -- id:" + id.ToString(), 17);
            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), level + id.ToString(), "Hoang dao: level:" + level + " -- id:" + id.ToString(), 17, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Hoang dao - parameter: " + price + " - level: " + level + " - id: " + id.ToString());
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }
    }
}