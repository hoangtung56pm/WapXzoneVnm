using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game.UserControlNew
{
    public partial class TruyCapNhanh : System.Web.UI.UserControl
    {
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = Request.QueryString["w"];
            DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(0, 74);
            if (lang == "1")
            {
                lnkTrangChu.Text =  Resources.Resource.wTrangChu ;
            }
            else
            {
                lnkTrangChu.Text = Resources.Resource.wTrangChu_KD ;
            }
            lnkTrangChu.NavigateUrl = UrlProcess.GetWapHomeUrlNew(lang, width);

            DataTable dt = WapController.CPConfig_GetByWap_IDHasCache((int)cpConfig.Rows[0]["WAP_ID"]);
            if(dt.Rows.Count > 0)
            {
                rptTruyCapNhanh.DataSource = dt;
                rptTruyCapNhanh.ItemDataBound += rptTruyCapNhanh_ItemDataBound;
                rptTruyCapNhanh.DataBind();
            }
        }

        protected void rptTruyCapNhanh_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                ltrDonvi.Text += "<a class=\"link-non-smokeblack\" href=\"" + curData["CP_Url"].ToString().Replace("Default","DefaultNew") + lnkExt + " \" >" + curData["CP_CategoryUnicode"] + "</a>";
            }
            else
            {
                ltrDonvi.Text += "<a class=\"link-non-smokeblack\" href=\"" + curData["CP_Url"].ToString().Replace("Default", "DefaultNew") + lnkExt + " \" >" + curData["CP_Category"] + "</a>";
            }
        }
    }
}