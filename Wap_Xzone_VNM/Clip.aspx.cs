using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM
{
    public partial class Clip : BasePage
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


                if (Session["msisdn"] != null)
                {
                    AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK CP");//Andy Service S2_94x   
                }

                Response.Redirect("http://wap.vietnamobile.com.vn/Video/Default.aspx?display=home&w=320&lang=1");
            }
        }
    }
}