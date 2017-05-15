using System;
using System.Configuration;
using System.Data;
using System.Web;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Ws_Game94x;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game
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
        private string linkStr;
        private string messageReturn = string.Empty;
        private bool freecate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("gameprice");
            lang = Request.QueryString["lang"];
            hotro = Request.QueryString["hotro"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (id == 1402 || id == 1401) 
                price = "15000";

            telCo = AppEnv.CheckSessionTelcoUndefine();

            linkStr = "<a href=\"" + UrlProcess.GameHome() + "\" >GAME</a>";

            if (!IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                //#region Free Content

                //if (AppEnv.GetSetting("FreeContent") == "1")
                //{
                //    HienThiNoiDung(true, false);
                //    return;
                //}

                //#endregion

                DataTable dtDetail = GameController.GetGameDetailByID(AppEnv.CheckSessionTelco(), id);
                if(dtDetail != null && dtDetail.Rows.Count > 0)
                {

                    string webName = dtDetail.Rows[0]["Web_Name"].ToString();
                    bool free = (webName.ToLower().Contains("online") || webName.ToLower().Contains("free"));

                    if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + dtDetail.Rows[0]["W_GameCategoryID"] + ",") > -1 || (",1712,1713,").IndexOf("," + id.ToString() + ",") > -1 || free)
                    {
                        freecate = true;
                        HienThiNoiDung(true, false,"0");
                        return;
                    }
                }

                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    //if (lang == "1")
                    //{
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("gamecode") + " " + dtDetail.Rows[0]["Game_Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("gamecommandcode") + "</b> để tải game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                        if (id == 1402 || id == 1401) ltrSMS.Text = "Soạn tin <b>HOT</b> gửi <b>333</b> để tải game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b> về máy" + Resources.Resource.wChon3G;
                    //}
                    //else
                    //{
                    //    ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan_KD;
                    //    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("gamecode") + " " + dtDetail.Rows[0]["Game_Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("gamecommandcode") + "</b> de tai game <b>" + dtDetail.Rows[0]["GameName"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    //    if (id == 1402 || id == 1401) ltrSMS.Text = "Soan tin <b>HOT</b> gui <b>333</b> de tai game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b> ve may" + Resources.Resource.wChon3G_KD;
                    //}
                }
                else
                {
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            var charging = new Library.VNMCharging.VNMChargingGW();

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "JG", Request.QueryString["id"]);

                            if (messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true,true,price);
                            }
                            else
                            {// Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(false,true,"0");
                            }
                            break;
                    }
                }
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            DataTable dtDetail = GameController.GetGameDetailByID(Session["telco"].ToString(), id);

            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "JG", Request.QueryString["id"] + "|Game: " + dtDetail.Rows[0]["GameName"]);

                    if (messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true,true,price);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false,true,"0");
                    }
                    break;
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog,string gamePrice)
        {
            pnlNoiDung.Visible = true;
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = GameController.GetGameDetailByID(AppEnv.CheckFreeContentTelco(), id);

            //chitietGiaodich = "Game: " + dtDetail.Rows[0]["GameNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            chitietGiaodich = "Game: " + dtDetail.Rows[0]["GameNameUnicode"].ToString() + " -- id:" + id.ToString();

            if (thuchien)
            {
                ltrTieuDe.Text = linkStr;
                //if (lang == "1")
                //{
                    lblTen.Text = dtDetail.Rows[0]["GameNameUnicode"].ToString();
                    lnkDownload.Text = Resources.Resource.wBamDeTai;
                    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong + " game " + dtDetail.Rows[0]["GameNameUnicode"].ToString() + " (" + dtDetail.Rows[0]["Game_Code"].ToString() + ")";
                //}
                //else
                //{
                //    lblTen.Text = dtDetail.Rows[0]["GameName"].ToString();
                //    lnkDownload.Text = Resources.Resource.wBamDeTai_KD;
                //    ltrNoiDung.Text = Resources.Resource.wMuaThanhCong_KD + " game " + dtDetail.Rows[0]["GameName"].ToString() + " (" + dtDetail.Rows[0]["Game_Code"].ToString() + ")";
                //};
                string url;
                try
                {
                    //VMGGame.MOReceiver urlservice = new VMGGame.MOReceiver();

                    //url = urlservice.VMG_ReturnUrlForGame(ConvertUtility.ToString(dtDetail.Rows[0]["GID"]), 
                    //                                        0, 
                    //                                        ConvertUtility.ToString(AppEnv.CheckFreeContentMsisdn()), 
                    //                                        ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]), 
                    //                                        "VNM", 
                    //                                        "WAP",
                    //                                        AppEnv.CheckFreeContentTelco(), 
                    //                                        Constant.T_VietnamobileWap, 
                    //                                        "", 
                    //                                        "");

                    var gameUrl = new GameHandler();
                    url = gameUrl.VMG_ReturnUrlForGame(ConvertUtility.ToString(dtDetail.Rows[0]["GID"]),
                                                        0,
                                                        ConvertUtility.ToString(AppEnv.CheckFreeContentMsisdn()), 
                                                        ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]),
                                                        "VNM", 
                                                        "WAP",
                                                        AppEnv.CheckFreeContentTelco(), 
                                                        Constant.T_VietnamobileWap, 
                                                        "",
                                                        "",
                                                        112,
                                                        ConvertUtility.ToInt32(price)
                                                        );

                    if (url.StartsWith("-1")) // if Non-Success : FIX TRA VE 1 LINK GAME VMG
                    {
                        url = gameUrl.VMG_ReturnUrlForGame("8629",
                                                      0,
                                                      AppEnv.CheckFreeContentMsisdn(),
                                                      ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]),
                                                      "VNM",
                                                      "WAP",
                                                      AppEnv.CheckFreeContentTelco(),
                                                      Constant.T_VietnamobileWap,
                                                      "", "", 112, ConvertUtility.ToInt32(price));
                    }

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
                catch (Exception ex) { url = ""; }

                lnkDownload.NavigateUrl = url;
                if (freecate == false)
                {
                    if(isLog)
                    {
                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 3);
                        GameController.SetGamePrice(Session["msisdn"].ToString(), url, Constant.T_VietnamobileWap, ConvertUtility.ToInt32(price));
                    }
                    //GameController.SetDownloadCounter(AppEnv.CheckFreeContentTelco(), id);
                }
                GameController.SetDownloadCounter(AppEnv.CheckFreeContentTelco(), id);
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
                //    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}
                if(isLog)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 3, messageReturn);
                }
                //--Thông báo lỗi thanh toán
            }
            if (freecate == false)
            {

                if(isLog)
                {
                    //log charging                                 
                    ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("--------------------------------------------------");
                    logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                    logger.Debug("Dich vu: Game - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["GameName"].ToString() + " - id: " + id);
                    logger.Debug("Game Url:" + lnkDownload.NavigateUrl);
                    logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                    logger.Debug("Error:" + messageReturn);
                    logger.Debug("Current Url:" + Request.RawUrl);
                    //end log
                }
                
            }
        }

    }
}