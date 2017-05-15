using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {

        private int pagesize = 12;
        private int pagenumber = 3;
        private int curpage = 1;
        //private int lang;
        //private string price;
        //private string width;
        private int catID;

        protected void Page_Load(object sender, EventArgs e)
        {
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if(!Page.IsPostBack)
            {
                string catName = string.Empty;
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                if(catInfo != null && catInfo.Rows.Count > 0)
                {
                    catName = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    lblCatetoryName.Text = catName;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                int totalrecord = 0;
                DataTable dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, pagesize, curpage, out totalrecord);
                if(dtCat != null && dtCat.Rows.Count > 0)
                {
                    rptCategory.DataSource = dtCat;
                    rptCategory.DataBind();

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.ThuGianChuyenMuc(catID, curpage, catName);
                    Paging1.queryparam = UrlProcess.ThuGianChuyenMuc(catID, curpage, catName);
                }

            }
        }
    }
}