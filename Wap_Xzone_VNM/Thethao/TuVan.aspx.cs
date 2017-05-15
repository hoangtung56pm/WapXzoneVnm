using System;
using System.Web;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using log4net;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Thethao
{
    public partial class TuVan : BasePage
    {
        private int width;
        private string lang;
        private string gameid;

        private string price;
        private string logPrice;

        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("tipprice");

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
                DataTable ykcg = ThethaoController.GetDetail_Tip_ByGameID(gameid);

                if (WapController.W4A_Subscriber_IsActive(ConvertUtility.ToString(Session["msisdn"]), 2))
                {
                    HienThiNoiDung(true, false);
                    return;
                }

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
                    gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.thethao + "7" + Request.QueryString["id"] + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("tipcode") + " " + ykcg.Rows[0]["Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("tipcommandcode") + "</b> để nhận tư vấn về trận đấu" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("tipcode") + " " + ykcg.Rows[0]["Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("tipcommandcode") + "</b> de nhan tu van ve tran dau" + Resources.Resource.wChon3G_KD;
                        }
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"]);

                                if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                                {
                                    messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"], out logPrice);
                                    price = logPrice;
                                }

                                if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                                {
                                    messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"]);
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

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"]);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"],out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "TIP", Request.QueryString["id"]);
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

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien, Boolean log)
        {
            pnlNoiDung.Visible = true;
            gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
            DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(gameid);
            string chitietGiaodich = string.Empty;
            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrTieuDe.Text = "BÓNG ĐÁ";
                    lblTen.Text = "Tư vấn";
                }
                else
                {
                    ltrTieuDe.Text = "BONG DA";
                    lblTen.Text = "Tu van";
                };
                if (tip.Rows.Count > 0)
                {
                    //chitietGiaodich = "Tư vấn trận đấu: " + tip.Rows[0]["Team_Name1"].ToString() + " - " + tip.Rows[0]["Team_Name2"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                    chitietGiaodich = "Tư vấn trận đấu: " + tip.Rows[0]["Team_Name1"] + " - " + tip.Rows[0]["Team_Name2"];

                    if (lang == "1")
                    {
                        ltrNoiDung.Text = tip.Rows[0]["Tip_Content"].ToString();
                    }
                    else
                    {
                        ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(tip.Rows[0]["Tip_Content"].ToString());
                    }
                    chitietGiaodich = chitietGiaodich + "\r\n" + ltrNoiDung.Text;
                    if (log)
                    {
                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 7);
                    }
                }
            }
            else
            {
                chitietGiaodich = "Tư vấn trận đấu: " + gameid + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
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
                if (log)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 7, messageReturn);
                }
                //--Thông báo lỗi thanh toán
            }
            if (log)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Tu van (TIP) " + gameid);
                logger.Debug("Chi tiet: " + chitietGiaodich);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
        }

    }
}
