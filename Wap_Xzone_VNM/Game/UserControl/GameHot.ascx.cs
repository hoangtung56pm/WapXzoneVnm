using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using System.Drawing;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Game.UserControl
{
    public partial class GameHot : System.Web.UI.UserControl
    {
        private int pagesize = 30;        
        protected int lang;
        protected string width;        
        private static string preurl;                
        private User_AgentInfo _info;
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);            
            _info = Get_User_Agent_Info();

            if (Session["msisdn"] != null)
            {
                string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), AppEnv.GetSetting("S2DK_Game"));
                if (value == "1")
                {
                   // pnlS2DkGame2.Visible = false;
                }
            }

            int totalrecord = 0;
            if (lang == 0)
            {                
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien_KD + "/game)";
            }
            else
            {
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien + "/game)";
            }            
            lnkXemThem.NavigateUrl = UrlProcess.GetGameHomeUrl(lang.ToString(), width, "0");
            //Tải nhiều nhất

            //DataTable dtHottest = GameController.GetAllGameByCategoryAndDisplayType(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, pagesize, 1, out totalrecord);
            var dtHottest = new DataTable();
            dtHottest = GameController.GetAllGameByCateTypeAndAgentNoCache(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, _info, 30, 1, out totalrecord);
            if (dtHottest.Rows.Count == 0)
            {
                dtHottest = GameController.GetAllGameByCategoryAndDisplayType(Session["telco"].ToString(), 15, (int)Constant.Game.Topdownload, 30, 1, out totalrecord);
            }

            Random rnd = new Random();
            while (dtHottest.Rows.Count > 3)
            {
                dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                dtHottest.AcceptChanges();
            }
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            rptHottest.DataBind();
        }

        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            System.Web.UI.WebControls.Image imgAvatar = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            string sGioiThieu;
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["GameNameUnicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                sGioiThieu = curData["DescriptionUnicode"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
                ltrLuottai.Text = Resources.Resource.wGioiThieu + sGioiThieu;
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["GameName"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                sGioiThieu = curData["Description"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
                ltrLuottai.Text = Resources.Resource.wGioiThieu_KD + sGioiThieu;
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }

            lnkTang.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), "0") + "&g=1";
            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                //lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_GameItemID"].ToString() + "&lang=" + lang + "&w=" + width;
                lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrl(lang.ToString(), width, curData["W_GameItemID"].ToString(), "0");
            }
            else 
            {
                lnkTai.NavigateUrl = "";
                if (lang == 1)
                {
                    lnkTai.Text = Resources.Resource.wKhongHoTro;
                }
                else {
                    lnkTai.Text = Resources.Resource.wKhongHoTro_KD;
                }
            }           
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), "0");
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["Avatar"].ToString(), 60, 70);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Avatar"].ToString(), 60, 70).Replace("~", "");
            //imgAvatar.ImageUrl = preurl + curData["Avatar"].ToString().Replace("~", "");
            if (curData["W_GameItemID"].ToString() == "1402" || curData["W_GameItemID"].ToString() == "1401")
            {
                ltrTheloai.Visible = false;
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