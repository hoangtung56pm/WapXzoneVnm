using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WapXzone_VNM.Sub
{
    public partial class RegisGameportal1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ms = "";
            if (Session["msisdn"] != null)
            {
                ms = Session["msisdn"].ToString();
            }
            if (ms != string.Empty && ms != "khach")
            {
                RegisGamePT.ProcessMO rs = new RegisGamePT.ProcessMO();
                rs.SMSMOReceiver("DK", "2288", ms, "DK KM", "2");
                Response.Redirect("http://wap.vietnamobile.com.vn");
            }
            else
            {
                Response.Redirect("http://vmgame.vn/tin-tuc-chi-tiet.html?Zone_ID=9&id=1646");
            }
        }
    }
}