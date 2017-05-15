﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Transaction;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Component.MT;
using log4net;

namespace WapXzone_VNM.Video
{
    public partial class SendGift : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string SoDT;
        private string chitietGiaodich = string.Empty;

        private string price;
        private string logPrice;

        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("videoprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            SoDT = Request.QueryString["sdt"];
            telCo = Session["telco"].ToString();
            linkStr = linkStr_KD = "<a href=\"../" + UrlProcess.GetVideoHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >VIDEO<a>";

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                //Nếu số điện thoại không hợp lệ thì hướng dẫn
                if (!MobileUtils.IsMobileNumber(SoDT))
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = Resources.Resource.wSoDienThoaiKhongHopLe;
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = Resources.Resource.wSoDienThoaiKhongHopLe_KD;
                    }
                    return;
                }

                DataTable dtDetail = VideoController.GetVideoDetailByID(Session["telco"].ToString(), id);
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + " " + SoDT + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> để gửi tặng video <b>" + dtDetail.Rows[0]["VTitle_Unicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + " " + SoDT + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> de gui tang video <b>" + dtDetail.Rows[0]["VTitle"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            var charging = new Library.VNMCharging.VNMChargingGW();

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"]);

                            if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                            {
                                messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"],out logPrice);
                                price = logPrice;
                            }

                            if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                            {
                                messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"]);
                            }

                            if (messageReturn == "1")
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

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"]);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"],out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"]);
                    }

                    if (messageReturn == "1")
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
            DataTable dtDetail = VideoController.GetVideoDetailByID(Session["telco"].ToString(), id);
            chitietGiaodich = "Video: " + dtDetail.Rows[0]["VTitle_Unicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            SoDT = MobileUtils.ToSTDMobileNumber(SoDT);
            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong + " video " + dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["VTitle"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong_KD + " video " + dtDetail.Rows[0]["VTitle"].ToString();
                };

                string url = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "5", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                MTInfo mtInfo = new MTInfo();
                Random random = new Random();
                //Thông báo cho người được tặng
                mtInfo.User_ID = SoDT;
                mtInfo.Service_ID = ConfigurationSettings.AppSettings.Get("videocommandcode");
                mtInfo.Command_Code = ConfigurationSettings.AppSettings.Get("videocode");
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                mtInfo.Total_Message = 1;
                mtInfo.Message_Index = 0;
                mtInfo.IsMore = 0;
                mtInfo.Content_Type = 0;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Message = "Ban nhan duoc qua tang video " + dtDetail.Rows[0]["VTitle"].ToString() + " tu so dien thoai " + "0" + Session["msisdn"].ToString().Remove(0, 2);
                MTController.SmsMtInsert(mtInfo);

                //MT thong bao cho nguoi gui tang biet
                mtInfo.Content_Type = 0;
                mtInfo.User_ID = ConvertUtility.ToString(Session["msisdn"]);
                mtInfo.Message = "Ban da gui tang thanh cong video " + dtDetail.Rows[0]["VTitle"].ToString() + " toi so dt " + SoDT;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);

                //Build waplink send to customer and insert to MT table
                mtInfo.User_ID = SoDT;
                mtInfo.Message = "Tai video duoc tang theo dia chi: " + url;
                mtInfo.Content_Type = 8;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 5);
                VideoController.SetDownloadCounter(Session["telco"].ToString(), id);
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
                    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 5, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("So gui tang: " + SoDT);
            logger.Debug("Dich vu: Video - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["VTitle"].ToString() + " - id: " + id);
            logger.Debug("Video Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log            
        }
    }
}
