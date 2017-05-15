using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {
        protected int id;
        protected int catid;
        private string price;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);

                //Detail
                DataTable dtDetail = HinhNenController.GetWallpaperDetailByIDHasCache(AppEnv.CheckSessionTelco(), id);
                catid = ConvertUtility.ToInt32(dtDetail.Rows[0]["W_CategoryID"]);
                //end detail

                if (dtDetail.Rows.Count > 0)
                {
                    if (catid == ConvertUtility.ToInt32(AppEnv.GetSetting("thuphapid")))
                        price = AppEnv.GetSetting("thuphapprice");
                    else
                        price = AppEnv.GetSetting("wallprice");

                    //lblPrice.Text = price;

                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                }
            }
        }
    }
}