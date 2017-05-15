using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Tintuc.UserControlNew
{
    public partial class HotNews : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if (!IsPostBack)
            {
                //lastest News
                DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("news_zoneid")), 3);
                DataSet ds = ConvertUtility.SplitDataTable(dtlatest, 1);

                rptTopNews.DataSource = ds.Tables[0];
                rptTopNews.DataBind();

                rptNews.DataSource = ds.Tables[1];
                rptNews.DataBind();
            }

        }
    }
}