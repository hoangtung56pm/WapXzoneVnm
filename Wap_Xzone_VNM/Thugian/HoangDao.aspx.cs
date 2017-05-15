using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Thugian
{
    public partial class HoangDao : BasePage
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

                string k = Request.QueryString["k"];

                string key = DateTime.Now.ToString("yyyyMMdd");
                string en = SecurityMethod.MD5Encrypt(key);

                if (en == k)
                {
                    Session["ChargedOk"] = "OK";
                    DataTable dt = TintucController.GetRandomForHoangDao();
                    string link = "/Thugian/Download.aspx?id=" + dt.Rows[0]["Distribution_ID"] + "&lang=1&w=320";
                    Response.Redirect(link);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }
        }
    }
}