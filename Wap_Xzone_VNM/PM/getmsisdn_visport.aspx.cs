using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdn_visport : Page
    {
        ILog logger = LogManager.GetLogger(typeof(getmsisdn_visport));
        protected void Page_Load(object sender, EventArgs e)
        {
            string domain = Request.QueryString["p"];
            

            #region VNM ISING

            //int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN1();

            string url;
            logger.Debug(" ");
            logger.Debug("Domain =" + domain);

            logger.Debug("msisdn =" + msisdn);
            logger.Debug(" ");

            if (!string.IsNullOrEmpty(msisdn) && msisdn != "unknown")
            {
                url = domain + "&msisdn=" + msisdn;
                logger.Debug("URL RESPONSE : " + url);
                Response.Redirect(url);
            }
            else
            {
                //url = "http://wap.vietnamobile.com.vn";
                //Response.Redirect(url);

                url = domain + "&msisdn=" + "khach";
                logger.Debug("URL RESPONSE : " + url);
                Response.Redirect(url);
            }

           

            #endregion
        }
    }
}