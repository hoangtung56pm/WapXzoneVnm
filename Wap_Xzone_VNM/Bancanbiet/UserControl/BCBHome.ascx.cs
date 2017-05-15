using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Bancanbiet;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Bancanbiet.UserControl
{
    public partial class BCBHome : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private string cipher;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            cipher = Request.QueryString["link"];
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lblTitle.Text = "MÁY ATM";
                    ltrMienphi1.Text="(Dịch vụ miễn phí)";
                    ltrMienphi.Text = "(Dịch vụ miễn phí)";
                }
            }
            //Get ATM
            DataTable dtATM = BCBController.GetAllBankName();
            rptAtm.DataSource = dtATM;
            rptAtm.ItemDataBound += new RepeaterItemEventHandler(rptAtm_ItemDataBound); ;
            rptAtm.DataBind();
            //Get Taxi
            DataTable dtTaxi = BCBController.GetAllCity();
            rptTaxi.DataSource = dtTaxi;
            rptTaxi.ItemDataBound += new RepeaterItemEventHandler(rptTaxi_ItemDataBound); ;
            rptTaxi.DataBind();
        }
        protected void rptAtm_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkAtm = (HyperLink)e.Item.FindControl("lnkAtm");
            if (lang == 1)
            {
                lnkAtm.Text = curData["name"].ToString();
            }
            else
            {
                lnkAtm.Text =curData["name_kd"].ToString();
            }
            lnkAtm.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listatm", width, curData["bank_id"].ToString());
        }
        protected void rptTaxi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnktaxi = (HyperLink)e.Item.FindControl("lnktaxi");
            if (lang == 1)
            {
                lnktaxi.Text = curData["province_name"].ToString();
            }
            else
            {
                lnktaxi.Text = UnicodeUtility.UnicodeToKoDau(curData["province_name"].ToString());
            }
            lnktaxi.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listtaxi", width, curData["province_id"].ToString());
        }
    }
}