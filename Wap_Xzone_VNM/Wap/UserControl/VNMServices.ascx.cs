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
    public partial class VNMServices : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
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

                DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache(38);
                rptDichvu.DataSource = cpConfig;
                rptDichvu.ItemDataBound += new RepeaterItemEventHandler(rptDichvu_ItemDataBound);
                rptDichvu.DataBind();               
            }
            if (lang == "1")
            {
                ltrDichVu.Text = "DỊCH VỤ VIETNAMOBILE";
            }
        }

        protected void rptDichvu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkIcon = (HyperLink)e.Item.FindControl("lnkIcon");
            HyperLink lnkText = (HyperLink)e.Item.FindControl("lnkText");
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            Literal ltrDaudong = (Literal)e.Item.FindControl("ltrDaudong");
            Literal ltrCuoidong = (Literal)e.Item.FindControl("ltrCuoidong");
            //
            ltrDaudong.Text = "<div class=\"col2\">";
            ltrCuoidong.Text = "</div>";
            if ((e.Item.ItemIndex + 3) % 3 == 0)
            {
                ltrDaudong.Text = "<div class=\"rowcontent\"><div class=\"col1\">";
                ltrCuoidong.Text = "</div>";
            }
            if ((e.Item.ItemIndex + 1) % 3 == 0)
            {
                ltrDaudong.Text = "<div class=\"col3\">";
                ltrCuoidong.Text = "</div></div><div class=\"clearfix\"></div>";
            }
            //
            if (lang == "1")
            {
                lnkText.Text = curData["CP_CategoryUnicode"].ToString();                
            }
            else
            {
                lnkText.Text = curData["CP_Category"].ToString();
            }
            imgAvatar.ImageUrl = ConfigurationSettings.AppSettings.Get("urldata") + curData["CP_Category_Avatar"].ToString().Replace("~", "");
            if (curData["CP_Url"].ToString().Contains("Default"))
            {
                lnkText.NavigateUrl = lnkIcon.NavigateUrl = curData["CP_Url"] + "&w=" + width + "&lang=" + lang;
            }
            else
            {
                lnkText.NavigateUrl = lnkIcon.NavigateUrl = curData["CP_Url"].ToString();
            }
            //lnkText.NavigateUrl = lnkIcon.NavigateUrl = curData["CP_Url"].ToString() + "&w=" + width + "&lang=" + lang;
        }
    }
}