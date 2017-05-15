using System;
using System.Configuration;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian
{
    public partial class DangKyNew : BasePage
    {
        private int width;
        private string lang;
        private int parentCatID;
        private string price;
        private string telCo;
        private string chitietGiaodich;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            telCo = Session["telco"].ToString();
            parentCatID = 255;//Đọc truyện
            price = ConfigurationSettings.AppSettings.Get("relaxtruyenprice");
            linkStr = "<a href=\"../" + UrlProcess.GetRelaxHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >THƯ GIÃN<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetRelaxHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >THU GIAN<a>";

            chitietGiaodich = "Đọc truyện: thuê bao tháng 255 -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Bạn vui lòng" + Resources.Resource.wChon3G.Remove(0, 10);
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Ban vui long" + Resources.Resource.wChon3G_KD.Remove(0, 10);
                    }
                }
                else
                {
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "RELAX", "dangkydoctruyen");
                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "RELAXSTORYMONTHLY", "READ_MONTHLY");

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "RELAXSTORYMONTHLY", "READ_MONTHLY", price, "D", "RELAX", "dangkydoctruyen");

                            if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                            {
                                WapController.W4A_Subscriber_Insert(Session["msisdn"].ToString(), 1, 30, "wap4a");
                                // Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true);
                            }
                            else
                            {// Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(false);
                            }
                            break;
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

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "RELAX", "dangkydoctruyen");
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "RELAXSTORYMONTHLY", "READ_MONTHLY");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "RELAXSTORYMONTHLY", "READ_MONTHLY", price, "D", "RELAX", "dangkydoctruyen");

                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {
                        WapController.W4A_Subscriber_Insert(Session["msisdn"].ToString(), 1, 30, "wap4a");
                        // Thanh toán thành công >> trả nội dung                                    
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

            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr + " » " + "ĐỌC TRUYỆN";
                    lblTen.Text = "Đăng ký thuê bao tháng";
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công thuê bao tháng dịch vụ đọc truyện.<br /> Chúc bạn vui vẻ.";
                }
                else
                {
                    ltrTieuDe.Text = linkStr + " » " + "DOC TRUYEN";
                    lblTen.Text = "Dang ky thue bao thang";
                    ltrNoiDung.Text = "Ban da dang ky thanh cong thue bao thang dich vu doc truyen.<br />Chuc ban vui ve.";
                };
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "255", chitietGiaodich, 13);
            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    ltrTieuDe.Text = Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    ltrTieuDe.Text = Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "255", chitietGiaodich, 13, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Thu gian - Doc truyen - parameter: " + price);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log        
        } 
    }
}