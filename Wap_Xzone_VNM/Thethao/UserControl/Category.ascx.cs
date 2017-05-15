using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Thethao.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private string tab;
        private static int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            tab = ConvertUtility.ToString(Request.QueryString["tab"]);

            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    ltrCacGiaiDau.Text = "CÁC GIẢI ĐẤU";
                    lnkTheThao.Text = "BÓNG ĐÁ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("tkdbprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    ltrCacGiaiDau.Text = "CAC GIAI DAU";
                    lnkTheThao.Text = "BONG DA";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("tkdbprice") + Resources.Resource.wDonViTien_KD + ")";
                }
                lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "home", width);
                DataTable dt = ThethaoController.GetAllCategoryExeptCatID((int)Constant.DefaultPortal.Mobifone, catid);
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound); ;
                rptCategory.DataBind();
            }

        }
        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");
            if (lang == 1)
            {
                lnkCatName.Text = curData["NameUnicode"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Name"].ToString();
            }
            switch (tab.ToLower())
            {
                case "bxh":
                    lnkCatName.NavigateUrl = UrlProcess.GetCompetitionBXHUrl(lang.ToString(), width, curData["W_CompetitionID"].ToString());
                    break;
                case "ltd":
                    lnkCatName.NavigateUrl = UrlProcess.GetCompetitionLTDUrl(lang.ToString(), width, curData["W_CompetitionID"].ToString());
                    break;
                case "kqtd":
                    lnkCatName.NavigateUrl = UrlProcess.GetCompetitionKQTDUrl(lang.ToString(), width, curData["W_CompetitionID"].ToString());
                    break;
                case "tkdb":
                    DataTable dtTKDB = ThethaoController.ThongKeDacBiet(ConvertUtility.ToString(curData["W_CompetitionID"]));
                    lnkCatName.NavigateUrl = "";
                    if (dtTKDB.Rows.Count > 0)
                        if (dtTKDB.Rows[0]["WapContent"].ToString().Trim().Length > 0)
                            lnkCatName.NavigateUrl = UrlProcess.GetCompetitionTKDBUrl(lang.ToString(), width, curData["W_CompetitionID"].ToString());
                    break;
            }

        }
    }
}