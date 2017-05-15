using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class Artist : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetArtistHasCache(curpage, pagesize, out totalrecord);

            rptTopCaSy.DataSource = dtCat;
            rptTopCaSy.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";

        }
    }
}