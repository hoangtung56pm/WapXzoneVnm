using System;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //{
            //    DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache(38);
            //    if(cpConfig != null && cpConfig.Rows.Count > 0)
            //    {
            //        rptMenu.DataSource = cpConfig;
            //        rptMenu.DataBind();
            //    }
            //}
        }
    }
}