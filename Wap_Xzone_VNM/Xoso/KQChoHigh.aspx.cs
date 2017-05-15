using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso
{
    public partial class KQChoHigh : BasePage
    {

        private int width;
        private string lang;
        private int id;
        private MTInfo mt;
        private MTWaittingInfo mtwaitting;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("kqchoxsprice");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"" + UrlProcess.XoSoHome() + "\" >XỔ SỐ</a>";
            //linkStr_KD = "<a href=\"../" + UrlProcess.GetXosoHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >XO SO<a>";

            if (!IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                DataTable ds = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
                    messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                    if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                    {// Thanh toán thành công >> trả nội dung                        
                        HienThiNoiDung(true,true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false,true);
                    }
                    Session["transactionid_old"] = null;
                }
                else
                {
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.xoso + "x11" + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        //if (lang == "1")
                        //{
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("kqchoxscode") + " " + ds.Rows[0]["company_comment"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("kqchoxscommandcode") + "</b> để nhận kết quả xổ số trực tiếp" + Resources.Resource.wChon3G;
                        //}
                        //else
                        //{
                        //    ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        //    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("kqchoxscode") + " " + ds.Rows[0]["company_comment"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("kqchoxscommandcode") + "</b> de nhan ket qua xo so truc tiep" + Resources.Resource.wChon3G_KD;
                        //}
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "XSKQCHO", Request.QueryString["id"]);

                                if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                                {// Thanh toán thành công >> trả nội dung                                    
                                    HienThiNoiDung(true,true);
                                }
                                else
                                {// Thanh toán không thành công >> thông báo lỗi
                                    HienThiNoiDung(false,true);
                                }
                                break;
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
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "XSKQCHO", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "XSKQCHO", Request.QueryString["id"]);

                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true,true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false,true);
                    }
                    break;
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable comXoSo = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));
            string companycode = comXoSo.Rows[0]["company_comment"].ToString();

            string chitietGiaodich = "Ket qua xo so truc tiep: " + companycode + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            if (thuchien)
            {
                //insertMT
                mt = new MTInfo();
                mt.User_ID = Session["msisdn"].ToString();
                mt.Message = "Ban da dang ky thanh cong dich vu lay ket qua truc tiep " + UnicodeUtility.UnicodeToKoDau(comXoSo.Rows[0]["company_name"].ToString()) + ". Cam on ban da su dung dich vu!";
                mt.Service_ID = ConfigurationSettings.AppSettings.Get("kqchoxscommandcode");
                mt.Command_Code = ConfigurationSettings.AppSettings.Get("kqchoxscode");
                mt.Message_Type = (int)Constant.MessageType.FREE;
                Random random = new Random();
                mt.Request_ID = random.Next(100000000, 999999999).ToString();
                mt.Total_Message = 1;
                mt.Message_Index = 0;
                mt.IsMore = 0;
                mt.Content_Type = 0;
                mt.ServiceType = 47;//servicetype of kq cho xo so;
                MTController.SmsMtInsert(mt);
                //insert mt waitting 
                mtwaitting = new MTWaittingInfo();
                mtwaitting.User_ID = Session["msisdn"].ToString();
                mtwaitting.Message = ConfigurationSettings.AppSettings.Get("kqchoxscode") + " " + companycode;
                mtwaitting.Service_ID = ConfigurationSettings.AppSettings.Get("kqchoxscommandcode");
                mtwaitting.Command_Code = ConfigurationSettings.AppSettings.Get("kqchoxscode");
                mtwaitting.Message_Type = (int)Constant.MessageType.FREE;
                mtwaitting.Request_ID = random.Next(100000000, 999999999).ToString();
                mtwaitting.Total_Message = 10;
                mtwaitting.Message_Index = 1;
                mtwaitting.IsMore = 0;
                mtwaitting.Content_Type = 0;
                mtwaitting.ServiceType = 47;//dv  ket qua cho
                mtwaitting.UniqueId = companycode;
                mtwaitting.ExpiredDate = DateTime.Now.AddDays(10);
                mtwaitting.PartnerID = string.Empty;
                mtwaitting.Operator = Session["telco"].ToString();
                MTController.SMS_MTWaittingInsert(mtwaitting);
                //
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = "XỔ SỐ";
                    lblTen.Text = "Kết quả xổ số trực tiếp";
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ lấy kết quả trực tiếp " + comXoSo.Rows[0]["company_name"].ToString() + ".<br />Cảm ơn bạn đã sử dụng dịch vụ!";
                //}
                //else
                //{
                //    ltrTieuDe.Text = "XO SO";
                //    lblTen.Text = "Ket qua xo so truc tiep";
                //    ltrNoiDung.Text = "Ban da dang ky thanh cong dich vu lay ket qua truc tiep " + UnicodeUtility.UnicodeToKoDau(comXoSo.Rows[0]["company_name"].ToString()) + ".<br />Cam on ban da su dung dich vu!";
                //};
                if(isLog)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 11);
                }
            }
            else
            {
                //Thông báo lỗi thanh toán
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                //}
                //else
                //{
                //    ltrTieuDe.Text = Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}
                if(isLog)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 11, messageReturn);
                }
                //--Thông báo lỗi thanh toán
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Xo so - Ket qua cho - parameter: " + price + " - Tinh: " + companycode + " - id: " + id);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
            
        }
    }
}