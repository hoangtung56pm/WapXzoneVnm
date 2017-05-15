using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem
{
    public partial class DownloadHigh : BasePage
    {

        private int width;
        private string lang;
        private string hotro;
        private int id;
        private string chitietGiaodich = string.Empty;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("appprice");
            lang = Request.QueryString["lang"];
            hotro = Request.QueryString["hotro"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = AppEnv.CheckSessionTelco();
            linkStr = "<a href=\"" + UrlProcess.PhanMemHome() + "\" >PHẦN MỀM</a>";
            //linkStr_KD = "<a href=\"../" + UrlProcess.GetAppHomeUrl(lang, width.ToString(), hotro).Replace("~/", "") + "\" >PHAN MEM<a>";

            //HienThiNoiDung(true, false);
            //return;

            if (!IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                #region Free Content

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region OLD

                DataTable dtDetail = PhanmemController.GetAPPDetailByID(AppEnv.CheckSessionTelco(), id);
                if (dtDetail.Rows[0]["Web_Name"].ToString() == "Vmg_zone") price = "15000";
                if (telCo == Constant.T_Mobifone)
                {
                    string content = Session["cpid"] + "&" + Constant.ungdungchung + id + "&" + price + "&" + Session["transactionid"];
                    Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                }
                //                
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    //if (lang == "1")
                    //{
                    ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                    ltrSMS.Text = "Soạn tin <b>" + AppEnv.GetSetting("appcode") + " " + dtDetail.Rows[0]["AppID"] + "</b> gửi <b>" + AppEnv.GetSetting("appcommandcode") + "</b> để tải phần mềm <b>" + dtDetail.Rows[0]["AppNameUnicode"] + "</b> về máy" + Resources.Resource.wChon3G;
                    //}
                    //else
                    //{
                    //    ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                    //    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("appcode") + " " + dtDetail.Rows[0]["AppID"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("appcommandcode") + "</b> de tai phan mem <b>" + dtDetail.Rows[0]["AppName"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    //}
                }
                else
                {
                    //pnlThongBao.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "phần mềm " + dtDetail.Rows[0]["AppNameUnicode"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo;
                    //    btnKhong.Text = Resources.Resource.btnKhong;
                    //}
                    //else
                    //{
                    //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "phan mem " + dtDetail.Rows[0]["AppName"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo_KD;
                    //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                    //}
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            var charging = new Library.VNMCharging.VNMChargingGW();

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "APP", Request.QueryString["id"].ToString());

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "APPDOWN", "APP_DOWN");

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "APPDOWN", "APP_DOWN", price, "D", "APP", Request.QueryString["id"]);

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
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "APP", Request.QueryString["id"].ToString());

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "APPDOWN", "APP_DOWN");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "APPDOWN", "APP_DOWN", price, "D", "APP", Request.QueryString["id"]);

                    if (messageReturn == "1")
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

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = PhanmemController.GetAPPDetailByID(AppEnv.CheckSessionTelco(), id);
            //chitietGiaodich = "Phần mềm: " + dtDetail.Rows[0]["AppNameUnicode"] + " -- id:" + id + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            chitietGiaodich = "Phần mềm: " + dtDetail.Rows[0]["AppNameUnicode"] + " -- id:" + id;
            if (thuchien)
            {
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = linkStr;
                    lblTen.Text = dtDetail.Rows[0]["AppNameUnicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " phần mềm " + dtDetail.Rows[0]["AppNameUnicode"].ToString();
                //}
                //else
                //{
                //    ltrTieuDe.Text = linkStr_KD;
                //    lblTen.Text = dtDetail.Rows[0]["AppName"].ToString();
                //    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                //    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " phan mem " + dtDetail.Rows[0]["AppName"].ToString();
                //}
                string url;
                try
                {
                    string appId = ConvertUtility.ToString(dtDetail.Rows[0]["AppID"]);
                    string msisdn = ConvertUtility.ToString(AppEnv.CheckMsisdn());
                    int partnerId = ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]);
                    string telco = ConvertUtility.ToString(AppEnv.CheckSessionTelco());

                    var urlservice = new VMGGame.MOReceiver();
                    url = urlservice.VMG_ReturnUrlForApplication(
                        appId, 
                        0, 
                        msisdn, 
                        partnerId,
                        "XZONE", 
                        "WAP", 
                        telco,
                        "WAP.XZONE.VN", 
                        "", 
                        "");

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
                lnkDownload.NavigateUrl = url;

                if(isLog)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, lnkDownload.NavigateUrl, id.ToString(), chitietGiaodich, 4);
                }
                PhanmemController.SetDownloadCounter(AppEnv.CheckFreeContentTelco(), id);
            }
            else
            {
                //Thông báo lỗi thanh toán
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                //}
                //else
                //{
                //    ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}

                if(isLog)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 4, messageReturn);
                }
                
                //--Thông báo lỗi thanh toán
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug(string.Format("MSISDN:{0}", Session["msisdn"]));
                logger.Debug(string.Format("Dich vu: Phan mem - parameter: {0} - Ten: {1} - id: {2}", price, dtDetail.Rows[0]["AppName"], id));
                logger.Debug("Phan mem Url:" + lnkDownload.NavigateUrl);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
        }
    }
}