using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class BottomBanner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DataTable dtAdv = WapController.WapVnmGetAdvByPosId(ConvertUtility.ToInt32(AppEnv.GetSetting("WapVnm_bottom")));
                if (dtAdv != null && dtAdv.Rows.Count > 0)
                {
                    string url = AppEnv.GetSetting("urldata") + dtAdv.Rows[0]["Advertise_Path"];

                    string str = "<a class=\"noelbanner\" href=\"" + dtAdv.Rows[0]["Advertise_RedirectUrl"] + "\">";


                    if (AppEnv.isMobileBrowser())
                    {
                        str += "<img width=\"" + "99%" + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                    }
                    else
                    {
                        str += "<img width=\"" + dtAdv.Rows[0]["Advertise_Width"] + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                    }

                    litAdvBottom.Text = str;
                }
            }
        }
    }
}