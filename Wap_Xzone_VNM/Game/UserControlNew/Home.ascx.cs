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
    public partial class Home : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        protected int lang;
        protected int hotro;
        protected string width;
        private static string preurl;
        private User_AgentInfo _info;

        private string[] _arrService;

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = AppEnv.GetSetting("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
            //hotro = 1;

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
            _info = Get_User_Agent_Info();

            int totalrecord = 0;

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
                            pnlS2DkGame1.Visible = false;
                            pnlS2DkGame2.Visible = false;
                        }
                    }
                }
            }

            #region Tai Nhieu Nhat
            
            //Tải nhiều nhất
            //if (hotro == 1)
            //{
            //    rptTaiNhieuNhat.DataSource = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, _info, pagesize, curpage, out totalrecord);
            //}
            //else
            //{
            //    rptTaiNhieuNhat.DataSource = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, pagesize, curpage, out totalrecord);
            //}

            var dtTaiNhieuNhat = new DataTable();
            dtTaiNhieuNhat = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, _info, pagesize, curpage, out totalrecord);
            if (dtTaiNhieuNhat.Rows.Count == 0)
            {
                dtTaiNhieuNhat = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, pagesize, curpage, out totalrecord);
            }

            rptTaiNhieuNhat.DataSource = dtTaiNhieuNhat;
            rptTaiNhieuNhat.ItemDataBound += rptTaiNhieuNhat_ItemDataBound;
            rptTaiNhieuNhat.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&hotro=" + Request.QueryString["hotro"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&hotro=" + Request.QueryString["hotro"] + "&cpage=";

            #endregion

            #region Moi Cap Nhat

            //if (hotro == 1)
            //{
            //    rptMoiCapNhat.DataSource = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), 16, (int)Constant.Game.Lastest, _info, pagesize, curpage, out totalrecord);
            //}
            //else
            //{
            //    rptMoiCapNhat.DataSource = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 16, (int)Constant.Game.Lastest, pagesize, tpage, out totalrecord);
            //}
            var dtMoiCapNhat = new DataTable();
            dtMoiCapNhat = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), 16, (int)Constant.Game.Lastest, _info, pagesize, curpage, out totalrecord);
            if(dtMoiCapNhat.Rows.Count == 0)
            {
                dtMoiCapNhat = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 16, (int)Constant.Game.Lastest, pagesize, tpage, out totalrecord);
            }

            rptMoiCapNhat.DataSource = dtMoiCapNhat;
            rptMoiCapNhat.ItemDataBound += rptMoiCapNhat_ItemDataBound;
            rptMoiCapNhat.DataBind();

            Paging2.totalrecord = totalrecord;
            Paging2.pagesize = pagesize;
            Paging2.numberpage = pagenumber;
            Paging2.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&hotro=" + Request.QueryString["hotro"];
            Paging2.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&hotro=" + Request.QueryString["hotro"] + "&tpage=";

            #endregion
        }

        protected void rptTaiNhieuNhat_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal)e.Item.FindControl("litBlank");
                if (lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }

        protected void rptMoiCapNhat_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

            if (e.Item.ItemIndex < 2)
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