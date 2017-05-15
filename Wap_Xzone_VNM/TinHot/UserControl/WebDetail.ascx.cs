using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class WebDetail : System.Web.UI.UserControl
    {
        //protected int lang;
        //protected string width;
        protected string CatName;
        protected int catID;
        private int id;
        protected string DetailName;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if(id > 0)
            {
                DataSet ds = TintucController.WebGetNewsInfoCache(id);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    CatName = ds.Tables[0].Rows[0]["ParentName"].ToString();
                    catID = ConvertUtility.ToInt32(ds.Tables[0].Rows[0]["ParentId"].ToString());

                    DetailName = ds.Tables[0].Rows[0]["Title"].ToString();

                    rptDetail.DataSource = ds.Tables[0];
                    rptDetail.DataBind();
                }
            }
        }
    }
}