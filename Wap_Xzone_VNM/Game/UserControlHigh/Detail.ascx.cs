using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {

        //private int pagesize = 3;
        //private int pagenumber = 3;
        //private int tpage = 1;
        //private int lang;
        //private string hotro;
        //private string width;
        //private static string preurl;
        private int id;
        protected string price;
        private bool freecate;
        DataTable dtDetail = null;
        //private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                //_info = Get_User_Agent_Info();
                dtDetail = GameController.GetGameDetailByIDHasCache(AppEnv.CheckSessionTelco(), id);
                if(dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    rptDes.DataSource = dtDetail;
                    rptDes.DataBind();

                    price = AppEnv.GetSetting("gameprice");
                    if (id == 1402 || id == 1401)
                    {
                        //ltrNhom.Visible = false;
                        price = "5000";
                    }

                    string webName = dtDetail.Rows[0]["Web_Name"].ToString();
                    bool free = (webName.ToLower().Contains("online") || webName.ToLower().Contains("free"));

                    if (AppEnv.GetSetting("freecate").IndexOf("," + dtDetail.Rows[0]["W_GameCategoryID"] + ",") > -1 || free)
                    {
                        freecate = true;
                    }
                        
                    if (freecate)
                    {
                        price = "0";
                    }
                        

                    int totaltopdownload;
                    DataTable dtList = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_GameCategoryID"]), 0, 6, 1, out totaltopdownload);
                    if (dtList != null && dtList.Rows.Count > 0)
                    {
                        rptList.DataSource = dtList;
                        rptList.DataBind();
                    }
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

        protected void rptDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                string msisdn = Session["msisdn"].ToString();
                if (!string.IsNullOrEmpty(msisdn))
                {
                    string uniqueID = WapController.UnixTimeStampUTC().ToString();
                    WapController.WapRegisterConfirm_Insert(uniqueID, msisdn, 4, 0, "Game", "Game");
                }
                Response.Redirect("http://wap.vietnamobile.com.vn");
            }
            
        }
               
    }
}