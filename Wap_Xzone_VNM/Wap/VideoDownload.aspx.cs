using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WapXzone_VNM.Library;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Nhacchuong;
using VmgPortal.Modules.Adsvertising.Lib.DataAccess;
using WapXzone_VNM.Library.Constant;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library.Component.HinhNen;
using WapXzone_VNM.Library.Component.Video;
using AppEnv = WapXzone_VNM.Library.AppEnv;

namespace WapXzone_VNM.Wap
{
    public partial class VideoDownload : BasePage
    {
        private int width;
        private string display;
        private string lang;   
        protected FileInfo[] files;
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
                var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                litAds.Text = advertisement.GetAds();

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

            string telCo = "Vietnamobile";
            string id = Request.QueryString["id"];
            
            Literal title = new Literal();
            Literal ltrEnd = new Literal();
            Literal ltrEnd1 = new Literal();
            try
            {
                string wapHomeURL = "http://wap.vietnamobile.com.vn";


                DataTable dt = VideoController.GetAllWap_Video_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageIdVideo")));
                title.Text = "<style type=\"text/css\">body {font-family:Verdana, Arial, Helvetica; font-size:12px;} .mainmenu {display:block;width: 100%;background-color: #de60cb;color:#fff;text-align:center;line-height:25px;} .mainmenu a{color:#fff;} a:link, a:visited {text-decoration:none;}</style>";
                if (lang == "1")
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chào mừng bạn đến với dịch vụ Video  <b style=\"color:blue\">(Miễn Phí)</b> của Vietnamobile" + "</div>";
                }
                else 
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chao mung ban den voi dich vu Video  <b style=\"color:blue\">(Mien Phi)</b> cua Vietnamobile" + "</div>";
                }
                plList.Controls.Add(title);

                Literal ltr = new Literal();
                ltr.Text = "<br />";
                plList.Controls.Add(ltr);

                rptItem.DataSource = dt;
                rptItem.ItemDataBound += new RepeaterItemEventHandler(rptItem_ItemDataBound);
                rptItem.DataBind();

                //foreach (DataRow row in dtMusic.Rows)
                //{
                //    string ringtonepath = row["Path"].ToString();
                //    if (!string.IsNullOrEmpty(ringtonepath))
                //    {
                //        HyperLink lnkfile = new HyperLink();
                //       Image img = new Image();
                                            
                //        if (lang == "1")
                //        {
                //            lnkfile.Text = row["Video_Name"].ToString();
                //        }
                //        else
                //        {
                //            lnkfile.Text = UnicodeUtility.UnicodeToKoDau(row["Video_Name"].ToString());
                //        }
                //        string download = AppEnv.GetSetting("downloadVideo");
                //        img.ImageUrl = "http://media.xzone.vn/" + row["Avatar"].ToString().Replace("~/", "");
                //        //img.Width = 60;
                //        img.Attributes.Add("style", "width:60px;padding-left:15px;");
                //        lnkfile.NavigateUrl = "http://media.xzone.vn/" + row["Path"].ToString().Replace("~/", "");
                //        lnkfile.Attributes.Add("style", "color:#006CBF;padding-left:15px;padding-top:3px;padding-bottom:3px;display:block");
                //        lnkfile.Attributes.Add("class", "bold");
                //        plList.Controls.Add(img);
                //        plList.Controls.Add(lnkfile);
                //        ltr = new Literal();
                //        ltr.Text = "<div class=\"clearfix\"></div>";
                //        plList.Controls.Add(ltr);
                //    }
                //}
                ////Khuyen mai
                //ltrEnd1.Text = "</div><div style=\"height: 7px; margin: 5px 0 0px 0; width: 100%;\"></div>";
               
                //ltrEnd.Text += "<div style=\"background-color: #EA6A00;  color: #FFFFFF;  display: block;  line-height: 25px; text-align: center; width: 100%;\">";
                //plList.Controls.Add(ltrEnd);
                //plList.Controls.Add(ltrEnd1);
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
            imgAvatar.ImageUrl = "http://media.xzone.vn/" + row["Avatar"].ToString().Replace("~/", "");
            lnkTen.NavigateUrl = lnkAvatar.NavigateUrl = "http://media.xzone.vn/" + row["Path"].ToString().Replace("~/", "");
            if (lang == "1")
            {
                lnkTen.Text = row["Video_Name"].ToString();
            }
            else
            {
                lnkTen.Text = UnicodeUtility.UnicodeToKoDau(row["Video_Name"].ToString());
            }
        }
    }
}
