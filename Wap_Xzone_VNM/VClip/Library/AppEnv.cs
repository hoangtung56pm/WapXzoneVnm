using System;
using System.Web;
using System.Web.Configuration;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.VClip.Library
{
    public class AppEnv
    {

        public static void GetMsisdnWithParam()
        {
            //use test only
            if (GetSetting("TestFlag") == "1")
            {
                HttpContext.Current.Session["msisdn"] = "841886602010";
                HttpContext.Current.Session["telco"] = Constant.T_Vietnamobile;
            }
            else
            {
                if (HttpContext.Current.Session["msisdn"] == null)
                {
                    HttpContext.Current.Response.Redirect("http://wap.vietnamobile.com.vn/pm/getmsisdnvclip.aspx?t=1");
                }
            }
        }

        public static void GetMsisdn()
        {
            //use test only
            if (GetSetting("TestFlag") == "1")
            {
                HttpContext.Current.Session["msisdn"] = "Khách";
                HttpContext.Current.Session["telco"] = Constant.T_Vietnamobile;
            }
            else
            {
                if (HttpContext.Current.Session["msisdn"] == null)
                {
                    HttpContext.Current.Response.Redirect("http://wap.vietnamobile.com.vn/pm/getmsisdnvclip.aspx");
                }
            }
        }

        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
        
        public static int GetDay()
        {
            int day = ConvertUtility.ToInt32(GetSetting("AddDay"));

            return day;
        }

        public static string ConvertToMb(string skb)
        {
            int kb = ConvertUtility.ToInt32(skb);
            float mb = ((float)kb/1024)/1024;
            string value = String.Format("{0:0.00} ", mb);
            return value;
        }

        public static string GetViewLink(string smartPhone,string mobilePath)
        {
            string viewLink;

            if (!string.IsNullOrEmpty(smartPhone))
                viewLink = smartPhone;
            else
                viewLink = mobilePath;

            if (HttpContext.Current.Request.UserAgent != null)
            {
                if (HttpContext.Current.Request.UserAgent.ToLower().Contains("safari"))
                {
                    return GetSetting("vnmviewIphone") + viewLink.Replace("~/", "/");
                }
                return GetSetting("vnmview") + viewLink.Replace("~/Upload/Video", "");
            }
            return GetSetting("vnmview") + viewLink.Replace("~/Upload/Video", "");
        }

        public static string GetViewLinkLow(string mobilePath)
        {
            return GetSetting("vnmview") + mobilePath.Replace("~/Upload/Video", "");
        }

        public static string TimeRemove(string  input)
        {
            string[] time = input.Split(':');
            if(time.Length > 2)
            {
                string str = time[1] + ":" + time[2];
                return str;
            }
            return input;
        }

        public static string GetAvatar(string avatar, int width, int height)
        {
            if (!string.IsNullOrEmpty(avatar))
            {

                CreateAvatar.MOReceiver ws = new CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(avatar, width, height);

                string urlData = GetSetting("urldata");
                string img = MultimediaUtility.GetAvatarThumnail(avatar, width, height).Replace("~", "");

                return urlData + img;
            }

            return "/Images/icon_app52.png";
        }
    }
}