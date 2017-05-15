using System;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class FooterTinTuc247 : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string strTrangchu = string.Empty;
            if (Request.QueryString["lang"] == "1")
            {
                lnkNgonNgu.NavigateUrl = MiscUtility.UpdateQueryStringItem(Request, "lang", "0");
                strTrangchu = "Trang chủ ";
                lnkNgonNgu.Text = "Không dấu";
            }
            else
            {
                lnkNgonNgu.NavigateUrl = MiscUtility.UpdateQueryStringItem(Request, "lang", "1");// Request.RawUrl.Replace("lang=0", "lang=1");
                lnkDauTrang.Text = "Dau trang";
                lnkNgonNgu.Text = "Co dau";
                //ltrHoTro.Text = "Ho tro: 19001255";
                //ltrBanquyen.Text = "Ban quyen Vietnamobile";
                strTrangchu = "Trang chu ";
            }

            string lang = Request.QueryString["lang"];
            string width = Request.QueryString["w"];
            //lnkWap3g.NavigateUrl = UrlProcess.GetWapHomeUrlNew(lang, width);

            lnkDauTrang.NavigateUrl = Request.RawUrl + "#";
        }
    }
}