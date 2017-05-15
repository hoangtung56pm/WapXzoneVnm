using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.GioiTinh.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private static int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(258, catid);

                rptCategory.DataSource = dt;
                rptCategory.DataBind();
            }
        }
    }
}