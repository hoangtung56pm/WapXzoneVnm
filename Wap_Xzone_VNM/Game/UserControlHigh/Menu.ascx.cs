using System;
using System.Data;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Game.UserControlHigh
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["telco"] == null)
                    Session["telco"] = Constant.T_Undefined;

                DataTable dt = GameController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Game.Category, 0);
                //totalcat = dt.Rows.Count;
                rptMenu.DataSource = dt;
                //rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound);
                rptMenu.DataBind();
            }
        }
    }
}