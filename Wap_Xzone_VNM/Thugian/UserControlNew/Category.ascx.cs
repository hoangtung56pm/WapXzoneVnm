using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlNew
{
    public partial class Category : System.Web.UI.UserControl
    {
        private static int lang;
        private string width;
        private static int catid;
        private string[] zonelist;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            zonelist = ConfigurationSettings.AppSettings.Get("relax_zoneid").Split(',');
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {
                rptZoneList.DataSource = zonelist;
                rptZoneList.ItemDataBound += rptZoneList_ItemDataBound;
                rptZoneList.DataBind();
            }

        }
        protected void rptZoneList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            string curData = (string)e.Item.DataItem;
            Label lblCatetoryName = (Label)e.Item.FindControl("lblCatetoryName");
            Repeater rptCategory = (Repeater)e.Item.FindControl("rptCategory");
            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(ConvertUtility.ToInt32(curData));
            if (lang == 1)
            {
                lblCatetoryName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
            }
            else
            {
                lblCatetoryName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
            }

            DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(ConvertUtility.ToInt32(curData), catid);
            rptCategory.DataSource = dt;
            rptCategory.ItemDataBound += rptCategory_ItemDataBound;
            rptCategory.DataBind();

        }
        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");
            if (lang == 1)
            {
                lnkCatName.Text = curData["Zone_Name"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Zone_Alias"].ToString();
            }
            lnkCatName.NavigateUrl = UrlProcess.GetRelaxNewsCategoryUrlNew(lang.ToString(), "list", width, curData["Zone_ID"].ToString());
        }
    }
}