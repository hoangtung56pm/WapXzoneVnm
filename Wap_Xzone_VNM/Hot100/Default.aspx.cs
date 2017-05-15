using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Transaction;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;
using MobileWap.Library;
using MobileWap.Library.IPNumbers;

namespace WapXzone_VNM.Hot100
{
    public partial class Default : BasePage
    {
        private int width;
        private int lang;
        private string vnmnumber = string.Empty;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }               
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 0)
                {
                    ltrHoTro.Text = "Ho tro: 19001255";
                    lnkDautrang.Text = "Dau trang <img src=\"img/dautrang.jpg\" style=\"border:0px\" />";
                }
            }

            plContent.Controls.Add(LoadControl("UserControl/List.ascx"));

            //vnmnumber = MobileUtils.GetMSISDN();

            //if (!string.IsNullOrEmpty(vnmnumber) && MobileUtils.CheckOperator(vnmnumber, "vietnammobile"))
            //{
            //    if (!WapController.W4A_Subscriber_IsActive(vnmnumber, 3))//3 là Hot 100
            //    {
            //        plThongbao.Controls.Add(LoadControl("UserControl/Thongbao.ascx"));
            //    }
            //}
            //else plThongbao.Controls.Add(LoadControl("UserControl/Thongbao.ascx"));

            IPList iplist = new IPList();
            iplist.Add("202.172.4.192", 26);
            iplist.Add("203.170.26.0", 24);
            iplist.Add("203.170.27.0", 24);
            iplist.Add("203.128.247.24", 30);
            iplist.Add("203.162.40.20", 30);

            if (!iplist.CheckNumber(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"])) plThongbao.Controls.Add(LoadControl("UserControl/Thongbao.ascx"));
        }
    }
}
