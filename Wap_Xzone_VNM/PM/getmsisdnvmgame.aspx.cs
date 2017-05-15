using System;
using System.Web.Script.Serialization;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.PM
{
    public partial class getmsisdnvmgame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int is3g = 0;
            string msisdn = MobileUtils.GetMSISDN(out is3g);
            //msisdn = "84123456789";

            string p = Request.QueryString["p"];
            if(p =="1")
            {
                Response.Redirect("");
            }

            var jsonObj = new
            {
                SDT = msisdn
            };
            var jScriptSerializer = new JavaScriptSerializer();
            string jsonClient = jScriptSerializer.Serialize(jsonObj);

            Response.Write(jsonClient);
        }
    }
}