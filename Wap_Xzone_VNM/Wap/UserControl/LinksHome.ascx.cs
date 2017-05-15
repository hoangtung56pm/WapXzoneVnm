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
    public partial class LinksHome : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private string display;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = Request.QueryString["lang"];
                width = Request.QueryString["w"];

                DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(2, 90);//25, 74);
                rptLienket.DataSource = cpConfig;
                rptLienket.ItemDataBound += new RepeaterItemEventHandler(rptLienket_ItemDataBound);
                rptLienket.DataBind();
                //end of lienket               
            }
            if (lang == "1")
            {
                lnkLienket.Text = "LIÊN KẾT";
            }
            lnkLienket.NavigateUrl = UrlProcess.GetVNMLienket(lang, width, "lk");
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
                ltrNhom.Text = curData["WAP_CategoryTitleUnicode"].ToString() + ": ";
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    //ltrDonvi.Text += "<a href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";

                    if (rCP["CP_Url"].ToString().Contains("Default.aspx"))
                    {
                        ltrDonvi.Text += "<a href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";
                    }
                    else
                    {
                        ltrDonvi.Text += "<a href=\"" + rCP["CP_Url"] + "\" >" + rCP["CP_CategoryUnicode"] + "</a>, ";
                    }

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
                    

                    if (rCP["CP_Url"].ToString().Contains("Default.aspx"))
                    {
                        ltrDonvi.Text += " - <a href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_Category"] + "</a>, ";
                    }
                    else
                    {
                        ltrDonvi.Text += " - <a href=\"" + rCP["CP_Url"] + "\" >" + rCP["CP_Category"] + "</a>, ";
                    }

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