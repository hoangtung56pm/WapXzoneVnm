using System;
using System.Web;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class Header : System.Web.UI.UserControl
    {
        private int count;
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = ConvertUtility.ToInt32(Request.QueryString["w"]).ToString();
           
            if (!IsPostBack)
            {
                string msisdn = ConvertUtility.ToString(Session["msisdn"]);
                if (lang == "1")
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chào : <span class=\"pink bold\">khách</span>";
                    else ltrXinChao.Text = "Xin chào thuê bao : <span class=\"pink bold\">" + msisdn + "</span>";
                }
                else
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chao : <span class=\"pink bold\">khach</span>";
                    else ltrXinChao.Text = "Xin chao thue bao : <span class=\"pink bold\">" + msisdn + "</span>";
                }

                string gameUrl = UrlProcess.GetGameHomeUrlNew(lang, width, "0");
                string musicUrl = UrlProcess.GetMusicHomeUrlNew(lang, width);
                string clipUrl = UrlProcess.GetVideoHomeUrlNew(lang, width);

                string rawUrl = HttpContext.Current.Request.RawUrl;

                if(rawUrl.Contains("/Game/"))
                {
                    litGame.Text = "<a style=\"text-decoration: none;color:#FF8000; font-weight:bold;\" href=\" " + gameUrl + " \">Game</a>";
                }
                else
                {
                    litGame.Text = "<a style=\"text-decoration: none;color:Black;\" href=\" " + gameUrl + " \">Game</a>";
                }

                if (rawUrl.Contains("/Video/"))
                {
                    litClip.Text = "<a style=\"text-decoration: none;color:#FF8000; font-weight:bold;\" href=\"" + clipUrl + "\">Clip</a>";
                }
                else
                {
                    litClip.Text = "<a style=\"text-decoration: none;color:Black;\" href=\"" + clipUrl + "\">Clip</a>";
                }

                if (rawUrl.Contains("/Music/"))
                {
                    litMusic.Text = "<a style=\"text-decoration: none;color:#FF8000; font-weight:bold;\" href=\"" + musicUrl + "\"> Music </a>";
                }
                else
                {
                    litMusic.Text = "<a style=\"text-decoration: none;color:Black;\" href=\"" + musicUrl + "\"> Music </a>";
                }
            }
        }
    }
}