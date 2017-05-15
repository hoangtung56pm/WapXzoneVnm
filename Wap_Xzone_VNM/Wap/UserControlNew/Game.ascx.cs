using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class Game : System.Web.UI.UserControl
    {
        protected int lang;
        protected int hotro;
        protected string width;
        private User_AgentInfo _info;

        protected void Page_Load(object sender, EventArgs e)
        {
            int totalrecord = 0;
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

            _info = Get_User_Agent_Info();

            //Tải nhiều nhất
            //DataTable dtHottest = GameController.GetAllGameByCategoryAndDisplayType(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, 30, 1, out totalrecord);
            //DataTable dtHottest = GameController.GetAllGameByCateTypeAndAgentNoCache(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, _info, 30, 1, out totalrecord);

            var dtHottest = new DataTable();
            dtHottest = GameController.GetAllGameByCateTypeAndAgentNoCache(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, _info, 30, 1, out totalrecord);
            if(dtHottest.Rows.Count == 0)
            {
                dtHottest = GameController.GetAllGameByCategoryAndDisplayType(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, 30, 1, out totalrecord);
            }

            if(dtHottest != null && dtHottest.Rows.Count > 0)
            {
                string gameLink = UrlProcess.GetGameHomeUrlNew(lang.ToString(), width, hotro.ToString());

                lnkXemThem.NavigateUrl = gameLink;

                Random rnd = new Random();
                while (dtHottest.Rows.Count > 3)
                {
                    dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                    dtHottest.AcceptChanges();
                }
                rptGame.DataSource = dtHottest;
                rptGame.ItemDataBound += rptGame_ItemDataBound;
                rptGame.DataBind();
            }
        }

        protected void rptGame_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;

            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");

            Literal litThongbao = (Literal)e.Item.FindControl("litThongbao");

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
                    litThongbao.Text = AppEnv.CheckLang("Dòng máy không hỗ trợ");
                }
            }


            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal)e.Item.FindControl("litTable");
                if (lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
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