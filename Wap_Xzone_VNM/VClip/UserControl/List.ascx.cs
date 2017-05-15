using System;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.VClip.Library;
using WapXzone_VNM.VClip.Library.UrlProcess;

namespace WapXzone_VNM.VClip.UserControl
{
    public partial class List : System.Web.UI.UserControl
    {
        private int pagesize = 8;
        private int pagenumber = 3;
        protected int lang;
        protected string width;
        private int catID;
        private int curpage = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            int totalrecord = 0;

            if (Session["telco"] == null)
                Session["telco"] = Constant.T_Undefined;


            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            DataTable dtCat = null;

            if (!IsPostBack)
            {
                if(catID == 1)
                {
                    lnkCateChannel.Text = "Mới cập nhât";
                    dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 1, 0, (int)Constant.Video.Lastest, pagesize, curpage, out totalrecord);
                }
                else if(catID == 2)
                {
                    lnkCateChannel.Text = "Tải nhiều nhất";
                    dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 3, 0, (int)Constant.Video.Topdownload, pagesize, curpage, out totalrecord);
                }
                else
                {
                    if (catID == 0)
                    {
                        lnkCateChannel.Text = "Mới cập nhât";
                        dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 1, 0, (int)Constant.Video.Lastest, pagesize, curpage, out totalrecord);
                    }
                    else
                    {
                        DataTable catInfo = VideoController.GetCategoryByCatIDHasCache(catID);
                        if (catInfo != null && catInfo.Rows.Count > 0)
                        {
                            lnkCateChannel.Text = catInfo.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        }
                        lnkCateChannel.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang.ToString(), width, catID.ToString());

                        dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, 0, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
                    }
                }

                lnkHomeChannel.NavigateUrl = UrlProcess.GetVideoHomeUrl(lang.ToString(), width);
            }

            //DataTable dtCat = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), catID, 0, (int)Constant.Video.Category, pagesize, curpage, out totalrecord);
            if (dtCat != null && dtCat.Rows.Count > 0)
            {
                rptList.DataSource = dtCat;
                rptList.DataBind();
            }
            
            Paging1.totalrecord = totalrecord;
            Paging1.pagesize = pagesize;
            Paging1.numberpage = pagenumber;
            Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
            Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
            //end category list      
        }
    }
}