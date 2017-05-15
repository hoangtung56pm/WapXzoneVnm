using System;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class DichVu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache(38);

                rptDichVu.DataSource = cpConfig;
                rptDichVu.DataBind();
            }
        }
    }
}