using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlNew
{
    public partial class TheLoaiVideo : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private static string preurl;
        private static int totalcat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                width = Request.QueryString["w"];
                DataTable dt = VideoController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Video.Category, 0);
                totalcat = dt.Rows.Count;

                if(dt.Rows.Count > 0)
                {
                    rptTheLoaiVideo.DataSource = dt;
                    rptTheLoaiVideo.ItemDataBound += rptTheLoaiGame_ItemDataBound;
                    rptTheLoaiVideo.DataBind();
                }
            }      
        }

        protected void rptTheLoaiGame_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatLink = (HyperLink)e.Item.FindControl("lnkCatLink");
            if (lnkCatLink != null)
            {
                lnkCatLink.NavigateUrl = UrlProcess.GetVideoCategoryUrlNew(lang, width, curData["W_VCategoryID"].ToString());
                lnkCatLink.CssClass = "link-non-black";
            }
        }
    }
}