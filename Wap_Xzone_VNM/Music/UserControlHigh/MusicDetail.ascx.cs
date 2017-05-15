using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class MusicDetail : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private int id;
        protected string price;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            if(!Page.IsPostBack)
            {
                //Detail
                DataTable dtDetail = MusicController.GetItemDetail(AppEnv.CheckSessionTelco(), id);
                //end detail  
                if (dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    price = AppEnv.GetSetting("ringtoneprice");

                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();
                }
            }
        }
    }
}