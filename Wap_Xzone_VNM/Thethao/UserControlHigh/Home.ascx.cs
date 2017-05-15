using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {
        private int catID = 11;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtVideo = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), catID, -1, (int)Constant.Video.Category, 4, 1, out totalrecord);
                if(dtVideo != null && dtVideo.Rows.Count > 0)
                {
                    rptVideo.DataSource = dtVideo;
                    rptVideo.DataBind();
                }

                DataTable dtlatest = ThethaoController.GetHomeNewsHasCache();
                if (dtlatest != null && dtlatest.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dtlatest.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentList = dtlatest.Select().Skip(1).Take(4).ToList();

                    rptTopNews.DataSource = contentTop.CopyToDataTable();
                    rptTopNews.DataBind();

                    if(contentList.Count > 0)
                    {
                        rptListNews.DataSource = contentList.CopyToDataTable();
                        rptListNews.DataBind();
                    }
                }
            }
        }
    }
}