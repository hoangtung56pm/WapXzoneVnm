using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Component.Transaction;
using log4net;

namespace WapXzone_VNM.Xoso
{
    public partial class KQ20N : BasePage
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
            price = ConfigurationSettings.AppSettings.Get("xs20price");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetXosoHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >XỔ SỐ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetXosoHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >XO SO<a>";
            
            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                DataTable ds = XosoController.GetInfobyCompanyID(id);
                string comname = ds.Rows[0]["company_name"].ToString();

                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
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
                        string content = Session["cpid"].ToString() + "&" + Constant.xoso +  "x12" + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();                        
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("xs20code") + " " + ds.Rows[0]["company_comment"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("xs20commandcode") + "</b> để nhận kết quả 20 phiên mở thưởng liên tiếp" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("xs20code") + " " + ds.Rows[0]["company_comment"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("xs20commandcode") + "</b> de nhan ket qua 20 phien mo thuong lien tiep" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        //pnlThongBao.Visible = true;
                        //if (lang == "1")
                        //{
                        //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDangKyDichVu + "dịch vụ kết quả 30 phiên " + comname;
                        //    btnCo.Text = Resources.Resource.btnCo;
                        //    btnKhong.Text = Resources.Resource.btnKhong;
                        //}
                        //else
                        //{
                        //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDangKyDichVu_KD + "dich vu ket qua 30 phien " + comname;
                        //    btnCo.Text = Resources.Resource.btnCo_KD;
                        //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                        //} 
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "XOSO20", Request.QueryString["id"].ToString());

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN");

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "XOSO20", Request.QueryString["id"]);

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

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "XOSO20", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "XOSO20", Request.QueryString["id"]);

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
            string comcode = XosoController.GetInfobyCompanyID(id).Rows[0]["company_comment"].ToString();
            string comname = XosoController.GetInfobyCompanyID(id).Rows[0]["company_name"].ToString();

            string chitietGiaodich = "KQXS 20 ngày: " + comname + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            if (thuchien)
            {   
                //insertMT
                mt = new MTInfo();
                mt.User_ID = Session["msisdn"].ToString();
                mt.Message = "Ban da dang ky thanh cong dich vu lay ket qua xo so 20 ngay lien tiep tinh " + comname + ". Cam on ban da su dung dich vu!";
                mt.Service_ID = ConfigurationSettings.AppSettings.Get("xs20commandcode");
                mt.Command_Code = ConfigurationSettings.AppSettings.Get("xs20code");
                mt.Message_Type = (int)Constant.MessageType.FREE;
                Random random = new Random();
                mt.Request_ID = random.Next(100000000, 999999999).ToString();
                mt.Total_Message = 1;
                mt.Message_Index = 0;
                mt.IsMore = 0;
                mt.Content_Type = 0;
                mt.ServiceType = 50;//servicetype of kq 20;
                MTController.SmsMtInsert(mt);

                //insert mt waitting 
                mtwaitting = new MTWaittingInfo();
                mtwaitting.User_ID = Session["msisdn"].ToString(); 
                mtwaitting.Message = ConfigurationSettings.AppSettings.Get("xs20code") + " " + comcode;
                mtwaitting.Service_ID = ConfigurationSettings.AppSettings.Get("xs20commandcode");
                mtwaitting.Command_Code = ConfigurationSettings.AppSettings.Get("xs20code");
                mtwaitting.Message_Type = (int)Constant.MessageType.FREE;
                mtwaitting.Request_ID = random.Next(100000000, 999999999).ToString();
                mtwaitting.Total_Message = 20;
                mtwaitting.Message_Index = 1;
                mtwaitting.IsMore = 0;
                mtwaitting.Content_Type = 0;
                mtwaitting.ServiceType = 50;//dv  ket qua 30 ngay
                mtwaitting.UniqueId = comcode;
                mtwaitting.ExpiredDate = DateTime.Now.AddDays(20);
                mtwaitting.PartnerID = string.Empty;
                mtwaitting.Operator = Session["telco"].ToString(); 
                MTController.SMS_MTXSWaittingInsert(mtwaitting);
                //
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr ;
                    lblTen.Text = "Xổ số 20 ngày liên tiếp";
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ lấy kết quả xổ số 20 ngày liên tiếp tỉnh " + comname + ".<br />Cảm ơn bạn đã sử dụng dịch vụ!"; 
                }
                else
                {
                    ltrTieuDe.Text =linkStr_KD;
                    lblTen.Text = "Xo so 20 ngay lien tiep";
                    ltrNoiDung.Text = "Ban da dang ky thanh cong dich vu lay ket qua xo so 20 ngay lien tiep tinh " + comname + ".<br />Cam on ban da su dung dich vu!";
                };
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 12);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 12, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Xo so - Ket qua 20 ngay - parameter: " + price + " - Tinh: " + comname + " - id: " + id);            
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }
    }
}
