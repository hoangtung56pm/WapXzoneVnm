using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.GioiTinh.UserControl
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;
        protected int catID;
        protected string CatName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                if (catInfo != null && catInfo.Rows.Count > 0)
                {
                    CatName = catInfo.Rows[0]["Zone_Name"].ToString();
                }

                int totalrecord = 0;
                DataTable dtCat = new DataTable();
                dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, pagesize, curpage, out totalrecord);

                if (dtCat != null && dtCat.Rows.Count > 0)
                {
                    rptList.DataSource = dtCat;
                    rptList.DataBind();

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.GioiTinhChuyenMuc(catID, curpage, CatName);
                    Paging1.queryparam = UrlProcess.GioiTinhChuyenMuc(catID, curpage, CatName);

                }
            }
        }
    }
}