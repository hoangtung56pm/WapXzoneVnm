using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Phanmem;

namespace WapXzone_VNM.Phanmem.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
       
        private string lang;
        private string hotro;
        private string width;
        private static string preurl;
        private static int totalcat;
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]).ToString();
                width = Request.QueryString["w"];
                preurl = ConfigurationSettings.AppSettings.Get("urldata");
                DataTable dt = PhanmemController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.APP.Category, 0);
                totalcat = dt.Rows.Count;                
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound); ;
                rptCategory.DataBind();
                string price = ConfigurationSettings.AppSettings.Get("appprice");
                if (ConvertUtility.ToString(Request.QueryString["catid"]) == "1") price = "1000";
                if (lang == "1")
                {
                    ltrTheLoai.Text = Resources.Resource.pmTheLoaiPhanMem;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + price + Resources.Resource.wDonViTien + "/phần mềm)";
                }
                else
                {
                    ltrTheLoai.Text = Resources.Resource.pmTheLoaiPhanMem_KD;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + price + Resources.Resource.wDonViTien_KD + "/phan mem)";
                }
            }           
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");            
            if (lang == "1")
            {
                lnkCatName.Text = curData["Title_Unicode"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Title"].ToString();
            }
            lnkCatName.NavigateUrl = UrlProcess.GetAppCategoryUrl(lang.ToString(), width, curData["W_AppCategoryID"].ToString(), hotro);
        }
    }
}