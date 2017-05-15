using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Game.UserControlHigh
{
    public partial class Category : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dt = GameController.GetAllCategoryExeptCatIDHasCache(AppEnv.CheckSessionTelco(), (int)Constant.Game.Category, 0);
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.DataBind();
                }
            }
        }
    }
}