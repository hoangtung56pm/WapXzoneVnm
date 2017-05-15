using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using log4net;

namespace WapXzone_VNM.dudoan_Chelsea
{
    public partial class Chelsea : System.Web.UI.Page
    {
        ILog logger = log4net.LogManager.GetLogger("Chelsea");
        private string mtContent;
        protected void Page_Load(object sender, EventArgs e)
        {
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);
            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {
                Session["msisdn"] = msisdn;
                logger.Debug(string.Format("sdt_Chelsea:{0}",msisdn));
            }
            if (Session["msisdn"] != null)
            {
                string sdt = Session["msisdn"].ToString();
                //mtContent = "Chuc mung Quy Khach da dang ky thanh cong dich vu Du doan Chelsea cua VNM.Quy Khach duoc mien phi su dung dich vu." +
                //            "De huy dich vu Quy khach vui long soan HUY gui 1003";

                #region S2 94x

                string s294xdk = "DK";

                if (s294xdk != "")
                {
                    string value1 = RegisterService("1003", "0",
                                                    sdt, "DK", s294xdk);

                    logger.Debug(string.Format("service_Chelsea:{0}", value1));
                    string[] values1 = value1.Split('|');

                    //if (values1[0].Trim() == "1")
                    //{

                    //    AppEnv.SendMt(sdt, "1003", "DK", mtContent);

                    //}

                }
                #endregion
                tab5.Visible = true;
                tab6.Visible = false;
            }
            if (Session["msisdn"] == null)
            {
                tab5.Visible = false;
                tab6.Visible = true;
            }
        }
        public static string RegisterService(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
          
            WS_VNMChelsea.WS_VNMChelsea objChelsea = new WS_VNMChelsea.WS_VNMChelsea();
            string reString = objChelsea.WapRequest(msisdn);

            return reString;
        }
        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
    }
}