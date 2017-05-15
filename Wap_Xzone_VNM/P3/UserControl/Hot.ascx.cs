using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WapXzone_VNM.P3.UserControl
{
    public partial class Hot : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptList.DataSource = Controller.GetDataHot(0, 5);           
            rptList.DataBind();

        }
        
        protected string GetLinkDetail(object id)
        {
            return "/P3/default.aspx?display=detail&id=" + id;
        }
    }
}