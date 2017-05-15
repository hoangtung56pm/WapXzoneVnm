using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.GioiTinh.UserControl
{
    public partial class Home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dtCat = TintucController.GetGioiTinhHomeCache();

                IList<DataRow> contentTop = dtCat.Select().Skip(0).Take(15).ToList();
                IList<DataRow> contentBottom = dtCat.Select().Skip(15).Take(19).ToList();

                if (contentTop.Count > 0)
                {
                    rptTop.DataSource = contentTop.CopyToDataTable();
                    rptTop.DataBind();
                }

                if (contentBottom.Count > 0)
                {
                    rptBottom.DataSource = contentBottom.CopyToDataTable();
                    rptBottom.DataBind();
                }
            }
        }
    }
}