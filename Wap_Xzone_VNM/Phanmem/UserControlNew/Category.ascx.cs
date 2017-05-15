using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem.UserControlNew
{
    public partial class Category : System.Web.UI.UserControl
    {
        private string lang;
        private string hotro;
        private string width;
        private static string preurl;
        private static int totalcat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]).ToString();
                width = Request.QueryString["w"];
                preurl = ConfigurationSettings.AppSettings.Get("urldata");
                DataTable dt = PhanmemController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.APP.Category, 0);
                totalcat = dt.Rows.Count;
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += rptCategory_ItemDataBound; ;
                rptCategory.DataBind();
                string price = ConfigurationSettings.AppSettings.Get("appprice");
                if (ConvertUtility.ToString(Request.QueryString["catid"]) == "1") price = "1000";
                if (lang == "1")
                {
                    ltrTheLoai.Text = Resources.Resource.pmTheLoaiPhanMem;
                }
                else
                {
                    ltrTheLoai.Text = Resources.Resource.pmTheLoaiPhanMem_KD;
                }
            }
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");
            if (lang == "1")
            {
                lnkCatName.Text = curData["Title_Unicode"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Title"].ToString();
            }
            lnkCatName.NavigateUrl = UrlProcess.GetAppCategoryUrlNew(lang, width, curData["W_AppCategoryID"].ToString(), hotro);
        }
    }
}