using System;
using System.Data;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {

        private int pagesize = 6;
        private int pagenumber = 3;
        private int tpage = 1;
        //private int lang;
        //private string hotro;
        //private string width;
        //private static string preurl;
        private int id;
        protected string price;
        //private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if(!Page.IsPostBack)
            {
                //_info = Get_User_Agent_Info();
                
                //Detail
                DataTable dtDetail = PhanmemController.GetAPPDetailByIDHasCache(AppEnv.CheckSessionTelco(), id);
                //end detail    

                if(dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    price = AppEnv.GetSetting("Appprice");
                    if (dtDetail.Rows[0]["Web_Name"].ToString() == "Vmg_zone") price = "1000";

                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    rptDes.DataSource = dtDetail;
                    rptDes.DataBind();

                    int totaltopdownload = 0;
                    DataTable dtltopdownload = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_AppCategoryID"]), 0, pagesize, tpage, out totaltopdownload);
                    rptList.DataSource = dtltopdownload;
                    //rptList.ItemDataBound += new RepeaterItemEventHandler(rptCungTheLoai_ItemDataBound);
                    rptList.DataBind();

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