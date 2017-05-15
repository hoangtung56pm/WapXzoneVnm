using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlNew
{
    public partial class TheLoaiHinhNen : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private static string preurl;
        private static int totalcat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                width = Request.QueryString["w"];
                preurl = AppEnv.GetSetting("urldata");
                DataTable dt = HinhNenController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.HinhNen.Category, 0);
                totalcat = dt.Rows.Count;
                rptTheLoai.DataSource = dt;
                rptTheLoai.ItemDataBound += rptCategory_ItemDataBound;
                rptTheLoai.DataBind();
                if (lang == "1")
                {
                    ltrTheLoai.Text = Resources.Resource.hnTheLoaiHinh;
                }
                else
                {
                    ltrTheLoai.Text = Resources.Resource.hnTheLoaiHinh_KD;
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
            lnkCatName.NavigateUrl = UrlProcess.GetWallpaperCategoryUrlNew(lang, width, curData["W_CategoryID"].ToString());
        }
    }
}