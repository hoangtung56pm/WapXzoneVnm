using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Wap.UserControlHigh
{
    public partial class GameHay : System.Web.UI.UserControl
    {

        private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int totalrecord = 0;
                _info = Get_User_Agent_Info();
                DataTable dtHottest = GameController.GetAllGameByCateTypeAndAgentNoCache(Constant.T_Vietnamobile, 15, (int)Constant.Game.Topdownload, _info, 30, 1, out totalrecord);
                if (dtHottest.Rows.Count == 0)
                {
                    dtHottest = GameController.GetAllGameByCategoryAndDisplayType(Constant.T_Vietnamobile, 15, (int)Constant.Game.Topdownload, 30, 1, out totalrecord);
                }

                Random rnd = new Random();
                while (dtHottest.Rows.Count > 6)
                {
                    dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                    dtHottest.AcceptChanges();
                }

                //IList<DataRow> contentTop = dtHottest.Select().Skip(0).Take(1).ToList();
                IList<DataRow> contentBottom = dtHottest.Select().Skip(0).Take(6).ToList();

                //rptTop.DataSource = contentTop.CopyToDataTable();
                //rptTop.DataBind();

                rptBottom.DataSource = contentBottom.CopyToDataTable();
                rptBottom.DataBind();

                //rptGameHay.DataSource = dtHottest;
                //rptGameHay.DataBind();

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