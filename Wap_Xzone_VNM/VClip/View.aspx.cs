using System;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.VClip.Library;
using System.Configuration;

namespace WapXzone_VNM.VClip
{
    public partial class View : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;
        private string opr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("XemMacDinh");
            lang = "1";// Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = " <h4 class=\"otherVideo\"><a  class=\"link-non-white\" href=\"/VClip/Default.aspx" + "\" >VIDEO<a> » ";

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
                    DataTable dtDetail = VideoController.GetVideoDetailByID(telCo, id);
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + Resources.Resource.wHuongDan + "</a></h4>";
                            ltrSMS.Text = "Soạn tin <b style=\"font-weight:bold\">" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + "</b> gửi <b style=\"font-weight:bold\">" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> để tải video <b>" + dtDetail.Rows[0]["VTitle_Unicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr + Resources.Resource.wHuongDan_KD + "</a></h4>";
                            ltrSMS.Text = "Soan tin <b style=\"font-weight:bold\">" + ConfigurationSettings.AppSettings.Get("videocode") + " " + dtDetail.Rows[0]["VID"].ToString() + "</b> gui <b style=\"font-weight:bold\">" + ConfigurationSettings.AppSettings.Get("videocommandcode") + "</b> de tai video <b>" + dtDetail.Rows[0]["VTitle"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        if (ConvertUtility.ToInt32(WapXzone_VNM.VClip.Library.AppEnv.GetSetting("ViettelConfirm")) == 0)
                        {
                            btnCo_Click(btnCo, EventArgs.Empty);
                        }
                        else
                        {
                            pnlThongBao.Visible = true;
                            if (lang == "1")
                            {
                                ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                                ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("tải", "xem") + "video " + dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                                btnCo.Text = Resources.Resource.btnCo;
                                btnKhong.Text = Resources.Resource.btnKhong;
                            }
                            else
                            {
                                ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao_KD;
                                //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                                ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("tai", "xem") + "video " + dtDetail.Rows[0]["VTitle"].ToString();
                                btnCo.Text = Resources.Resource.btnCo_KD;
                                btnKhong.Text = Resources.Resource.btnKhong_KD;
                            }
                        }
                    }
                }
            }
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
                }

                if (dtDetail.Rows.Count > 0)
                {
                    string viewLink;

                    if (!string.IsNullOrEmpty(dtDetail.Rows[0]["SmartPhonePath"].ToString()))
                        viewLink = dtDetail.Rows[0]["SmartPhonePath"].ToString();
                    else
                        viewLink = dtDetail.Rows[0]["VMobilePath"].ToString();

                    if (HttpContext.Current.Request.UserAgent != null)
                    {
                        if (HttpContext.Current.Request.UserAgent.ToLower().Contains("safari"))
                        {
                            lnkDownload.NavigateUrl = ConfigurationSettings.AppSettings.Get("vnmviewIphone") + viewLink.Replace("~/", "/");
                        }
                        else
                        {
                            lnkDownload.NavigateUrl = ConfigurationSettings.AppSettings.Get("vnmview") + viewLink.Replace("~/Upload/Video", "");
                        }
                    }
                    else
                    {
                        lnkDownload.NavigateUrl = ConfigurationSettings.AppSettings.Get("vnmview") + viewLink.Replace("~/Upload/Video", "");
                    }
                }

                //lnkDownload.NavigateUrl = ConfigurationSettings.AppSettings.Get("vnmview") + dtDetail.Rows[0]["VMobilePath"].ToString().Replace("~/Upload/Video", "");
                bool log = true;
                if (ConvertUtility.ToString(Session["transactionid_detail"]) == chitietGiaodich) log = false;
                Session["transactionid_detail"] = chitietGiaodich;
                if (log)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 5);
                }

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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 5, messageReturn);
                //--Thông báo lỗi thanh toán
            }


            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Info("Dich vu: Video - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["VTitle"].ToString() + " - id: " + id);
            logger.Info("Video Url:" + lnkDownload.NavigateUrl);
            string clientIP = HttpContext.Current.Request.UserHostAddress;
            if (Session["telco"].ToString() == Constant.T_Viettel)
            {
                clientIP = ConvertUtility.ToString(HttpContext.Current.Request.Headers.Get("VX-Forwarded-For"));
            }
            logger.Debug("IP:" + clientIP);
            logger.Debug("Current Url:" + Request.RawUrl);
            logger.Info("Header: " + Request.Headers.ToString());
            logger.Info("Current TransactionID: " + ConvertUtility.ToString(Session["transactionid"]));
            //end log  
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            try
            {
                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", Request.QueryString["id"]);

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
            }
            catch (Exception ex)
            {
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("----------Lỗi charging----------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug(ex.ToString());
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            string backurl = Session["LastPage"].ToString();
            Response.Redirect(backurl);
        }
    }
}