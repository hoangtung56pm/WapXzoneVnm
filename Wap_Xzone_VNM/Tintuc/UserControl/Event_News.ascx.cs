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
using VmgPortal.Modules.Adsvertising;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class Event_News : System.Web.UI.UserControl
    {
        private int lang;
        private int count;
        private string width;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {                
                //lastest News
                DataTable dtlatest = TintucController.GetTopNewsHasCache(381, 3);
                count = dtlatest.Rows.Count - 1;
                rptNewLastest.DataSource = dtlatest;
                rptNewLastest.ItemDataBound += new RepeaterItemEventHandler(rptNewLastest_ItemDataBound);
                rptNewLastest.DataBind();
                //end lastest News                
                lnkCacTinKhac.NavigateUrl = UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, "320");
                if (lang != 1)
                {
                    lnkCacTinKhac.Text = "Cac tin khac »";                    

                };
            }
        }

        protected void rptNewLastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitlelist = (HyperLink)e.Item.FindControl("lnkTitlelist");
            Image imglist = (Image)e.Item.FindControl("imglist");
            Panel pn = (Panel)e.Item.FindControl("othernews");
            if (e.Item.ItemIndex == 0)
            {
                if (lang == 1)
                {
                    lnkTitle.Text = curData["Content_Headline"].ToString();
                    //ltrTeaser.Text = curData["Content_Teaser"].ToString();
                }
                else
                {
                    lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
                    //ltrTeaser.Text = curData["Content_TeaserKD"].ToString();
                }
                //Ảnh đại diện
                if (string.IsNullOrEmpty(ConvertUtility.ToString(curData["Content_Avatar"])))
                {
                    imgAvatar.ImageUrl = "/Images/icon_app52.png";
                }
                else
                {
                    WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    ws.GenerateAvatarThumnail(curData["Content_Avatar"].ToString(), 51, 51);
                    imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Content_Avatar"].ToString(), 51, 51).Replace("~","");
                }
                lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
                ltrTime.Text = ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                pn.Visible = false;
            }
            else
            {
                if (lang == 1)
                {
                    lnkTitlelist.Text = curData["Content_Headline"].ToString();
                }
                else
                {
                    lnkTitlelist.Text = curData["Content_HeadlineKD"].ToString();
                }

                lnkTitlelist.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
                pn.Visible = true;
            }

        }
    }
}