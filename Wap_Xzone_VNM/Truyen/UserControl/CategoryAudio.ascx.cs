using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Truyen.UserControl
{
    public partial class CategoryAudio : System.Web.UI.UserControl
    {

        //private static int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                DataTable dt = TintucController.GetCategoryTruyenAudioCache();

                rptCategory.DataSource = dt;
                rptCategory.DataBind();
            }
        }
    }
}