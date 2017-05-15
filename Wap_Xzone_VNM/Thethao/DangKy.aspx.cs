﻿using System;
using System.Web;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using WapXzone_VNM.Library.Component.Wap;
using log4net;

namespace WapXzone_VNM.Thethao
{
    public partial class DangKy : BasePage
    {
        private int width;
        private string lang;

        private string price;
        private string logPrice;

        private string telCo;
        private string chitietGiaodich;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            telCo = Session["telco"].ToString();

            price = ConfigurationSettings.AppSettings.Get("bongdathangprice");
            linkStr = "<a href=\"../" + UrlProcess.GetSportHomeUrl(lang, "home", width.ToString()).Replace("~/", "") + "\" >BÓNG ĐÁ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetSportHomeUrl(lang, "home", width.ToString()).Replace("~/", "") + "\" >BONG DA<a>";

            chitietGiaodich = "Bong da: thue bao ngay -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                //                
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
                            Library.VNMCharging.VNMChargingGW charging = new Library.VNMCharging.VNMChargingGW();

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao");

                            if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                            {
                                messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao",out logPrice);
                                price = logPrice;
                            }

                            if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                            {
                                messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao");
                            }

                            if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                WapController.W4A_Subscriber_Insert(Session["msisdn"].ToString(), 2, 1, "wap4a");
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
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao");

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao",out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", "dangkythethao");
                    }

                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        WapController.W4A_Subscriber_Insert(Session["msisdn"].ToString(), 2, 1, "wap4a");
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
                    ltrTieuDe.Text = linkStr + " » " + "THUÊ BAO NGÀY";
                    lblTen.Text = "Đăng ký thuê bao ngày";
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công thuê bao ngày dịch vụ bóng đá.<br /> Chúc bạn vui vẻ.";
                }
                else
                {
                    ltrTieuDe.Text = linkStr + " » " + "THUE BAO NGAY";
                    lblTen.Text = "Dang ky thue bao ngay";
                    ltrNoiDung.Text = "Ban da dang ky thanh cong thue bao ngay dich vu bong da.<br />Chuc ban vui ve.";
                };
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 19);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 19, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN: " + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Bong da - Thue bao ngay - parameter: " + price);
            logger.Debug("Chi tiet: " + chitietGiaodich);
            logger.Debug("IP: " + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error: " + messageReturn);
            logger.Debug("Current Url: " + Request.RawUrl);
            //end log
        }
    }
}