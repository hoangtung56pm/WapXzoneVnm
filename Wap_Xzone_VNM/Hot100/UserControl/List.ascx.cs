using System;
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
using MobileWap.Library;
using MobileWap.Library.IPNumbers;

namespace WapXzone_VNM.Hot100.UserControl
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private bool showDL = false;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);            
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            int is3g = 0;
            //string msisdn = MobileUtils.GetMSISDN(out is3g);

            string vnmnumber = MobileUtils.GetMSISDN(out is3g);
            
            IPList iplist = new IPList();
            iplist.Add("202.172.4.192", 26);
            iplist.Add("203.170.26.0", 24);
            iplist.Add("203.170.27.0", 24);
            iplist.Add("203.128.247.24", 30);            
            iplist.Add("203.162.40.20", 30);
            if (iplist.CheckNumber(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"])) showDL = true;            

            //if (!string.IsNullOrEmpty(vnmnumber) && MobileUtils.CheckOperator(vnmnumber, "vietnammobile") && (iplist.CheckNumber(HttpContext.Current.Request.UserHostAddress)))
            //    if (VietnamobileWap.Library.Component.Wap.WapController.W4A_Subscriber_IsActive(vnmnumber, 3)) showDL = true;
                        
            //start category list
            int totalrecord = 0;
            //DataTable dtCat = RTController.GetAllRingToneByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(),110, (int)Constant.RingTone.Hot100, pagesize, curpage, out totalrecord);
            DataTable dtCat = RTController.VNM_GetAllRingToneByCategoryAndDisplayTypeHasCache(110, (int)Constant.RingTone.Hot100, pagesize, curpage, out totalrecord);
            
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            Pagging1.totalrecord = totalrecord;
            Pagging1.pagesize = pagesize;
            Pagging1.numberpage = pagenumber;
            Pagging1.defaultparam = "?lang=" + Request.QueryString["lang"];
            Pagging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&cpage=";
            //end category list
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkDL = (HyperLink)e.Item.FindControl("lnkDL");
            Literal ltrStt = (Literal)e.Item.FindControl("ltrStt");
            Label lblTen = (Label)e.Item.FindControl("lblTen");
            Literal ltrCasy = (Literal)e.Item.FindControl("ltrCasy");
            ltrStt.Text = (e.Item.ItemIndex + 1 + (curpage-1) * pagesize).ToString() + ". ";
            if (ltrStt.Text.Length == 3) ltrStt.Text = "0" + ltrStt.Text;
            if (lang == 1)
            {
                lblTen.Text = curData["SongNameUnicode"].ToString();
                ltrCasy.Text = curData["ArtistNameUnicode"].ToString();
            }
            else
            {
                lblTen.Text = curData["SongName"].ToString();
                ltrCasy.Text = curData["ArtistName"].ToString();
            }
            //lnkDL.NavigateUrl = UrlProcess.GetRingToneDetailUrl(lang.ToString(), "detail", width, curData["W_RTItemID"].ToString());
            if (showDL) lnkDL.NavigateUrl = UrlProcess.GetGameDownloadItem(Session["telco"].ToString(),"2", curData["W_RTItemID"].ToString(), SecurityMethod.MD5Encrypt(curData["W_RTItemID"].ToString()));
            else lnkDL.Visible = false;
        }
    }
}