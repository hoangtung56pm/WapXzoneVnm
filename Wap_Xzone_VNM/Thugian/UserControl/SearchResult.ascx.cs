using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone.Library.UrlProcess;
using WapXzone.Library.Component.Tintuc;
using WapXzone.Library.Utilities;
using System.Configuration;

using WapXzone.Library;
using WapXzone.Library.Constant;

namespace WapXzone.Thugian.UserControl
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
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            key = Request.QueryString["key"];
            parentid = ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("relax_zoneiddefaut"));
            price = ConfigurationSettings.AppSettings.Get("relaxprice");
            cipher = Request.QueryString["link"];
            MobileUtils.GetDetailUrl(EAS.DecryptData(cipher, ConfigurationSettings.AppSettings.Get("vmskey")), ref msisdn, ref cpid, ref vmstransactionid);
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
            DataTable dtCat = TintucController.GetAllNewsByKey(key, pagesize, curpage, out totalrecord, parentid);
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
            Label lblCreatedOn = (Label)e.Item.FindControl("lblCreatedOn");
            if (lang == 1)
            {
                lnkTitle.Text = curData["Content_Headline"].ToString();
                lblCreatedOn.Text = "Ngày: " + ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy");
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
                lblCreatedOn.Text = "Ngay: " + ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy");
            }
            //lnkTitle.NavigateUrl = UrlProcess.GetRelaxNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
            string content = cpid + "&" + Constant.giaitri_haihuoc + curData["Distribution_ID"].ToString() + "&" + price + "&" + vmstransactionid;
            lnkTitle.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey")));
        }
    }
}