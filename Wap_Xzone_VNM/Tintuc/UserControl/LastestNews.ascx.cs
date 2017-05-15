using System;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class LastestNews : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;        
        private int lang;
        private string width;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lblTitle.Text = "TIN MỚI NHẤT";
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //lastest News
            int totalrecord = 0;
            DataTable dtlatest = TintucController.GetTopNewsWithPaggingHasCache(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("news_zoneid")), pagesize, curpage, 60, out totalrecord);
            rptlastest.DataSource = dtlatest;
            rptlastest.ItemDataBound += rptlastest_ItemDataBound;
            rptlastest.DataBind();

            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";
            
            //end lastest News
            if (curpage == 1)
            {
                int totalrecord1;
                DataTable dtTinTongHop = TintucController.GetAllNewsByCategory(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("tintonghop")), 1, 1, out totalrecord1);
                if (dtTinTongHop.Rows.Count > 0)
                {
                    //divtintonghop.Visible = true;
                    if (lang == 1)
                    {
                        lnkTitle.Text = dtTinTongHop.Rows[0]["Content_Headline"].ToString();
                    }
                    else
                    {
                        lnkTitle.Text = dtTinTongHop.Rows[0]["Content_HeadlineKD"].ToString();
                    }
                    if (string.IsNullOrEmpty(ConvertUtility.ToString(dtTinTongHop.Rows[0]["Content_Avatar"])))
                    {
                        imgAvatar.ImageUrl = "/Images/icon_app52.png";
                    }
                    else
                    {
                        CreateAvatar.MOReceiver ws = new CreateAvatar.MOReceiver();
                        ws.GenerateAvatarThumnail(dtTinTongHop.Rows[0]["Content_Avatar"].ToString(), 60, 60);
                        imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtTinTongHop.Rows[0]["Content_Avatar"].ToString(), 60, 60).Replace("~", "");
                        //imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatar(curData["Content_Avatar"].ToString().Replace("~", ""));
                    }
                    lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, dtTinTongHop.Rows[0]["Distribution_ID"].ToString());
                }
            }
        }

        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                CreateAvatar.MOReceiver ws = new CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["Content_Avatar"].ToString(), 60, 60);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Content_Avatar"].ToString(), 60, 60).Replace("~", "");
            }            
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
        }
    }
}