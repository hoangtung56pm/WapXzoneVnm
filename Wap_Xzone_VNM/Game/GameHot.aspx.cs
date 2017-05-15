using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game
{
    public partial class GameHot : BasePage
    {
        private int width;
        private string display;
        private string lang;
        protected FileInfo[] files;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            if(string.IsNullOrEmpty(lang))
            {
                Response.Redirect("/Game/GameHot.aspx?w=320&lang=1");
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


                #region TU DONG DK SUB GAME
                
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

                  //string url = UrlProcess.GetGameHomeUrl("1", "320", "0");
                  if (Session["msisdn"] != null)
                  {
                      string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0",
                                                            Session["msisdn"].ToString(), "DK", "DK GAME");//ANDY Service S2_94x
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
            Literal ltrEnd = new Literal();
            Literal ltrEnd1 = new Literal();
            try
            {
                string wapHomeURL = "http://wap.vietnamobile.com.vn";


                DataTable dtMusic = GameController.GetAllGame_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageIdGame")));
                title.Text = "<style type=\"text/css\">body {font-family:Verdana, Arial, Helvetica; font-size:12px;} .mainmenu {display:block;width: 100%;background-color: #de60cb;color:#fff;text-align:center;line-height:25px;} .mainmenu a{color:#fff;} a:link, a:visited {text-decoration:none;}</style>";
                if (lang == "1")
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chào mừng bạn đến với dịch vụ game <b style=\"color:blue\">(Miễn Phí)</b> của Vietnamobile" + "</div>";
                }
                else
                {
                    title.Text += "<div style=\"background-color:#EA6A00;color:#FFFFFF;display:block;line-height:25px;width:100%;margin-top:5px;padding-left:5px;font-weight:bold;\">" + "Chao mung ban den voi dich vu game <b style=\"color:blue\">(Miễn Phí)</b> cua Vietnamobile" + "</div>";
                }
                plList.Controls.Add(title);
                foreach (DataRow row in dtMusic.Rows)
                {
                    HyperLink lnkfile = new HyperLink();
                    if (lang == "1")
                    {
                        lnkfile.Text = row["Name"].ToString();
                    }
                    else
                    {
                        lnkfile.Text = UnicodeUtility.UnicodeToKoDau(row["Name"].ToString());
                    }
                    lnkfile.NavigateUrl = AppEnv.GetSetting("JavaGameDownload") + "?id=" + row["GameID"] + "&type=3" + "&code=" + SecurityMethod.MD5Encrypt(row["GameID"].ToString());
                    lnkfile.Attributes.Add("style", "color:#006CBF;padding-left:15px;padding-top:5px;padding-bottom:5px;display:block");
                    lnkfile.Attributes.Add("class", "bold");
                    plList.Controls.Add(lnkfile);

                }
                //Khuyen mai
                ltrEnd1.Text = "</div><div style=\"border-bottom: 1px solid #790083;height: 7px; margin: 5px 0 10px 0; width: 100%;\"></div>";

                ltrEnd.Text = "</div><div style=\"height: 7px; margin: 5px 0 0px 0; width: 100%;\"></div>";

                ltrEnd.Text += "<div style=\"background-color: #EA6A00;  color: #FFFFFF;  display: block;  line-height: 25px; text-align: center; width: 100%;\">";
                ltrEnd.Text += "<a style=\"color:#fff\" href=\"" + wapHomeURL + "\">Trang chủ</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Game/Default.aspx?lang=1&display=home&hotro=0\">Game</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Music/Default.aspx?lang=1&display=home\">Nhạc</a> | <a style=\"color:#fff\" href=\"" + wapHomeURL + "/Thethao/Default.aspx?lang=1&display=home\">Bóng đá</a></div>";
                plList.Controls.Add(ltrEnd);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

    }
}