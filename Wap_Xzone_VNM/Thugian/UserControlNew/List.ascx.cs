using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string price;
        private string width;
        private int catID;
        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("relaxprice");
            width = Request.QueryString["w"];
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (!IsPostBack)
            {

                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                DataTable catParent;
                if (ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]) != 0)
                {
                    catParent = TintucController.GetCategoryByCatIDHasCache(ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]));
                    if (lang == 1)
                    {
                        lblCatName.Text = catParent.Rows[0]["Zone_Name"].ToString().ToUpper() + " » " + catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    }
                    else
                    {
                        lblCatName.Text = catParent.Rows[0]["Zone_Alias"].ToString().ToUpper() + " » " + catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
                    }
                }
                else
                {
                    if (lang == 1)
                    {
                        lblCatName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    }
                    else
                    {
                        lblCatName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
                    }
                }
                if (lang == 1)
                {
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "xxx" + Resources.Resource.wDonViTien;
                }
                else
                {
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "xxx" + Resources.Resource.wDonViTien_KD;
                }

                if (catID == 264) ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxsexprice"));
                switch (catInfo.Rows[0]["Zone_ParentID"].ToString())
                {
                    case "118":
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxprice")) + ")";
                        break;
                    case "258":
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxtuvanprice")) + ")";
                        break;
                    case "121":
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxtuvanprice")) + ")";
                        break;
                    case "268":
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxanchoiprice")) + ")";
                        break;
                    case "255":
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxtruyenprice")) + "/30 ngày đọc truyện)";
                        break;
                    default:
                        ltrGia.Text = ltrGia.Text.Replace("xxx", ConfigurationSettings.AppSettings.Get("relaxprice")) + ")";
                        break;
                }

            }

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            //start category list
            int totalrecord = 0;
            DataTable dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            if(e.Item.ItemIndex == 0)
            {
                Literal litwidth5 = (Literal)e.Item.FindControl("litwidth5");
                Literal litwidth6 = (Literal)e.Item.FindControl("litwidth6");

                litwidth5.Text = "<td width=\"5\" rowspan=\"6\"><img src=\"/imagesnew/blank.gif\" width=\"8\" height=\"10\" /></td>";
                litwidth6.Text = "<td rowspan=\"6\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"10\" /></td>";
            }

            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            Literal ltrLuotxem = (Literal)e.Item.FindControl("ltrLuotxem");
            if (lang == 1)
            {
                lnkTitle.Text = curData["Content_Headline"].ToString() ;
                ltrLuotxem.Text = Resources.Resource.wLuotXem + curData["Distribution_View"];
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
                ltrLuotxem.Text = Resources.Resource.wLuotXem_KD + curData["Distribution_View"];
            }
            lnkTitle.NavigateUrl = "../DownloadNew.aspx?id=" + curData["Distribution_ID"] + "&lang=" + lang + "&w=" + width;
        }
    }
}