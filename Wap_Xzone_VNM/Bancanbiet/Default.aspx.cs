using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using System.Data;
using WapXzone_VNM.Library.Component.Bancanbiet;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Bancanbiet
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControl/BCBHome.ascx"));
                    break;
                case "listatm":
                    plContent.Controls.Add(LoadControl("UserControl/ListATM.ascx"));
                    break;
                case "listtaxi":
                    plContent.Controls.Add(LoadControl("UserControl/ListTaxi.ascx"));
                    break;
                case "listbycity":
                    plContent.Controls.Add(LoadControl("UserControl/ListByCity.ascx"));
                    break;
                case "atmdetail":
                    plContent.Controls.Add(LoadControl("UserControl/ATMDetail.ascx"));
                    break;
                case "search":
                    plContent.Controls.Add(LoadControl("UserControl/SearchResult.ascx"));
                    break;
            }

        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(UrlProcess.GetLocationSearchResultUrl(Request.QueryString["lang"], "search", Request.QueryString["w"], UnicodeUtility.UnicodeToKoDau(txtkey.Text).Trim(),Request.QueryString["catid"]));
        //}

    }
}
