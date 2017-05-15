using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Phanmem.UserControlNew
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
        private User_AgentInfo _info;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]).ToString();
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                _info = Get_User_Agent_Info();
                
                //Detail
                DataTable dtDetail = PhanmemController.GetAPPDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    price = ConfigurationSettings.AppSettings.Get("Appprice");
                    if (dtDetail.Rows[0]["Web_Name"].ToString() == "Vmg_zone") price = "1000";
                    lnkCateChannel.NavigateUrl = UrlProcess.GetAppCategoryUrlNew(lang.ToString(), width, dtDetail.Rows[0]["W_AppCategoryID"].ToString(), hotro);
                    lnkHomeChannel.NavigateUrl = UrlProcess.GetAppHomeUrlNew(lang.ToString(), width, hotro);
                    if (lang == 1)
                    {
                        lnkHomeChannel.Text = "PHẦN MỀM";
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["AppNameUnicode"].ToString();
                        ltrNhom.Text = Resources.Resource.wTheLoai + dtDetail.Rows[0]["Web_Name"];
                        ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;

                        ltrGioiThieu.Text = Resources.Resource.wGioiThieu + dtDetail.Rows[0]["DescriptionUnicode"];

                        lnkTai.Text = Resources.Resource.wTaiVe;
                        ltrCungTheLoai.Text = Resources.Resource.pmPhanMemCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["AppName"].ToString();
                        ltrNhom.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["Web_Name"].ToString());
                        ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;

                        
                        ltrGioiThieu.Text = Resources.Resource.wGioiThieu_KD + dtDetail.Rows[0]["Description"];

                        lnkTai.Text = Resources.Resource.wTaiVe_KD;
                        ltrCungTheLoai.Text = Resources.Resource.pmPhanMemCungTheLoai_KD;
                    }

                    if (MobileUtils.CheckValidModel(dtDetail.Rows[0]["ModelSupport"].ToString(), _info))
                    {
                        lnkTai.NavigateUrl = UrlProcess.GetAppDownloadUrlNew(lang.ToString(), width, dtDetail.Rows[0]["W_AppItemID"].ToString(), hotro);
                    }
                    else
                    {
                        lnkTai.Visible = false;
                    }
                    WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    ws.GenerateAvatarThumnail(dtDetail.Rows[0]["Avatar"].ToString(), 120, 141);
                    imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["Avatar"].ToString(), 120, 141).Replace("~", "");
                    //Other 
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
                    int totaltopdownload = 0;
                    DataTable dtltopdownload = PhanmemController.GetAllAppByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_AppCategoryID"]), 0, pagesize, tpage, out totaltopdownload);
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += rptCungTheLoai_ItemDataBound;
                    rptCungTheLoai.DataBind();
                    Paging1.totalrecord = totaltopdownload;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&tpage=";
                }
            }

        }
        protected void rptCungTheLoai_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            if(e.Item.ItemIndex < pagesize - 1)
            {
                Literal lit = (Literal)e.Item.FindControl("litBlank");
                lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }

            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");

            Literal ltrGioiThieu = (Literal)e.Item.FindControl("ltrGioiThieu");
            string sGioiThieu;
            if (lang == 1)
            {
                lnkTenAnh.Text = curData["AppNameUnicode"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"];
                sGioiThieu = curData["DescriptionUnicode"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";

                if(ltrGioiThieu != null)
                    ltrGioiThieu.Text = Resources.Resource.wGioiThieu + sGioiThieu;

                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                lnkTenAnh.Text = curData["AppName"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                sGioiThieu = curData["DescriptionUnicode"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";

                if (ltrGioiThieu != null)
                    ltrGioiThieu.Text = Resources.Resource.wGioiThieu_KD + sGioiThieu;

                lnkTai.Text = Resources.Resource.wTai_KD;
            }

            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                lnkTai.NavigateUrl = UrlProcess.GetAppDownloadUrlNew(lang.ToString(), width, curData["W_AppItemID"].ToString(), hotro);
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
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetAppDetailUrlNew(lang.ToString(), "detail", width, curData["W_AppItemID"].ToString(), hotro);
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