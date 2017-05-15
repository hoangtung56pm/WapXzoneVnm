using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlNew
{
    public partial class Home : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;  

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
            {
                tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
            }
            int totalrecord = 0;
            if (lang == 0)
            {
                litGia.Text = "(Gia: " + AppEnv.GetSetting("videoprice") + " d/video)";
                //ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat_KD;
                //ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat_KD;
            }
            else
            {
                litGia.Text = "(Giá: " + AppEnv.GetSetting("videoprice") + " đ/video)";
                //ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat;
                //ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat;
            }

            #region Tai Nhieu Nhat
            
            DataTable dtHottest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 3, -1, (int)Constant.Video.Topdownload, pagesize, curpage, out totalrecord);
            rptTaiNhieuNhat.DataSource = dtHottest;
            rptTaiNhieuNhat.ItemDataBound += rptTaiNhieuNhat_ItemDataBound;
            rptTaiNhieuNhat.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";

            #endregion

            #region Moi Cap Nhat
            
            DataTable dtLatest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 1, -1, (int)Constant.Video.Lastest, pagesize, tpage, out totalrecord);
            rptMoiCapNhat.DataSource = dtLatest;
            rptMoiCapNhat.ItemDataBound += rptMoiCapNhat_ItemDataBound;
            rptMoiCapNhat.DataBind();

            Paging2.totalrecord = totalrecord;
            Paging2.pagesize = pagesize;
            Paging2.numberpage = pagenumber;
            Paging2.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"];
            Paging2.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&tpage=";

            #endregion

        }

        protected void rptTaiNhieuNhat_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void rptMoiCapNhat_ItemDataBound(object sender, RepeaterItemEventArgs e)
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