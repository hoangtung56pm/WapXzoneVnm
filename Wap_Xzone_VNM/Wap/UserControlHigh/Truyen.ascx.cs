using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class Truyen : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = TintucController.GetTruyenOnlineHomeCache();
                if (ds != null)
                {
                    DataTable dtMoiNhat = ds.Tables[0];

                    IList<DataRow> contentTop = dtMoiNhat.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentBottom = dtMoiNhat.Select().Skip(1).Take(4).ToList();

                    rptTop.DataSource = contentTop.CopyToDataTable();
                    rptTop.DataBind();

                    rptBottom.DataSource = contentBottom.CopyToDataTable();
                    rptBottom.DataBind();
                }
            }
        }
    }
}