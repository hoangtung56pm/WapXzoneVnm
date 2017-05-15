using System.Configuration;

namespace WapXzone_VNM.VClip.Library.UrlProcess
{
    public class UrlProcess
    {
        //Trang chu mac dinh
        public static string GetWapHomeUrl(string lang, string width)
        {
            return "/Wap/Default.aspx?lang=" + lang + "&w=" + width;
        }

        public static string GetWapHomeUrlLow(string lang, string width)
        {
            return "/Wap/DefaultLow.aspx?lang=" + lang + "&w=" + width;
        }

        //Trang chu redirect
        public static string GetVNMOtherHomeUrl()
        {
            return "/Wap/Default.aspx";
        }
        public static string GetVNMLienket(string lang, string width, string display)
        {
            return "/Wap/Lienket.aspx?lang=" + lang + "&w=" + width + "&display=" + display;
        }
        

        #region Trang video
        //Trang chu Video
        public static string GetVideoHomeUrl(string lang, string width)
        {
            return "~/VClip/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }


        //Trang chi tiet Video
        public static string GetVideoDetailUrl(string lang, string width, string id)
        {
            return "/VClip/Default.aspx?lang=" + lang + "&display=detail&w=" + width + "&id=" + id;
        }

        //Trang Category Video
        public static string GetVideoCategoryUrl(string lang, string width, string catid)
        {
            return "/VClip/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
        }

        //Trang ket qua tim kiem
        public static string GetVideoSearchResultUrl(string lang, string width, string key)
        {
            return "/VClip/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
        }
    
        //Trang charging của Video

        public static string GetVideoDownloadUrl(string lang, string width, string id)
        {
            return "/VClip/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
        }
             
        public static string GetVideoViewUrl(string lang, string width, string id)
        {
            return "/VClip/View.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
        }
             
        public static string GetVideoSmsUrl(string lang, string width)
        {
            return "/VClip/Sms.aspx?display=sms&lang=" + lang + "&w=" + width;
        }
        
        #endregion

        
        //Trang download
        //public static string GetDownloadItem(string telco, string itemtype, string itemid, string encode)
        //{
        //    //itemtype = 1 : hinh nen
        //    //itemtype = 2 : Nhac chuong
        //    //itemtype = 3: game
        //    return ConfigurationSettings.AppSettings.Get("download") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        //}

        public static string GetGameDownloadItem(string telco, string itemtype, string itemid, string encode)
        {
            //itemtype = 1 : hinh nen
            //itemtype = 2 : Nhac chuong
            //itemtype = 22 : Am nhac
            //itemtype = 3: game
            //itemtype = 4: app
            //itemtype = 5: video
            //itemtype = 6: y kien chuyen gia
            //itemtype = 7: tip
            //itemtype = 8: ket qua cho
            //itemtype = 9: ket qua xo so
            //itemtype = 10: soi cau
            //itemtype = 11: ket qua xoso cho
            //itemtype = 12: ket qua xoso 20 ngay lien tiep
            //itemtype = 13: truyen cuoi
            return ConfigurationSettings.AppSettings.Get("vnmdownloadClip") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        }

    }
}