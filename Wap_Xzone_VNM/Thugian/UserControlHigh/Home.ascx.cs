using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {

        private string[] zonelist;
        private static int catid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                zonelist = ConfigurationSettings.AppSettings.Get("relax_zoneid").Split(',');
                if (!IsPostBack)
                {
                    rptZone.DataSource = zonelist;
                    rptZone.ItemDataBound += rptZoneList_ItemDataBound;
                    rptZone.DataBind();
                }
            }
        }

        protected void rptZoneList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            string curData = (string)e.Item.DataItem;
            Label lblCatetoryName = (Label)e.Item.FindControl("lblCatetoryName");
            Repeater rptCategory = (Repeater)e.Item.FindControl("rptCategory");

            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(ConvertUtility.ToInt32(curData));
            lblCatetoryName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();

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

            lnkCatName.Text = curData["Zone_Name"].ToString();

            lnkCatName.NavigateUrl = UrlProcess.ThuGianChuyenMuc(ConvertUtility.ToInt32(curData["Zone_ID"].ToString()), 1, curData["Zone_Alias"].ToString());
        }
    }
}