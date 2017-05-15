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
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Component.MT;
using log4net;

namespace WapXzone_VNM.Phanmem
{
    public partial class SendGift : BasePage
    {
        private int width;        
        private string lang;
        private string hotro;
        private int id;
        private string SoDT;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("appprice");
            lang = Request.QueryString["lang"];            
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            hotro = Request.QueryString["hotro"];
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            SoDT = Request.QueryString["sdt"];
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetAppHomeUrl(lang, width.ToString(), hotro).Replace("~/", "") + "\" >PHẦN MỀM<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetAppHomeUrl(lang, width.ToString(), hotro).Replace("~/", "") + "\" >PHAN MEM<a>";
            
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
                                
                DataTable dtDetail = PhanmemController.GetAPPDetailByID(Session["telco"].ToString(), id);
                if (dtDetail.Rows[0]["Web_Name"].ToString() == "Vmg_zone") price = "15000";

                //                
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("appcode") + " " + dtDetail.Rows[0]["AppID"].ToString() + " " + SoDT + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("appcommandcode") + "</b> để gửi tặng phần mềm <b>" + dtDetail.Rows[0]["AppNameUnicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("appcode") + " " + dtDetail.Rows[0]["AppID"].ToString() + " " + SoDT + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("appcommandcode") + "</b> de gui tang phan mem <b>" + dtDetail.Rows[0]["AppName"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    //pnlThongBao.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu + "phần mềm " + dtDetail.Rows[0]["AppNameUnicode"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo;
                    //    btnKhong.Text = Resources.Resource.btnKhong;
                    //}
                    //else
                    //{
                    //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD + "phan mem " + dtDetail.Rows[0]["AppName"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo_KD;
                    //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                    //}  
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "APP", Request.QueryString["id"].ToString());

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "APPGIFT", "APP_GIFT");

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "APPGIFT", "APP_GIFT", price, "D", "APP", Request.QueryString["id"]);

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
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "APP", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "APPGIFT", "APP_GIFT");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "APPGIFT", "APP_GIFT", price, "D", "APP", Request.QueryString["id"]);

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
            DataTable dtDetail = PhanmemController.GetAPPDetailByID(Session["telco"].ToString(), id);
            chitietGiaodich = "Phần mềm: " + dtDetail.Rows[0]["AppNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            SoDT = MobileUtils.ToSTDMobileNumber(SoDT);
            if (thuchien)
            {                    
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["AppNameUnicode"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong + " phần mềm " + dtDetail.Rows[0]["AppNameUnicode"].ToString();
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD;
                    lblTen.Text = dtDetail.Rows[0]["AppName"].ToString();
                    //lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong_KD + " phan mem " + dtDetail.Rows[0]["AppName"].ToString();
                };
                string url;
                try
                {
                    VMGGame.MOReceiver urlservice = new VMGGame.MOReceiver();
                    url = urlservice.VMG_ReturnUrlForApplication(ConvertUtility.ToString(dtDetail.Rows[0]["AppID"]), 0, Session["msisdn"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]), "XZONE", "WAP", Session["telco"].ToString(), "WAP.XZONE.VN", "", "");
                    int indexofhttp = url.IndexOf("http://");
                    if (indexofhttp == -1)
                    {
                        url = "http://" + url;
                    }
                    else
                    {
                        url = url.Substring(indexofhttp);
                    }
                }
                catch { url = ""; }            
                //string url = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "4", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                MTInfo mtInfo = new MTInfo();
                Random random = new Random();
                //Thông báo cho người được tặng                
                mtInfo.User_ID = SoDT;
                mtInfo.Service_ID = ConfigurationSettings.AppSettings.Get("appcommandcode");
                mtInfo.Command_Code = ConfigurationSettings.AppSettings.Get("appcode");
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                mtInfo.Total_Message = 1;
                mtInfo.Message_Index = 0;
                mtInfo.IsMore = 0;
                mtInfo.Content_Type = 0;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Message = "Ban nhan duoc qua tang phan mem " + dtDetail.Rows[0]["AppName"].ToString() + " tu so dien thoai " + "0" + Session["msisdn"].ToString().Remove(0, 2);
                MTController.SmsMtInsert(mtInfo);

                //MT thong bao cho nguoi gui tang biet
                mtInfo.Content_Type = 0;
                mtInfo.User_ID = Session["msisdn"].ToString();
                mtInfo.Message = "Ban da gui tang thanh cong phan mem " + dtDetail.Rows[0]["AppName"].ToString() + " toi so dt " + SoDT;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);

                //Build waplink send to customer and insert to MT table
                mtInfo.User_ID = SoDT;
                mtInfo.Message = "Tai phan mem duoc tang theo dia chi: " + url;
                mtInfo.Content_Type = 8;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);

                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 4);
                PhanmemController.SetDownloadCounter(Session["telco"].ToString(), id);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 4, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("So gui tang: " + SoDT);
            logger.Debug("Dich vu: Phan mem - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["AppName"].ToString() + " - id: " + id);
            logger.Debug("Phan mem Url:" + lnkDownload.NavigateUrl);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }
    }
}
