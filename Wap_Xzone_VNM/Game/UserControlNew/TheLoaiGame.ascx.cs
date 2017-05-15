using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlNew
{
    public partial class TheLoaiGame : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private static string preurl;
        private static int totalcat;
        private int hotro;
        private int catID;
        private bool freecate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                width = Request.QueryString["w"];
                hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
                DataTable dt = GameController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Game.Category, 0);
                
                if(dt.Rows.Count > 0)
                {
                    totalcat = dt.Rows.Count;
                    rptTheLoaiGame.DataSource = dt;
                    rptTheLoaiGame.ItemDataBound += rptTheLoaiGame_ItemDataBound;
                    rptTheLoaiGame.DataBind();
                }
            }
        }

        protected void rptTheLoaiGame_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatLink = (HyperLink)e.Item.FindControl("lnkCatLink");
            if(lnkCatLink != null)
            {
                lnkCatLink.NavigateUrl = UrlProcess.GetGameCategoryUrlNew(lang, width, curData["W_GameCategoryID"].ToString(), hotro.ToString());
                lnkCatLink.CssClass = "link-non-black";
            }
        }

    }
}