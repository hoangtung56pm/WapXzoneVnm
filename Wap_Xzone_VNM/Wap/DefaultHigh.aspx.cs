using System;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Wap
{
    public partial class DefaultHigh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //Response.Redirect("NotFound.aspx");
                AppEnv.RegisterAllSubConfig();
                
            }
        }
    }
}