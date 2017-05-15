using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Hinhnen.UserControlHigh
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dt = HinhNenController.GetAllCategoryExeptCatIDHasCache(AppEnv.CheckSessionTelco(), (int)Constant.HinhNen.Category, 0);
                rptMenu.DataSource = dt;
                rptMenu.DataBind();
            }
        }
    }
}