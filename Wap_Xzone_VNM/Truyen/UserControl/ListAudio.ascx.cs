using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Truyen.UserControl
{
    public partial class ListAudio : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;
        protected string catID;
        protected string CatName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                catID = Request.QueryString["catid"];
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataSet ds = TintucController.GetAudioBookByCategoryCache(catID,curpage,pagesize);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    CatName = ds.Tables[2].Rows[0]["StyleName"].ToString();

                    rptList.DataSource = ds.Tables[0];
                    rptList.DataBind();

                    Paging1.totalrecord = ConvertUtility.ToInt32(ds.Tables[1].Rows[0]["totalRows"]);
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.TruyenAudioChuyenMuc(catID, curpage, CatName);
                    Paging1.queryparam = UrlProcess.TruyenAudioChuyenMuc(catID, curpage, CatName);
                }
            }
        }
    }
}