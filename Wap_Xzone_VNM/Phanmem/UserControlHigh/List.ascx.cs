using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {

        private int pagesize = 12;
        private int pagenumber = 3;
        private int curpage = 1;
        
        private int catID;
        
        private User_AgentInfo _info;
        private bool freecate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                string CatName = string.Empty;

                if (catID == ConvertUtility.ToInt32(AppEnv.GetSetting("freecate")))
                    freecate = true;
                _info = Get_User_Agent_Info();

                int totalrecord = 0;

                DataTable catInfo = PhanmemController.GetCategoryByCatIDHasCache(catID);
                if(catInfo != null && catInfo.Rows.Count > 0)
                {
                    lblChuyenMuc.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    CatName = catInfo.Rows[0]["Title"].ToString().ToUpper();
                }

                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                DataTable dtList = new DataTable();
                if(catID == 9)
                {
                    dtList = PhanmemController.GetAllAppByCateTypeAndAgent(AppEnv.CheckSessionTelco(), 9, (int)Constant.APP.Lastest, _info, pagesize, curpage, out totalrecord);
                    if (dtList.Rows.Count == 0)
                    {
                        dtList = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 9, (int)Constant.APP.Lastest, pagesize, curpage, out totalrecord);
                    }
                }
                else if(catID == 10)
                {
                    dtList = PhanmemController.GetAllAppByCateTypeAndAgent(AppEnv.CheckSessionTelco(), 10, (int)Constant.APP.Topdownload, _info, pagesize, curpage, out totalrecord);
                    if (dtList.Rows.Count == 0)
                    {
                        dtList = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), 10, (int)Constant.APP.Topdownload, pagesize, curpage, out totalrecord);
                    }
                }
                else
                {
                    dtList = PhanmemController.GetAllAppByCateTypeAndAgent(AppEnv.CheckSessionTelco(), catID, (int)Constant.APP.Category, _info, pagesize, curpage, out totalrecord);
                    if (dtList.Rows.Count == 0)
                    {
                        dtList = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), catID, (int)Constant.APP.Category, pagesize, curpage, out totalrecord);
                    }
                }

                if(dtList.Rows.Count > 0)
                {
                    rptList.DataSource = dtList;
                    rptList.DataBind();

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;

                    Paging1.defaultparam = UrlProcess.PhanMemChuyenMuc(catID, curpage, CatName);
                    Paging1.queryparam = UrlProcess.PhanMemChuyenMuc(catID, curpage, CatName);
                }
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