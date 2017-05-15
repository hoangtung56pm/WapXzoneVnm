using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class DichVuNoiBat : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                width = Request.QueryString["w"];

                DataTable cpConfig = WapController.Setting_Category_GetAllByParentIDHasCache(32, 74); //39, 90);//
                if (cpConfig != null && cpConfig.Rows.Count > 0)
                {
                    for (int i = 0; i < cpConfig.Rows.Count; i++)
                    {
                        if ((int)cpConfig.Rows[i]["WAP_ID"] == 33)
                        {
                            cpConfig.Rows[i]["WAP_ID"] = 40;
                            cpConfig.AcceptChanges();
                            break;
                        }
                    }
                }
                rptLienket.DataSource = cpConfig;
                rptLienket.ItemDataBound += rptLienket_ItemDataBound;
                rptLienket.DataBind();
                //end of lienket
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
            if (lang == 1)
            {
                ltrNhom.Text = curData["WAP_CategoryTitleUnicode"].ToString().ToUpper();
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    ltrDonvi.Text += " - <a class=\"link-non-black\" href=\"" + rCP["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_CategoryUnicode"] + "</a>";
                }
            }
            else
            {
                ltrNhom.Text = curData["WAP_CategoryTitle"].ToString().ToUpper();
                foreach (DataRow rCP in cpConfig.Rows)
                {
                    ltrDonvi.Text += " - <a class=\"link-non-black\" href=\"" + rCP["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&lang=" + lang + "&w=" + width + "\" >" + rCP["CP_Category"] + "</a>";
                }
            }
            if (curData["WAP_CategoryDes"].ToString() != "")
            {
                string lnkExt;
                if (curData["WAP_CategoryDes"].ToString().IndexOf("?") > 0)
                    lnkExt = "&lang=" + lang + "&w=" + width;
                else
                    lnkExt = "?lang=" + lang + "&w=" + width;
                ltrNhom.Text = "<a class=\"link-non-orange-bold\" href=\"" + curData["WAP_CategoryDes"].ToString().Replace("Default", "DefaultNew") + lnkExt + "\">" + ltrNhom.Text + "<a/>";
            }
        }
    }
}