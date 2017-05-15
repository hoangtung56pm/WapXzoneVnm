using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlNew
{
    public partial class Home : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        protected int lang;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                litGia.Text = "(Gia: " + AppEnv.GetSetting("wallprice") + " d/hinh nen)";
                litTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat_KD;
                litMoiCapNhat.Text = Resources.Resource.wMoiCapNhat_KD;
            }
            else
            {
                litGia.Text = "(Giá: " + AppEnv.GetSetting("wallprice") + " đ/hình nền)";
                litTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat;
                litMoiCapNhat.Text = Resources.Resource.wMoiCapNhat;
            }

            //Tải nhiều nhất
            DataTable dtHottest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 4, (int)Constant.HinhNen.Topdownload, pagesize, curpage, out totalrecord);
           
            if(dtHottest.Rows.Count > 3)
            {
                DataSet ds = ConvertUtility.SplitDataTable(dtHottest, 3);

                rptTaiNhieuNhat1.DataSource = ds.Tables[0];
                rptTaiNhieuNhat1.DataBind();

                rptTaiNhieuNhat11.DataSource = ds.Tables[0];
                rptTaiNhieuNhat11.DataBind();

                rptTaiNhieuNhat2.DataSource = ds.Tables[1];
                rptTaiNhieuNhat2.DataBind();

                rptTaiNhieuNhat22.DataSource = ds.Tables[1];
                rptTaiNhieuNhat22.DataBind();
            }
            else
            {
                rptTaiNhieuNhat1.DataSource = dtHottest;
                rptTaiNhieuNhat1.DataBind();

                rptTaiNhieuNhat11.DataSource = dtHottest;
                rptTaiNhieuNhat11.DataBind();
            }

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";

            //Mới nhất
            DataTable dtLatest = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 2, (int)Constant.HinhNen.Lastest, pagesize, tpage, out totalrecord);

            if(dtLatest.Rows.Count > 3)
            {
                DataSet ds = ConvertUtility.SplitDataTable(dtLatest, 3);

                rptMoiCapNhat1.DataSource = ds.Tables[0];
                rptMoiCapNhat1.DataBind();

                rptMoiCapNhat11.DataSource = ds.Tables[0];
                rptMoiCapNhat11.DataBind();

                rptMoiCapNhat2.DataSource = ds.Tables[1];
                rptMoiCapNhat2.DataBind();

                rptMoiCapNhat22.DataSource = ds.Tables[1];
                rptMoiCapNhat22.DataBind();
            }
            else
            {
                rptMoiCapNhat1.DataSource = dtLatest;
                rptMoiCapNhat1.DataBind();

                rptMoiCapNhat11.DataSource = dtLatest;
                rptMoiCapNhat11.DataBind();
            }

            Paging2.totalrecord = totalrecord;
            Paging2.pagesize = pagesize;
            Paging2.numberpage = pagenumber;
            Paging2.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"];
            Paging2.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&tpage=";

        }
    }
}