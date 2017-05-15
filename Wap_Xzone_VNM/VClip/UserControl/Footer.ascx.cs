using System;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.VClip.Library;

namespace WapXzone_VNM.VClip.UserControl
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!Page.IsPostBack)
            {
                DataTable dt = VideoController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Video.Category, 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.DataBind();
                }
            }
        }
    }
}