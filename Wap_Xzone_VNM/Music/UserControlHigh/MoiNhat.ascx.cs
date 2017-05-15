using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class MoiNhat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dtMoiNhat = MusicController.GetItemTopHasCache(AppEnv.CheckSessionTelco(), 5);
                if (dtMoiNhat != null && dtMoiNhat.Rows.Count > 0)
                {
                    rptMoiNhat.DataSource = dtMoiNhat;
                    rptMoiNhat.DataBind();
                }
            }
        }
    }
}