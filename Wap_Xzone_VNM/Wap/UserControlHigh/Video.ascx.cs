using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class Video : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                //Tải nhiều nhất
                DataTable dtHottest = VideoController.GetAllVideoByCategoryAndDisplayType(Constant.T_Vietnamobile, 1, -1, (int)Constant.Video.Lastest, 15, 1, out totalrecord);

                if (dtHottest != null && dtHottest.Rows.Count > 0)
                {
                    Random rnd = new Random();
                    while (dtHottest.Rows.Count > 5)
                    {
                        dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                        dtHottest.AcceptChanges();
                    }

                    IList<DataRow> contentTop = dtHottest.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentTopList = dtHottest.Select().Skip(1).Take(5).ToList();

                    rptTopNew.DataSource = contentTop.CopyToDataTable();
                    rptTopNew.DataBind();

                    rptBottomNew.DataSource = contentTopList.CopyToDataTable();
                    rptBottomNew.DataBind();
                }
            }
        }
    }
}