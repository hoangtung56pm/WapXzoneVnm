using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.UserControlHigh
{
    public partial class Home : System.Web.UI.UserControl
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

        protected string Ngay;

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

            Ngay = ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM");

            city = ConfigurationSettings.AppSettings.Get(DateTime.Now.AddDays(-day).DayOfWeek.ToString()).Split(',');
            rptList.DataSource = city;
            rptList.ItemDataBound += rptlst_ItemDataBound;
            rptList.DataBind();

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

            //HyperLink lnks2DangKy = (HyperLink)e.Item.FindControl("lnkS2DangKy");
            //Panel pnlXoSoList = (Panel)e.Item.FindControl("pnlXsList");

            //if (Session["msisdn"] != null)
            //{
            //    string dkXoSo = string.Format(AppEnv.GetSetting("S2DK_XS"), info.Rows[0]["Company_Comment"]);
            //    string value = AppEnv.GetRegisterService(Session["msisdn"].ToString(), dkXoSo);
            //    if (value == "1")
            //    {
            //        pnlXoSoList.Visible = false;
            //    }
            //}

            lnkCity.Text = info.Rows[0]["company_name"].ToString();
            lnkkqc.Text = "Kết quả chờ";
            //lnksc.Text = Resources.Resource.xsSoiCau;
            lnksc.Text = "Thống kê cặp số";
            
            //lnkxkq.NavigateUrl = lnkCity.NavigateUrl = "../KQXS.aspx?id=" + info.Rows[0]["company_id"] + "&day=" + day + "&lang=" + lang + "&w=" + width;

            lnkxkq.NavigateUrl = lnkCity.NavigateUrl = UrlProcess.XoSoChiTietNew(ConvertUtility.ToInt32(info.Rows[0]["company_id"].ToString()), day.ToString(), Constant.XoSo_Kqxs_Rewrite);

            //string content1 = cpid + "&" + Constant.xoso + curData + "@" + day + "&" + kqxsprice + "&" + vmstransactionid;

            //lnkkqc.NavigateUrl = "../KQCho.aspx?id=" + info.Rows[0]["company_id"] + "&lang=" + lang + "&w=" + width;
            lnkkqc.NavigateUrl = UrlProcess.XoSoChiTiet(ConvertUtility.ToInt32(info.Rows[0]["company_id"]),Constant.XoSo_KqCho_Rewrite);


            //lnksc.NavigateUrl = "../SoiCau.aspx?id=" + info.Rows[0]["company_id"].ToString() + "&lang=" + lang + "&w=" + width;
            //lnks2DangKy.NavigateUrl = UrlProcess.GetS2RegisterXoSoUrl2G(lang.ToString(), width,info.Rows[0]["company_id"].ToString());

            //lnksc.NavigateUrl = "/Xoso/ThongKe.aspx?id=" + info.Rows[0]["company_id"] + "&lang=" + lang + "&w=" + width;
            lnksc.NavigateUrl = UrlProcess.XoSoChiTiet(ConvertUtility.ToInt32(info.Rows[0]["company_id"].ToString()),Constant.XoSo_ThongKe_Rewrite);

            if (day == 0)
            {
                lnkxkq.Text = Resources.Resource.xsKQKyTruoc + " (" + ConvertUtility.ToDateTime(XosoController.GetKQXSLastestDetailbyCompanyID(ConvertUtility.ToInt32(ConvertUtility.ToInt32(info.Rows[0]["company_id"]))).Rows[0]["lot_time"]).ToString("dd/MM") + ")";
            }
            else
            {
                lnkxkq.Text = "Kết quả " + "(" + ConvertUtility.ToDateTime(DateTime.Now.AddDays(-day)).ToString("dd/MM") + ")";
            }
        }
    }
}