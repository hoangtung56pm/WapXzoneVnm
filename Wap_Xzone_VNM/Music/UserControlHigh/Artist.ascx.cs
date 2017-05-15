using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class Artist : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        //private string lang;
        //private string width;
        //private static string preurl;

        protected void Page_Load(object sender, EventArgs e)
        {
            //preurl = ConfigurationSettings.AppSettings.Get("urldata");
            //width = Request.QueryString["w"];
            //lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();

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
            Paging1.defaultparam = UrlProcess.AmNhacChuyenMucCaSy("1", curpage.ToString(), "bai-hat-theo-ca-sy");
            Paging1.queryparam = UrlProcess.AmNhacChuyenMucCaSy("1", curpage.ToString(), "bai-hat-theo-ca-sy");
        }
    }
}