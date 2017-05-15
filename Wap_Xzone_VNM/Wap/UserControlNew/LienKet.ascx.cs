using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class LienKet : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lang = Request.QueryString["lang"];
                width = Request.QueryString["w"];

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();

                DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(2, 90);//25, 74);
                if (cpConfig != null && cpConfig.Rows.Count > 0)
                {
                    rptLienKet.DataSource = cpConfig;
                    rptLienKet.ItemDataBound += rptLienket_ItemDataBound;
                    rptLienKet.DataBind();
                }  
            }
        }

        protected void rptLienket_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrNhom = (Literal)e.Item.FindControl("ltrNhom");
            Literal ltrDonvi = (Literal)e.Item.FindControl("ltrDonvi");
            //

            DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache((int)curData["WAP_ID"]);
            int i = 0;
            if (lang == "1")
            {
                ltrNhom.Text = curData["WAP_CategoryTitleUnicode"] + ": ";
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    if (rCP["CP_Url"].ToString().Contains("http://wap.vietnamobile.com.vn"))
                    {
                        if (rCP["CP_Url"].ToString().ToLower().Contains("nhaccho") || rCP["CP_Url"].ToString().ToLower().Contains("nhacchuong"))
                            ltrDonvi.Text += "<a class=\"style7\" href=\"" + UrlProcess.GetMusicHomeUrlNew(lang, width) + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";
                        else
                            ltrDonvi.Text += "<a class=\"style7\" href=\"" + rCP["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";
                    }
                    else
                        ltrDonvi.Text += "<a class=\"style7\" href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";


                    i += 1;
                    if (i == 2)
                    {
                        ltrDonvi.Text += "...";
                        break;
                    }
                }
            }
            else
            {
                ltrNhom.Text = curData["WAP_CategoryTitle"].ToString();
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    if (rCP["CP_Url"].ToString().Contains("http://wap.vietnamobile.com.vn"))
                        ltrDonvi.Text += " - <a class=\"style7\" href=\"" + rCP["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_Category"] + "</a>, ";
                    else
                        ltrDonvi.Text += " - <a class=\"style7\" href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_Category"] + "</a>, ";

                    i += 1;
                    if (i == 2)
                    {
                        ltrDonvi.Text += "...";
                        break;
                    }
                }
            }
        }

    }
}