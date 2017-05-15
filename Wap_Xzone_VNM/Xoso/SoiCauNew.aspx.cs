using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso
{
    public partial class SoiCauNew : BasePage
    {
        protected int width;
        protected string lang;
        protected int id;
        private MTInfo mt;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        private string[] _arrService;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("xssoicauprice");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetXosoHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >XỔ SỐ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetXosoHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >XO SO<a>";

            if (Session["serviceList"] != null)
            {
                _arrService = Session["serviceList"] as string[];
            }

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                DataTable soicau = XosoController.GetSoicauInfoBycompanyID(id);

                if (_arrService != null)
                {
                    if (_arrService.Length > 0)
                    {
                        string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_SC"), soicau.Rows[0]["MainCode"]);
                        foreach (var item in _arrService)
                        {
                            if (item == dkXoSo)
                            {
                                pnlS2DangKy.Visible = false;
                            }
                        }
                    }
                }

                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
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
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.xoso + "x10" + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("xssoicode") + " " + soicau.Rows[0]["MainCode"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("xssoicaucommandcode") + "</b> để nhận dự đoán kết quả xổ số" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("xssoicode") + " " + soicau.Rows[0]["MainCode"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("xssoicaucommandcode") + "</b> de nhan du doan ket qua xo so" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        //pnlThongBao.Visible = true;
                        //if (lang == "1")
                        //{
                        //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "dịch vụ soi cầu " + soicau.Rows[0]["ProvinceName"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo;
                        //    btnKhong.Text = Resources.Resource.btnKhong;
                        //}
                        //else
                        //{
                        //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "dich vu soi cau " + soicau.Rows[0]["ProvinceName"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo_KD;
                        //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                        //} 
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "SOICAU", Request.QueryString["id"].ToString());

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU");

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "SOICAU", Request.QueryString["id"]);

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

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "SOICAU", Request.QueryString["id"].ToString());

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "SOICAU", Request.QueryString["id"]);

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

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable soicau = XosoController.GetSoicauInfoBycompanyID(id);
            string chitietGiaodich = "Soi cau: " + soicau.Rows[0]["Content"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            //Neu ton tai soi cau 
            if (soicau.Rows.Count > 0)
            {
                if (thuchien)
                {
                    //insertMT
                    mt = new MTInfo();
                    mt.User_ID = Session["msisdn"].ToString();
                    mt.Message = soicau.Rows[0]["Content"].ToString(); ;
                    mt.Service_ID = ConfigurationSettings.AppSettings.Get("xssoicaucommandcode");
                    mt.Command_Code = ConfigurationSettings.AppSettings.Get("xssoicode");
                    mt.Message_Type = (int)Constant.MessageType.FREE;
                    Random random = new Random();
                    mt.Request_ID = random.Next(100000000, 999999999).ToString();
                    mt.Total_Message = 1;
                    mt.Message_Index = 0;
                    mt.IsMore = 0;
                    mt.Content_Type = 0;
                    MTController.SMS_MTInsert(mt);
                    //
                    if (lang == "1")
                    {
                        ltrTieuDe.Text = "XỔ SỐ";
                        lblTen.Text = "Soi cầu";
                        ltrNoiDung.Text = soicau.Rows[0]["Content"].ToString(); ;
                    }
                    else
                    {
                        ltrTieuDe.Text = "XO SO";
                        lblTen.Text = "Soi cau";
                        ltrNoiDung.Text = soicau.Rows[0]["Content"].ToString(); ;
                    };
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 10);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 10, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Dich vu: Xo so - Soi cau - parameter: " + price + " - id: " + id);
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }
    }
}