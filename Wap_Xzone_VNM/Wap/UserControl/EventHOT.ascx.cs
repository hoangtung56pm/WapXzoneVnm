using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class EventHOT : System.Web.UI.UserControl
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

                DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(32, 74);//39, 90);//
                //if (cpConfig != null && cpConfig.Rows.Count > 0)
                //{
                //    for (int i = 0; i < cpConfig.Rows.Count; i++)
                //    {
                //        if ((int)cpConfig.Rows[i]["WAP_ID"] == 33)
                //        {
                //            cpConfig.Rows[i]["WAP_ID"] = 40;
                //            cpConfig.AcceptChanges();
                //            break;
                //        }
                //    }
                //}
                rptLienket.DataSource = cpConfig;
                rptLienket.ItemDataBound += rptLienket_ItemDataBound;
                rptLienket.DataBind();
                //end of lienket

                int totalrecord1;
                DataTable dtTinTongHop = WapXzone_VNM.Library.Component.Tintuc.TintucController.GetAllNewsByCategory(ConvertUtility.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("tintonghop")), 1, 1, out totalrecord1);
                if (dtTinTongHop.Rows.Count > 0)
                {
                    if (lang == "1")
                    {
                        ltrNhom.Text = "<a href=\"" + "../" + UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, System.Configuration.ConfigurationSettings.AppSettings.Get("tintonghop")).Replace("~/", "") + "\" >HOTNEWS</a>";                        
                        ltrDonvi.Text = " - <a href=\"" + "../" + UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, dtTinTongHop.Rows[0]["Distribution_ID"].ToString()).Replace("~/", "") + "\" >" + dtTinTongHop.Rows[0]["Content_Headline"].ToString() + "</a>"; ;
                    }
                    else
                    {
                        ltrNhom.Text = "<a href=\"" + "../" + UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, System.Configuration.ConfigurationSettings.AppSettings.Get("tintonghop")).Replace("~/", "") + "\" >HOTNEWS</a>";
                        ltrDonvi.Text = " - <a href=\"" + "../" + UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, dtTinTongHop.Rows[0]["Distribution_ID"].ToString()).Replace("~/", "") + "\" >" + dtTinTongHop.Rows[0]["Content_HeadlineKD"].ToString() + "</a>"; ;
                    }
                }
            }            
            lnkLienket.NavigateUrl = "";//UrlProcess.GetVNMHomeUrl(lang, width, "links");
        }

        protected void rptLienket_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrNhom = (Literal)e.Item.FindControl("ltrNhom");
            Literal ltrDonvi = (Literal)e.Item.FindControl("ltrDonvi");
            //
            DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache((int)curData["WAP_ID"]);
            if (lang == "1")
            {
                ltrNhom.Text = curData["WAP_CategoryTitleUnicode"].ToString().ToUpper();
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    if (rCP["CP_Url"].ToString().Contains("Default.aspx"))
                    {
                        ltrDonvi.Text += " - <a href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>";
                    }
                    else
                    {
                        ltrDonvi.Text += " - <a href=\"" + rCP["CP_Url"] + "\" >" + rCP["CP_CategoryUnicode"] + "</a>";
                    }
                }
            }
            else
            {
                ltrNhom.Text = curData["WAP_CategoryTitle"].ToString().ToUpper();
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    ltrDonvi.Text += " - <a href=\"" + rCP["CP_Url"] + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_Category"] + "</a>";
                }
            }
            if (curData["WAP_CategoryDes"].ToString() != "")
            {
                string lnkExt;
                if (curData["WAP_CategoryDes"].ToString().IndexOf("?") > 0)
                    lnkExt = "&lang=" + lang + "&w=" + width;
                else
                {
                    if (curData["WAP_CategoryDes"].ToString().Contains("Default.aspx"))
                    {
                        lnkExt = "?lang=" + lang + "&w=" + width;
                    }
                    else
                    {
                        lnkExt = string.Empty;
                    }
                }
                    
                ltrNhom.Text = "<a href=\"" + curData["WAP_CategoryDes"] + lnkExt + "\"><span class=\"link-non-orange-bold\">" + ltrNhom.Text + "</span><a/>";
            }
        }
    }
}