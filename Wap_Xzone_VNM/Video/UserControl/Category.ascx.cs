using System;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Video;

namespace WapXzone_VNM.Video.UserControl
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
                DataTable dt = VideoController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Video.Category, 0);
                totalcat = dt.Rows.Count;                
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += rptCategory_ItemDataBound; ;
                rptCategory.DataBind();

                if (lang == "1")
                {
                    ltrTheLoai.Text = Resources.Resource.vTheLoaiVideo;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien + "/video)";
                }
                else
                {
                    ltrTheLoai.Text = Resources.Resource.vTheLoaiVideo_KD;
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien_KD + "/video)";
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
            lnkCatName.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang, width, curData["W_VCategoryID"].ToString());
        }
    }
}