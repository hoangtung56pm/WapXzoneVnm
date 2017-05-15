using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen
{
    public partial class DownloadHigh : BasePage
    {

        private int width;
        private string lang;
        private int id;
        private int catID;
        private string chitietGiaodich = string.Empty;
        private string price;

        private string logPrice;

        private string linkStr, linkStr_KD;
        private string telCo;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            if (catID == ConvertUtility.ToInt32(AppEnv.GetSetting("thuphapid")))
                price = AppEnv.GetSetting("thuphapprice");
            else
                price = AppEnv.GetSetting("wallprice");

            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            telCo = AppEnv.CheckSessionTelco();

            //linkStr = "<a href=\"/" + UrlProcess.HinhNenHome() + "\" >HÌNH NỀN<a>";
            //linkStr_KD = "<a href=\"/" + UrlProcess.HinhNenHome() + "\" >HINH NEN<a>";

            if (!IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                #region Free Content

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region Old Content

                DataTable dtDetail = HinhNenController.GetWallpaperDetailByID(AppEnv.CheckSessionTelco(), id);
                if (dtDetail != null)
                {
                    chitietGiaodich = "Hinh nen: " + dtDetail.Rows[0]["WTitle"] + " -- id:" + id;
                }

                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("wallcode") + " " + dtDetail.Rows[0]["WCode"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("wallcommandcode") + "</b> để tải hình nền <b>" + dtDetail.Rows[0]["WTitle_Unicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("wallcode") + " " + dtDetail.Rows[0]["WCode"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("wallcommandcode") + "</b> de tai hinh nen <b>" + dtDetail.Rows[0]["WTitle"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            var charging = new Library.VNMCharging.VNMChargingGW();

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", chitietGiaodich);

                            if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                            {
                                messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", chitietGiaodich, out logPrice);
                                price = logPrice;
                            }

                            if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                            {
                                messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", chitietGiaodich);
                            }

                            if (messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true, true);
                            }
                            else
                            {// Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(false, true);
                            }
                            break;
                    }
                }

                #endregion
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = HinhNenController.GetWallpaperDetailByID(Session["telco"].ToString(), id);

            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", Request.QueryString["id"] + "Thu phap: " + dtDetail.Rows[0]["WTitle_Unicode"]);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", chitietGiaodich, out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "PICDOWN", "PIC_DOWN", price, "D", "WP", chitietGiaodich);
                    }

                    if (messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true,true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false, true);
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
            DataTable dtDetail = HinhNenController.GetWallpaperDetailByID(AppEnv.CheckSessionTelco(), id);
            if (thuchien)
            {
                if (lang == "1")
                {
                    //ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["WTitle_Unicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " hình nền " + dtDetail.Rows[0]["WTitle_Unicode"].ToString() + " (" + dtDetail.Rows[0]["WCode"].ToString() + ")";
                }
                else
                {
                    //ltrTieuDe.Text = linkStr_KD;
                    lblTen.Text = dtDetail.Rows[0]["WTitle"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " hình nền " + dtDetail.Rows[0]["WTitle"].ToString() + " (" + dtDetail.Rows[0]["WCode"].ToString() + ")";
                }
                lnkDownload.NavigateUrl = UrlProcess.GetDownloadItem(AppEnv.CheckSessionTelco(), "1", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                if (ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]) == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
                {
                    if(isLog)
                    {
                        chitietGiaodich = "Thu phap: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                        Transaction.Success(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 15);
                    }
                }
                else
                {
                   if(isLog)
                   {
                       chitietGiaodich = "Hinh nen: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                       Transaction.Success(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 1);
                   }
                }
                //if(isLog)
                //{
                    HinhNenController.SetDownloadCounter(AppEnv.CheckFreeContentTelco(), id);
                //}
            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    //ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    //ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                if (ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]) == ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thuphapid")))
                {
                    chitietGiaodich = "Thu phap: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                    if(isLog)
                    {
                        Transaction.Failure(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 15, messageReturn);
                    }
                }
                else
                {
                    chitietGiaodich = "Hinh nen: " + dtDetail.Rows[0]["WCode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                    if(isLog)
                    {
                        Transaction.Failure(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 1, messageReturn);
                    }
                }
                //--Thông báo lỗi thanh toán                
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Hinh nen - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["WTitle"].ToString() + " - id: " + id);
                logger.Debug("Wallpaper Url:" + lnkDownload.NavigateUrl);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log  
            }

        }

    }
}