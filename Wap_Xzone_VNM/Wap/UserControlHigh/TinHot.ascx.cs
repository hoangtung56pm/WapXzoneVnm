using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class TinHot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                DataTable dtCat = TintucController.GetAllNewsByCategoryHasCacheVnm(380, 5, 1, out totalrecord);

                if(dtCat != null && dtCat.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dtCat.Select().Skip(0).Take(1).ToList();
                    IList<DataRow> contentBottom = dtCat.Select().Skip(1).Take(5).ToList();

                    rptTop.DataSource = contentTop.CopyToDataTable();
                    rptTop.DataBind();

                    rptBottom.DataSource = contentBottom.CopyToDataTable();
                    rptBottom.DataBind();

                }
            }
        }
    }
}