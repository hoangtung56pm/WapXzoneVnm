using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class Album : System.Web.UI.UserControl
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
            DataTable dtCat = MusicController.GetAlbumHasCache(AppEnv.CheckSessionTelco(), curpage, pagesize, out totalrecord);
            rptAlbum.DataSource = dtCat;
            rptAlbum.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = UrlProcess.AmNhacChuyenMucAlbum("1",curpage.ToString(),"album-hot");
            Paging1.queryparam = UrlProcess.AmNhacChuyenMucAlbum("1", curpage.ToString(), "album-hot");
        }
    }
}