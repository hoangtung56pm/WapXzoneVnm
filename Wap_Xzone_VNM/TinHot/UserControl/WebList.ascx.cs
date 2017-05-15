using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class WebList : System.Web.UI.UserControl
    {

        protected string CatName;
        protected int CatID;

        protected void Page_Load(object sender, EventArgs e)
        {
            CatID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (CatID > 0)
            {
                DataSet ds = TintucController.WebGetNewsByCatIdCache(CatID);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptList.DataSource = ds.Tables[0];
                    rptList.DataBind();
                }

                if(ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    CatName = ds.Tables[1].Rows[0]["Name"].ToString();
                }

            }
        }
    }
}