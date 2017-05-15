using System;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class ListNews : System.Web.UI.UserControl
    {

        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int catID;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            //catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            if (!IsPostBack)
            {

                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                //DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                {
                    //lnkCatName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    lnkHomeChannel.Text = "TIN TỨC";
                }
                //else
                //{
                //    //lnkCatName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
                //}
                //lnkCatName.NavigateUrl = UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetNewsHomeUrl(lang.ToString(), width);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;

            //DataTable dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, pagesize, curpage, out totalrecord);

            DataTable dtCat = ThethaoController.GetLastestNewsFromTheThaoSoHasCache(curpage, pagesize, out totalrecord);

            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
            //end category list
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            Label lblCreatedOn = (Label)e.Item.FindControl("lblCreatedOn");
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            if (lang == 1)
            {
                lnkTitle.Text = curData["Content_Headline"].ToString();
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
            }
            if (string.IsNullOrEmpty(ConvertUtility.ToString(curData["Content_Avatar"])))
            {
                imgAvatar.ImageUrl = "/Images/icon_app52.png";
            }
            else
            {
                imgAvatar.ImageUrl = AppEnv.GetAvatarTheThaoSo(curData["Content_Avatar"].ToString(), 60, 60);
            }
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrlTheThaoSo(lang.ToString(),width, curData["Distribution_ID"].ToString());
            lblCreatedOn.Text = ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy hh:mm");
        }

    }
}