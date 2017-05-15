using System;
using System.Web;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using log4net;

namespace WapXzone_VNM.Thethao
{
    public partial class KQCho : BasePage
    {
        private int width;
        private string lang;
        private string gameid;
        private MTInfo mt;
        private MTWaittingInfo mtwaitting;

        private string price;
        private string logPrice;

        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("kqchoprice");

            telCo = AppEnv.CheckFreeContentTelco();

            linkStr = "<a href=\"../" + UrlProcess.GetSportHomeUrl(lang, "home", width.ToString()).Replace("~/", "") + "\" >BÓNG ĐÁ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetSportHomeUrl(lang, "home", width.ToString()).Replace("~/", "") + "\" >BONG DA<a>";

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                #region Free Content

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region OLD

                gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
                DataTable sportinfo = ThethaoController.GetSport_GameDetailByID(gameid);
                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
                    messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                    if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                    {// Thanh toán thành công >> trả nội dung                        
                        HienThiNoiDung(true, true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false, true);
                    }
                    Session["transactionid_old"] = null;
                }
                else
                {
                    //gameid = ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.thethao + "8" + Request.QueryString["id"] + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("kqchocode") + " " + sportinfo.Rows[0]["Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("kqchocommandcode") + "</b> để nhận kết quả chờ trận đấu" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("kqchocode") + " " + sportinfo.Rows[0]["Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("kqchocommandcode") + "</b> de nhan ket qua cho tran dau" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);

                                if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                                {
                                    messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"], out logPrice);
                                    price = logPrice;
                                }

                                if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                                {
                                    messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);
                                }

                                if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
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

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"],out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);
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

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            pnlNoiDung.Visible = true;

            gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
            DataTable sportinfo = ThethaoController.GetSport_GameDetailByID(gameid);

            //string chitietGiaodich = "Ket qua cho tran dau: " + sportinfo.Rows[0]["Team_Name1"].ToString() + " - " + sportinfo.Rows[0]["Team_Name2"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            string chitietGiaodich = "Ket qua cho tran dau: " + sportinfo.Rows[0]["Team_Name1"] + " - " + sportinfo.Rows[0]["Team_Name2"];

            if (thuchien)
            {
                //insertMT
                string smscontent = "Bạn đã đăng ký thành công dịch vụ Kết quả chờ trận đấu " + sportinfo.Rows[0]["Team_Name1"].ToString() + " - " + sportinfo.Rows[0]["Team_Name2"].ToString() + ". Cảm ơn bạn đã sử dụng dịch vụ.";
                mt = new MTInfo();
                mt.User_ID = Session["msisdn"].ToString();
                mt.Message = UnicodeUtility.UnicodeToKoDau(smscontent);
                mt.Service_ID = ConfigurationSettings.AppSettings.Get("kqchocommandcode");
                mt.Command_Code = ConfigurationSettings.AppSettings.Get("kqchocode");
                mt.Message_Type = (int)Constant.MessageType.FREE;
                Random random = new Random();
                mt.Request_ID = random.Next(100000000, 999999999).ToString();
                mt.Total_Message = 1;
                mt.Message_Index = 0;
                mt.IsMore = 0;
                mt.Content_Type = 0;
                mt.ServiceType = 4;//servicetype of kq cho;
                MTController.SmsMtInsert(mt);
                //insert mt waitting 
                mtwaitting = new MTWaittingInfo();
                mtwaitting.User_ID = Session["msisdn"].ToString();
                mtwaitting.Message = "";
                mtwaitting.Service_ID = ConfigurationSettings.AppSettings.Get("kqchocommandcode");
                mtwaitting.Command_Code = ConfigurationSettings.AppSettings.Get("kqchocode");
                mtwaitting.Message_Type = (int)Constant.MessageType.FREE;
                mtwaitting.Request_ID = random.Next(100000000, 999999999).ToString();
                mtwaitting.Total_Message = 10;
                mtwaitting.Message_Index = 1;
                mtwaitting.IsMore = 0;
                mtwaitting.Content_Type = 0;
                mtwaitting.ServiceType = 4;//dv  ket qua cho
                mtwaitting.UniqueId = gameid;
                mtwaitting.ExpiredDate = DateTime.Now.AddDays(10);
                mtwaitting.PartnerID = string.Empty;
                mtwaitting.Operator = AppEnv.CheckFreeContentMsisdn();
                MTController.SMS_MTWaittingInsert(mtwaitting);
                //insert wap transaction

                //
                if (lang == "1")
                {
                    ltrTieuDe.Text = "BÓNG ĐÁ";
                    lblTen.Text = "Kết quả chờ trận đấu";
                    ltrNoiDung.Text = smscontent;
                }
                else
                {
                    ltrTieuDe.Text = "BONG DA";
                    lblTen.Text = "Ket qua cho tran dau";
                    ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(smscontent);
                }
                
                if(isLog)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 8);
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

                if(isLog)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 8, messageReturn);
                }
                //--Thông báo lỗi thanh toán
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN: " + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Ket qua cho (truc tiep) " + gameid);
                logger.Debug("Chi tiet: " + chitietGiaodich);
                logger.Debug("IP: " + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error: " + messageReturn);
                logger.Debug("Current Url: " + Request.RawUrl);
                //end log
            }

            
        }
    }
}
