using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video
{
    public partial class ViewNew : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("videopriceView");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetVideoHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >VIDEO<a>";

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
                    DataTable dtDetail = VideoController.GetVideoDetailByID(Session["telco"].ToString(), id);
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.clipchung + "0" + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> để tải video <b>" + dtDetail.Rows[0]["VTitle_Unicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> de tai video <b>" + dtDetail.Rows[0]["VTitle"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        try
                        {
                            switch (Session["telco"].ToString())
                            {
                                case "Vietnamobile":
                                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "VID", Request.QueryString["id"].ToString());

                                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "VIDEOVIEW", "VIDEO_VIEW");

                                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOVIEW", "VIDEO_VIEW", price, "D", "VID", Request.QueryString["id"]);

                                    ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                                    logger.Debug("---" + messageReturn + "---");
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
                        catch (Exception ex)
                        {
                            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                            logger.Debug("----------Lỗi charging----------------------");
                            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                            logger.Debug(ex.ToString());
                            logger.Debug("----------Lỗi charging----------------------");
                        }
                    }
                }
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            try
            {
                switch (Session["telco"].ToString())
                {
                    case "Vietnamobile":
                        WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                        //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "VID", Request.QueryString["id"].ToString());
                        //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "VIDEOVIEW", "VIDEO_VIEW");

                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOVIEW", "VIDEO_VIEW", price, "D", "VID", Request.QueryString["id"]);

                        ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                        logger.Debug("---" + messageReturn + "---");
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
            catch (Exception ex)
            {
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("----------Lỗi charging----------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug(ex.ToString());
                logger.Debug("----------Lỗi charging----------------------");
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
            chitietGiaodich = "Video view: " + dtDetail.Rows[0]["VTitle_Unicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeXem + "video";
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " video " + dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["VTitle"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeXem_KD + "video";
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " video " + dtDetail.Rows[0]["VTitle"].ToString();
                };

                lnkDownload.NavigateUrl = ConfigurationSettings.AppSettings.Get("vnmview") + dtDetail.Rows[0]["VMobilePath"].ToString().Replace("~/Upload/Video", "");
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 5);
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
            logger.Debug("Dich vu: Video - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["VTitle"].ToString() + " - id: " + id);
            logger.Debug("Video Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log             
        }       
    }
}