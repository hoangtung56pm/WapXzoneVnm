using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using log4net;
using VmgPortal.Modules.Adsvertising.Lib.DataAccess;
using AppEnv = WapXzone_VNM.Library.AppEnv;

namespace WapXzone_VNM.PM
{
    public partial class c_vnm : PaymnetPage
    {
        ILog logger = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            string partnerid = string.Empty;
            try
            {
                DesSecurity des = new DesSecurity();
                string token = des.Des3Decrypt(Request.QueryString["c"], AppEnv.GetSetting("msisdnkey"));

                logger.Debug("token =" + token);
                logger.Debug("c =" + Request.QueryString["c"]); 

                DataTable dtTrans = DBController.Transaction_Online_GetByToken(token);
                if (dtTrans != null && dtTrans.Rows.Count > 0)
                {
                    //logger.Debug("dtTrans.Rows.Count =" + dtTrans.Rows.Count);

                    int status = 1;
                    string debit_status = string.Empty;
                    string strType = Constant.pmContentTypeVNM[ConvertUtility.ToInt32(dtTrans.Rows[0]["ItemType"])];

                    partnerid = dtTrans.Rows[0]["PartnerID"].ToString();
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    string productId = string.Empty;
                    string productKey = string.Empty;

                    string price = dtTrans.Rows[0]["Price"].ToString();

                    if(strType == "TEXT")
                    {
                        if(price == "1000")
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
                    else if(strType == "TT")
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

                    debit_status = charging.NavigatePaymentVnm(dtTrans.Rows[0]["msisdn"].ToString(), productId, productKey, price, "D", strType, UnicodeUtility.RemoveSpecialCharacter(UnicodeUtility.UnicodeToKoDau(dtTrans.Rows[0]["ItemDetail"].ToString())));
                    
                    //debit_status = charging.PaymentVNM(dtTrans.Rows[0]["msisdn"].ToString(),productId,productKey);
                    if (!string.IsNullOrEmpty(debit_status) && debit_status == "1")
                    {
                        // Thanh toán thành công >> trả nội dung                                    
                        status = 0;
                    }

                    //logger.Debug("debit_status =" + debit_status);

                    //Tạo Transaction_Online mới
                    string vTransactionID = DBController.Transaction_Online_Insert(dtTrans.Rows[0]["msisdn"].ToString(), 4, ConvertUtility.ToInt32(partnerid), "", "");
                    //Ghi Transaction, Transaction_Log, xoá Transaction_Online cũ
                    DBController.Transaction_Insert_New(dtTrans.Rows[0]["ItemID"].ToString(), dtTrans.Rows[0]["ItemDetail"].ToString(), ConvertUtility.ToInt32(dtTrans.Rows[0]["ItemType"]),
                        dtTrans.Rows[0]["msisdn"].ToString(), 4, 0, ConvertUtility.ToInt32(dtTrans.Rows[0]["Price"]), ConvertUtility.ToInt32(partnerid),
                        ConvertUtility.ToDecimal(dtTrans.Rows[0]["TransactionID"]), ConvertUtility.ToDateTime(dtTrans.Rows[0]["Created"]), "debit_status: " + debit_status, status);
                    WapController.Transaction_Online_Delete(dtTrans.Rows[0]["msisdn"].ToString());

                    //Trả kết quả qua URL
                    if (status == 0)
                    {
                        if (AppEnv.GetSetting("ExceptPartner").IndexOf("|" + ConvertUtility.ToString(dtTrans.Rows[0]["PartnerID"]) + "|") > -1)
                        {
                            logger.Debug("http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "?&p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()));

                            Response.Redirect(@"http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "?&p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()), false);
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                            return;
                        }
                        else
                        {
                            logger.Debug("http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "?p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()));
                            if (dtTrans.Rows[0]["CallBackUrl"].ToString().IndexOf("?") > -1)
                            {
                                Response.Redirect(@"http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "&p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()), false);
                            }
                            else
                            {
                                Response.Redirect(@"http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "?p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()), false);
                            }
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                            return;
                        }
                    }
                    else
                    {
                        if (dtTrans.Rows[0]["CallBackUrl"].ToString().IndexOf("?") > -1)
                        {
                            Response.Redirect("http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "&p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|-1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()), false);
                        }
                        else
                        {
                            Response.Redirect("http://" + dtTrans.Rows[0]["Domain"].ToString() + dtTrans.Rows[0]["CallBackUrl"].ToString() + "?p=" + des.Des3Encrypt(dtTrans.Rows[0]["msisdn"].ToString() + "|-1|" + vTransactionID + "|" + dtTrans.Rows[0]["TransactionID"].ToString(), dtTrans.Rows[0]["KeyCode"].ToString()), false);
                        }
                    }
                }
                else
                {
                    Response.Redirect("http://payment.xzone.vn/e.aspx", false);
                }
            }
            catch (Exception ex)
            {
                logger.Debug("Exception=" + ex.ToString());
                Response.Redirect("http://payment.xzone.vn/e.aspx", false);
                //Response.Write(ex.ToString());
                //Response.Redirect("http://payment.xzone.vn/sc.aspx?pid=" + partnerid);
            }
        }
    }
}
