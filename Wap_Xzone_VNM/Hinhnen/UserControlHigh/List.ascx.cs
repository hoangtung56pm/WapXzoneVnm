using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {

        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        //private static string preurl;
        private int catID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                int totalrecord = 0;

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataTable dtCat;
                if(catID == 4)
                {
                    dtCat = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 4, (int)Constant.HinhNen.Topdownload, pagesize, curpage, out totalrecord);
                }
                else
                {
                    dtCat = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), catID, (int)Constant.HinhNen.Category, pagesize, curpage, out totalrecord);
                }

                

                if(dtCat != null && dtCat.Rows.Count > 0)
                {
                    string catName = dtCat.Rows[0]["Web_Name"].ToString();

                    rptList.DataSource = dtCat;
                    rptList.DataBind();

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.HinhNenChuyenMuc(catID, curpage, catName);
                    Paging1.queryparam = UrlProcess.HinhNenChuyenMuc(catID, curpage, catName);

                }
            }
        }
    }
}