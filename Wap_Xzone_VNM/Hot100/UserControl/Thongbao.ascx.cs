using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;
using MobileWap.Library;

namespace WapXzone_VNM.Hot100.UserControl
{
    public partial class Thongbao : System.Web.UI.UserControl
    {        
        private string lang;
        private string width;
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            width = Request.QueryString["w"];            
            lang = Request.QueryString["lang"];

            int is3g = 0;
            //string msisdn = MobileUtils.GetMSISDN(out is3g);

            string vnmnumber = MobileUtils.GetMSISDN(out is3g);
            if (string.IsNullOrEmpty(vnmnumber) || !MobileUtils.CheckOperator(vnmnumber, "vietnammobile"))
            {
                if (lang == "1")
                    lblThongbao.Text = "Nếu bạn là thuê bao mạng Vietnamobile hãy chọn kết nối GPRS bằng <font color=\"red\">APN \"VM WAP\"</font><br>(Không nên chọn kết nối bằng APN \"Internet\" vì sẽ khó khăn trong việc sử dụng dịch vụ).";
                else
                    lblThongbao.Text = "Neu ban la thue bao mang Vietnamobile hay cho ket noi GPRS bang <font color=\"red\">APN \"VM WAP\"</font><br>(Khong nen chon ket noi bang APN \"Internet\" vi se kho khan trong viec su dung dich vu).";
            }
            else
            { 
              if (lang == "1")
                  lblThongbao.Text = "Dịch vụ này chỉ áp dụng cho khách hàng là thuê bao của Vietnamobile. Nếu bạn là khách hàng của Vietnamobile, hãy đăng ký bằng cách soạn nhắn DK HD gửi đến 123. Hotline: 123 hoặc 789.";
                else
                  lblThongbao.Text = "Dich vu nay chi ap dung cho khach hang la thue bao cua Vietnamobile. Neu ban la khach hang cua Vietnamobile, hay dang ky bang cach soan tin nhan: DK HD gui den 123. Hotline: 123 hoac 789.";
              
            }
            
            log4net.ILog logger = log4net.LogManager.GetLogger("File");
            logger.Info("-----------------------------------");
            logger.Info("Dich vu: Hot 100");
            logger.Info("MSISDN: " + vnmnumber + " - IP Address: " + HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            logger.Info("-----------------------------------");

            //if (!string.IsNullOrEmpty(vnmnumber) && MobileUtils.CheckOperator(vnmnumber, "vietnammobile"))
            //{
            //    if (lang == "1")
            //        lblThongbao.Text = "Bạn đã hết thời hạn truy cập!<br>Soạn tin <font color=\"red\">DK NC</font> gửi <font color=\"red\">123</font> để tiếp tục sử dụng dịch vụ";
            //    else
            //        lblThongbao.Text = "Ban da het thoi han truy cap!<br>Soan tin <font color=\"red\">DK NC</font> gui <font color=\"red\">123</font> de tiep tuc su dung dich vu";
            //}
            //else
            //{
            //    if (lang == "1")
            //        lblThongbao.Text = "Nếu bạn là thuê bao mạng Vietnamobile hãy chọn kết nối GPRS bằng <font color=\"red\">APN \"VM WAP\"</font><br>(Không nên chọn kết nối bằng APN \"Internet\" vì sẽ khó khăn trong việc sử dụng dịch vụ).";
            //    else
            //        lblThongbao.Text = "Neu ban la thue bao mang Vietnamobile hay cho ket noi GPRS bang <font color=\"red\">APN \"VM WAP\"</font><br>(Khong nen chon ket noi bang APN \"Internet\" vi se kho khan trong viec su dung dich vu).";
            //}
        }        
    }
}