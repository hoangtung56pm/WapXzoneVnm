using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music
{
    public partial class NhacHot : BasePage
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
                Response.Redirect("/Music/NhacHot.aspx?w=320&lang=1");
            }

            Session["LastPage"] = Request.RawUrl;
            
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                //
                var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                litAds.Text = advertisement.GetAds();

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();

                #region TU DONG DK SUB NHACCHUONG

                if (!Page.IsPostBack)
                {
                    if (Session["msisdn"] == null)
                    {
                        int is3g;
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

                    //string url = UrlProcess.GetMusicHomeUrl("1", "320");
                    if (Session["msisdn"] != null)
                    {
                        string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0",Session["msisdn"].ToString(), "DK", "DK NC");//ANDY Service S2_94x
                        string[] res = value.Split('|');
                        if (res.Length > 0)
                        {
                            if (res[0] == "1")//DK THANH CONG
                            {
                                pnlThongBao.Visible = true;
                            }
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

            //string telCo = "Vietnamobile";
            //string id = Request.QueryString["id"];

            Literal title = new Literal();
            Literal ltrEnd = new Literal();
            Literal ltrEnd1 = new Literal();
            try
            {
                //string wapHomeURL = "http://wap.vietnamobile.com.vn";


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
                        lnkfile.NavigateUrl = "http://media.xzone.vn/" + ringtonepath.Replace("~/", "");
                        lnkfile.Attributes.Add("style", "color:#006CBF;padding-left:15px;padding-top:3px;padding-bottom:3px;display:block");
                        lnkfile.Attributes.Add("class", "bold");
                        plList.Controls.Add(ltr);
                        plList.Controls.Add(lnkfile);
                        ltr = new Literal();
                        ltr.Text = "<div class=\"clearfix\"></div>";
                        plList.Controls.Add(ltr);
                    }
                }

                ltrEnd1.Text = "</div><div style=\"height: 7px; margin: 5px 0 0px 0; width: 100%;\"></div>";

                ltrEnd.Text += "<div style=\"background-color: #EA6A00;  color: #FFFFFF;  display: block;  line-height: 25px; text-align: center; width: 100%;\">";
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