using System;
using System.Data;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Phanmem.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
    {

        private int pagesize = 12;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        private int lang;
        private int hotro;
        private string width;
        private static string preurl;
        private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                _info = Get_User_Agent_Info();
                int totalrecord = 0;

                DataTable dtHotNhat = new DataTable();
                DataTable dtMoiNhat = new DataTable();

                #region HOT NHAT

                dtHotNhat = PhanmemController.GetAllAppByCateTypeAndAgent(AppEnv.CheckSessionTelco(), 10, (int)Constant.APP.Topdownload, _info, pagesize, curpage, out totalrecord);
                if (dtHotNhat.Rows.Count == 0)
                {
                    dtHotNhat = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 10, (int)Constant.APP.Topdownload, pagesize, curpage, out totalrecord);
                }

                if (dtHotNhat.Rows.Count > 0)
                {
                    rptHotNhat.DataSource = dtHotNhat;
                    rptHotNhat.DataBind();
                }

                #endregion

                #region MOI NHAT

                dtMoiNhat = PhanmemController.GetAllAppByCateTypeAndAgent(AppEnv.CheckSessionTelco(), 9, (int)Constant.APP.Lastest, _info, pagesize, tpage, out totalrecord);
                if(dtMoiNhat.Rows.Count == 0)
                {
                    dtMoiNhat = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 9, (int)Constant.APP.Lastest, pagesize, tpage, out totalrecord);
                }

                if(dtMoiNhat.Rows.Count > 0)
                {
                    rptMoiNhat.DataSource = dtMoiNhat;
                    rptMoiNhat.DataBind();
                }

                #endregion

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