using System;
using System.Web.UI;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdnvsport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesSecurity des = new DesSecurity();
            //Kiểm tra Vietnamobile  
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);
            //string msisdn = MobileUtils.GetMSISDN();

            //if (String.IsNullOrEmpty(msisdn) && Session["msisdn"] == null)
            //    msisdn = MobileUtils.GetVietnamobileMsisdn();

            string t = Request.QueryString["t"];

            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {
                Response.Redirect(AppEnv.GetSetting("vsporturl") + des.Des3Encrypt("4|" + msisdn + "||", AppEnv.GetSetting("msisdnkey")) + "&t=" + t);
            }
            else
            {
                Response.Redirect(AppEnv.GetSetting("vsporturl") + des.Des3Encrypt("0|||", AppEnv.GetSetting("msisdnkey")) + "&t=" + t);
            }
        }
    }
}