using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.SQLHelper;

namespace WapXzone_VNM.Wap
{
    public partial class HuongDan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = Vnm_Confirm_Link_Getall();
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptNoiDung.DataSource = dt;
                    rptNoiDung.DataBind();
                }
            }
        }
        public static DataTable Vnm_Confirm_Link_Getall()
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.GetConnectionString("ConnectionString_TTND_Services")
                                                , "Vnm_Confirm_Link_Getall");

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}