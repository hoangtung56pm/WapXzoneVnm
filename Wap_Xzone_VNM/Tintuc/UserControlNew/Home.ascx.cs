using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Tintuc.UserControlNew
{
    public partial class Home : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;

        protected int CurrentRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            //lastest News
            int totalrecord = 0;
            DataTable dtlatest = TintucController.GetTopNewsWithPaggingHasCache(ConvertUtility.ToInt32(AppEnv.GetSetting("news_zoneid")), pagesize, curpage, 60, out totalrecord);
            if(dtlatest.Rows.Count > 0)
            {
                CurrentRow = dtlatest.Rows.Count;

                rptlastest.DataSource = dtlatest;
                rptlastest.ItemDataBound += rptlastest_ItemDataBound;
                rptlastest.DataBind();

                

                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;
                Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
                Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";
            
            }
           
        }

        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            

            if (e.Item.ItemIndex < 0) return;

           

            var curData = (DataRowView)e.Item.DataItem;
            var lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            var litBlank = (Literal)e.Item.FindControl("litBlank");

            if (e.Item.ItemIndex < CurrentRow - 1)
            {
                litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }
            
            if (lang == 1)
            {
                lnkTitle.Text = curData["Content_Headline"].ToString();
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
            }
            
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrlNew(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
        }
    }
}