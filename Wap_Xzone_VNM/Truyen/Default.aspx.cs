using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Truyen
{
    public partial class Default : BasePage
    {

        private int width;
        private string display;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            }

            #region Change Menu

            if (AppEnv.isMobileBrowser())
            {
                string model = AppEnv.GetUserAgent();
                if (model == "low")
                {
                    plHeader.Controls.Add(LoadControl("/TinHot/UserControl/Header.ascx"));
                }
                else
                {
                    plHeader.Controls.Add(LoadControl("/Wap/UserControlHigh/Header.ascx"));
                    plMenu.Controls.Add(LoadControl("/Wap/UserControlHigh/Menu.ascx"));
                    ltrSmartCss.Text = "<link rel=\"stylesheet\" href=\"/Content/asset/Css/style.css\"/>";
                }
            }
            else
            {
                plHeader.Controls.Add(LoadControl("/Wap/UserControlHigh/Header.ascx"));
                plMenu.Controls.Add(LoadControl("/Wap/UserControlHigh/Menu.ascx"));
                ltrSmartCss.Text = "<link rel=\"stylesheet\" href=\"/Content/asset/Css/style.css\"/>";
            }

            #endregion

            display = Request.QueryString["display"];
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("UserControl/Home.ascx"));
                    break;
                case "homeaudio":
                    plContent.Controls.Add(LoadControl("UserControl/HomeAudio.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControl/List.ascx"));
                    break;
                case "listaudio":
                    plContent.Controls.Add(LoadControl("UserControl/ListAudio.ascx"));
                    break;
                case "detail":
                    plContent.Controls.Add(LoadControl("UserControl/Detail.ascx"));
                    break;
                case "detailaudio":
                    plContent.Controls.Add(LoadControl("UserControl/DetailAudio.ascx"));
                    break;
            }
        }

    }
}