using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class BaiHatTheoTheLoai : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dt = MusicController.GetStyleTopHasCache(5);
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptTheLoai.DataSource = dt;
                    //rptTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptTheLoai_ItemDataBound);
                    rptTheLoai.DataBind();
                }
            }
        }
    }
}