using System;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class YoutubeSearch : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 5;
        private int curpage = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["key"];
            key = UnicodeUtility.RemoveSpecialCharacter(key);
            key = UnicodeUtility.RemoveHtmlTags(key);
            key = UnicodeUtility.UnicodeToKoDau(key);
            key = key.ToLower();

            if(!string.IsNullOrEmpty(key))
            {

                int totalrecord = 0;
                string cateName = "tim-phim";

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataSet ds = VideoController.KhoClipSearch(key, pagesize, curpage);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptList.DataSource = ds.Tables[0];
                    rptList.DataBind();

                    totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0]["totalRows"]);

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.YoutubeTimKiem(key,curpage, cateName);
                    Paging1.queryparam = UrlProcess.YoutubeTimKiem(key,curpage, cateName);

                }

                lblKetqua.Text = "Tìm thấy <b>" + totalrecord + "</b> phim";

            }
        }
    }
}