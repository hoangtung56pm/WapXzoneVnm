using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.HoangDao;

namespace WapXzone_VNM.Hoangdao.UserControl
{
    public partial class Boivui_Boqua : System.Web.UI.UserControl
    {
        private string width;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {                          
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];            
            if (lang == "1")
            {                                    
            }
            else
            {
                ltrTieude.Text = "BO QUA BOI VUI";
                ltrHuongdan.Text = "• Bấm về trang chủ để sử dụng dịch vụ khác<br />• Bấm Bỏ qua để rời khỏi mục Bói vui";
                lnkTrangchu.Text = "TRANG CHU";
                btnBoqua.Text = "BO QUA";
            }
            lnkTrangchu.NavigateUrl = UrlProcess.GetWapHomeUrl(lang, width);
        }

        protected void btnBoqua_Click(object sender, EventArgs e)
        {         
            HttpCookie cookie_boivui = new HttpCookie("boivuiboqua","1");            
            cookie_boivui.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie_boivui);
            Response.Redirect(UrlProcess.GetWapHomeUrl(lang, width));
        }
    }
}