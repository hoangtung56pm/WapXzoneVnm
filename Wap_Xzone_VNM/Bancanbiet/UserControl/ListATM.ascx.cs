using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Bancanbiet;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Bancanbiet.UserControl
{
    public partial class ListATM : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private int catid;
        private string cipher;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            cipher = Request.QueryString["link"];
            DataTable dtbank = BCBController.GetBankNameByID(catid);
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lnkChanelHome.Text = "<span class=\"trang\">" + "MÁY ATM" + "</span>";
                    lnkCatName.Text = "<span class=\"trang\">" + dtbank.Rows[0]["name"].ToString().ToUpper() + "</span>"; 
                }
                else {
                    lnkChanelHome.Text = "<span class=\"trang\">" + "MÁY ATM" + "</span>";
                    lnkCatName.Text = "<span class=\"trang\">" + dtbank.Rows[0]["name_kd"].ToString().ToUpper() + "</span>"; 
                }
            }
            lnkChanelHome.NavigateUrl = UrlProcess.GetYouNeedKnowHomeUrl(lang.ToString(), "home", width);
            lnkCatName.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listatm", width, catid.ToString());
            //Get City of ATM
            DataTable dtATM = BCBController.GetAllCityOfATM();
            rptcity.DataSource = dtATM;
            rptcity.ItemDataBound += new RepeaterItemEventHandler(rptcity_ItemDataBound); ;
            rptcity.DataBind();
            
        }

        protected void rptcity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCity = (HyperLink)e.Item.FindControl("lnkCity");
            if (lang == 1)
            {
                lnkCity.Text = curData["name"].ToString();
            }
            else
            {
                lnkCity.Text = curData["name_kd"].ToString();
            }
            lnkCity.NavigateUrl = UrlProcess.GetBankByCityUrl(lang.ToString(), "listbycity", width, catid.ToString(), curData["city_id"].ToString());
        }
    }
}