using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected int ZoneId;

        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if(!Page.IsPostBack)
            {
                DataTable dt = TintucController.GetCategoryForHotNewsHomeCache();
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.ItemDataBound += rptCategory_ItemDataBound;
                    rptCategory.DataBind();
                }
            }
        }

        void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var rptTop = (Repeater)e.Item.FindControl("rptTop");
                var rptBottom = (Repeater)e.Item.FindControl("rptBottom");

                var currData = (DataRowView)e.Item.DataItem;

                int totalrecord = 0;
                DataTable dtCat = new DataTable();

                ZoneId = ConvertUtility.ToInt32(currData["Zone_ID"]);

                if (ConvertUtility.ToInt32(currData["Zone_ID"]) == 129)// THE THAO SO
                {
                    dtCat = ThethaoController.GetLastestNewsFromTheThaoSoHasCache(1, 10, out totalrecord);
                }
                else
                {
                    dtCat = TintucController.GetAllNewsByCategoryHasCache(ConvertUtility.ToInt32(currData["Zone_ID"]), 10, 1, out totalrecord);
                }

                IList<DataRow> contentTop = dtCat.Select().Skip(0).Take(5).ToList();
                IList<DataRow> contentBottom = dtCat.Select().Skip(5).Take(9).ToList();

                if(contentTop.Count > 0)
                {
                    rptTop.DataSource = contentTop.CopyToDataTable();
                    rptTop.DataBind();
                }

                if (contentBottom.Count > 0)
                {
                    rptBottom.DataSource = contentBottom.CopyToDataTable();
                    rptBottom.DataBind();
                }

            }

        }
    }
}