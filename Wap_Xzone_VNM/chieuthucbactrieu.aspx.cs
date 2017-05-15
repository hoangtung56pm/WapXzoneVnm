using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM
{
    public partial class chieuthucbactrieu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                    }
                }

                string returnUrl = Request.QueryString["returnUrl"];
                string redirectUrl = "http://chieuthucbactrieu.com/";
                if(!string.IsNullOrEmpty(returnUrl))
                {
                    redirectUrl = returnUrl;
                }

                if (Session["msisdn"] != null)
                {
                    //DK Chieuthucbactrieu
                    AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "CTBT", "CTBT");//Andy Service S2_94x   
                }

                Response.Redirect(redirectUrl);
            }
        }
    }
}