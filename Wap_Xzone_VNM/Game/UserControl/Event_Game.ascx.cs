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
    public partial class Event_Game : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private int hotro;
        private static string preurl;
        private int catID = 26;
        private int validGame = 0;
        private User_AgentInfo _info;
        private bool freecate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //price = ConfigurationSettings.AppSettings.Get("gameprice");
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

            if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + catID.ToString() + ",") > -1) freecate = true;
            _info = Get_User_Agent_Info();

            if (!IsPostBack)
            {
                //DataTable catInfo = GameController.GetCategoryByCatIDHasCache(catID);
                if (lang == 0)
                {
                    ltrTieude.Text = "Games Olympic 2012";
                    lnkXemthem.Text = "Xem them » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien_KD + "/game)";
                }
                else
                {
                    ltrTieude.Text = "Games Olympic 2012";
                    lnkXemthem.Text = "Xem thêm » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien + "/game)";
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["e"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["e"]);
            }
            else
            {
                Random rnd = new Random();
                curpage = rnd.Next(1, 15);
            }
            //start category list
            int totalrecord = 0;
            if (hotro == 1)
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=1", "hotro=0").Replace("e=" + curpage.ToString(), "e=1");
                rptlstCategory.DataSource = GameController.GetAllGameByCateTypeAndAgent(Session["telco"].ToString(), catID, (int)Constant.Game.Category, _info, pagesize, curpage, out totalrecord);
            }
            else
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=0", "hotro=1").Replace("e=" + curpage.ToString(), "e=1"); ;
                rptlstCategory.DataSource = GameController.GetAllGameByCategoryAndDisplayTypeHasCache("vietnamobile", catID, (int)Constant.Game.Category, pagesize, curpage, out totalrecord);
            }
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            //Paging1.totalrecord = totalrecord;
            //Paging1.pagesize = pagesize;
            //Paging1.numberpage = pagenumber;
            //Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"];
            //Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"] + "&e=";
            //end category list
            if (lang == 1)
                if (hotro == 0) lnkValidModel.Text = "Chỉ hiển thị những game hỗ trợ";
                else lnkValidModel.Text = "Hiển thị tất cả các game";
            else
                if (hotro == 0) lnkValidModel.Text = "Chi hien thi nhung game ho tro";
                else lnkValidModel.Text = "Hien thi tat ca cac game";
            lnkValidModel.Text = "<span class=\"orange\">" + lnkValidModel.Text + "</span>";
            lnkXemthem.NavigateUrl = UrlProcess.GetGameCategoryUrl(lang.ToString(), width, catID.ToString(), hotro.ToString());
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
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["GameNameUnicode"].ToString() + "</span>";
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
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["GameName"].ToString() + "</span>";
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