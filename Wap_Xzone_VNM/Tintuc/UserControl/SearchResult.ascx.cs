using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int catID;
        private int id;
        private string price;
        private string key;
        private int parentid;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            key = Request.QueryString["key"];
            parentid = ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("news_zoneid"));
            if (!IsPostBack)
            {

                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lblTitle.Text = "Kết quả tìm kiếm";
                }

            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = TintucController.GetAllNewsByKey(key, pagesize, curpage, out totalrecord,parentid);
            rptResult.DataSource = dtCat;
            rptResult.ItemDataBound += new RepeaterItemEventHandler(rptResult_ItemDataBound);
            rptResult.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&key=" + Request.QueryString["key"] + "&id=" + Request.QueryString["id"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&key=" + Request.QueryString["key"] + "&id=" + Request.QueryString["id"] + "&cpage=";
            //end category list
            if (lang == 1)
            {
                ltrCount.Text = "Tìm thấy " + totalrecord + " bài";
            }
            else
            {
                ltrCount.Text = "Tim thay " + totalrecord + " bai";
            }
        }
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
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
                imgAvatar.ImageUrl = "/Images/vnm_vnmicon.jpg";
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["Content_Avatar"].ToString(), 60, 60);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Content_Avatar"].ToString(), 60, 60).Replace("~", "");
            }
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
        }
    }
}