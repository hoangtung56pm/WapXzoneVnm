using System;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.Hinhnen
{
    public partial class DefaultHigh : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string display;
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
                        plContent.Controls.Add(LoadControl("UserControlHigh/Home.ascx"));
                        break;
                    case "list":
                        plContent.Controls.Add(LoadControl("UserControlHigh/List.ascx"));
                        break;
                    case "detail":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Detail.ascx"));
                        break;
                    case "download":
                        plContent.Controls.Add(LoadControl("UserControlHigh/Download.ascx"));
                        break;
                }
            }
        }
    }
}