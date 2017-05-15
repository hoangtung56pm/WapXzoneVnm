using System;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class YoutubeDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                if(id > 0)
                {
                    DataTable dt = VideoController.KhoClipGetInfoCache(id);
                    if(dt != null && dt.Rows.Count > 0)
                    {
                        rptDetail.DataSource = dt;
                        rptDetail.DataBind();

                        DataTable dtList = VideoController.KhoClipGetTopCache();
                        rptList.DataSource = dtList;
                        rptList.DataBind();
                    }
                }
            }
        }
    }
}