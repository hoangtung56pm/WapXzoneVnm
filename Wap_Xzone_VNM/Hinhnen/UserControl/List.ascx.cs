﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Hinhnen.UserControl
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;
        private int catID;        
        //private string price;        
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            
            if (!IsPostBack)
            {                
                DataTable catInfo = HinhNenController.GetCategoryByCatIDHasCache(catID);
                if (lang == 1)
                {
                    lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    lnkHomeChannel.Text = "HÌNH NỀN";
                }
                else
                    lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
                lnkCateChannel.NavigateUrl = UrlProcess.GetWallpaperCategoryUrl(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetWallpaperHomeUrl(lang.ToString(), width);
            }
            
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.HinhNen.Category, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
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
            System.Web.UI.WebControls.Image imgAvatar = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["WTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["WTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetWallpaperDetailUrl(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&catid=" + curData["W_CategoryID"].ToString();
            //lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_WItemID"].ToString() + "&catid=" + curData["W_CategoryID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrl(lang.ToString(), width, curData["W_WItemID"].ToString(), curData["W_CategoryID"].ToString());
            lnkTang.NavigateUrl = UrlProcess.GetWallpaperDetailUrl(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&g=1&catid=" + curData["W_CategoryID"].ToString();
            if (curData["WThumnail"].ToString().LastIndexOf(".gif") > 0)
            {
                WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                imgAvatar.ImageUrl = preurl + ws.GetAvatarGif(curData["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 60, 60);
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["WThumnail"].ToString(), 60, 60);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["WThumnail"].ToString(), 60, 60).Replace("~", "");
            }
        }        
    }
}