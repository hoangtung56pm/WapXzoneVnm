using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class Event_Video : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int catID = 26;
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
                //DataTable catInfo = VideoController.GetCategoryByCatIDHasCache(catID);
                if (lang == 0)
                {
                    ltrTieude.Text = "Khoanh khac Olympic 2012";
                    lnkXemthem.Text = "Xem them » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien_KD + "/video)";
                }
                else
                {
                    ltrTieude.Text = "Khoảnh khắc Olympic 2012";
                    lnkXemthem.Text = "Xem thêm » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien + "/video)";
                }
            }
            lnkXemthem.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang.ToString(), width, catID.ToString());
            if (!string.IsNullOrEmpty(Request.QueryString["c"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["c"]);
            }
            else
            {
                Random rnd = new Random();
                curpage = rnd.Next(1, 4);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache("vietnamobile", catID, -1, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            //Paging1.totalrecord = totalrecord;
            //Paging1.pagesize = pagesize;
            //Paging1.numberpage = pagenumber;
            //Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&e=" + Request.QueryString["e"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"];
            //Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&e=" + Request.QueryString["e"] + "&d=" + Request.QueryString["d"] + "&f=" + Request.QueryString["f"] + "&c=";
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
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                //ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle"].ToString() + "</span>";
                //ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkXem.NavigateUrl = "../View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~", "");
        }        
    }
}