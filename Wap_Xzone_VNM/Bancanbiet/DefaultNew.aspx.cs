using System;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Bancanbiet
{
    public partial class DefaultNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(AppEnv.GetSetting("WapDefault"));
        }
    }
}