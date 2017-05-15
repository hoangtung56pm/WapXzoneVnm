using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Collections;

namespace WapXzone_VNM.Bancanbiet.UserControl
{
    public partial class Paging : System.Web.UI.UserControl
    {
        //trang hien tai
        private int curpage = 1;
        private int cpage;
        
        //tong so ban ghi
        public int totalrecord = 0;
        // so ban ghi tren 1 trang
        public int pagesize = 0;
        //tong so trang 
        private int totalpage = 0;
        //So trang can the hien ben ngoa`i
        public int numberpage = 0;
        //tham so truyen vao cho trang dau
        public string defaultparam;
        //tham so truyen vao cho 1 trang bat ky
        public string queryparam;

        protected void Page_Load(object sender, EventArgs e)
        {
            int cpage = ConvertUtility.ToInt32(Request.QueryString[queryparam.Substring(queryparam.Length - 6, 5)]);
            if (cpage > 0)
            {
                curpage = cpage;
            }
        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (totalrecord > 0 && pagesize > 0 && numberpage > 0)
            {
                totalpage = (int)Math.Ceiling((double)totalrecord / pagesize);
                int c = (int)Math.Ceiling((double)curpage / numberpage);
                int from = (c - 1) * numberpage + 1;
                int to = c * numberpage;
                if (to > totalpage) to = totalpage;
                ArrayList x = new ArrayList();
                for (int i = from; i <= to; i++) x.Add(i);
                rptPage.DataSource = x;
                rptPage.ItemDataBound += new RepeaterItemEventHandler(rptPage_ItemDataBound);
                rptPage.DataBind();
                
                int ct = (int)curpage / 5;
                if (1 < curpage)
                {
                    lnkFirst.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Bancanbiet/", "") + queryparam + (1).ToString();
                    lnkPrev.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Bancanbiet/", "") + queryparam + (curpage - 1).ToString();
                }
                if (curpage < totalpage)
                {
                    lnkLast.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Bancanbiet/", "") + queryparam + totalpage.ToString();
                    lnkNext.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Bancanbiet/", "") + queryparam + (curpage + 1).ToString();
                }
            }
            else
            {
                ltrNoData.Visible = true;
                lnkFirst.Visible = lnkPrev.Visible = lnkLast.Visible = lnkNext.Visible = false;
                if (Request.QueryString["lang"] == "1") ltrNoData.Text = "Dữ liệu của mục này hiện đang được cập nhật.";
            }
        }

        public void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int curdata = ConvertUtility.ToInt32(e.Item.DataItem);
            if (curdata == pagesize || curdata == totalpage)
            {
                Literal ltrGach = (Literal)e.Item.FindControl("ltrGach");
                ltrGach.Visible = false;
            }
            Label ltrPage = (Label)e.Item.FindControl("ltrPage");
            string url = Request.AppRelativeCurrentExecutionFilePath.Replace("~/Bancanbiet/", "") + queryparam + e.Item.DataItem;

            
            if ((e.Item.ItemIndex + 1) == curpage)
            {                
                ltrPage.Text = "<span class=\"orange bold\">" + ConvertUtility.ToString(e.Item.DataItem) + "</span>";
            }
            else
            {
                if (curpage > numberpage)
                {
                    if (ConvertUtility.ToInt32(e.Item.DataItem) == curpage)
                    {
                        ltrPage.Text = "<span class=\"orange bold\">" + ConvertUtility.ToString(e.Item.DataItem) + "</span>";                        
                    }
                    else
                    {
                        ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + " </a>";
                    }
                }
                else
                {
                    ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + " </a>";
                }
            }
        }


        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //    if (totalrecord > 0 && pagesize > 0 && numberpage > 0)
        //    {
        //        totalpage = (int)Math.Ceiling((double)totalrecord / pagesize);
        //        int c = (int)Math.Ceiling((double)curpage / numberpage);
        //        int from = (c - 1) * numberpage + 1;
        //        int to = c * numberpage;
        //        if (to > totalpage) to = totalpage;
        //        ArrayList x = new ArrayList();
        //        for (int i = from; i <= to; i++) x.Add(i);
        //        rptPage.DataSource = x;
        //        rptPage.ItemDataBound += new RepeaterItemEventHandler(rptPage_ItemDataBound);
        //        rptPage.DataBind();
        //        //ltrPage.Text = (((curpage - 1) * pagesize) + 1).ToString() + " - " + (curpage * pagesize).ToString();

        //        int ct = (int)curpage / 5;
        //        if ( 1 < curpage )
        //        {
        //            //lnkFirst.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hinhnen/", "") + queryparam + (1).ToString();
        //            lnkPrev.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hinhnen/", "") + queryparam + (curpage - 1).ToString();
        //        }
        //        if (curpage < totalpage)
        //        {
        //            //lnkLast.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hinhnen/", "") + queryparam + totalpage.ToString();
        //            lnkNext.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hinhnen/", "") + queryparam + (curpage + 1).ToString();
        //        }                
        //    }            
        //}

        //public void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex == totalpage - 1)
        //    {
        //        Literal ltrGach = (Literal)e.Item.FindControl("ltrGach");
        //        ltrGach.Visible = false;                
        //    }
        //    HyperLink lnkPage = (HyperLink)e.Item.FindControl("lnkPage");
        //    string url = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hinhnen/", "") + queryparam + e.Item.DataItem;
        //    int curdata = ConvertUtility.ToInt32(e.Item.DataItem);
        //    lnkPage.Text = curdata.ToString();
        //    lnkPage.NavigateUrl = url;
        //    if (curdata == cpage)//ConvertUtility.ToInt32(Request.QueryString["cpage"]))
        //    {
        //        lnkPage.Enabled = false;
        //    }
        //}
    }
}