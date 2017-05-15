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

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Game.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int tpage = 1;
        private int lang;
        private string hotro;
        private string width;
        private static string preurl;
        private int id;        
        private string price;
        private bool freecate = false;
        private User_AgentInfo _info;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = Request.QueryString["hotro"];
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            if (!IsPostBack)
            {
                _info = Get_User_Agent_Info();
                if (ConvertUtility.ToInt32(Request.QueryString["g"]) == 1)
                    txtSoDienThoaiTang.Focus();
                //Detail
                DataTable dtDetail = GameController.GetGameDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    lnkCateChannel.NavigateUrl = UrlProcess.GetGameCategoryUrl(lang.ToString(), width, dtDetail.Rows[0]["W_GameCategoryID"].ToString(), hotro);
                    lnkHomeChannel.NavigateUrl = UrlProcess.GetGameHomeUrl(lang.ToString(), width, hotro);
                    price = ConfigurationSettings.AppSettings.Get("gameprice");
                    if (id == 1402 || id == 1401)
                    {
                        ltrNhom.Visible = false;
                        price = "5000";
                    }
                    if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + dtDetail.Rows[0]["W_GameCategoryID"].ToString() + ",") > -1)
                        freecate = true;
                    if (freecate == true) ltrGiaTai.Visible = false;
                    if (lang == 1)
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        ltrTenAnh.Text= dtDetail.Rows[0]["GameNameUnicode"].ToString();
                        ltrNhom.Text = Resources.Resource.wTheLoai + dtDetail.Rows[0]["Web_Name"].ToString();
                        ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang + price + Resources.Resource.wDonViTien;
                        ltrGioiThieu.Text = Resources.Resource.wGioiThieu + dtDetail.Rows[0]["DescriptionUnicode"].ToString();
                        lnkTai.Text = "<span class=\"bold\">"+ Resources.Resource.wTaiVe + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang;
                        ltrCungTheLoai.Text = Resources.Resource.gGameCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["GameName"].ToString();
                        ltrNhom.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["Web_Name"].ToString());                        
                        ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang_KD + price + Resources.Resource.wDonViTien_KD;
                        ltrGioiThieu.Text = Resources.Resource.wGioiThieu_KD + dtDetail.Rows[0]["Description"].ToString();
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang_KD;
                        ltrCungTheLoai.Text = Resources.Resource.gGameCungTheLoai_KD;
                    }
                    if (MobileUtils.CheckValidModel(dtDetail.Rows[0]["ModelSupport"].ToString(), _info))
                    {
                        lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrl(lang.ToString(), width, dtDetail.Rows[0]["W_GameItemID"].ToString(), hotro.ToString());
                        //lnkTai.NavigateUrl = "../Download.aspx?id=" + dtDetail.Rows[0]["W_GameItemID"].ToString() + "&lang=" + lang + "&w=" + width;
                    }
                    else
                    {
                        lnkTai.Visible = false;
                    }
                    WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    ws.GenerateAvatarThumnail(dtDetail.Rows[0]["Avatar"].ToString(), 120, 141);
                    imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["Avatar"].ToString(), 120, 141).Replace("~", "");
                    //imgDetail.ImageUrl = preurl + dtDetail.Rows[0]["Avatar"].ToString().Replace("~", "");
                    //Other wallpaper
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = GameController.GetAllGameByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_GameCategoryID"]), 0, pagesize, tpage, out totaltopdownload);
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptCungTheLoai_ItemDataBound);
                    rptCungTheLoai.DataBind();
                    Paging1.totalrecord = totaltopdownload;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&hotro=" + Request.QueryString["hotro"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&hotro=" + Request.QueryString["hotro"] + "&tpage=";
                    //end lastest wallpaper
                }
            }
            
        }
        protected void rptCungTheLoai_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            lnkTang.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), hotro) + "&g=1";

            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrl(lang.ToString(), width, curData["W_GameItemID"].ToString(), hotro.ToString());
                //lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_GameItemID"].ToString() + "&lang=" + lang + "&w=" + width;
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
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetGameDetailUrl(lang.ToString(), "detail", width, curData["W_GameItemID"].ToString(), hotro);
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

        protected void btnTang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(UrlProcess.GetGameSendGiftUrl(lang.ToString(), width, Request.QueryString["id"], txtSoDienThoaiTang.Text.Trim(), hotro));
        }
    }
}