using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Sub
{
    public partial class RegisVisport : Page
    {
        private string width;
        private string height;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_AgentInfo info = Get_User_Agent_Info();
            width = info.resolution_width;
            height = info.resolution_height;
            if (ConvertUtility.ToInt32(width) == 0 || ConvertUtility.ToInt32(width) > 400)
            {
                width = ConvertUtility.ToString((int)Constant.DefaultScreen.Standard);
            }

            ltrimg.Text = " <img src=\"/images/banner1.jpg\" width=\"" + width + "px\" height = \"94%\" />";
            //ltrimg.Text = " <img src=\"/images/banner1.jpg\" width=\"" + width + "px\" height = \"" + height + "px\" />";
            //ltrimg.Text = " <img src=\"/images/banner1.jpg\" width=\"" + width + "px\" />";
        }

        protected User_AgentInfo Get_User_Agent_Info()
        {
            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("\\WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
            o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            User_AgentInfo _info = new User_AgentInfo();
            _info.device_os = o_capabilityGetter.getCapability("device_os");
            _info.mobile_browser = o_capabilityGetter.getCapability("mobile_browser");
            _info.resolution_width = o_capabilityGetter.getCapability("resolution_width");
            _info.resolution_height = o_capabilityGetter.getCapability("resolution_height");
            _info.model_name = o_capabilityGetter.getCapability("model_name");
            _info.brand_name = o_capabilityGetter.getCapability("brand_name");
            BasePage.AddDevice(HttpContext.Current.Request.UserAgent, _info.model_name, _info.brand_name, _info.device_os, _info.mobile_browser, _info.resolution_width, _info.resolution_height);
            return _info;
        }
    }
}