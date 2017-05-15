using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using System.Configuration;
using log4net;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdnising : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ILog logger = LogManager.GetLogger("File");

            string domain = Request.QueryString["p"];
            if (domain.Trim() == "ising.vn" || domain.Trim() == "123.29.67.36:7001")
            {
                #region ISING

                //int is3g = 0;
                string msisdn = MobileUtils.GetMSISDN1();

                string url;
                logger.Debug(" ");
                logger.Debug("Domain =" + domain);

                logger.Debug("msisdn =" + msisdn);
                logger.Debug(" ");

                if (!string.IsNullOrEmpty(msisdn) && msisdn != "unknown")
                {
                    url = "http://" + domain + "/?p=" + msisdn;
                    logger.Debug("URL RESPONSE : " + url);
                    Response.Redirect(url);
                }
                else
                {
                    url = "http://" + domain + "/";
                    Response.Redirect(url);
                }   

                #endregion
            }
            else if (domain.IndexOf("vnm.ising.vn") > 0 || domain.Trim() == "123.29.67.36")
            {
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
                    url = domain + "&p=" + msisdn;
                    logger.Debug("URL RESPONSE : " + url);
                    Response.Redirect(url);
                }
                else
                {
                    //url = "http://wap.vietnamobile.com.vn";
                    //Response.Redirect(url);

                    url = domain + "&p=" + "khach";
                    logger.Debug("URL RESPONSE : " + url);
                    Response.Redirect(url);
                }

                #endregion
            }
            else if(domain.ToLower().Trim().IndexOf("mtv.vietnamobile.com.vn") > -1)
            {
                #region mtv.vietnamobile.com.vn
                try
                {
                    //int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN1();

                    string url;
                    logger.Debug("MTV");
                    logger.Debug("Domain =" + domain);

                    logger.Debug("msisdn =" + msisdn);
                    logger.Debug(" ");
                    string key = "v@sCAVnM";
                    MTVSecurity objSecurity = new MTVSecurity();
                    string t = ConvertUtility.ToString(Request.QueryString["t"]);
                    string strTime = objSecurity.Decrypt(t, key);
                    if (!string.IsNullOrEmpty(msisdn) && msisdn != "unknown")
                    {
                        logger.Debug("MTV Succ");
                        string strvalue = objSecurity.Encrypt(string.Concat(strTime, ",", msisdn), key);
                        url = "http://" + domain + "?p=" + strvalue;
                        logger.Debug("MTV URL RESPONSE : " + url);
                        Response.Redirect(url);
                    }
                    else
                    {
                        logger.Debug("MTV Fail");
                        url = "http://" + domain + "?p=" + t;
                        Response.Redirect(url);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.ToString());
                }
                #endregion
            }
            //else if (domain.ToLower().Trim().IndexOf("http://123.29.67.36:7001") > -1)
            //{
            //    //http://123.29.67.36:7001/GetMsisdn.aspx

            //    #region VFUN

            //    //int is3g = 0;
            //    string msisdn = MobileUtils.GetMSISDN1();

            //    string url;
            //    logger.Debug(" ");
            //    logger.Debug("Domain =" + domain);

            //    logger.Debug("msisdn =" + msisdn);
            //    logger.Debug(" ");

            //    if (!string.IsNullOrEmpty(msisdn) && msisdn != "unknown")
            //    {
            //        url = "http://" + domain + "/?p=" + msisdn;
            //        logger.Debug("URL RESPONSE : " + url);
            //        Response.Redirect(url);
            //    }
            //    else
            //    {
            //        url = "http://" + domain + "/";
            //        Response.Redirect(url);
            //    }   

            //    #endregion

            //}

        }
    }
}
