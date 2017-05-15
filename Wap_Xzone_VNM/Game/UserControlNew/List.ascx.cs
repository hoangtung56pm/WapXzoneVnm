using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        protected int hotro;
        private static string preurl;
        private int catID;
        private int validGame = 0;
        private User_AgentInfo _info;
        private bool freecate = false;

        private string[] _arrService;

        protected string Price;

        protected void Page_Load(object sender, EventArgs e)
        {
            //price = ConfigurationSettings.AppSettings.Get("gameprice");
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
            //hotro = 1;

            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            if (AppEnv.GetSetting("freecate").IndexOf("," + catID + ",") > -1) freecate = true;
            _info = Get_User_Agent_Info();

            if (!IsPostBack)
            {

                if (Session["serviceList"] != null)
                {
                    _arrService = Session["serviceList"] as string[];
                }

                if (_arrService != null)
                {
                    if (_arrService.Length > 0)
                    {
                        string dkGame = string.Format(AppEnv.GetSetting("S2DK_Game"));
                        foreach (var item in _arrService)
                        {
                            if (item == dkGame)
                            {
                                pnlDkGame.Visible = false;
                            }
                        }
                    }
                }


                if (catID == 22)
                    Price = "0";
                else
                    Price = AppEnv.GetSetting("gameprice");

                DataTable catInfo = GameController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                    lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                else
                    lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
                lnkCateChannel.NavigateUrl = UrlProcess.GetGameCategoryUrlNew(lang.ToString(), width, catID.ToString(), hotro.ToString());
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            //if (hotro == 1)
            //{
            //    rptlstCategory.DataSource = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), catID, (int)Constant.Game.Category, _info, pagesize, curpage, out totalrecord);
            //}
            //else
            //{
            //    rptlstCategory.DataSource = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.Game.Category, pagesize, curpage, out totalrecord);
            //}

            var dt = new DataTable();
            dt = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), catID, (int)Constant.Game.Category, _info, pagesize, curpage, out totalrecord);
            if(dt.Rows.Count == 0)
            {
                dt = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.Game.Category, pagesize, curpage, out totalrecord);
            }

            rptlstCategory.DataSource = dt;
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&hotro=" + Request.QueryString["hotro"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&hotro=" + Request.QueryString["hotro"] + "&cpage=";
            //end category list

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
                    lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrlNew(lang.ToString(), width, curData["W_GameItemID"].ToString(), hotro.ToString());
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