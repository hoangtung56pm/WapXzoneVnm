using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;

namespace WapXzone_VNM
{
    public partial class User_Agent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
            if (txtUserAgentName.Text=="")
            {
                // current device
                o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            }
            else
            {
                o_capabilityGetter.prepareNavigatorModelCapabilities(txtUserAgentName.Text);
            }
            // output result to label
            User_AgentInfo _info = new User_AgentInfo();
            string s_result = "Width: " + o_capabilityGetter.getCapability("resolution_width");
            s_result +=" - Height: " + o_capabilityGetter.getCapability("resolution_height") + ";";
            s_result += "Dinh dang anh ho tro: Jpg(" + o_capabilityGetter.getCapability("jpg") + ") -";
            s_result += " Gif(" + o_capabilityGetter.getCapability("gif") + ") -";
            s_result += " Anh dong(" + o_capabilityGetter.getCapability("gif_animated") + ");";
            s_result += " He dieu ha`nh: " + o_capabilityGetter.getCapability("device_os") + ";";
            s_result += " Tri`nh duyet: " + o_capabilityGetter.getCapability("mobile_browser") + ";";
            txtResult.Text =s_result;
            o_capabilityGetter.destroy();
        }

        protected User_AgentInfo Get_User_Agent_Info() {

            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("WURFL_Data\\wurfl.xml");
                Application["wurflFileProcessor"] = new wurflApi.deviceFileProcessor(s_path);
            }
            wurflApi.deviceFileProcessor o_deviceFileProcessor = (Application["wurflFileProcessor"] as wurflApi.deviceFileProcessor);
            // prepare capability getter
            wurflApi.capabilitiesGetter o_capabilityGetter = new wurflApi.capabilitiesGetter(ref o_deviceFileProcessor);
//            o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            if (txtUserAgentName.Text == "")
            {
                // current device
                o_capabilityGetter.prepareNavigatorModelCapabilities(Request);
            }
            else
            {
                o_capabilityGetter.prepareNavigatorModelCapabilities(txtUserAgentName.Text);
            }
            User_AgentInfo _info = new User_AgentInfo();
            _info.device_os = o_capabilityGetter.getCapability("device_os");
            _info.mobile_browser = o_capabilityGetter.getCapability("mobile_browser");
            _info.resolution_width = o_capabilityGetter.getCapability("resolution_width");
            _info.resolution_height = o_capabilityGetter.getCapability("resolution_height");
            _info.model_name = o_capabilityGetter.getCapability("model_name");
            _info.brand_name = o_capabilityGetter.getCapability("brand_name");
            return _info;
        }
    }
}
