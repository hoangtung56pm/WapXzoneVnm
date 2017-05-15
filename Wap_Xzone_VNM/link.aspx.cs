using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WapXzone_VNM
{
    public partial class link : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p = Request.QueryString["p"];
            switch (p)
            {
                case "0":
                    Response.Redirect("/Game/Default.aspx?lang=1&display=home&w=320&hotro=0");
                    break;
                default :
                    break;
            }
            
        }
    }
}