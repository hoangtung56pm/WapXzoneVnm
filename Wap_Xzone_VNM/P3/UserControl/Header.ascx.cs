using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.P3.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msisdn = ConvertUtility.ToString(Session["msisdn"]);
            //if (lang == "1")
            //{
                if (string.IsNullOrEmpty(msisdn))
                    ltrXinChao.Text = "Xin chào <span class=\"bold\">khách</span>";
                else ltrXinChao.Text = "Xin chào thuê bao <span class=\"bold\">" + msisdn + "</span>";
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(msisdn))
            //    {
            //        ltrXinChao.Text = "Xin chao <span class=\"bold\">khach</span>";
            //    }
            //    else
            //    {
            //        ltrXinChao.Text = "Xin chao thue bao <span class=\"bold\">" + msisdn + "</span>";
            //    }
            //}
        }
    }
}