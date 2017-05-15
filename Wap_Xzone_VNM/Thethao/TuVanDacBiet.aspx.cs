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
    public partial class TuVanDacBiet : BasePage
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
            price = ConfigurationSettings.AppSettings.Get("goldprice");

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

                gameid = ThethaoController.GetAll_Sport87DetailByGame87ID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game87_ID"].ToString();
                DataSet ds87detail = ThethaoController.GetAll_Sport87_DetailBy_PK_Game87ID(gameid);
                if (!ConvertUtility.ToBoolean(ds87detail.Tables[0].Rows[0]["IsFull"]))
                {
                    pnlThongBao.Visible = true;
                    if (lang == "1")
                    {
                        ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                        //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                        ltrThongBao.Text = ds87detail.Tables[1].Rows[0]["ContentValue"].ToString();
                        btnCo.Visible = false;
                        btnKhong.Visible = false;
                    }
                    else
                    {
                        ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                        //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                        ltrThongBao.Text = UnicodeUtility.UnicodeToKoDau(ds87detail.Tables[1].Rows[0]["ContentValue"].ToString());
                        btnCo.Visible = false;
                        btnKhong.Visible = false;
                    }
                }
                else
                {
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
                        //gameid = ThethaoController.GetAll_Sport87DetailByGame87ID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game87_ID"].ToString();                        
                        if (telCo == Constant.T_Mobifone)
                        {
                            string content = Session["cpid"].ToString() + "&" + Constant.thethao + "9" + Request.QueryString["id"] + "&" + price + "&" + Session["transactionid"].ToString();
                            Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                        }
                        //                
                        if (telCo == "Undefined")
                        {
                            pnlSMS.Visible = true;
                            if (lang == "1")
                            {
                                ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                                //Xiên
                                if (Request.QueryString["id"] == "2")
                                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("xiencode") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("xiencommandcode") + "</b> để nhận chuỗi kèo xiên sáng nhất" + Resources.Resource.wChon3G;
                                //Trận cầu vàng
                                if (Request.QueryString["id"] == "4")
                                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("goldcode") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("goldcommandcode") + "</b> để nhận thông tin về trận cầu ngon ăn nhất" + Resources.Resource.wChon3G;
                                //Tài Xỉu sáng nhất
                                if (Request.QueryString["id"] == "5")
                                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("tvtxcode") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("tvtxcommandcode") + "</b> để nhận thông tin Tài Xỉu sáng nhất" + Resources.Resource.wChon3G;
                                //Trên dưới sáng nhất
                                if (Request.QueryString["id"] == "6")
                                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("tvtdcode") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("tvtdcommandcode") + "</b> để nhận thông tin Trên Dưới sáng nhất" + Resources.Resource.wChon3G;
                                //Sáng nhất giải
                                if (",1,3,7,8,9,10,11,12,".LastIndexOf("," + Request.QueryString["id"] + ",") >= 0)
                                    ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("sangcode") + " &lt;ma tran&gt;</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("sangcommandcode") + "</b> để nhận thông tin Kèo sáng nhất giải" + Resources.Resource.wChon3G;
                            }
                            else
                            {
                                ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                                if (Request.QueryString["id"] == "2")
                                    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("xiencode") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("xiencommandcode") + "</b> de nhan chuoi keo xien sang nhat" + Resources.Resource.wChon3G;
                                if (Request.QueryString["id"] == "4")
                                    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("goldcode") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("goldcommandcode") + "</b> de nhan thong tin ve tran cau ngon an nhat" + Resources.Resource.wChon3G_KD;
                                if (Request.QueryString["id"] == "5")
                                    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("tvtxcode") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("tvtxcommandcode") + "</b> de nhan thong tin Tai Xiu sang nhat" + Resources.Resource.wChon3G_KD;
                                if (Request.QueryString["id"] == "6")
                                    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("tvtdcode") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("tvtdcommandcode") + "</b> de nhan thong tin Tren Duoi sang nhat" + Resources.Resource.wChon3G_KD;
                                if (",1,3,7,8,9,10,11,12,".LastIndexOf("," + Request.QueryString["id"] + ",") >= 0)
                                    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("sangcode") + " &lt;ma tran&gt;</b> gui <b>" + ConfigurationSettings.AppSettings.Get("sangcommandcode") + "</b> de nhan thong tin Keo sang nhat giai" + Resources.Resource.wChon3G_KD;
                            }

                        }
                        else
                        {
                            pnlThongBao.Visible = false;
                            switch (Session["telco"].ToString())
                            {
                                case "Vietnamobile":
                                    var charging = new Library.VNMCharging.VNMChargingGW();


                                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);

                                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                                    {
                                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"], out logPrice);
                                        price = logPrice;
                                    }

                                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                                    {
                                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);
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

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"],out logPrice);
                        price = logPrice;
                    }

                    if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                    {
                        messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);
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

            gameid = ThethaoController.GetAll_Sport87DetailByGame87ID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game87_ID"].ToString();
            DataSet ds87detail = ThethaoController.GetAll_Sport87_DetailBy_PK_Game87ID(gameid);
            string chitietGiaodich = string.Empty;
            if (thuchien)
            {
                if (ds87detail.Tables[0].Rows.Count > 0)
                {
                    if (lang == "1")
                    {
                        ltrTieuDe.Text = linkStr;
                        lblTen.Text = ds87detail.Tables[0].Rows[0]["Name"].ToString();
                        ltrNoiDung.Text = ds87detail.Tables[0].Rows[0]["ContentValue"].ToString().Replace("\r\n", "<div class=\"clearfix\"></div>");
                    }
                    else
                    {
                        ltrTieuDe.Text = linkStr_KD;
                        lblTen.Text = UnicodeUtility.UnicodeToKoDau(ds87detail.Tables[0].Rows[0]["Name"].ToString());
                        ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(ds87detail.Tables[0].Rows[0]["ContentValue"].ToString().Replace("\r\n", "<div class=\"clearfix\"></div>"));
                    }
                    //chitietGiaodich = "Tu van dac biet: " + ds87detail.Tables[0].Rows[0]["Name"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

                    chitietGiaodich = "Tu van dac biet: " + ds87detail.Tables[0].Rows[0]["Name"];

                    chitietGiaodich = chitietGiaodich + "\r\n" + ltrNoiDung.Text;
                    if (log) 
                    {
                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 14);//game 87
                    }
                }
            }
            else
            {
                chitietGiaodich = "Tu van dac biet: " + gameid + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
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
                if (log) Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 14, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            if (log)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN: " + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Tu van dac biet (Game87)" + gameid);
                logger.Debug("Chi tiet: " + chitietGiaodich);
                logger.Debug("IP: " + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error: " + messageReturn);
                logger.Debug("Current Url: " + Request.RawUrl);
                //end log
            }
        }

    }
}
