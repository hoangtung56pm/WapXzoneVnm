using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hinhnen
{
    public partial class Hot : BasePage
    {
        private int width;
        private string display;
        private string lang;
        protected FileInfo[] files;
        protected void Page_Load(object sender, EventArgs e)
        {

            lang = Request.QueryString["lang"];
            if (string.IsNullOrEmpty(lang))
            {
                Response.Redirect("/HinhNen/Hot.aspx?w=320&lang=1");
            }

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
                var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                litAds.Text = advertisement.GetAds();

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();

                #region TU DONG DK SUB
                
                 if (Session["msisdn"] == null)
                 {
                     int is3g = 0;
                     string msisdn = MobileUtils.GetMSISDN(out is3g);
                     if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                     {
                         Session["telco"] = Constant.T_Vietnamobile;
                         Session["msisdn"] = msisdn;
                     }
                     else
                     {
                         Session["msisdn"] = null;
                         Session["telco"] = Constant.T_Undefined;
                     }
                 }

                 if (Session["msisdn"] != null)
                 {
                     string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0",Session["msisdn"].ToString(), "DK", "DK HNEN");//ANDY Service S2_94x
                     string[] res = value.Split('|');
                     if (res.Length > 0)
                     {
                         if (res[0] == "1")//DK THANH CONG
                         {
                             pnlThongBao.Visible = true;
                         }
                     }
                 }

                #endregion

            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }

            
            Literal title = new Literal();
            try
            {
                DataTable dt = HinhNenController.GetAllWap_HinhNen_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageIdWallpaper")));

                rptItem.DataSource = dt;
                rptItem.ItemDataBound += rptItem_ItemDataBound;
                rptItem.DataBind();

                title.Text = "<style type=\"text/css\">body {font-family:Verdana, Arial, Helvetica; font-size:12px;} .mainmenu {display:block;width: 100%;background-color: #de60cb;color:#fff;text-align:center;line-height:25px;} .mainmenu a{color:#fff;} a:link, a:visited {text-decoration:none;}</style>";
                if (lang == "1")
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chào mừng bạn đến với dịch vụ hình nền  <b style=\"color:blue\">(Miễn Phí)</b> của Vietnamobile" + "</div>";
                }
                else
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chao mung ban den voi dich vu hinh nen  <b style=\"color:blue\">(Mien Phi)</b> cua Vietnamobile" + "</div>";
                }
                plList.Controls.Add(title);

                Literal ltr = new Literal();
                ltr.Text = "<br />";
                plList.Controls.Add(ltr);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        void rptItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkTen = (HyperLink)e.Item.FindControl("lnkTen");

            DataRowView row = (DataRowView)e.Item.DataItem;
            string download = AppEnv.GetSetting("VNMdownload");
            imgAvatar.ImageUrl = "http://media.xzone.vn/" + row["Path"].ToString().Replace("~/", "");
            lnkTen.NavigateUrl = lnkAvatar.NavigateUrl = download + "?type=1&id=" + row["ID"].ToString() + "&code=" + SecurityMethod.MD5Encrypt(row["ID"].ToString());
            if (lang == "1")
            {
                lnkTen.Text = row["Wallpaper_Name"].ToString();
            }
            else
            {
                lnkTen.Text = UnicodeUtility.UnicodeToKoDau(row["Wallpaper_Name"].ToString());
            }
        }

    }
}