using System;
using System.Data;
using System.Web.UI;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM
{
    public partial class BigPromotion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSdt.Text))
            {
                string userId = txtSdt.Text.Trim();
                //userId = userId.Replace(userId.Substring(0,1), "84");
                DataTable dtUser = WapController.BigPromotionGetCode(userId);
                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    rptCode.DataSource = dtUser;
                    rptCode.DataBind();
                }
            }
        }

    }
}