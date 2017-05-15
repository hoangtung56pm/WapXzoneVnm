using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Collections;

namespace WapXzone_VNM.Hot100.UserControl
{
    public partial class Pagging : System.Web.UI.UserControl
    {
        //trang hien tai
        private int curpage = 1;
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
            int cpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            if (cpage > 0)
            {
                curpage = cpage;
            }
            if (Request.QueryString["lang"] == "1")
            {
                lnkEnd.Text = "Cuối";
                lnkFist.Text = "Đầu";
                lnkPrev.Text = "Trước";
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
                lnkFist.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hot100/", "") + defaultparam;
                lnkEnd.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hot100/", "") + queryparam + totalpage;
                if (totalpage > to)
                {
                    lnkNext.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hot100/", "") + queryparam + (to + 1).ToString();
                }
                else
                {
                    lnkNext.Enabled = false;
                }
                if (from > numberpage)
                {
                    lnkPrev.NavigateUrl = Request.AppRelativeCurrentExecutionFilePath.Replace("~/UserControl/Hot100/", "") + queryparam + (from - numberpage).ToString();
                }
                else
                {
                    lnkPrev.Enabled = false;
                }
            }
            else
            {
                lnkNext.Enabled = false;
                lnkPrev.Enabled = false;
                lnkFist.Enabled = false;
                lnkEnd.Enabled = false;
            }
        }

        public void rptPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal ltrPage = (Literal)e.Item.FindControl("ltrPage");
            string url = Request.AppRelativeCurrentExecutionFilePath.Replace("~/Hot100/", "") + queryparam + e.Item.DataItem;

            int curdata = ConvertUtility.ToInt32(e.Item.DataItem);
            if ((e.Item.ItemIndex + 1) == curpage)
            {
                if (curdata == numberpage || curdata == totalpage)
                {
                    ltrPage.Text = "[" + ConvertUtility.ToString(e.Item.DataItem) + "] ";
                }
                else
                {
                    ltrPage.Text = "[" + ConvertUtility.ToString(e.Item.DataItem) + "], ";
                }

            }
            else
            {

                if (curpage > numberpage)
                {
                    if (ConvertUtility.ToInt32(e.Item.DataItem) == curpage)
                    {
                        if (curdata == numberpage || curdata == totalpage)
                        {
                            ltrPage.Text = "[" + ConvertUtility.ToString(e.Item.DataItem) + "] ";
                        }
                        else
                        {
                            ltrPage.Text = "[" + ConvertUtility.ToString(e.Item.DataItem) + "], ";
                        }
                    }
                    else
                    {
                        if (curdata == numberpage || curdata == totalpage)
                        {
                            ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + " </a>";
                        }
                        else
                        {
                            ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + ", </a>";
                        }
                    }
                }
                else
                {
                    if (curdata == numberpage || curdata == totalpage)
                    {
                        ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + " </a>";
                    }
                    else
                    {
                        ltrPage.Text = "<a href=\"" + url + "\" >" + ConvertUtility.ToString(e.Item.DataItem) + ", </a>";
                    }
                }
            }
        }
    }
}