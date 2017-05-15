using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Tintuc
{
    public partial class TinKhuyenMai : BasePage
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

                string url = UrlProcess.GetNewsHomeUrl("1", "320");
                if (Session["msisdn"] != null)
                {
                    //DK TIN KHUYEN MAI
                    AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK KM");//Andy Service S2_94x   
                }

                Response.Redirect(url);
            }
        }
    }
}