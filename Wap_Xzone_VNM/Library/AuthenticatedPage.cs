using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WapXzone_VNM.Library
{
    public class AuthenticatedPage: Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);
            string urlRes = AppEnv.GetSetting("WapDefault") + "/login.aspx";          

            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {
                Session["telco"] = Constant.Constant.T_Vietnamobile;
                Session["msisdn"] = msisdn;

            }
            else
            {
                Session["msisdn"] = null;
                Session["telco"] = Constant.Constant.T_Undefined;
                Response.Redirect(urlRes);
            }

        }
    }
}

