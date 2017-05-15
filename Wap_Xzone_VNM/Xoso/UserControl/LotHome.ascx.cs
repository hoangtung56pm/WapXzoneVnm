using System;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library;

using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Xoso.UserControl
{
    public partial class LotHome : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        private int day;
        private string[] city;
        private string thudo;
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        private string soicauprice;
        private string kqcprice;
        private string day20price;
        private string kqxsprice;

        private string[] _arrService;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            width = Request.QueryString["w"];
            day = ConvertUtility.ToInt32(Request.QueryString["day"]);            
            soicauprice = ConfigurationSettings.AppSettings.Get("xssoicauprice");
            kqcprice = ConfigurationSettings.AppSettings.Get("kqchoxsprice");
            day20price = ConfigurationSettings.AppSettings.Get("xs20price");
            kqxsprice = ConfigurationSettings.AppSettings.Get("xs20price");
            kqxsprice = ConfigurationSettings.AppSettings.Get("kqxsprice");
            thudo = ConfigurationSettings.AppSettings.Get("xsthudo");
            //Get info cipher

            if (Session["serviceList"] != null)
            {
                _arrService = Session["serviceList"] as string[];
            }

            DataTable thudoinfo = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(thudo));
            if (!IsPostBack)
            {

                //if (_arrService != null)
                //{
                //    if (_arrService.Length > 0)
                //    {
                //        string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), "TD");
                //        foreach (var item in _arrService)
                //        {
                //            if (item == dkXoSo)
                //            {
                //                pnlXsThuDo.Visible = false;
                //            }
                //        }
                //    }
                //}

                if (Session["msisdn"] != null)
                {
                    string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), "TD");
                    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), dkXoSo);
                    if (value == "1")
                    {
                        pnlXsThuDo.Visible = false;
                    }
                }

                if (lang == 1)
                {
                    lblTitle.Text = Resources.Resource.xsCacTinhMoThuong;                    
                    lnkThudo.Text = "<span class=\"blue bold\">" + thudoinfo.Rows[0]["company_name"].ToString() + "</span>";
                    lnkKQCho.Text = Resources.Resource.xsKQCho;
                    //lnkSoiCau.Text = Resources.Resource.xsSoiCau;
                    lnkSoiCau.Text = "<span class=\"orange bold\">Thống kê cặp số</span>";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "KQ chờ " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien +
                    //    ", Thống kê cặp số " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien + 
                    //    ", Kết quả " + ConfigurationSettings.AppSettings.Get("kqxsprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    lblTitle.Text = Resources.Resource.xsCacTinhMoThuong_KD;                    
                    lnkThudo.Text = "<span class=\"blue bold\">" + UnicodeUtility.UnicodeToKoDau(thudoinfo.Rows[0]["company_name"].ToString()) + "</span>"; ;
                    lnkKQCho.Text = Resources.Resource.xsKQCho_KD;
                    //lnkSoiCau.Text = Resources.Resource.xsSoiCau_KD;
                    lnkSoiCau.Text = "<span class=\"orange bold\">Thong ke cap so</span>";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "KQ cho " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + 
                    //    ", Thong ke cap so " + ConfigurationSettings.AppSettings.Get("xssoicauprice") + Resources.Resource.wDonViTien_KD + 
                    //    ", Ket qua " + ConfigurationSettings.AppSettings.Get("kqxsprice") + Resources.Resource.wDonViTien_KD + ")";
                }                
                lnkxemkq.NavigateUrl = lnkThudo.NavigateUrl = "../KQXS.aspx?id=" + thudo + "&day=" + day + "&lang=" + lang + "&w=" + width;                
                lnkKQCho.NavigateUrl = "../KQCho.aspx?id=" + thudo + "&lang=" + lang + "&w=" + width;

                //lnkSoiCau.NavigateUrl = "../SoiCau.aspx?id=" + thudo + "&lang=" + lang + "&w=" + width;
                lnkSoiCau.NavigateUrl = "/Xoso/ThongKe.aspx?id=" + thudo + "&lang=" + lang + "&w=" + width;

            }
            if (day == 0)
            {
                if (lang == 1) { lnkxemkq.Text = "<span class=\"orange bold\">" + Resources.Resource.xsKQKyTruoc + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(thudo)).Rows[0]["lot_time"]).ToString("dd/MM") + ")</span>"; }
                else { lnkxemkq.Text = "<span class=\"orange bold\">" + Resources.Resource.xsKQKyTruoc_KD + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(thudo)).Rows[0]["lot_time"]).ToString("dd/MM") + ")</span>"; }
            }
            else
            {
                lnkxemkq.Text = "<span class=\"orange bold\">KQ " + "(" + ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM") + ")</span>";
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            city = ConfigurationSettings.AppSettings.Get(DateTime.Now.AddDays(-day).DayOfWeek.ToString()).Split(',');
            rptlst.DataSource = city;
            rptlst.ItemDataBound += new RepeaterItemEventHandler(rptlst_ItemDataBound);
            rptlst.DataBind();
        }
        protected void rptlst_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            string curData = (string)e.Item.DataItem;
            HyperLink lnkCity = (HyperLink)e.Item.FindControl("lnkCity");
            DataTable info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(curData));
            HyperLink lnkxkq = (HyperLink)e.Item.FindControl("lnkxkq");
            HyperLink lnkkqc = (HyperLink)e.Item.FindControl("lnkkqc");
            HyperLink lnksc = (HyperLink)e.Item.FindControl("lnksc");

            HyperLink lnks2DangKy = (HyperLink)e.Item.FindControl("lnkS2DangKy");  
            Panel pnlXoSoList = (Panel)e.Item.FindControl("pnlXsList");

            //if (_arrService != null)
            //{
            //    if (_arrService.Length > 0)
            //    {
            //        string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), info.Rows[0]["Company_Comment"]);
            //        foreach (var item in _arrService)
            //        {
            //            if (item == dkXoSo)
            //            {
            //                pnlXoSoList.Visible = false;
            //            }
            //        }
            //    }
            //}

            if (Session["msisdn"] != null)
            {
                string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), info.Rows[0]["Company_Comment"]);
                string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), dkXoSo);
                if (value == "1")
                {
                    pnlXoSoList.Visible = false;
                }
            }

            if (lang == 1)
            {
                lnkCity.Text = "<span class=\"blue bold\">" + info.Rows[0]["company_name"].ToString() +"</span>";                 
                lnkkqc.Text = Resources.Resource.xsKQCho;
                //lnksc.Text = Resources.Resource.xsSoiCau;
                lnksc.Text = "<span class=\"orange bold\">Thống kê cặp số</span>";
             //   lnks2DangKy.Text = "<span class=\"orange bold\">Nhận KQXS hàng ngày</span>";
            }
            else
            {
                lnkCity.Text = "<span class=\"blue bold\">" + UnicodeUtility.UnicodeToKoDau(info.Rows[0]["company_name"].ToString()) + "</span>";
                lnkkqc.Text = Resources.Resource.xsKQCho_KD;
                //lnksc.Text = Resources.Resource.xsSoiCau_KD;
                lnksc.Text = "<span class=\"orange bold\">Thong ke cap so</span>";
              //  lnks2DangKy.Text = "<span class=\"orange bold\">Nhan KQXS hang ngay</span>";
            }
            lnkxkq.NavigateUrl = lnkCity.NavigateUrl = "../KQXS.aspx?id=" + info.Rows[0]["company_id"]+ "&day=" + day + "&lang=" + lang + "&w=" + width;
            string content1 = cpid + "&" + Constant.xoso + curData + "@" + day + "&" + kqxsprice + "&" + vmstransactionid;
            
            lnkkqc.NavigateUrl = "../KQCho.aspx?id=" + info.Rows[0]["company_id"] + "&lang=" + lang + "&w=" + width;

            //lnksc.NavigateUrl = "../SoiCau.aspx?id=" + info.Rows[0]["company_id"].ToString() + "&lang=" + lang + "&w=" + width;
            //lnks2DangKy.NavigateUrl = UrlProcess.GetS2RegisterXoSoUrl2G(lang.ToString(), width,info.Rows[0]["company_id"].ToString());

            lnksc.NavigateUrl = "/Xoso/ThongKe.aspx?id=" + info.Rows[0]["company_id"] + "&lang=" + lang + "&w=" + width;
           // lnks2DangKy.NavigateUrl = "/Xoso/KetQua.aspx?id=" + info.Rows[0]["company_id"] + "&lang=" + lang + "&w=" + width;

            if (day == 0)
            {
                if (lang == 1){ lnkxkq.Text = "<span class=\"orange bold\">" + Resources.Resource.xsKQKyTruoc + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(ConvertUtility.ToInt32(info.Rows[0]["company_id"]))).Rows[0]["lot_time"]).ToString("dd/MM") + ")</span>"; }
                else { lnkxkq.Text = "<span class=\"orange bold\">" + Resources.Resource.xsKQKyTruoc_KD + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(ConvertUtility.ToInt32(info.Rows[0]["company_id"]))).Rows[0]["lot_time"]).ToString("dd/MM") + ")</span>"; }
            }
            else
            {
                lnkxkq.Text = "<span class=\"orange bold\">KQ " + "(" + ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM") + ")</span>";
            }
        }
    }
}