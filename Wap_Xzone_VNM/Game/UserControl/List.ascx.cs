using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Game.UserControl
{
    public partial class List : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            //price = ConfigurationSettings.AppSettings.Get("gameprice");
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

            //hotro = 1;

            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

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
                        }
                    }
                }
            }

            if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + catID.ToString() + ",") > -1) freecate = true;
            _info = Get_User_Agent_Info();
            
            if (!IsPostBack)
            {                             
               DataTable catInfo = GameController.GetCategoryByCatIDHasCache(catID);
               if (lang == 1)
                   lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
               else
                   lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
               lnkCateChannel.NavigateUrl = UrlProcess.GetGameCategoryUrl(lang.ToString(), width, catID.ToString(), hotro.ToString());
               lnkHomeChannel.NavigateUrl = UrlProcess.GetGameHomeUrl(lang.ToString(), width, hotro.ToString());
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            if (hotro == 1)
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=1", "hotro=0").Replace("cpage=" + curpage.ToString(), "cpage=1");
                //rptlstCategory.DataSource = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), catID, (int)Constant.Game.Category, _info, pagesize, curpage, out totalrecord);
            }
            else
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=0", "hotro=1").Replace("cpage=" + curpage.ToString(), "cpage=1"); ;
                //rptlstCategory.DataSource = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.Game.Category, pagesize, curpage, out totalrecord);
            }

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
            if (lang == 1)
                if (hotro == 0) lnkValidModel.Text = "Chỉ hiển thị những game hỗ trợ";
                else lnkValidModel.Text = "Hiển thị tất cả các game"; 
            else
                if (hotro == 0) lnkValidModel.Text = "Chi hien thi nhung game ho tro";
                else lnkValidModel.Text =  "Hien thi tat ca cac game";
            lnkValidModel.Text = "<span class=\"orange\">" + lnkValidModel.Text + "</span>";
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

            lnkTang.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), hotro.ToString()) + "&g=1";
            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrl(lang.ToString(), width, curData["W_GameItemID"].ToString(), hotro.ToString());
                validGame += 1;
            }
            else
            {
                lnkTai.NavigateUrl = "";
                if (lang == 1)
                {
                    lnkTai.Text = Resources.Resource.wKhongHoTro;
                }
                else
                {
                    lnkTai.Text = Resources.Resource.wKhongHoTro_KD;
                }
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), hotro.ToString());
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