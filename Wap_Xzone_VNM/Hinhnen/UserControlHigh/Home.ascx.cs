using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected int catId;
        protected string catName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;

                //DataTable dtHottest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 4, (int)Constant.HinhNen.Topdownload, 10, 1, out totalrecord);
                //DataTable dtHottest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 2, (int)Constant.HinhNen.Lastest, 10, 1, out totalrecord);
                DataTable dtHottest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 13, (int)Constant.HinhNen.Category, 10, 1, out totalrecord);
                if (dtHottest != null && dtHottest.Rows.Count > 0)
                {
                    catId = ConvertUtility.ToInt32(dtHottest.Rows[0]["W_CategoryID"].ToString());
                    catName = dtHottest.Rows[0]["Web_Name"].ToString();

                    rptHome.DataSource = dtHottest;
                    rptHome.DataBind();
                }
            }
        }
    }
}