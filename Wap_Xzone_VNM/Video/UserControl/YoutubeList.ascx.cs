using System;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class YoutubeList : System.Web.UI.UserControl
    {

        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        //private static string preurl;
        //private int catID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            //catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            if (!Page.IsPostBack)
            {
                int totalrecord = 0;
                string cateName = Constant.YoutubeFilmRewriteCatName;
                //catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

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


                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";

                }
            }
        }
    }
}