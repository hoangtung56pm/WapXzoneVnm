using System;
using System.Collections;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
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
            if (!IsPostBack)
            {
                //int cpage = ConvertUtility.ToInt32(Request.QueryString[queryparam.Substring(queryparam.Length - 6, 5)]);

                string urlGet = Request.RawUrl;
                string[] arrUrl = urlGet.Split('/');

                if(arrUrl[1] == Constant.YoutubeFilmRewrite)
                {
                    cpage = ConvertUtility.ToInt32(arrUrl[2]);
                }
                else
                {
                    cpage = ConvertUtility.ToInt32(arrUrl[4]);
                }

                if (cpage > 0)
                {
                    curpage = cpage;
                }
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
                rptPage.ItemDataBound += rptPage_ItemDataBound;
                rptPage.DataBind();

                string url = Request.RawUrl;
                string[] arrUrl = url.Split('/');
                string key = Request.QueryString["key"];

                int ct = curpage / 5;
                if (1 < curpage)
                {
                    if(arrUrl[1] == Constant.YoutubeFilmRewrite && key == null)
                    {
                        lnkFirst.NavigateUrl = UrlProcess.YoutubeChuyenMuc(1,arrUrl[3].Replace(".aspx", ""));
                        lnkPrev.NavigateUrl = UrlProcess.YoutubeChuyenMuc((curpage - 1), arrUrl[3].Replace(".aspx", ""));
                    }
                    else if(arrUrl[1] == Constant.YoutubeFilmRewrite && key != null)
                    {
                        key = UnicodeUtility.UnicodeToKoDau(key);
                        key = key.Replace(" ", "+");
                        lnkFirst.NavigateUrl = UrlProcess.YoutubeTimKiem(key, 1, Constant.YoutubeFilmRewriteSearch);
                        lnkPrev.NavigateUrl = UrlProcess.YoutubeTimKiem(key, (curpage - 1), Constant.YoutubeFilmRewriteSearch);
                    }
                    else
                    {
                        lnkFirst.NavigateUrl = UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(arrUrl[3]), 1, arrUrl[5].Replace(".aspx", ""));
                        lnkPrev.NavigateUrl = UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(arrUrl[3]), (curpage - 1), arrUrl[5].Replace(".aspx", ""));
                    }
                }
                if (curpage < totalpage)
                {
                    if (arrUrl[1] == Constant.YoutubeFilmRewrite && key == null)
                    {
                        lnkLast.NavigateUrl = UrlProcess.YoutubeChuyenMuc(totalpage, arrUrl[3].Replace(".aspx", ""));
                        lnkNext.NavigateUrl = UrlProcess.YoutubeChuyenMuc(curpage + 1, arrUrl[3].Replace(".aspx", ""));
                    }
                    else if (arrUrl[1] == Constant.YoutubeFilmRewrite && key != null)
                    {
                        key = UnicodeUtility.UnicodeToKoDau(key);
                        key = key.Replace(" ", "+");
                        lnkLast.NavigateUrl = UrlProcess.YoutubeTimKiem(key, totalpage, Constant.YoutubeFilmRewriteSearch);
                        lnkNext.NavigateUrl = UrlProcess.YoutubeTimKiem(key, curpage + 1, Constant.YoutubeFilmRewriteSearch);
                    }
                    else
                    {
                        lnkLast.NavigateUrl = UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(arrUrl[3]), totalpage, arrUrl[5].Replace(".aspx", ""));
                        lnkNext.NavigateUrl = UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(arrUrl[3]), curpage + 1, arrUrl[5].Replace(".aspx", ""));
                    }
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

            string urlGet = Request.RawUrl;
            string[] arrUrl = urlGet.Split('/');
            string url = string.Empty;
            string key = Request.QueryString["key"];

            if (arrUrl[1] == Constant.YoutubeFilmRewrite && key == null)
            {
                url = UrlProcess.YoutubeChuyenMuc(ConvertUtility.ToInt32(e.Item.DataItem), arrUrl[3].Replace(".aspx", ""));
            }
            else if (arrUrl[1] == Constant.YoutubeFilmRewrite && key != null)
            {
                key = UnicodeUtility.UnicodeToKoDau(key);
                key = key.Replace(" ", "+");
                
                url = UrlProcess.YoutubeTimKiem(key,ConvertUtility.ToInt32(e.Item.DataItem), Constant.YoutubeFilmRewriteSearch);
            }
            else
            {
                url = UrlProcess.VideoChuyenMuc(ConvertUtility.ToInt32(arrUrl[3]), ConvertUtility.ToInt32(e.Item.DataItem), arrUrl[5].Replace(".aspx", ""));
            }
           
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
    }

}