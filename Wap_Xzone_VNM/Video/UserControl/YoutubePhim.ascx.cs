using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class YoutubePhim : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

                DataTable dt = VideoController.KhoClipGetTopCache();
                if (dt != null && dt.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dt.Select().Skip(0).Take(3).ToList();

                    rptHottest.DataSource = contentTop.CopyToDataTable();
                    rptHottest.DataBind();
                }
            }

        }
    }
}