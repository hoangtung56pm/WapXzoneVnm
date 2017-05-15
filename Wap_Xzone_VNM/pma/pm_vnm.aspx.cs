using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using log4net;
using WapXzone_VNM.PM;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM
{
    public partial class pm_vnm : PaymnetPage
    {
        ILog logger = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                logger.Debug("------------- wapPayment4APP Vietnamobile ------------------");                
                DesSecurity des = new DesSecurity();
                try
                {
                    string cipher = ConvertUtility.ToString(Request.QueryString["link"]);
                    string price = string.Empty;
                    string msisdn = string.Empty;
                    string itemid = string.Empty;
                    string itemtype = string.Empty;
                    string itemdetail = string.Empty;
                    string partnerid = string.Empty;
                    MobileUtils.GetDetailAppUrl(des.Des3Decrypt(cipher, ConfigurationSettings.AppSettings.Get("msisdnkey")), ref partnerid, ref price, ref itemid, ref itemtype, ref itemdetail);
                
                    //Kiểm tra Vinaphone
                    string alertMessage = string.Empty;

                    int is3g = 0;
                    //string msisdn = MobileUtils.GetMSISDN(out is3g);
                    msisdn = MobileUtils.GetMSISDN(out is3g);

                    logger.Debug("msisdn=" + msisdn);
                    //Nhận diện được MSISDN >> form xác thực yêu cầu thanh toán
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["_price"] = price;  
                        Session["_msisdn"] = msisdn;
                        Session["_itemid"] = itemid;
                        Session["_itemtype"] = itemtype;
                        Session["_itemdetail"] = itemdetail;
                        Session["_partnerid"] = partnerid;
                        ltrMSISDN.Text = "Xin chào " + msisdn + "<br /><b>Nạp VKIM</b>";
                        ltrTB.Text = "Phí nạp VKIM là " + price + " đồng. Vui lòng xác nhận để thực hiện giao dịch.";
                        pnlXacnhan.Visible = true;                
                    }                
                    else
                    {
                        Response.Redirect("http://payment.xzone.vn/atc.aspx?link=END", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                catch (Exception ex)
                {
                    logger.Debug("Exception=" + ex.ToString());
                    Response.Redirect("http://payment.xzone.vn/atc.aspx?link=END", false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            
        }

        protected void btnHuyBo_Click(object sender, EventArgs e)
        {
            Session["_price"] = null;  
            Session["_msisdn"] = null;
            Session["_itemid"] = null;
            Session["_itemtype"] = null;
            Session["_itemdetail"] = null;
            Session["_partnerid"] = null;
            ltrMSISDN.Text = "<b>Thông báo</b>";
            ltrTB1.Text = "Giao dịch đã được huỷ.";
            pnlXacnhan.Visible = false;
            pnlThongbao.Visible = true;
        }

        protected void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                int status = 1;
                string debit_status = string.Empty;
                //string debit_status = Vinaphone_Charging.ReturnChargingResult(Session["_msisdn"].ToString(), Session["_price"].ToString());
                string strType = Constant.pmContentTypeVNM[ConvertUtility.ToInt32(Session["_itemtype"])];
                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                string productId = string.Empty;
                string productKey = string.Empty;

                string price = Session["_price"].ToString();

                if (strType == "TEXT")
                {
                    if (price == "1000")
                    {
                        productId = "RELAXSTORYREAD";
                        productKey = "READ";
                    }
                    else if (price == "15000")
                    {
                        productId = "RELAXSTORYMONTHLY";
                        productKey = "READ_MONTHLY";
                    }
                    else if (price == "2000")
                    {
                        productId = "RELAXLOVER";
                        productKey = "LOVER";
                    }
                    else if (price == "3000")
                    {
                        productId = "RELAXPLACE";
                        productKey = "PLACE";
                    }
                    else if (price == "5000")
                    {
                        productId = "RELAXADVISESEX";
                        productKey = "ADVISE_SEX";
                    }
                }
                else if (strType == "WP")
                {
                    productId = "PICDOWN";
                    productKey = "PIC_DOWN";
                }
                else if (strType == "TT")
                {
                    productId = "FOOTBALLSUMARY";
                    productKey = "FOOTBALL_SUMARY";
                }
                else if (strType == "JG")
                {
                    productId = "GAMEDOWN";
                    productKey = "GAME_DOWN";
                }
                else if (strType == "APP")
                {
                    productId = "APPDOWN";
                    productKey = "APP_DOWN";
                }
                else if (strType == "VID")
                {
                    productId = "VIDEODOWN";
                    productKey = "VIDEO_DOWN";
                }
                else if (strType == "YKCG")
                {
                    productId = "FOOTBALLADVISE";
                    productKey = "FOOTBALL_ADVISE";
                }
                else if (strType == "TIP")
                {
                    productId = "FOOTBALLADVISE";
                    productKey = "FOOTBALL_ADVISE";
                }
                else if (strType == "KQCHO")
                {
                    productId = "FOOTBALLRESULT";
                    productKey = "FOOTBALL_RESULT";
                }
                else if (strType == "KQXS")
                {
                    productId = "LOTOLASTRESULT";
                    productKey = "LAST_RESULT";
                }
                else if (strType == "SOICAU")
                {
                    productId = "LOTOSOICAU";
                    productKey = "SOICAU";
                }
                else if (strType == "XSKQCHO")
                {
                    productId = "LOTORESULT";
                    productKey = "RESULT";
                }
                else if (strType == "XOSO20")
                {
                    productId = "LOTORESULTMONTHLY";
                    productKey = "RESULTMONTHLY";
                }
                else if (strType == "RELAX")
                {
                    productId = "RELAXSTORYREAD";
                    productKey = "READ";
                }
                else if (strType == "GAME87")
                {
                    productId = "FOOTBALLADVISE";
                    productKey = "FOOTBALL_RESULT";
                }
                else if (strType == "Tu vi")
                {
                    productId = "HOROSCOPE";
                    productKey = "HOROSCOPE";
                }

                debit_status = charging.PaymentVNM(Session["_msisdn"].ToString(), productId, productKey);

                //debit_status = charging.PaymentVNM(Session["_msisdn"].ToString(), Session["_price"].ToString(), "D", strType, Session["_itemid"].ToString());


                if (!string.IsNullOrEmpty(debit_status) && debit_status == "1")
                {// Thanh toán thành công >> trả nội dung                                    
                    status = 0; ;
                }
                //Ghi Transaction, Transaction_Log, xoá Transaction_Online cũ
                int TransID = DBController.Transaction_Insert(Session["_itemid"].ToString(), "APP IT R&D", ConvertUtility.ToInt32(Session["_itemtype"]), Session["_msisdn"].ToString(), 
                    4, 0, ConvertUtility.ToInt32(Session["_price"]), ConvertUtility.ToInt32(Session["_partnerid"]), 0, DateTime.Now, "debit_status: " + debit_status, status);
                //log
                logger.Debug("msisdn=" + Session["_msisdn"].ToString() + "; price=" + Session["_price"].ToString() + "; debit_status" + debit_status);

                //Hiển thị kết quả 
                ltrMSISDN.Text = "<b>Thông báo</b>";
                if (status == 0)
                {
                    AppPaymentInfo.Service ws = new AppPaymentInfo.Service();
                    string[][] arrTopupList = ws.wapGetTopupListByID(Session["_itemdetail"].ToString(), Session["_itemid"].ToString(), ConfigurationSettings.AppSettings.Get("appkey"));
                    string[] arrResult = ws.wapTopupMoney(Session["_itemdetail"].ToString(), arrTopupList[0][2], ConvertUtility.ToInt32(arrTopupList[0][1]), ConvertUtility.ToInt32(arrTopupList[0][3]), TransID.ToString(), ConfigurationSettings.AppSettings.Get("appkey"));
                    if (ConvertUtility.ToInt32(arrResult[0]) > 0)
                    {
                        ltrTB1.Text = "Giao dịch nạp VKIM đã được thực hiện (" + arrResult[0] + "). <br />Cảm ơn bạn đã sử dụng dịch vụ!";
                    }
                    else
                    {
                        ltrTB1.Text = "<span style=\"color: #FF0000\">Giao dịch không thành công. Vui lòng kiểm tra lại tài khoản. <br />" + arrResult[1] + "</span>";
                    }
                }
                else
                {
                    ltrTB1.Text = "<span style=\"color: #FF0000\">Giao dịch không thành công. Vui lòng kiểm tra lại tài khoản.</span>";
                }   

                Session["_price"] = null;  
                Session["_msisdn"] = null;
                Session["_itemid"] = null;
                Session["_itemtype"] = null;
                Session["_itemdetail"] = null;
                Session["_partnerid"] = null;
                         
            }
            catch (Exception ex)
            {
                logger.Debug("Exception=" + ex.ToString());
                ltrTB1.Text = "Giao dịch không thành công. Vui lòng kiểm tra lại tài khoản.<br />" + ex.ToString();
            }
            pnlXacnhan.Visible = false;
            pnlThongbao.Visible = true;
        }
    }
}
