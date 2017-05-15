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
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Component.MT;
using log4net;

namespace WapXzone_VNM.Game
{
    public partial class SendGift : BasePage
    {
        private int width;        
        private string lang;        
        private int id;
        private string hotro;
        private string SoDT = string.Empty;
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
            if (id == 1402 || id == 1401) price = "15000";
            SoDT = Request.QueryString["sdt"];
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetGameHomeUrl(lang, width.ToString(),hotro).Replace("~/", "") + "\" >GAME<a>";            
            
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
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = Resources.Resource.wSoDienThoaiKhongHopLe_KD;
                    }
                    return;
                }
                DataTable dtDetail = GameController.GetGameDetailByID(Session["telco"].ToString(), id);
                if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + dtDetail.Rows[0]["W_GameCategoryID"].ToString() + ",") > -1 || (",1712,1713,").IndexOf("," + id.ToString() + ",") > -1)
                {
                    freecate = true;
                    HienThiNoiDung(true);
                    return;
                }
                if (telCo == "Undefined")
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("gamecode") + " " + dtDetail.Rows[0]["Game_Code"].ToString() + " " + SoDT + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("gamecommandcode") + "</b> để gửi tặng game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
                        if (id == 1402 || id == 1401) ltrSMS.Text = "Soạn tin <b>HOT " + SoDT + "</b> gửi <b>333</b> để gửi tặng game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b>" + Resources.Resource.wChon3G;
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("gamecode") + " " + dtDetail.Rows[0]["Game_Code"].ToString() + " " + SoDT + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("gamecommandcode") + "</b> de gui tang game <b>" + dtDetail.Rows[0]["GameName"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
                        if (id == 1402 || id == 1401) ltrSMS.Text = "Soan tin <b>HOT " + SoDT + "</b> gui <b>333</b> de gui tang game <b>" + dtDetail.Rows[0]["GameNameUnicode"].ToString() + "</b>" + Resources.Resource.wChon3G_KD;
                    }
                }
                else
                {
                    //pnlThongBao.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu + "game " + dtDetail.Rows[0]["GameNameUnicode"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo;
                    //    btnKhong.Text = Resources.Resource.btnKhong;
                    //}
                    //else
                    //{
                    //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao_KD;
                    //    //ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD.Replace("xxx", price);
                    //    ltrThongBao.Text = Resources.Resource.wXacNhanTangDichVu_KD + "game " + dtDetail.Rows[0]["GameName"].ToString();
                    //    btnCo.Text = Resources.Resource.btnCo_KD;
                    //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                    //}
                    pnlThongBao.Visible = false;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "JG", Request.QueryString["id"].ToString());
                            //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEGIFT", "GAME_GIFT");

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEGIFT", "GAME_GIFT", price, "D", "JG", Request.QueryString["id"]);

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
            DataTable dtDetail = GameController.GetGameDetailByID(Session["telco"].ToString(), id);

            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "JG", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEGIFT", "GAME_GIFT");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEGIFT", "GAME_GIFT", price, "D", "JG", Request.QueryString["id"] + "|Game: " + dtDetail.Rows[0]["GameNameUnicode"]);

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
            DataTable dtDetail = GameController.GetGameDetailByID(Session["telco"].ToString(), id);
            chitietGiaodich = "Game: " + dtDetail.Rows[0]["GameNameUnicode"].ToString() + " -- id:" + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            SoDT = MobileUtils.ToSTDMobileNumber(SoDT);
            if (thuchien)
            {
                ltrTieuDe.Text = linkStr;
                if (lang == "1")
                {                        
                    lblTen.Text = dtDetail.Rows[0]["GameNameUnicode"].ToString();
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong + " game " + dtDetail.Rows[0]["GameNameUnicode"].ToString() + " (" + dtDetail.Rows[0]["Game_Code"].ToString() + ")";
                }
                else
                {
                    lblTen.Text = dtDetail.Rows[0]["GameName"].ToString();
                    ltrNoiDung.Text = Resources.Resource.wTangThanhCong_KD + " game " + dtDetail.Rows[0]["GameName"].ToString() + " (" + dtDetail.Rows[0]["Game_Code"].ToString() + ")";
                };
                string url;
                //if (",1,2,3,6,12,".LastIndexOf("," + ConvertUtility.ToString(dtDetail.Rows[0]["Partner_ID"]) + ",") == -1)
                //{
                //    url = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(), "3", id.ToString(), SecurityMethod.MD5Encrypt(id.ToString()));
                //}
                //else
                //{
                //    GameUrl.MOReceiver urlservice = new WapXzone_VNM.GameUrl.MOReceiver();
                //    url = urlservice.ReturnWapUrlForGame(ConvertUtility.ToInt32(dtDetail.Rows[0]["GID"]));
                //    if (url.IndexOf("http://") == -1)
                //    {
                //        url = "http://" + url;
                //    }
                //}
                VMGGame.MOReceiver urlservice = new VMGGame.MOReceiver();
                url = urlservice.VMG_ReturnUrlForGame(ConvertUtility.ToString(dtDetail.Rows[0]["GID"]), 0, ConvertUtility.ToString(Session["msisdn"]), ConvertUtility.ToInt32(dtDetail.Rows[0]["Partner_ID"]), "XZONE", "WAP", Session["telco"].ToString(), "WAP.XZONE.VN", "", "");
                int indexofhttp = url.IndexOf("http://");
                if (indexofhttp == -1)
                {
                    url = "http://" + url;
                }
                else
                {
                    url = url.Substring(indexofhttp);
                }

                MTInfo mtInfo = new MTInfo();
                Random random = new Random();
                mtInfo.Service_ID = ConfigurationSettings.AppSettings.Get("gamecommandcode");
                mtInfo.Command_Code = ConfigurationSettings.AppSettings.Get("gamecode");
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Total_Message = 1;
                mtInfo.Message_Index = 0;
                mtInfo.IsMore = 0;
                if (freecate == false)
                {
                    //Thông báo cho người được tặng                
                    mtInfo.User_ID = SoDT;                    
                    mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();                    
                    mtInfo.Content_Type = 0;
                    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                    mtInfo.Message = "Ban nhan duoc qua tang game " + dtDetail.Rows[0]["GameName"].ToString() + " tu so dien thoai " + "0" + ConvertUtility.ToString(Session["msisdn"]).Remove(0, 2);
                    MTController.SmsMtInsert(mtInfo);
                
                    //MT thong bao cho nguoi gui tang biet
                    mtInfo.Content_Type = 0;
                    mtInfo.User_ID = Session["msisdn"].ToString();
                    mtInfo.Message = "Ban da gui tang thanh cong game " + dtDetail.Rows[0]["GameName"].ToString() + " toi so dt " + SoDT;
                    mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                    mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                    MTController.SmsMtInsert(mtInfo);
                }
                //Build waplink send to customer and insert to MT table
                mtInfo.User_ID = SoDT;
                mtInfo.Message = "Tai game duoc tang theo dia chi: " + url;
                mtInfo.Content_Type = 8;
                mtInfo.Message_Type = (int)Constant.MessageType.FREE;
                mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
                MTController.SmsMtInsert(mtInfo);
                if (freecate == false)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, url, id.ToString(), chitietGiaodich, 3);
                    GameController.SetDownloadCounter(Session["telco"].ToString(), id);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 3, messageReturn);                    
                //--Thông báo lỗi thanh toán
            }
            if (freecate == false)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN: " + Session["msisdn"].ToString());
                logger.Debug("So gui tang: " + SoDT);
                logger.Debug("Dich vu: Game - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["GameName"].ToString() + " - id: " + id);
                logger.Debug("Game Url:" + ConvertUtility.ToString(lnkDownload.NavigateUrl));
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
        }
        
    }
}
