using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music
{
    public partial class DownloadHigh : BasePage
    {

        private int width;
        private string lang;
        private int id;
        private string chitietGiaodich = string.Empty;

        private string price;
        private string logPrice;

        private string telCo;
        private string messageReturn = string.Empty;
        private bool free = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("ringtoneprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = AppEnv.CheckSessionTelco();
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

                #region OLD

                DataTable dtDetail = MusicController.GetItemDetailHasCache(telCo, id);
                if (dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    chitietGiaodich = "Nhac: " + dtDetail.Rows[0]["SongName"] + " -- id:" + id;
                }
                //Miễn phí
                if (id == 2843)
                {
                    free = true;
                    HienThiNoiDung(true, false);
                    return;
                }
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    //if (lang == "1")
                    //{
                    ltrHuongdan.Text = Resources.Resource.wHuongDan;
                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"] + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> để tải bản nhạc <b>" + dtDetail.Rows[0]["SongNameUnicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                    //}
                    //else
                    //{
                    //    ltrHuongdan.Text = Resources.Resource.wHuongDan_KD;
                    //    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"] + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> de tai ban nhac <b>" + dtDetail.Rows[0]["SongName"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    //}
                }
                else
                {
                    pnlThongBao.Visible = false;
                    try
                    {
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", chitietGiaodich);

                                if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                                {
                                    messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", chitietGiaodich, out logPrice);
                                    price = logPrice;
                                }

                                if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                                {
                                    messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", chitietGiaodich);
                                }

                                if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                                {
                                    // Thanh toán thành công >> trả nội dung                                    
                                    HienThiNoiDung(true, true);
                                }
                                else
                                {// Thanh toán không thành công >> thông báo lỗi
                                    HienThiNoiDung(false, true);
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                        logger.Debug("----------Lỗi charging----------------------");
                        logger.Debug(string.Format("MSISDN:{0}", Session["msisdn"]));
                        logger.Debug(ex.ToString());
                        logger.Debug("----------Lỗi charging----------------------");
                    }
                }

                #endregion

                

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
                        Library.VNMCharging.VNMChargingGW charging = new Library.VNMCharging.VNMChargingGW();

                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", Request.QueryString["id"]);

                        if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                        {
                            messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", chitietGiaodich, out logPrice);
                            price = logPrice;
                        }

                        if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                        {
                            messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN", price, "D", "TT", chitietGiaodich);
                        }

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
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger(Session["telco"].ToString());
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

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            pnlNoiDung.Visible = true;
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = MusicController.GetItemDetailHasCache(AppEnv.CheckFreeContentTelco(), id);
            //chitietGiaodich = "Nhạc: " + dtDetail.Rows[0]["SongNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            chitietGiaodich = "Nhạc: " + dtDetail.Rows[0]["SongNameUnicode"].ToString() + " -- id:" + id.ToString();
            if (thuchien)
            {
                DataTable dtKhuyenMai = MusicController.GetItemDetailRandom(AppEnv.CheckFreeContentTelco(), id);
                string khuyenmaiID = ConvertUtility.ToString(dtKhuyenMai.Rows[0]["W_MItemID"]);
                lnkKhuyenMai.NavigateUrl = UrlProcess.GetGameDownloadItem(AppEnv.CheckFreeContentTelco(), "22", khuyenmaiID, SecurityMethod.MD5Encrypt(khuyenmaiID));
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = "ÂM NHẠC";
                    lblTen.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " bản nhạc " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkKhuyenMai.Text = "Nhạc tặng: " + dtKhuyenMai.Rows[0]["SongNameUnicode"].ToString();
                //}
                //else
                //{
                //    ltrTieuDe.Text = "AM NHAC";
                //    lblTen.Text = dtDetail.Rows[0]["SongName"].ToString();
                //    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                //    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " ban nhac " + dtDetail.Rows[0]["SongName"].ToString();
                //    lnkKhuyenMai.Text = "Nhac tang: " + dtKhuyenMai.Rows[0]["SongName"].ToString();
                //}
                    lnkDownload.NavigateUrl = UrlProcess.GetGameDownloadItem(AppEnv.CheckFreeContentTelco(), "22", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));

                if (free != true)
                {
                    if(isLog)
                    {
                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 2);
                    }
                }

                MusicController.SetDownloadCounter(AppEnv.CheckFreeContentTelco(), id);

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
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 2, messageReturn);
                }

                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            if (free != true)
            {
                if(isLog)
                {
                    ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("--------------------------------------------------");
                    logger.Debug("MSISDN:" + Session["msisdn"]);
                    logger.Debug("Dich vu: Am nhac - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["SongName"] + " - id: " + id);
                    logger.Debug("Am nhac Url:" + lnkDownload.NavigateUrl);
                    logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                    logger.Debug("Error:" + messageReturn);
                    logger.Debug("Current Url:" + Request.RawUrl);
                }
            }
            //end log
        }
    }
}