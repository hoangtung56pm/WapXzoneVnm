using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class Msisdn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //{
            //    if (Session["msisdn"] == null)
            //    {
            //        int is3g = 0;
            //        string msisdn = MobileUtils.GetMSISDN(out is3g);
            //        if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            //        {
            //            Session["telco"] = Constant.T_Vietnamobile;
            //            Session["msisdn"] = msisdn;
            //            ltrXinChao.Text = msisdn;
            //        }
            //        else
            //        {
            //            Session["msisdn"] = null;
            //            Session["telco"] = Constant.T_Undefined;
            //            ltrXinChao.Text = "Khách";
            //        }
            //    }
            //}
        }
    }
}