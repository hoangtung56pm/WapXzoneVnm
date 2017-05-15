﻿using System;
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
using AppEnv = WapXzone_VNM.Library.AppEnv;

namespace WapXzone_VNM.Wap
{
    public partial class Download : BasePage
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


                DataTable dtMusic = RTController.GetAllWap_RingTone_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageId")));
                title.Text = "<style type=\"text/css\">body {font-family:Verdana, Arial, Helvetica; font-size:12px;} .mainmenu {display:block;width: 100%;background-color: #de60cb;color:#fff;text-align:center;line-height:25px;} .mainmenu a{color:#fff;} a:link, a:visited {text-decoration:none;}</style>";
                if (lang == "1")
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chào mừng bạn đến với dịch vụ nhạc chuông  <b style=\"color:blue\">(Miễn Phí)</b> của Vietnamobile" + "</div>";
                }
                else 
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chao mung ban den voi dich vu nhac chuong  <b style=\"color:blue\">(Mien Phi)</b> cua Vietnamobile" + "</div>";
                }
                //title.Text += "<div style=\"padding-left:5px;margin:5px 0 5px 0;\">Click để tải:";
                plList.Controls.Add(title);

                Literal ltr = new Literal();
                ltr.Text = "<br />";
                plList.Controls.Add(ltr);
                foreach (DataRow row in dtMusic.Rows)
                {
                    string ringtonepath = row["Path"].ToString();
                    if (!string.IsNullOrEmpty(ringtonepath))
                    {
                        HyperLink lnkfile = new HyperLink();
                        ltr = new Literal();
                        ltr.Text = "<img style=\"padding-left:10px\"  class=\"thumblist\" alt=\"thumb\" src=\"../img/b-ring.gif\">";
                        if (lang == "1")
                        {
                            lnkfile.Text = row["SongName"].ToString();
                        }
                        else 
                        {
                            lnkfile.Text = UnicodeUtility.UnicodeToKoDau(row["SongName"].ToString());
                        }
                        string ext = ringtonepath.Split('.')[ringtonepath.Split('.').Length - 1];
                        lnkfile.NavigateUrl =  "http://media.xzone.vn/" + ringtonepath.Replace("~/", "") ;
                        lnkfile.Attributes.Add("style", "color:#006CBF;padding-left:15px;padding-top:3px;padding-bottom:3px;display:block");
                        lnkfile.Attributes.Add("class", "bold");
                        plList.Controls.Add(ltr);
                        plList.Controls.Add(lnkfile);
                        ltr = new Literal();
                        ltr.Text = "<div class=\"clearfix\"></div>";
                        plList.Controls.Add(ltr);
                    }
                }
                //Khuyen mai
                //ltrEnd1.Text = "</div><div style=\"border-bottom: 1px solid #790083;height: 7px; margin: 5px 0 10px 0; width: 100%;\"></div>";
                
                ltrEnd1.Text = "</div><div style=\"height: 7px; margin: 5px 0 0px 0; width: 100%;\"></div>";
               
                ltrEnd.Text += "<div style=\"background-color: #EA6A00;  color: #FFFFFF;  display: block;  line-height: 25px; text-align: center; width: 100%;\">";
                //ltrEnd.Text += "<a style=\"color:#fff\" href=\"" + wapHomeURL + "\">Trang chủ</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Game/Default.aspx?lang=1&display=home&hotro=0\">Game</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Music/Default.aspx?lang=1&display=home\">Nhạc</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Thethao/Default.aspx?lang=1&display=home\">Bóng đá</a></div>";
                plList.Controls.Add(ltrEnd);
                plList.Controls.Add(ltrEnd1);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
