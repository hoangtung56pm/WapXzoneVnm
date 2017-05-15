using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao
{
    public partial class KQChoNew : BasePage
    {
        private int width;
        private string lang;
        private string gameid;
        private MTInfo mt;
        private MTWaittingInfo mtwaitting;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("kqchoprice");
            telCo = Session["telco"].ToString();
            linkStr = "<a href=\"../" + UrlProcess.GetSportHomeUrlNew(lang, "home", width.ToString()).Replace("~/", "") + "\" >BÓNG ĐÁ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetSportHomeUrlNew(lang, "home", width.ToString()).Replace("~/", "") + "\" >BONG DA<a>";

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
                DataTable sportinfo = ThethaoController.GetSport_GameDetailByID(gameid);
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
                        //pnlThongBao.Visible = true;
                        //if (lang == "1")
                        //{
                        //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDangKyDichVu + "kết quả chờ trận đấu " + sportinfo.Rows[0]["Team_Name1"].ToString() + " - " + sportinfo.Rows[0]["Team_Name2"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo;
                        //    btnKhong.Text = Resources.Resource.btnKhong;
                        //}
                        //else
                        //{
                        //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDangKyDichVu_KD + "ket qua cho tran dau " + sportinfo.Rows[0]["Team_Name1"].ToString() + " - " + sportinfo.Rows[0]["Team_Name2"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo_KD;
                        //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                        //}
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "KQCHO", Request.QueryString["id"].ToString());

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "FOOTBALLRESULT", "FOOTBALL_RESULT");
                                //Dungnt sua ngay 10/11 tu FOOTBALLRESULT thanh LOTOSOICAU
                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU");

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);

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

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "KQCHO", Request.QueryString["id"].ToString());

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU");
                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOSOICAU", "SOICAU", price, "D", "KQCHO", Request.QueryString["id"]);

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

            gameid = Request.QueryString["id"];//ThethaoController.GetSport_GameDetailBySportID(ConvertUtility.ToInt32(Request.QueryString["id"])).Rows[0]["PK_Game_ID"].ToString();
            DataTable sportinfo = ThethaoController.GetSport_GameDetailByID(gameid);

            string chitietGiaodich = "Ket qua cho tran dau: " + sportinfo.Rows[0]["Team_Name1"].ToString() + " - " + sportinfo.Rows[0]["Team_Name2"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
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
                MTController.SMS_MTInsert(mt);
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
                mtwaitting.Operator = Session["telco"].ToString();
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
                };
                Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 8);
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
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 8, messageReturn);
                //--Thông báo lỗi thanh toán
            }
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