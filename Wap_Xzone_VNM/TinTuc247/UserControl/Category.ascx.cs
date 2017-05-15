using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.TinTuc247.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static string preurl;
        private static int catid;
        private int parentid;
        private static int totalcat;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            parentid = ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("news_zoneid"));
            
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                    ltrTitle.Text = "CÁC CHUYÊN MỤC";
                DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(parentid, catid);
                totalcat = dt.Rows.Count;
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound); ;
                rptCategory.DataBind();
            }

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
            lnkCatName.NavigateUrl = UrlProcess.GetTinTucNewCategoryUrl(lang.ToString(), width, curData["Zone_ID"].ToString());
        }
    }
}