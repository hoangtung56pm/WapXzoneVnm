using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Bancanbiet;
using System.Data;

namespace WapXzone_VNM.Bancanbiet.UserControl
{
    public partial class ListTaxi : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            //Get Taxi by city
            DataTable dtTaxi = BCBController.GetAllTaxyByCity(catid);
            rptTaxidetail.DataSource = dtTaxi;
            rptTaxidetail.ItemDataBound += new RepeaterItemEventHandler(rptTaxidetail_ItemDataBound); ;
            rptTaxidetail.DataBind();
            
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if (lang == 1)
            {
                lblTitle.Text = "<span class=\"trang\">" + dtTaxi.Rows[0]["province_name"].ToString().ToUpper() + "</span>" ;
            }
            else {
                lblTitle.Text = "<span class=\"trang\">" + UnicodeUtility.UnicodeToKoDau(dtTaxi.Rows[0]["province_name"].ToString().ToUpper()) + "</span>";
            }          
        }
        protected void rptTaxidetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrTaxiName = (Literal)e.Item.FindControl("ltrTaxiName");
            if (lang == 1)
            {
                ltrTaxiName.Text = curData["taxi_name"].ToString() + " : " + curData["taxi_phone"].ToString();
            }
            else
            {
                ltrTaxiName.Text = UnicodeUtility.UnicodeToKoDau(curData["taxi_name"].ToString()) + " : " + curData["taxi_phone"].ToString();
            }
        }
    }
}