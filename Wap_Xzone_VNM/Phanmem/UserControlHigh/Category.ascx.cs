using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Phanmem.UserControlHigh
{
    public partial class Category : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dt = PhanmemController.GetAllCategoryExeptCatIDHasCache(AppEnv.CheckSessionTelco(), (int)Constant.APP.Category, 0);
                
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.DataBind();
                }
            }
        }
    }
}