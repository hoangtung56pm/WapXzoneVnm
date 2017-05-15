using System;
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
using WapXzone_VNM.Library.Component.MT;
using log4net;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music
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
        private string messageReturn = string.Empty;
        private bool free = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("ringtoneprice");
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            SoDT = Request.QueryString["sdt"];
            telCo = Session["telco"].ToString();

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
                        ltrHuongdan.Text = Resources.Resource.wHuongDan;
                        ltrSMS.Text = Resources.Resource.wSoDienThoaiKhongHopLe;
                    }
                    else
                    {
                        ltrHuongdan.Text = Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = Resources.Resource.wSoDienThoaiKhongHopLe_KD;
                    }
                    return;
                }

                DataTable dtDetail = MusicController.GetItemDetailHasCache(Session["telco"].ToString(), id);
                if (dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    chitietGiaodich = "Nhac: " + dtDetail.Rows[0]["SongName"] + " -- id:" + id;
                }

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
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + " " + SoDT + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> để gửi tặng bản nhạc <b>" + dtDetail.Rows[0]["SongNameUnicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + " " + SoDT + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> de gui tang ban nhac <b>" + dtDetail.Rows[0]["SongName"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    //pnlThongBao.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrTitle.Text =  Resources.Resource.wThongBao;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu + "nhạc chuông " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo;
                    //    btnKhong.Text = Resources.Resource.btnKhong;
                    //}
                    //else
                    //{
                    //    ltrTitle.Text = Resources.Resource.wThongBao_KD;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD + "nhac chuong " + dtDetail.Rows[0]["SongName"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo_KD;
                    //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                    //}
                    pnlThongBao.Visible = false;
                    try
                    {
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", chitietGiaodich);

                                if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                                {
                                    messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", chitietGiaodich,out logPrice);
                                    price = logPrice;
                                }

                                if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                                {
                                    messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", chitietGiaodich);
                                }

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
                        var charging = new Library.VNMCharging.VNMChargingGW();

                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", Request.QueryString["id"]);

                        if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                        {
                            messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", chitietGiaodich,out logPrice);
                            price = logPrice;
                        }

                        if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                        {
                            messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "MUSICUPLOAD", "MUSIC_GIFT", price, "D", "TT", chitietGiaodich);
                        }

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
            SoDT = MobileUtils.ToSTDMobileNumber(SoDT);
            if (thuchien)
            {
                DataTable dtKhuyenMai = MusicController.GetItemDetailRandom(Session["telco"].ToString(), id);
                string khuyenmaiID = ConvertUtility.ToString(dtKhuyenMai.Rows[0]["W_MItemID"]);
                lnkKhuyenMai.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "2", khuyenmaiID, SecurityMethod.MD5Encrypt(khuyenmaiID));
                if (lang == "1")
                {
                    ltrTieuDe.Text = "ÂM NHẠC";
                    lblTen.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong + " bản nhạc " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkKhuyenMai.Text = "Nhạc tặng: " + dtKhuyenMai.Rows[0]["SongNameUnicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = "AM NHAC";
                    lblTen.Text = dtDetail.Rows[0]["SongName"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong_KD + " ban nhac " + dtDetail.Rows[0]["SongName"].ToString();
                    lnkKhuyenMai.Text = "Nhac tang: " + dtKhuyenMai.Rows[0]["SongName"].ToString();
                };
                string url = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "2", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                MTInfo mtInfo = new MTInfo();
                Random random = new Random();
                //Thông báo cho người được tặng                
                mtInfo.User_ID = SoDT;
                mtInfo.Service_ID = ConfigurationSettings.AppSettings.Get("ringtonecommandcode");
                mtInfo.Command_Code = ConfigurationSettings.AppSettings.Get("ringtonecode");
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                mtInfo.Total_Message = 1;
                mtInfo.Message_Index = 0;
                mtInfo.IsMore = 0;
                mtInfo.Content_Type = 0;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Message = "Ban nhan duoc qua tang nhac chuong " + dtDetail.Rows[0]["Code"].ToString() + " tu so dien thoai " + "0" + Session["msisdn"].ToString().Remove(0, 2);
                MTController.SmsMtInsert(mtInfo);

                //MT thong bao cho nguoi gui tang biet
                mtInfo.Content_Type = 0;
                mtInfo.User_ID = Session["msisdn"].ToString();
                mtInfo.Message = "Ban da gui tang thanh cong nhac chuong " + dtDetail.Rows[0]["Code"].ToString() + " toi so dt " + SoDT;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);

                //Build waplink send to customer and insert to MT table
                mtInfo.User_ID = SoDT;
                mtInfo.Message = "Tai nhac chuong duoc tang theo dia chi: " + url;
                mtInfo.Content_Type = 8;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);
                if (free != true)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 2);
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
                logger.Debug("MSISDN: " + Session["msisdn"].ToString());
                logger.Debug("So gui tang: " + SoDT);
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
