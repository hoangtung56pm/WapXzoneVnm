using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.NhacChoSub;

namespace WapXzone_VNM
{
    public partial class nc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

            if (Session["msisdn"] != null)
            {

                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                string messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "", "", "3000", "D", "RELAX", "DK MN 943");

                if (messageReturn == "1")
                {
                    MOProcessor obj = new MOProcessor();

                    obj.ProcessMO("DK", "943", Session["msisdn"].ToString(), "DK MN", DateTime.Now.ToString("yyyyMMddHHmmss"));
                }
                else
                {
                    pnlSMS.Visible = true;

                    ltrSMS.Text = "Bạn vui lòng soạn tin theo cú pháp <b>DK MN</b> gửi <b>943</b>";
                }
            }
            else
            {
                pnlSMS.Visible = true;
                ltrSMS.Text = "Bạn vui lòng soạn tin theo cú pháp <b>DK MN</b> gửi <b>943</b>";
            }
        }
    }
}