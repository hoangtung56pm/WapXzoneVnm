using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.UserControlNew
{
    public partial class LotHome : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected int day;
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

        protected int Count;

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
                if (_arrService != null)
                {
                    if (_arrService.Length > 0)
                    {
                        string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), "TD");
                        foreach (var item in _arrService)
                        {
                            if (item == dkXoSo)
                            {
                                pnlXsThuDo.Visible = false;
                            }
                        }
                    }
                }
                    
                if (lang == 1)
                {
                    lnkThudo.Text = thudoinfo.Rows[0]["company_name"].ToString();
                    lnkKQCho.Text = Resources.Resource.xsKQCho.Replace("<span class=\"orange bold\">","").Replace("<span>","");
                    lnkSoiCau.Text = Resources.Resource.xsSoiCau.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                }
                else
                {
                    lnkThudo.Text = UnicodeUtility.UnicodeToKoDau(thudoinfo.Rows[0]["company_name"].ToString());
                    lnkKQCho.Text = Resources.Resource.xsKQCho_KD.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                    lnkSoiCau.Text = Resources.Resource.xsSoiCau_KD.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                }
                lnkxemkq.NavigateUrl = lnkThudo.NavigateUrl = "../KQXSNew.aspx?id=" + thudo + "&day=" + day + "&lang=" + lang + "&w=" + width;
                lnkKQCho.NavigateUrl = "../KQChoNew.aspx?id=" + thudo + "&lang=" + lang + "&w=" + width;
                lnkSoiCau.NavigateUrl = "../SoiCauNew.aspx?id=" + thudo + "&lang=" + lang + "&w=" + width;
            }
            if (day == 0)
            {
                if (lang == 1) { lnkxemkq.Text = Resources.Resource.xsKQKyTruoc + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(thudo)).Rows[0]["lot_time"]).ToString("dd/MM") + ")"; }
                else { lnkxemkq.Text = Resources.Resource.xsKQKyTruoc_KD + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(thudo)).Rows[0]["lot_time"]).ToString("dd/MM") + ")"; }
            }
            else
            {
                lnkxemkq.Text = "KQ " + "(" + ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM") + ")";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            city = ConfigurationSettings.AppSettings.Get(DateTime.Now.AddDays(-day).DayOfWeek.ToString()).Split(',');
            rptlst.DataSource = city;
            rptlst.ItemDataBound += rptlst_ItemDataBound;
            rptlst.DataBind();
        }
        protected void rptlst_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            

            string curData = (string)e.Item.DataItem;
            HyperLink lnkCity = (HyperLink)e.Item.FindControl("lnkCity");
            DataTable info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(curData));

            Count = info.Rows.Count;
            Literal litBlank = (Literal)e.Item.FindControl("litBlank");
            if (e.Item.ItemIndex < Count - 1)
            {
                litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }

            HyperLink lnkxkq = (HyperLink)e.Item.FindControl("lnkxkq");
            HyperLink lnkkqc = (HyperLink)e.Item.FindControl("lnkkqc");
            HyperLink lnksc = (HyperLink)e.Item.FindControl("lnksc");
            HyperLink lnks2DangKy = (HyperLink)e.Item.FindControl("lnkS2DangKy");
            Panel pnlXoSoList = (Panel)e.Item.FindControl("pnlXsList");

            

            if (_arrService != null)
            {
                if (_arrService.Length > 0)
                {
                    string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), info.Rows[0]["Company_Comment"]);
                    foreach (var item in _arrService)
                    {
                        if (item == dkXoSo)
                        {
                            pnlXoSoList.Visible = false;
                        }
                    }
                }
            }

            if (lang == 1)
            {
                lnkCity.Text = info.Rows[0]["company_name"].ToString();
                lnkkqc.Text = Resources.Resource.xsKQCho.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                lnksc.Text = Resources.Resource.xsSoiCau.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                lnks2DangKy.Text = "Nhận KQXS hàng ngày (500đ/ngày)";
            }
            else
            {
                lnkCity.Text = UnicodeUtility.UnicodeToKoDau(info.Rows[0]["company_name"].ToString());
                lnkkqc.Text = Resources.Resource.xsKQCho_KD.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                lnksc.Text = Resources.Resource.xsSoiCau_KD.Replace("<span class=\"orange bold\">", "").Replace("<span>", "");
                lnks2DangKy.Text = "Nhan KQXS hang ngay (500d/ngay)";
            }
            lnkxkq.NavigateUrl = lnkCity.NavigateUrl = "../KQXSNew.aspx?id=" + info.Rows[0]["company_id"].ToString() + "&day=" + day + "&lang=" + lang + "&w=" + width;
            string content1 = cpid + "&" + Constant.xoso + curData + "@" + day + "&" + kqxsprice + "&" + vmstransactionid;

            lnkkqc.NavigateUrl = "../KQChoNew.aspx?id=" + info.Rows[0]["company_id"].ToString() + "&lang=" + lang + "&w=" + width;
            lnksc.NavigateUrl = "../SoiCauNew.aspx?id=" + info.Rows[0]["company_id"].ToString() + "&lang=" + lang + "&w=" + width;

            lnks2DangKy.NavigateUrl = UrlProcess.GetS2RegisterXoSoUrl(lang.ToString(), width,
                                                                      info.Rows[0]["company_id"].ToString());

            if (day == 0)
            {
                if (lang == 1) { lnkxkq.Text = Resources.Resource.xsKQKyTruoc + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(ConvertUtility.ToInt32(info.Rows[0]["company_id"]))).Rows[0]["lot_time"]).ToString("dd/MM") + ")"; }
                else { lnkxkq.Text = Resources.Resource.xsKQKyTruoc_KD + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(ConvertUtility.ToInt32(info.Rows[0]["company_id"]))).Rows[0]["lot_time"]).ToString("dd/MM") + ")"; }
            }
            else
            {
                lnkxkq.Text = "KQ " + "(" + ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM") + ")";
            }

        }
    }
}