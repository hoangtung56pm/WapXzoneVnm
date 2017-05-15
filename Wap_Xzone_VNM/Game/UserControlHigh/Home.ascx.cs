using System;
using System.Data;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Game.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {

        private User_AgentInfo _info;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                _info = Get_User_Agent_Info();
                int totalrecord = 0;
                var dtLastest = new DataTable();
                dtLastest = GameController.GetAllGameByCateTypeAndAgent(AppEnv.CheckSessionTelco(), 16, (int)Constant.Game.Lastest, _info, 12, 1, out totalrecord);
                if (dtLastest.Rows.Count == 0)
                {
                    dtLastest = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 16, (int)Constant.Game.Lastest, 12, 1, out totalrecord);
                }

                rptGameHay.DataSource = dtLastest;
                rptGameHay.DataBind();
            }
        }

        public User_AgentInfo Get_User_Agent_Info()
        {

            if (Application["wurflFileProcessor"] == null)
            {
                string s_path = HttpContext.Current.Request.MapPath("..\\WURFL_Data\\wurfl.xml");
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
            return _info;
        }

    }
}