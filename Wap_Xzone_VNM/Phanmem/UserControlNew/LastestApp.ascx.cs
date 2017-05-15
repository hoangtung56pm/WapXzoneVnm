﻿using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem.UserControlNew
{
    public partial class LastestApp : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        private int lang;
        private int hotro;
        private string width;
        private static string preurl;
        private User_AgentInfo _info;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
            _info = Get_User_Agent_Info();

            int totalrecord = 0;
            if (lang == 0)
            {
                litGia.Text = "	(Gia: " + AppEnv.GetSetting("appprice") + " d/phan mem) ";
                ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat_KD;
                ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat_KD;
            }
            else
            {
                litGia.Text = "	(Giá: " + AppEnv.GetSetting("appprice") + " đ/phần mềm) ";
                ltrTaiNhieuNhat.Text = Resources.Resource.wTaiNhieuNhat;
                ltrMoiNhat.Text = Resources.Resource.wMoiCapNhat;
            }
            //Tải nhiều nhất
            if (hotro == 1)
            {
                rptHottest.DataSource = PhanmemController.GetAllAppByCateTypeAndAgent(Session["telco"].ToString(), 10, (int)Constant.APP.Topdownload, _info, pagesize, curpage, out totalrecord);
            }
            else
            {
                rptHottest.DataSource = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 10, (int)Constant.APP.Topdownload, pagesize, curpage, out totalrecord);
            }

            rptHottest.ItemDataBound += rptlastest_ItemDataBound;
            rptHottest.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&hotro=" + Request.QueryString["hotro"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&hotro=" + Request.QueryString["hotro"] + "&cpage=";

            //Mới nhất
            if (hotro == 1)
            {
                rptLastest.DataSource = PhanmemController.GetAllAppByCateTypeAndAgent(Session["telco"].ToString(), 9, (int)Constant.APP.Lastest, _info, pagesize, tpage, out totalrecord);
            }
            else
            {
                rptLastest.DataSource = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 9, (int)Constant.APP.Lastest, pagesize, tpage, out totalrecord);
            }
            
            rptLastest.ItemDataBound += rptlastest_ItemDataBound;
            rptLastest.DataBind();

            Paging2.totalrecord = totalrecord;
            Paging2.pagesize = pagesize;
            Paging2.numberpage = pagenumber;
            Paging2.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&hotro=" + Request.QueryString["hotro"];
            Paging2.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=" + Request.QueryString["cpage"] + "&hotro=" + Request.QueryString["hotro"] + "&tpage=";


        }
        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            if (e.Item.ItemIndex < pagesize - 1)
            {
                Literal litBlank = (Literal)e.Item.FindControl("litBlank");
                litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }

            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            string sGioiThieu;
            if (lang == 1)
            {
                lnkTenAnh.Text = curData["AppNameUnicode"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                sGioiThieu = curData["DescriptionUnicode"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                lnkTenAnh.Text = curData["AppName"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                sGioiThieu = curData["Description"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
                lnkTai.Text = Resources.Resource.wTai_KD;
            }

            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                lnkTai.NavigateUrl = UrlProcess.GetAppDownloadUrlNew(lang.ToString(), width, curData["W_AppItemID"].ToString(), hotro.ToString());
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
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetAppDetailUrlNew(lang.ToString(), "detail", width, curData["W_AppItemID"].ToString(), hotro.ToString());
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["Avatar"].ToString(), 36, 48);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Avatar"].ToString(), 36, 48).Replace("~", "");
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