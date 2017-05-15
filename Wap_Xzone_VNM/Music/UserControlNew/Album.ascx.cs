using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class Album : System.Web.UI.UserControl
    {
        private int pagesize = 6;
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
            DataTable dtCat = MusicController.GetAlbumHasCache(Session["telco"].ToString(), curpage, pagesize, out totalrecord);

            DataSet ds = ConvertUtility.SplitDataTable(dtCat, 3);

            rptAlbum1.DataSource = ds.Tables[0];
            rptAlbum1.DataBind();

            rptAlbum11.DataSource = ds.Tables[0];
            rptAlbum11.DataBind();

            rptAlbum2.DataSource = ds.Tables[1];
            rptAlbum2.DataBind();

            rptAlbum22.DataSource = ds.Tables[1];
            rptAlbum22.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";
        }
    }
}