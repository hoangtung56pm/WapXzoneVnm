using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using WapXzone_VNM.Library;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdn : PaymnetPage
    {
        ILog log = log4net.LogManager.GetLogger("File");
        protected void Page_Load(object sender, EventArgs e)
        {
            DesSecurity des = new DesSecurity();
            //Kiểm tra Vietnamobile  
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);
            //string msisdn = MobileUtils.GetMSISDN();

            //if (String.IsNullOrEmpty(msisdn) && Session["msisdn"] == null)
            //    msisdn = MobileUtils.GetVietnamobileMsisdn();
            int partnerId = ConvertUtility.ToInt32(Request.QueryString["partnerid"]);

            log.Info("partnerId: " + partnerId);
            

            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {
                log.Info("msisdn: " + msisdn);
                if (partnerId == 0)
                {
                    Response.Redirect("http://payment.xzone.vn/sc.aspx?link=" + des.Des3Encrypt("4|" + msisdn + "||", ConfigurationSettings.AppSettings.Get("msisdnkey")));
                }
                else
                {
                    try
                    {
                        DataTable dtPartner = DBController.Partner_GetInfo(partnerId);
                        string vTransactionID = DBController.Transaction_Online_Insert(msisdn, 4, partnerId, "", "");

                        string url = "http://" + dtPartner.Rows[0]["Domain"].ToString() +
                                     dtPartner.Rows[0]["URL"].ToString() + "?p=" +
                                     des.Des3Encrypt(msisdn + "|4|" + vTransactionID,
                                                     dtPartner.Rows[0]["KeyCode"].ToString());

                        log.Info("Url Response : " + url);


                        Response.Redirect("http://" + dtPartner.Rows[0]["Domain"].ToString() + dtPartner.Rows[0]["URL"].ToString() + "?p=" + des.Des3Encrypt(msisdn + "|4|" + vTransactionID, dtPartner.Rows[0]["KeyCode"].ToString()), false);

                    }
                    catch (Exception ex)
                    {
                        log.Info("Ex Response : " + ex.Message + "|" + ex.StackTrace);
                    }
                }

            }
            else
            {
                DataTable dtPartner = DBController.Partner_GetInfoHasCache(partnerId);
                Response.Redirect("http://" + dtPartner.Rows[0]["Domain"].ToString() + dtPartner.Rows[0]["URL"].ToString() + "?p=" + des.Des3Encrypt("||", dtPartner.Rows[0]["KeyCode"].ToString()), false);


                //Response.Redirect("http://payment.xzone.vn/sc.aspx?link=" + des.Des3Encrypt("0|||", ConfigurationSettings.AppSettings.Get("msisdnkey")));            
            }
        }
    }
}
