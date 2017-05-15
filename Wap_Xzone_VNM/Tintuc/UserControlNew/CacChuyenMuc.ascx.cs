using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Tintuc.UserControlNew
{
    public partial class CacChuyenMuc : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static string preurl;
        private static int catid;
        private int parentid;
        private static int totalcat;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            parentid = ConvertUtility.ToInt32(AppEnv.GetSetting("news_zoneid"));

            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

                DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(parentid, catid);
                totalcat = dt.Rows.Count;

                if(dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.ItemDataBound += rptCategory_ItemDataBound; ;
                    rptCategory.DataBind();
                }
            }
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCateName");
            if (lang == 1)
            {
                lnkCatName.Text = curData["Zone_Name"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Zone_Alias"].ToString();
            }
            lnkCatName.NavigateUrl = UrlProcess.GetNewsCategoryUrlNew(lang.ToString(), width, curData["Zone_ID"].ToString());
        }
    }
}