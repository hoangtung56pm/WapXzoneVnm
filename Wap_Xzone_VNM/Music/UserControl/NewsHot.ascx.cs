﻿using System;
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

namespace WapXzone_VNM.Music.UserControl
{
    public partial class NewsHot : System.Web.UI.UserControl
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
                DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("news_showbizid")), 3);
                count = dtlatest.Rows.Count - 1;
                rptNewLastest.DataSource = dtlatest;
                rptNewLastest.ItemDataBound += new RepeaterItemEventHandler(rptNewLastest_ItemDataBound);
                rptNewLastest.DataBind();
                //end lastest News                
                lnkCacTinKhac.NavigateUrl = UrlProcess.GetMusicNewsListUrl(lang.ToString(), width);
                if (lang != 1) lnkCacTinKhac.Text = "» Xem tiep";
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
                    lnkTitle.Text = "<span class=\"bold black\">" + curData["Content_Headline"].ToString() + "</span>";
                    ltrTeaser.Text = curData["Content_Teaser"].ToString();
                }
                else
                {
                    lnkTitle.Text = "<span class=\"bold black\">" + curData["Content_HeadlineKD"].ToString() + "</span>";
                    ltrTeaser.Text = curData["Content_TeaserKD"].ToString();
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
                lnkTitle.NavigateUrl = UrlProcess.GetMusicNewsDetailUrl(lang.ToString(), width, curData["Distribution_ID"].ToString());
                ltrTime.Text = ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                pn.Visible = false;
            }
            else
            {
                if (lang == 1)
                {
                    lnkTitlelist.Text = "<span class=\"black\">" + curData["Content_Headline"].ToString() + "</span>";
                }
                else
                {
                    lnkTitlelist.Text = "<span class=\"black\">" + curData["Content_HeadlineKD"].ToString() + "</span>";
                }

                lnkTitlelist.NavigateUrl = UrlProcess.GetMusicNewsDetailUrl(lang.ToString(), width, curData["Distribution_ID"].ToString());
                pn.Visible = true;
            }

        }
    }
}