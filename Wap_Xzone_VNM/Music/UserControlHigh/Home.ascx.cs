using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtVideo = Library.Component.Video.VideoController.GetAllVideoByCategoryAndDisplayType(AppEnv.CheckSessionTelco(), 31, 0, (int)Constant.Video.Category, 10, 1, out totalrecord);
                if (dtVideo != null && dtVideo.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dtVideo.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentList = dtVideo.Select().Skip(2).Take(5).ToList();
                    if(contentTop.Count > 0)
                    {
                        rptVideoTop.DataSource = contentTop.CopyToDataTable();
                        rptVideoTop.DataBind();
                    }

                    if(contentList.Count > 0)
                    {
                        rptVideoList.DataSource = contentList.CopyToDataTable();
                        rptVideoList.DataBind();
                    }
                }

                DataTable dtAlbum = MusicController.GetAlbumHotHasCache(AppEnv.CheckSessionTelco());
                if(dtAlbum != null && dtAlbum.Rows.Count > 0)
                {
                    IList<DataRow> albumlbum = dtAlbum.Select().Skip(0).Take(6).ToList();
                    rptAlbum.DataSource = albumlbum.CopyToDataTable();
                    rptAlbum.DataBind();
                }

            }
        }
    }
}