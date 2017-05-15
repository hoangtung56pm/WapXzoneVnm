﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class Style : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private static string preurl;
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                        
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (lang == "0") ltrTheLoai.Text = "BAI HAT THEO THE LOAI";
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetStyleHasCache(curpage, pagesize, out totalrecord);
            rptlstCategory.DataSource = dtCat;            
            rptlstCategory.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"]  + "&cpage=";
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrTheLoai = (Literal)e.Item.FindControl("ltrTheLoai");
            if (lang == "1")
            {
                ltrTheLoai.Text = "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black bold\">" + curData["StyleNameUnicode"].ToString() + "</span></a>";
            }
            else
            {
                ltrTheLoai.Text = "<a href=\"" + UrlProcess.GetMusicByStyleUrl(lang, width, curData["StyleID"].ToString()) + "\"><span class=\"black bold\">" + curData["StyleName"].ToString() + "</span></a>";
            }
        }        
    }
}