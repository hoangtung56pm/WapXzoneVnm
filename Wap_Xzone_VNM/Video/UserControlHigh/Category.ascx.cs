using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class Category : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = VideoController.GetAllCategoryExeptCatIDHasCache(AppEnv.CheckSessionTelco(), (int)Constant.Video.Category, 0);
            
            if(dt != null && dt.Rows.Count > 0)
            {
                rptCategory.DataSource = dt;
                rptCategory.DataBind();
            }

        }
    }
}