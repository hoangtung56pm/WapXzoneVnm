using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap
{
    public partial class WallpaperDownloadNew : BasePage
    {
        private int width;
        private string display;
        private string lang;
        protected int Count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = Request.QueryString["lang"];
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                //
                //var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds.Text = advertisement.GetAds();

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();
            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }

            DataTable dt = HinhNenController.GetAllWap_HinhNen_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageIdWallpaper")));
            if(dt.Rows.Count > 0)
            {
                Count = dt.Rows.Count;

                rptHinhNen.DataSource = dt;
                rptHinhNen.ItemDataBound += rptHinhNen_ItemDataBound;
                rptHinhNen.DataBind();
            }
        }

        void rptHinhNen_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");

            DataRowView row = (DataRowView)e.Item.DataItem;

            string download = AppEnv.GetSetting("VNMdownload");
            lnkTenAnh.NavigateUrl = lnkAvatar.NavigateUrl = download + "?type=1&id=" + row["ID"] + "&code=" + SecurityMethod.MD5Encrypt(row["ID"].ToString());
            if (lang == "1")
            {
                lnkTenAnh.Text = row["Wallpaper_Name"].ToString();
            }
            else
            {
                lnkTenAnh.Text = UnicodeUtility.UnicodeToKoDau(row["Wallpaper_Name"].ToString());
            }


            if (e.Item.ItemIndex < Count - 1)
            {
                Literal litBlank = (Literal)e.Item.FindControl("litBlank");
                if(litBlank != null)
                {
                    litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}