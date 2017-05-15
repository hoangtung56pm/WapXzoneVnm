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
    public partial class ListByCity : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private int catid;
        private int cityid;
        private string cipher;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            cityid = ConvertUtility.ToInt32(Request.QueryString["id"]);
            cipher = Request.QueryString["link"];
            DataTable dtbank = BCBController.GetBankNameByID(catid);
            DataTable dtbycity = BCBController.GetAllByCityID(cityid);
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lnkAtm.Text = "<span class=\"trang\">" + dtbank.Rows[0]["name"].ToString().ToUpper() + "</span>";
                    lnkTitle.Text = "<span class=\"trang\">" + dtbycity.Rows[0]["CityName"].ToString().ToUpper() + "</span>";
                }
                else
                {
                    lnkAtm.Text = "<span class=\"trang\">" + dtbank.Rows[0]["name_kd"].ToString().ToUpper() + "</span>";
                    lnkTitle.Text = "<span class=\"trang\">" + dtbycity.Rows[0]["CityNamKD"].ToString().ToUpper() + "</span>";
                }
                lnkAtm.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listatm", width, catid.ToString());
                lnkTitle.NavigateUrl = UrlProcess.GetBankByCityUrl(lang.ToString(), "listbycity", width, catid.ToString(), cityid.ToString());
            }
            //Get City of ATM
            rptcity.DataSource = dtbycity;
            rptcity.ItemDataBound += new RepeaterItemEventHandler(rptcity_ItemDataBound); ;
            rptcity.DataBind();

        }

        protected void rptcity_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkByCity = (HyperLink)e.Item.FindControl("lnkByCity");
            if (lang == 1)
            {
                lnkByCity.Text = curData["name"].ToString();
            }
            else
            {
                lnkByCity.Text = curData["name_kd"].ToString();
            }
            lnkByCity.NavigateUrl = UrlProcess.GetBankByCityUrl(lang.ToString(), "atmdetail", width, catid.ToString(), curData["zone_id"].ToString());
        }
    }
}