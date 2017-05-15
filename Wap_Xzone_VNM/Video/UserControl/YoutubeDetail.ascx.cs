using System;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class YoutubeDetail : System.Web.UI.UserControl
    {

        protected int lang;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if (id > 0)
            {
                DataTable dt = VideoController.KhoClipGetInfoCache(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptDetail.DataSource = dt;
                    rptDetail.DataBind();

                    DataTable dtList = VideoController.KhoClipGetTopCache();
                    rptCungTheLoai.DataSource = dtList;
                    rptCungTheLoai.DataBind();
                }
            }
        }
    }
}