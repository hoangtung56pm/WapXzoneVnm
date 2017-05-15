using System.Web.Services;
using _3GChargingWebService.Library;

namespace _3GChargingWebService
{
    /// <summary>
    /// Summary description for WebServiceCharging3g
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCharging3g : System.Web.Services.WebService
    {

        [WebMethod]
        public string PaymentVnm(string msisdn, string price, string content, string servicename)
        {
            string returnValue = VNMChargingGW2G.PaymentVNM(msisdn, price, "D", content, servicename);

            return returnValue;
        }

        [WebMethod]
        public string PaymentVnmWithAccount(string msisdn, string price, string content, string servicename, string userName, string userPass, string cpId)
        {
            string returnValue = VNMChargingGW2G.PaymentVnmWithAccount(msisdn, price, "D", content, servicename,userName,userPass,cpId);

            return returnValue;
        }

    }
}
