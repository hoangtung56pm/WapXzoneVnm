using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music
{
    public partial class DownloadNew : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string messageReturn = string.Empty;
        private bool free = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("ringtoneprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                DataTable dtDetail = MusicController.GetItemDetailHasCache(Session["telco"].ToString(), id);
                //Miễn phí
                if (id == 2843)
                {
                    free = true;
                    HienThiNoiDung(true);
                    return;
                }
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> để tải bản nhạc <b>" + dtDetail.Rows[0]["SongNameUnicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> de tai ban nhac <b>" + dtDetail.Rows[0]["SongName"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    //pnlThongBao.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrTitle.Text = Resources.Resource.wThongBao;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "nhạc chuông " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo;
                    //    btnKhong.Text = Resources.Resource.btnKhong;
                    //}
                    //else
                    //{
                    //    ltrTitle.Text = Resources.Resource.wThongBao_KD;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "nhac chuong " + dtDetail.Rows[0]["SongName"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo_KD;
                    //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                    //}    

                    pnlThongBao.Visible = false;
                    try
                    {
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "TT", Request.QueryString["id"].ToString());

                                messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN");

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

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            try
            {
                switch (Session["telco"].ToString())
                {
                    case "Vietnamobile":
                        WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                        //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "TT", Request.QueryString["id"].ToString());

                        messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "MUSICDOWNLOAD", "MUSIC_DOWN");

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
            DataTable dtDetail = MusicController.GetItemDetailHasCache(Session["telco"].ToString(), id);
            chitietGiaodich = "Nhạc: " + dtDetail.Rows[0]["SongNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            if (thuchien)
            {
                DataTable dtKhuyenMai = MusicController.GetItemDetailRandom(Session["telco"].ToString(), id);
                string khuyenmaiID = ConvertUtility.ToString(dtKhuyenMai.Rows[0]["W_MItemID"]);
                lnkKhuyenMai.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "22", khuyenmaiID, SecurityMethod.MD5Encrypt(khuyenmaiID));
                if (lang == "1")
                {
                    ltrTieuDe.Text = "ÂM NHẠC";
                    lblTen.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " bản nhạc " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkKhuyenMai.Text = "Nhạc tặng: " + dtKhuyenMai.Rows[0]["SongNameUnicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = "AM NHAC";
                    lblTen.Text = dtDetail.Rows[0]["SongName"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " ban nhac " + dtDetail.Rows[0]["SongName"].ToString();
                    lnkKhuyenMai.Text = "Nhac tang: " + dtKhuyenMai.Rows[0]["SongName"].ToString();
                };
                lnkDownload.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "22", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));

                if (free != true)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 2);
                    MusicController.SetDownloadCounter(Session["telco"].ToString(), id);
                }
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 2, messageReturn);

                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            if (free != true)
            {
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Am nhac - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["SongName"].ToString() + " - id: " + id);
                logger.Debug("Am nhac Url:" + lnkDownload.NavigateUrl);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
            }
            //end log
        }        
    }
}