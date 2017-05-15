using System;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Truyen.UserControl
{
    public partial class HomeAudio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataSet ds = TintucController.GetTruyenAudioHomeCache();
                
                if(ds != null)
                {
                    DataTable dtMoi = ds.Tables[0];
                    DataTable dtHot = ds.Tables[1];

                    rptTruyenMoi.DataSource = dtMoi;
                    rptTruyenMoi.DataBind();

                    rptTruyenHot.DataSource = dtHot;
                    rptTruyenHot.DataBind();
                }
            }
        }
    }
}