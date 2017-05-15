using System;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;
using System.Web;

namespace WapXzone_VNM.Wap
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        private string lang;        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("NotFound.aspx");
            Session["LastPage"] = Request.RawUrl;
            lang = Request.QueryString["lang"];            
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }

                //ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                //
                //var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds.Text = advertisement.GetAds();

                //var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds1.Text = advertisement1.GetAds();

                AppEnv.RegisterAllSubConfig();
            }

            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }
            //if (HttpContext.Current.Session["msisdn"] == null)
            //{
            //    Response.Redirect(AppEnv.GetSetting("WapDefault") + "/login.aspx");
            //}
        }
    }
}
