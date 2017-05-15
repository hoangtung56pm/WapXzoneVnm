using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        private static string preurl;
        private static int catid;
        private int parentid;
        private static int totalcat;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            parentid = ConvertUtility.ToInt32(AppEnv.GetSetting("news_zoneid"));

            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                //if (lang == 1)ltrTitle.Text = "CÁC CHUYÊN MỤC";
                DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(parentid, catid);
                totalcat = dt.Rows.Count;
                rptCategory.DataSource = dt;
                rptCategory.DataBind();
            }
        }
    }
}