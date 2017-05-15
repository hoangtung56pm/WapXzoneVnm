using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {

        private int pagesize = 5;
        //private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        protected int lang;
        protected string width;
        //private static string preurl;   

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;

                //Tải nhiều nhất
                DataTable dtHottest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 3, -1, (int)Constant.Video.Topdownload, pagesize, curpage, out totalrecord);
                if(dtHottest != null && dtHottest.Rows.Count > 0)
                {
                    rptTaiNhieuNhat.DataSource = dtHottest;
                    rptTaiNhieuNhat.DataBind(); 
                }
                
                //Mới nhất
                DataTable dtLatest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 1, -1, (int)Constant.Video.Lastest, pagesize, tpage, out totalrecord);
                if(dtLatest != null && dtLatest.Rows.Count > 0)
                {
                    rptMoiCapNhat.DataSource = dtLatest;
                    rptMoiCapNhat.DataBind();
                }

                //Nong Trong ngay
                DataTable dtNong = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 4, -1, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
                if(dtNong != null && dtNong.Rows.Count > 0)
                {
                    rptNongTrongNgay.DataSource = dtNong;
                    rptNongTrongNgay.DataBind();
                }

                //Shock
                DataTable dtShock = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 21, -1, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
                if(dtShock != null && dtShock.Rows.Count > 0)
                {
                    rptShock.DataSource = dtShock;
                    rptShock.DataBind();
                }

            }
        }
    }
}