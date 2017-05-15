using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen.UserControlNew
{
    public partial class List : System.Web.UI.UserControl
    {

        private int pagesize = 6;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
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
                    litGia.Text = "(Giá: " + AppEnv.GetSetting("wallprice") + " đ/hình nền)";
                    lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    lnkHomeChannel.Text = "HÌNH NỀN";
                }
                else
                {
                    litGia.Text = "(Gia: " + AppEnv.GetSetting("wallprice") + " d/hinh nen)";
                    lnkCateChannel.Text = catInfo.Rows[0]["Title"].ToString().ToUpper();
                }
                    
                lnkCateChannel.NavigateUrl = UrlProcess.GetWallpaperCategoryUrlNew(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetWallpaperHomeUrlNew(lang.ToString(), width);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = HinhNenController.GetAllWallpaperByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, (int)Constant.HinhNen.Category, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
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

            if(e.Item.ItemIndex < pagesize - 1)
            {
                Literal litBlank = (Literal)e.Item.FindControl("litBlank");
                litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
            }

            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            if (lang == 1)
            {
                lnkTenAnh.Text = curData["WTitle_Unicode"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"];
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai;
            }
            else
            {
                lnkTenAnh.Text = curData["WTitle"].ToString();
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"];
                lnkTai.Text = Resources.Resource.wTai_KD;
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetWallpaperDetailUrlNew(lang.ToString(), "detail", width, curData["W_WItemID"].ToString()) + "&catid=" + curData["W_CategoryID"].ToString();
            lnkTai.NavigateUrl = UrlProcess.GetWallpaperDownloadUrlNew(lang.ToString(), width, curData["W_WItemID"].ToString(), curData["W_CategoryID"].ToString());
            if (curData["WThumnail"].ToString().LastIndexOf(".gif") > 0)
            {
                WapXzone_VNM.CreateGIFAvatar.Ws_Process ws = new WapXzone_VNM.CreateGIFAvatar.Ws_Process();
                imgAvatar.ImageUrl = preurl + ws.GetAvatarGif(curData["WThumnail"].ToString().Replace("~", "").Replace("thumb_", ""), 82, 66);
            }
            else
            {
                WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(curData["WThumnail"].ToString(), 82, 66);
                imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["WThumnail"].ToString(), 82, 66).Replace("~", "");
            }
        }        

    }
}