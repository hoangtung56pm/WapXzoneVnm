using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControl
{
    public partial class JavaGameVnm : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private int hotro;
        private static string preurl;
        private int catID;
        private int validGame = 0;
        private User_AgentInfo _info;
        private bool freecate = false;

        private string[] _arrService;

        private string msisdn;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            int is3g = 0;
            msisdn = MobileUtils.GetMSISDN(out is3g);

            if (!IsPostBack)
            {
                int count = GameController.GetFreeGame(msisdn);

                if (count > 0)
                {
                    lblAlert.Text = "Bạn được miễn phí " + GameController.GetFreeGame(msisdn) + " game trong chuyên mục này";
                }
                else
                {
                    lblAlert.Text = "";
                }
                DataTable dt = GameController.GetAllGameJavaVnmHasCache();

                rptlstCategory.DataSource = dt;
                rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
                rptlstCategory.DataBind();
            }

        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            //Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            //HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            string sGioiThieu;

            lnkTenAnh.Text = "<span class=\"bold\">" + curData["Name"] + "</span>";
            //ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
            sGioiThieu = curData["Description"].ToString();
            if (sGioiThieu.Length > 120)
                sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
            ltrLuottai.Text = Resources.Resource.wGioiThieu + sGioiThieu;
            lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";

            string url = AppEnv.GetSetting("JavaGameDownloadPartner") + "?id=" + curData["GameID"] + "&code=" + SecurityMethod.MD5Encrypt(curData["GameID"] + "_" + msisdn) + "&msisdn=" + msisdn;

            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = url;
            lnkTai.NavigateUrl = url;

            CreateAvatar.MOReceiver ws = new CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["Avatar"].ToString(), 60, 70);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Avatar"].ToString(), 60, 70).Replace("~", "");

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