using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;
using System.Configuration;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class Links_List : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = Request.QueryString["lang"];
                width = Request.QueryString["w"];
                if (width == "0")
                {
                    width = Constant.DefaultScreen.Standard.ToString();
                }                

                DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(2, 90);
                rptLienket.DataSource = cpConfig;
                rptLienket.ItemDataBound += new RepeaterItemEventHandler(rptLienket_ItemDataBound);
                rptLienket.DataBind();
            }
        }

        protected void rptLienket_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrNhom = (Literal)e.Item.FindControl("ltrNhom");
            Repeater rptDonvi = (Repeater)e.Item.FindControl("rptDonvi");
            //                        
            if (lang == "1")
            {
                ltrNhom.Text = curData["WAP_CategoryTitleUnicode"].ToString().ToUpper();                
            }
            else
            {
                ltrNhom.Text = curData["WAP_CategoryTitle"].ToString().ToUpper();                
            }
            //
            DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache((int)curData["WAP_ID"]);
            count = cpConfig.Rows.Count-1;
            rptDonvi.DataSource = cpConfig;
            rptDonvi.ItemDataBound += new RepeaterItemEventHandler(rptDonvi_ItemDataBound);
            rptDonvi.DataBind();
        }

        protected void rptDonvi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");;
            HyperLink lnkDonvi = (HyperLink)e.Item.FindControl("lnkDonvi");
            HyperLink lnkIcon = (HyperLink)e.Item.FindControl("lnkIcon");            
            Literal ltrMota = (Literal)e.Item.FindControl("ltrMota");
            Literal divClass = (Literal)e.Item.FindControl("divClass");
            
            //
            divClass.Text = "<div class=\"itemlk\">";
            if (e.Item.ItemIndex == count)
            {
                divClass.Text = "<div class=\"itemlk-last\">";
            }
            if (lang == "1")
            {
                lnkDonvi.Text = curData["CP_CategoryUnicode"].ToString();
                ltrMota.Text = curData["CP_DescriptionUnicode"].ToString();
            }
            else
            {
                lnkDonvi.Text = curData["CP_Category"].ToString();
                ltrMota.Text = curData["CP_Description"].ToString();
            }
            //
            lnkDonvi.NavigateUrl = lnkIcon.NavigateUrl = curData["CP_Url"].ToString();
            imgAvatar.ImageUrl = ConfigurationSettings.AppSettings.Get("urldata") + curData["CP_Category_Avatar"].ToString().Replace("~", "");
        }
    }
}