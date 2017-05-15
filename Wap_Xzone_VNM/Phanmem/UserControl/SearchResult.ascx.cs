using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Phanmem;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Phanmem.UserControl
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private int hotro;
        private string width;
        private static string preurl;
        private User_AgentInfo _info;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            _info = Get_User_Agent_Info();
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
            if (!IsPostBack)
            {                
                if (lang == 1)
                {
                    ltrTenChuyenMuc.Text = "KẾT QUẢ TÌM KIẾM";
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start result list
            int totalrecord = 0;
            if (hotro == 1)
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=1", "hotro=0").Replace("cpage=" + curpage.ToString(), "cpage=1");
                rptResult.DataSource = PhanmemController.GetAllApp_ItemByKeyAndAgent(Session["telco"].ToString(), Request.QueryString["key"], _info, pagesize, curpage, out totalrecord);
            }
            else
            {
                lnkValidModel.NavigateUrl = Request.RawUrl.Replace("hotro=0", "hotro=1").Replace("cpage=" + curpage.ToString(), "cpage=1"); ;
                rptResult.DataSource = PhanmemController.GetAllApp_ItemByKey(Session["telco"].ToString(), Request.QueryString["key"], pagesize, curpage, out totalrecord);
            }
            //DataTable dtCat = PhanmemController.GetAllApp_ItemByKey(Session["telco"].ToString(), Request.QueryString["key"], pagesize, curpage, out totalrecord);
            //rptResult.DataSource = dtCat;
            rptResult.ItemDataBound += new RepeaterItemEventHandler(rptlstResult_ItemDataBound);
            rptResult.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&hotro=" + Request.QueryString["hotro"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&hotro=" + Request.QueryString["hotro"] +"&cpage=";
            if (totalrecord == 0) Paging1.Visible = false;
            if (lang == 1)
            {
                ltrCount.Text = "Tìm thấy " + totalrecord + " phần mềm";
                if (hotro == 0) lnkValidModel.Text = "Chỉ hiển thị những phần mềm hỗ trợ";
                else lnkValidModel.Text = "Hiển thị tất cả các phần mềm"; 
            }
            else
            {
                ltrCount.Text = "Tim thay  " + totalrecord + " phan mem";
                if (hotro == 0) lnkValidModel.Text = "Chi hien thi nhung phan mem ho tro";
                else lnkValidModel.Text = "Hien thi tat ca cac phan mem";
            }
            lnkValidModel.Text = "<span class=\"orange\">" + lnkValidModel.Text + "</span>";
            //end result list
        }
        protected void rptlstResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["AppNameUnicode"].ToString() + "</span>";
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
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["AppName"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                sGioiThieu = curData["Description"].ToString();
                if (sGioiThieu.Length > 120)
                    sGioiThieu = sGioiThieu.Substring(0, sGioiThieu.LastIndexOf(" ", 110)) + "...";
                ltrLuottai.Text = Resources.Resource.wGioiThieu_KD + sGioiThieu;
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }

            lnkTang.NavigateUrl = UrlProcess.GetAppDetailUrl(lang.ToString(), "detail", width, curData["W_AppItemID"].ToString(), hotro.ToString()) + "&g=1"; 
            if (MobileUtils.CheckValidModel(curData["ModelSupport"].ToString(), _info))
            {
                lnkTai.NavigateUrl = UrlProcess.GetGameDownloadUrl(lang.ToString(), width, curData["W_AppItemID"].ToString(), hotro.ToString());
                //lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_AppItemID"].ToString() + "&lang=" + lang + "&w=" + width;
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
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetAppDetailUrl(lang.ToString(), "detail", width, curData["W_AppItemID"].ToString(), hotro.ToString());
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