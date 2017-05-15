using System;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class YoutubeList : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        //private static string preurl;
        private int catID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int totalrecord = 0;
                string cateName = Constant.YoutubeFilmRewriteCatName;
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataSet ds = VideoController.KhoClipGetListCache(pagesize, curpage);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                    totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0]["totalRows"]);

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.YoutubeChuyenMuc(curpage, cateName);
                    Paging1.queryparam = UrlProcess.YoutubeChuyenMuc(curpage, cateName);
                }
            }
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string key = txtKey.Text.Trim();
        //    key = UnicodeUtility.RemoveSpecialCharacter(key);
        //    key = UnicodeUtility.RemoveHtmlTags(key);
        //    if (!string.IsNullOrEmpty(key))
        //    {
        //        string url = UrlProcess.YoutubeTimKiem(key, 1, "tim-phim");

        //        //HttpContext.Current.RewritePath(url, false);

        //        Response.Redirect(url);
        //    }
        //}

    }
}