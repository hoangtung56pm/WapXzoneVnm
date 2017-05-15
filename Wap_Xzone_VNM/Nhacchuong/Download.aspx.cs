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
using WapXzone_VNM.Library.Component.Nhacchuong;
using log4net;

namespace WapXzone_VNM.Nhacchuong
{
    public partial class Download : BasePage
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
            price = ConfigurationSettings.AppSettings.Get("ringtoneprice");
            lang = Request.QueryString["lang"];            
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);            
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetRingToneHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >NHẠC<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetRingToneHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >NHAC<a>";
            
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
                    DataTable dtDetail = RTController.GetRingToneDetailByIDHasCache(Session["telco"].ToString(), id); 
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.nhacchuong + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();                        
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> để tải bản nhạc <b>" + dtDetail.Rows[0]["SongNameUnicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;                            
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("ringtonecode") + " " + dtDetail.Rows[0]["Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("ringtonecommandcode") + "</b> de tai ban nhac <b>" + dtDetail.Rows[0]["SongName"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = true;
                        if (lang == "1")
                        {
                            ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                            //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                            ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "nhạc chuông " + dtDetail.Rows[0]["SongNameUnicode"].ToString();
                            btnCo.Text = Resources.Resource.btnCo;
                            btnKhong.Text = Resources.Resource.btnKhong;
                        }
                        else
                        {
                            ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                            //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                            ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "nhac chuong " + dtDetail.Rows[0]["SongName"].ToString();
                            btnCo.Text = Resources.Resource.btnCo_KD;
                            btnKhong.Text = Resources.Resource.btnKhong_KD;
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
                    messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "TT", Request.QueryString["id"].ToString());
                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false);
                    }
                    break;
                case "Vinaphone":
                    messageReturn = Vinaphone_Charging.ReturnChargingResult(Session["msisdn"].ToString(), price);
                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "0")
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
            DataTable dtDetail = RTController.GetRingToneDetailByIDHasCache(Session["telco"].ToString(), id);                
            chitietGiaodich = "Nhạc: " + dtDetail.Rows[0]["SongNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);                
            if (thuchien)
            {   
                DataTable dtKhuyenMai = RTController.GetRingToneDetailRandom(Session["telco"].ToString(), id);
                string khuyenmaiID = ConvertUtility.ToString(dtKhuyenMai.Rows[0]["W_RTItemID"]);
                lnkKhuyenMai.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "2", khuyenmaiID, SecurityMethod.MD5Encrypt(khuyenmaiID));                
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " bản nhạc " + dtDetail.Rows[0]["SongNameUnicode"].ToString() ;
                    lnkKhuyenMai.Text = "Nhạc tặng: " + dtKhuyenMai.Rows[0]["SongNameUnicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD;
                    lblTen.Text = dtDetail.Rows[0]["SongName"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " ban nhac " + dtDetail.Rows[0]["SongName"].ToString() ;
                    lnkKhuyenMai.Text = "Nhac tang: " + dtKhuyenMai.Rows[0]["SongName"].ToString();
                };
                lnkDownload.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "2", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 2);
                RTController.SetDownloadCounter(Session["telco"].ToString(), id);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 2, messageReturn);
             
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Nhac chuong - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["SongName"].ToString() + " - id: " + id);
            logger.Debug("Nhac chuong Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }        
    }
}
