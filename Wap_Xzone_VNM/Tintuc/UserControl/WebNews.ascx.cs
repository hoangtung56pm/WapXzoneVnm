using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class WebNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataSet ds = TintucController.WebGetNewsCategoryCache();
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptCategory.DataSource = ds.Tables[0];
                    rptCategory.DataBind();
                }
            }
        }
    }
}