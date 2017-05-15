using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlNew
{
    public partial class Detail : System.Web.UI.UserControl
    {
        protected string Price;
        protected int lang;
        protected string hotro;
        protected string width;
        private int pagesize = 3;
        private int pagenumber = 3;
        private int id;
        private bool freecate = false;
        private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = Request.QueryString["hotro"];
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                _info = Get_User_Agent_Info();
                //Detail
                DataTable dtDetail = GameController.GetGameDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    lnkCateChannel.NavigateUrl = UrlProcess.GetGameCategoryUrlNew(lang.ToString(), width, dtDetail.Rows[0]["W_GameCategoryID"].ToString(), hotro);
                    lnkHomeChannel.NavigateUrl = UrlProcess.GetGameHomeUrlNew(lang.ToString(), width, hotro);

                    rptDetail.DataSource = dtDetail;
                    rptDetail.ItemDataBound += rptDetail_ItemDataBound;
                    rptDetail.DataBind();

                    Price = ConfigurationSettings.AppSettings.Get("gameprice");
                    if (id == 1402 || id == 1401)
                    {
                        Price = "5000";
                    }
                    if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + dtDetail.Rows[0]["W_GameCategoryID"] + ",") > -1)
                        freecate = true;
                    if (freecate == true) Price = "0";
                    if (lang == 1)
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                    }
                    
                    
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_GameCategoryID"]), 0, pagesize, 1, out totaltopdownload);
                    rptGameCungLoai.DataSource = dtltopdownload;
                    rptGameCungLoai.ItemDataBound += rptlstCategory_ItemDataBound;
                    rptGameCungLoai.DataBind();

                   
                }
            }
        }

        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            if (lnkTai != null)
            {
                if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
                {
                    lnkTai.Text = "<img alt=\"\" src=\"/imagesnew/icon/down.png\" /> " + AppEnv.CheckLang("Tải");
                    lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrlNew(lang.ToString(), width, curData["W_GameItemID"].ToString(), hotro);
                }
                else
                {
                    lnkTai.NavigateUrl = "";
                    lnkTai.Text = AppEnv.CheckLang("Dòng máy không hỗ trợ");
                }
            }

            if (e.Item.ItemIndex < pagesize - 1)
            {
                Literal lit = (Literal)e.Item.FindControl("litBlank");
                if (lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }

        protected void rptDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;

            HyperLink lnkTai = (HyperLink) e.Item.FindControl("lnkTai");
            if(lnkTai != null)
            {
                if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
                {
                    lnkTai.Text = "<img alt=\"\" src=\"/imagesnew/icon/down.png\" /> " + AppEnv.CheckLang("Tải");
                    lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrlNew(lang.ToString(), width, curData["W_GameItemID"].ToString(), hotro);
                }
                else
                {
                    lnkTai.NavigateUrl = "";
                    lnkTai.Text = AppEnv.CheckLang("Dòng máy không hỗ trợ");
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