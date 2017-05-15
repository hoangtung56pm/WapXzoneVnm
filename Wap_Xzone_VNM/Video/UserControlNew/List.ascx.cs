using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private int catID;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            if (!IsPostBack)
            {
                DataTable catInfo = VideoController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                {
                    litGia.Text = "(Giá: " + AppEnv.GetSetting("videoprice") + " đ/video)";
                    lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                }
                else
                {
                    litGia.Text = "(Gia: " + AppEnv.GetSetting("videoprice") + " d/video)";
                    lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
                }
                    
                lnkCateChannel.NavigateUrl = UrlProcess.GetVideoCategoryUrlNew(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetVideoHomeUrlNew(lang.ToString(), width);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, -1, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);

            if(dtCat.Rows.Count > 0)
            {
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
            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal)e.Item.FindControl("litBlank");
                if (lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}