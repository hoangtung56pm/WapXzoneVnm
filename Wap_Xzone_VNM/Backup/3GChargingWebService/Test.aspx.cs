using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _3GChargingWebService.Library;

namespace _3GChargingWebService
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string returnValue = VNMChargingGW2G.PaymentVnmWithAccount("84923045548", "2000", "D", "Test", "ViSport", "VMGViSport", "v@#port", "1930");

            lblTest.Text = returnValue;
        }
    }
}