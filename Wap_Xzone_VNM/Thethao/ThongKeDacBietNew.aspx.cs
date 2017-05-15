using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao
{
    public partial class ThongKeDacBietNew : BasePage
    {
        private int width;
        private string lang;
        private string gameid;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("goldprice");


            telCo = Session["telco"].ToString();
            

            linkStr = "<a href=\"../" + UrlProcess.GetSportHomeUrlNew(lang, "home", width.ToString()).Replace("~/", "") + "\" >BÓNG ĐÁ<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetSportHomeUrlNew(lang, "home", width.ToString()).Replace("~/", "") + "\" >BONG DA<a>";

            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                DataTable dtGiai = ThethaoController.GetCompetitionGetByWID(ConvertUtility.ToInt32(Request.QueryString["catid"]));

                if (WapController.W4A_Subscriber_IsActive(ConvertUtility.ToString(Session["msisdn"]), 2))
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                gameid = ThethaoController.GetCompetitionGetByWID(ConvertUtility.ToInt32(Request.QueryString["catid"])).Rows[0]["CompetitionID"].ToString();
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
                    if (telCo == Constant.T_Mobifone)
                    {
                        //Chưa xử lý
                        string content = Session["cpid"].ToString() + "&" + Constant.thethao + "5" + Request.QueryString["catid"] + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("tkdbcode") + " " + dtGiai.Rows[0]["Code"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("tkdbcommandcode") + "</b> để nhận thống kê đặc biệt của giải" + Resources.Resource.wChon3G;
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("tkdbcode") + " " + dtGiai.Rows[0]["Code"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("tkdbcommandcode") + "</b> de nhan thong ke dac biet cua giai" + Resources.Resource.wChon3G_KD;
                        }

                    }
                    else
                    {
                        //pnlThongBao.Visible = true;
                        //if (lang == "1")
                        //{
                        //    ltrTitle.Text = linkStr + " » " + Resources.Resource.wThongBao;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu + "dịch vụ thống kê đặc biệt giải " + dtGiai.Rows[0]["Name"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo;
                        //    btnKhong.Text = Resources.Resource.btnKhong;
                        //}
                        //else
                        //{
                        //    ltrTitle.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                        //    //ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD.Replace("xxx", price);
                        //    ltrThongBao.Text = Resources.Resource.wXacNhanDichVu_KD + "dich vu thong ke dac biet giai " + dtGiai.Rows[0]["Name"].ToString();
                        //    btnCo.Text = Resources.Resource.btnCo_KD;
                        //    btnKhong.Text = Resources.Resource.btnKhong_KD;
                        //} 
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "GAME87", Request.QueryString["catid"].ToString());
                                //ban dang chay
                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN");

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);

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
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "GAME87", Request.QueryString["catid"].ToString());

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN");

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "GAMEDOWN", "GAME_DOWN", price, "D", "GAME87", Request.QueryString["id"]);

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

            DataTable dtGiai = ThethaoController.GetCompetitionGetByWID(ConvertUtility.ToInt32(Request.QueryString["catid"]));
            gameid = dtGiai.Rows[0]["CompetitionID"].ToString();
            DataTable dtTKDB = ThethaoController.ThongKeDacBiet(gameid);
            string chitietGiaodich = string.Empty;
            if (thuchien)
            {
                if (dtTKDB.Rows.Count > 0)
                {
                    string noidung = dtTKDB.Rows[0][0].ToString().Trim();
                    //for (int i = 4; i <= 14; i++)
                    //{
                    //    if (!string.IsNullOrEmpty(dtTKDB.Rows[0][i].ToString().Trim()))
                    //    {
                    //        noidung += "<br />" + dtTKDB.Rows[0][i].ToString().Trim();
                    //    }
                    //}
                    ltrNoiDung.Text = noidung;
                    if (lang == "1")
                    {
                        ltrTieuDe.Text = linkStr;
                        lblTen.Text = dtGiai.Rows[0]["NameUnicode"].ToString();
                    }
                    else
                    {
                        ltrTieuDe.Text = linkStr_KD;
                        lblTen.Text = dtGiai.Rows[0]["Name"].ToString();
                    };
                    chitietGiaodich = "Thống kê đặc biệt: " + dtGiai.Rows[0]["Name"].ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                    chitietGiaodich = chitietGiaodich + "\r\n" + ltrNoiDung.Text;
                    if (log) Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 20);//Thong ke dac biet
                }
            }
            else
            {
                chitietGiaodich = "Thống kê đặc biệt: " + gameid + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
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
                if (log) Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), gameid, chitietGiaodich, 20, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            if (log)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN: " + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Thong ke dac biet " + gameid);
                logger.Debug("Chi tiet: " + chitietGiaodich);
                logger.Debug("IP: " + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error: " + messageReturn);
                logger.Debug("Current Url: " + Request.RawUrl);
                //end log
            }
        }
    }
}