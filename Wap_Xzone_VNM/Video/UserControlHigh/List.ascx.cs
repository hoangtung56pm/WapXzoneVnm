using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
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
                int totalrecord = 0;
                string cateName = string.Empty;
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

                DataTable catInfo = VideoController.GetCategoryByCatIDHasCache(catID);
                if(catInfo != null && catInfo.Rows.Count > 0)
                {
                    cateName = catInfo.Rows[0]["Title_Unicode"].ToString();
                    lblCategorryName.Text = cateName;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                var dt = new DataTable();
                if(catID == 1)
                {
                    cateName = "tai-nhieu-nhat";
                    dt = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 3, -1, (int)Constant.Video.Topdownload, pagesize, curpage, out totalrecord);
                }
                else if(catID == 2)
                {
                    cateName = "moi-cap-nhat";
                    dt = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 1, -1, (int)Constant.Video.Lastest, pagesize, curpage, out totalrecord);
                }
                else
                {
                    dt = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), catID, -1, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
                }

                if(dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.VideoChuyenMuc(catID, curpage, cateName);
                    Paging1.queryparam = UrlProcess.VideoChuyenMuc(catID, curpage, cateName);

                }
            }
        }

    }
}