using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {   
                if (lang == 1)
                {
                    ltrTenChuyenMuc.Text = "KẾT QUẢ TÌM KIẾM";
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start result list
            int totalrecord = 0;
            DataTable dtCat = VideoController.GetAllWap_Video_ItemByKey(Session["telco"].ToString(), Request.QueryString["key"], pagesize, curpage, out totalrecord);
            rptResult.DataSource = dtCat;
            rptResult.ItemDataBound += new RepeaterItemEventHandler(rptlstResult_ItemDataBound);
            rptResult.DataBind();
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&key=" + Request.QueryString["key"] + "&cpage=";
            if (totalrecord == 0) Paging1.Visible = false;
            if (lang == 1)
            {
                ltrCount.Text = "Tìm thấy " + totalrecord + " video clip";
            }
            else {
                ltrCount.Text = "Tim thay " + totalrecord + " video clip";
            }
            //end result list
        }
        protected void rptlstResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            lnkXem.NavigateUrl = "../View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~", "");
        }   
    }
}