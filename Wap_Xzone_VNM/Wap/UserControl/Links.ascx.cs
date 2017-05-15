using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class Links : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];
            DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(0, 74);
            if (lang == "1")
            {
                ltrNhom.Text = cpConfig.Rows[0]["WAP_CategoryTitleUnicode"].ToString();
                lnkTrangChu.Text = "<span class=\"pink bold\">" + Resources.Resource.wTrangChu + "</span>";
            }
            else
            {
                ltrNhom.Text = cpConfig.Rows[0]["WAP_CategoryTitle"].ToString();
                lnkTrangChu.Text = "<span class=\"pink bold\">" + Resources.Resource.wTrangChu_KD + "</span>";
            }
            lnkTrangChu.NavigateUrl = UrlProcess.GetWapHomeUrl(lang, width);
            //            
            rptLienket.DataSource = WapController.CPConfig_GetByWap_IDHasCache((int)cpConfig.Rows[0]["WAP_ID"]);
            rptLienket.ItemDataBound += new RepeaterItemEventHandler(rptLienket_ItemDataBound);
            rptLienket.DataBind();
            
        }


        protected void rptLienket_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;            
            Literal ltrDonvi = (Literal)e.Item.FindControl("ltrDonvi");
            string lnkExt;
            if (curData["CP_Url"].ToString().IndexOf("?") > 0)
                lnkExt = "&lang=" + lang + "&w=" + width;
            else
                lnkExt = "?lang=" + lang + "&w=" + width;
            if (lang == "1")
            {
                ltrDonvi.Text += "<a href=\"" + curData["CP_Url"].ToString() + lnkExt + " \" >" + curData["CP_CategoryUnicode"] + "</a>";
            }
            else
            {
                ltrDonvi.Text += "<a href=\"" + curData["CP_Url"].ToString() + lnkExt + " \" >" + curData["CP_Category"] + "</a>";
            }            
            //imgAvatar.ImageUrl = ConfigurationSettings.AppSettings.Get("urldata") + ".." + curData["CP_Category_Avatar"].ToString().Replace("~", "");
            //lnkText.NavigateUrl = lnkIcon.NavigateUrl = curData["CP_Url"].ToString() + "&w=" + width;
        }
    }
}