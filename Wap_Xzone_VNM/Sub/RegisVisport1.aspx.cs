using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WapXzone_VNM.Sub
{
    public partial class RegisVisport1 : System.Web.UI.Page
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
                WSVisport.WebService ws = new WSVisport.WebService();
                //Random ran = new Random();
                //ran.Next(0, 1000);
                ws.WSProcessMo(ms, "979", "DK", "DK KM", "1001");
                Response.Redirect("http://wap.vietnamobile.com.vn");
            }
            else
            {
                Response.Redirect("http://wap.vietnamobile.com.vn");
            }
           
        }
    }
}