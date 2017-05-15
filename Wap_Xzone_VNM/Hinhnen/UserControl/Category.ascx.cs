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
using WapXzone_VNM.Library.Component.HinhNen;

namespace WapXzone_VNM.Hinhnen.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
       
        private string lang;
        private string width;
        private static string preurl;
        private static int totalcat;
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                width = Request.QueryString["w"];
                preurl = ConfigurationSettings.AppSettings.Get("urldata");
                DataTable dt = HinhNenController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.HinhNen.Category, 0);
                totalcat = dt.Rows.Count;                
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound); ;
                rptCategory.DataBind();
                if (lang == "1")
                {
                    ltrTheLoai.Text = Resources.Resource.hnTheLoaiHinh;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("wallprice") + Resources.Resource.wDonViTien + "/hình nền)";
                }
                else
                {
                    ltrTheLoai.Text = Resources.Resource.hnTheLoaiHinh_KD;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("wallprice") + Resources.Resource.wDonViTien_KD + "/hinh nen)";
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
            lnkCatName.NavigateUrl = UrlProcess.GetWallpaperCategoryUrl(lang.ToString(), width, curData["W_CategoryID"].ToString());
        }
    }
}