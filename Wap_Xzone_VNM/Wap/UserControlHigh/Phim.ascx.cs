using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Video;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class Phim : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dt = VideoController.KhoClipGetTopCache();
                if(dt != null && dt.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dt.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentTopList = dt.Select().Skip(1).Take(5).ToList();

                    rptTopNew.DataSource = contentTop.CopyToDataTable();
                    rptTopNew.DataBind();

                    rptBottomNew.DataSource = contentTopList.CopyToDataTable();
                    rptBottomNew.DataBind();
                }
            }
        }
    }
}