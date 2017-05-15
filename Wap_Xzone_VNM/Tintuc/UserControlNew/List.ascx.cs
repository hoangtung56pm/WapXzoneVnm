using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising.Lib;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Tintuc.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;
        private int catID;
        protected int CurrentRow;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (!IsPostBack)
            {

                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                {
                    lnkCatName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                }
                else
                {
                    lnkCatName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
                }
                lnkCatName.NavigateUrl = UrlProcess.GetNewsCategoryUrlNew(lang.ToString(), width, catID.ToString());
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, pagesize, curpage, out totalrecord);

            if(dtCat.Rows.Count > 0)
            {
                CurrentRow = dtCat.Rows.Count;
                rptlstCategory.DataSource = dtCat;
                rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
                rptlstCategory.DataBind();
                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;
                Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
                Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
            }
            //end category list
        }

        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
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