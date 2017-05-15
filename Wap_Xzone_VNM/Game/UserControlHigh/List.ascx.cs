using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {
        private User_AgentInfo _info;

        private int pagesize = 12;
        private int pagenumber = 3;
        private int curpage = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                _info = Get_User_Agent_Info();

                string CatName = string.Empty;

                DataTable catInfo = GameController.GetCategoryByCatIDHasCache(catID);
                if(catInfo != null && catInfo.Rows.Count > 0)
                {
                    CatName = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    lblCategoryName.Text = CatName;
                }

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                int totalrecord = 0;
                var dt = new DataTable();
                dt = GameController.GetAllGameByCateTypeAndAgent(AppEnv.CheckSessionTelco(), catID, (int)Constant.Game.Category, _info, pagesize, curpage, out totalrecord);
                if (dt.Rows.Count == 0)
                {
                    dt = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), catID, (int)Constant.Game.Category, pagesize, curpage, out totalrecord);
                }

                rptGameHay.DataSource = dt;
                rptGameHay.DataBind();

                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;

                Paging1.defaultparam = UrlProcess.GameChuyenMuc(catID, curpage, CatName);
                Paging1.queryparam = UrlProcess.GameChuyenMuc(catID, curpage, CatName);

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