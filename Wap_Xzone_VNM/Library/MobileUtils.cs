using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using log4net;

namespace WapXzone_VNM.Library
{
    public class MobileUtils
    {
        const string regularWindows = @"(windows ce; pcc;|windows ce; smartphone;|windows ce; iemobile;|wm5 pie)";
        const string regularPalm = @"(palm os|palm|hiptop|avantgo|plucker|xiino|blazer|elaine)";
        const string regularOther =
            @"(up.browser|up.link|mmp|symbian|smartphone|midp|wap|vodafone|o2|pocket|kindle|maemo|docomo|sec-sgh|sony|mobile|pda|tablet|sonyericsson|ericsson|linux|com2|mini|psp|treo|webkit|openweb|playstation|xbox|symbianos|series60|palmos|webos|opera|operamobile|dangerhiptop|series70|series80|series90|vnd.rim|blackberry95)";
        const string regularOther2 =
            @"(1207|3gso|4thp|501i|502i|503i|504i|505i|506i|6310|6590|770s|802s|a wa|acer|acs-|airn|alav|asus|attw|au-m|aur |aus |abac|acoo|aiko|alco|alca|amoi|anex|anny|anyw|aptu|arch|argo|bell|bird|bw-n|bw-u|beck|benq|bilb|blac|c55/|cdm-|chtm|capi|comp|cond|craw|dall|dbte|dc-s|dica|ds-d|ds12|dait|devi|dmob|doco|dopo|el49|erk0|esl8|ez40|ez60|ez70|ezos|ezze|elai|emul|eric|ezwa|fake|fly-|fly_|g-mo|g1 u|g560|gf-5|grun|gene|go.w|good|grad|hcit|hd-m|hd-p|hd-t|hei-|hp i|hpip|hs-c|htc |htc-|htca|htcg|htcp|htcs|htct|htc_|haie|hita|huaw|hutc|i-20|i-go|i-ma|i230|iac|iac-|iac/|ig01|im1k|inno|iris|jata|java|kddi|kgt|kgt/|kpt |kwc-|klon|lexi|lg g|lg-a|lg-b|lg-c|lg-d|lg-f|lg-g|lg-k|lg-l|lg-m|lg-o|lg-p|lg-s|lg-t|lg-u|lg-w|lg/k|lg/l|lg/u|lg50|lg54|lge-|lge/|lynx|leno|m1-w|m3ga|m50/|maui|mc01|mc21|mcca|medi|meri|mio8|mioa|mo01|mo02|mode|modo|mot |mot-|mt50|mtp1|mtv |mate|maxo|merc|mits|mobi|motv|mozz|n100|n101|n102|n202|n203|n300|n302|n500|n502|n505|n700|n701|n710|nec-|nem-|newg|neon|netf|noki|nzph|o2 x|o2-x|opwv|owg1|opti|oran|p800|pand|pg-1|pg-2|pg-3|pg-6|pg-8|pg-c|pg13|phil|pn-2|pt-g|palm|pana|pire|pock|pose|psio|qa-a|qc-2|qc-3|qc-5|qc-7|qc07|qc12|qc21|qc32|qc60|qci-|qwap|qtek|r380|r600|raks|rim9|rove|s55/|sage|sams|sc01|sch-|scp-|sdk/|se47|sec-|sec0|sec1|semc|sgh-|shar|sie-|sk-0|sl45|slid|smb3|smt5|sp01|sph-|spv |spv-|sy01|samm|sany|sava|scoo|send|siem|smar|smit|soft|sony|t-mo|t218|t250|t600|t610|t618|tcl-|tdg-|telm|tim-|ts70|tsm-|tsm3|tsm5|tx-9|tagt|talk|teli|topl|tosh|up.b|upg1|utst|v400|v750|veri|vk-v|vk40|vk50|vk52|vk53|vm40|vx98|virg|vite|voda|vulc|w3c |w3c-|wapj|wapp|wapu|wapm|wig |wapi|wapr|wapv|wapy|wapa|waps|wapt|winc|winw|wonu|x700|xda2|xdag|yas-|your|zte-|zeto|acs-|alav|alca|amoi|aste|audi|avan|benq|bird|blac|blaz|brew|brvw|bumb|ccwa|cell|cldc|cmd-|dang|doco|eml2|eric|fetc|hipt|http|ibro|idea|ikom|inno|ipaq|jbro|jemu|java|jigs|kddi|keji|kyoc|kyok|leno|lg-c|lg-d|lg-g|lge-|libw|m-cr|maui|maxo|midp|mits|mmef|mobi|mot-|moto|mwbp|mywa|nec-|newt|nok6|noki|o2im|opwv|palm|pana|pant|pdxg|phil|play|pluc|port|prox|qtek|qwap|rozo|sage|sama|sams|sany|sch-|sec-|send|seri|sgh-|shar|sie-|siem|smal|smar|sony|sph-|symb|t-mo|teli|tim-|tosh|treo|tsm-|upg1|upsi|vk-v|voda|vx52|vx53|vx60|vx61|vx70|vx80|vx81|vx83|vx85|wap-|wapa|wapi|wapp|wapr|webc|whit|winw|wmlb|xda-)";
        const string regulariswml = @"";
        const string regularismobileform = @"(6610|3600)";

        public static string GetMSISDN(out int is3g)
        {
            //phoneno = HttpContext.Current.Request.ServerVariables.Get("HTTP_X_UP_CALLING_LINE_ID");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_MSISDN");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_X_FH_MSISDN");
            //phoneno = HttpContext.Current.Request.ServerVariables["MSISDN"];
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("User-Identity-Forward-msisdn");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_X_MSISDN");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("X-MSISDN");
            //phoneno += HttpContext.Current.Request.Headers.Get("X-WAP-MSISDN");

            string msisdn = HttpContext.Current.Request.Headers.Get("MSISDN");

            if (String.IsNullOrEmpty(msisdn))
            {

                string ipAddress = GetClientIPAddress();
                if (Regex.IsMatch(ipAddress, @"^10\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}$"))
                {
                    is3g = 1;
                    ILog logger = LogManager.GetLogger("File");

                    try
                    {
                        var msidsnService = new MsisdnService.MsisdnService();
                        msisdn = msidsnService.GetVietnamobileMsisdn(ipAddress);

                        logger.Info("--------------------------------------------------");
                        logger.Info(String.Format("REMOTE_ADDR: {0}", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]));
                        logger.Info(String.Format("REMOTE_HOST: {0}", HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]));
                        logger.Info(String.Format("HTTP_HOST: {0}", HttpContext.Current.Request.ServerVariables["HTTP_HOST"]));
                        logger.Info(String.Format("HTTP_X_FORWARDED_HOST: {0}", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_HOST"]));
                        logger.Info(String.Format("HTTP_X_FORWARDED_FOR: {0}", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]));
                        logger.Info("MSISDN: " + msisdn);
                        logger.Info("IP: " + ipAddress);
                        //logger.Info(String.Format("Current Url: {0}", HttpContext.Current.Request.RawUrl));
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        logger.Error(ex.StackTrace);
                    }
                   
                    return msisdn;
                }
                is3g = 2;
                return String.Empty;
            }
            is3g = 0;
            return msisdn;

            //return msisdn == "unknown" ? String.Empty : msisdn;
        }

        public static string GetMSISDN1()
        {

            ILog logger = log4net.LogManager.GetLogger("File");
            logger.Info("msisdn out :" + "Fuck");
            
            //phoneno = HttpContext.Current.Request.ServerVariables.Get("HTTP_X_UP_CALLING_LINE_ID");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_MSISDN");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_X_FH_MSISDN");
            //phoneno = HttpContext.Current.Request.ServerVariables["MSISDN"];
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("User-Identity-Forward-msisdn");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("HTTP_X_MSISDN");
            //phoneno += HttpContext.Current.Request.ServerVariables.Get("X-MSISDN");
            //phoneno += HttpContext.Current.Request.Headers.Get("X-WAP-MSISDN");
            try
            {
                string msisdn = HttpContext.Current.Request.Headers.Get("MSISDN");

                //logger.Info("msisdn out :" + msisdn);

                if (String.IsNullOrEmpty(msisdn))
                {

                    string ipAddress = GetClientIPAddress();

                    logger.Info("ISING-IP :" + ipAddress);

                    //if (System.Text.RegularExpressions.Regex.IsMatch(ipAddress, @"^10\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}$"))
                    //{
                        
                        logger.Info("ISING-msisdn in :" + msisdn);

                        try
                        {
                            WapXzone_VNM.MsisdnService.MsisdnService msidsnService = new WapXzone_VNM.MsisdnService.MsisdnService();
                            msisdn = msidsnService.GetVietnamobileMsisdn(ipAddress);

                            logger.Info(" ");
                            logger.Info(" ");
                            logger.Info("--------------------ISING------------------------------");
                            logger.Info(String.Format("ISING-REMOTE_ADDR: {0}", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]));
                            logger.Info(String.Format("ISING-REMOTE_HOST: {0}", HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]));
                            logger.Info(String.Format("ISING-HTTP_HOST: {0}", HttpContext.Current.Request.ServerVariables["HTTP_HOST"]));
                            logger.Info(String.Format("ISING-HTTP_X_FORWARDED_HOST: {0}", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_HOST"]));
                            logger.Info(String.Format("ISING-HTTP_X_FORWARDED_FOR: {0}", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]));
                            logger.Info("ISING-MSISDN: " + msisdn);
                            logger.Info("ISING-IP: " + ipAddress);
                            //logger.Info(String.Format("Current Url: {0}", HttpContext.Current.Request.RawUrl));
                            logger.Info("--------------------ISING------------------------------");
                            logger.Info(" ");
                            logger.Info(" ");
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex.Message);
                            logger.Error(ex.StackTrace);
                        }
                        logger.Info("ISING-MSISDN111: " + msisdn);
                        return msisdn;
                    //}
                    //else
                    //{
                        
                    //    logger.Info("ISING-msisdn in : is3g = 2");
                    //    return String.Empty;

                    //}
                }
                else
                {
                    
                    logger.Info("ISING-msisdn in : is3g = 0;");
                    return msisdn;

                }
            }
            catch (Exception ex)
            {
                
                logger.Error("Ising.vn" + ex.ToString());
                throw;
            }
            

            //return msisdn == "unknown" ? String.Empty : msisdn;
        }

        private static string GetClientIPAddress()
        {
            string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] ?? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            return ipAddress ?? String.Empty;
        }

        public static bool CheckOperator(string mobile, string _operator)
        {
            if (mobile.Length > 9)
            {
                if (_operator != "evn" && _operator != "sphone")
                {
                    string prenumber = mobile.Substring(0, 5);
                    string[] dfsplit = ConfigurationSettings.AppSettings.Get(_operator).Split('|');
                    foreach (string s in dfsplit)
                    {
                        if (prenumber.IndexOf(s) > -1 && s.Length > 2)
                        {
                            return true;
                            break;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public static bool IsMobileNumber(string mobilenumber)
        {
            string list = ConfigurationSettings.AppSettings.Get("ispremobilenumber");
            bool retval = false;
            if (mobilenumber.Length > 9 && mobilenumber.Length < 12)
            {
                for (int j = 0; j < mobilenumber.Length; j++)
                {
                    char c = mobilenumber[j];
                    if (!(c >= '0' && c <= '9')) return false;
                }

                string[] valid = list.Split(',');
                int index = -1;
                for (int i = 0; i < valid.Length; i++)
                {
                    index = mobilenumber.Substring(0, 5).ToString().IndexOf(valid[i]);
                    if (index >= 0) break;
                }
                if (index >= 0)
                {
                    retval = true;
                }
                else
                {
                    retval = false;
                }
            }
            else
            {
                return retval;
            }
            return retval;
        }

        public static bool IsVINAMobileNumber(string mobilenumber)
        {
            string list = ConfigurationSettings.AppSettings.Get("isVINAmobilenumber");
            string prenumber = string.Empty;
            prenumber = ",0" + mobilenumber.Substring(2, 2) + ",";
            if (list.LastIndexOf(prenumber) != -1) return true;

            prenumber = ",0" + mobilenumber.Substring(2, 3) + ",";
            if (list.LastIndexOf(prenumber) != -1) return true;

            return false;
        }

        public static bool IsMOBIMobileNumber(string mobilenumber)
        {
            string list = ConfigurationSettings.AppSettings.Get("isMOBImobilenumber");
            string prenumber = string.Empty;
            prenumber = ",0" + mobilenumber.Substring(2, 2) + ",";
            if (list.LastIndexOf(prenumber) != -1) return true;

            prenumber = ",0" + mobilenumber.Substring(2, 3) + ",";
            if (list.LastIndexOf(prenumber) != -1) return true;

            return false;
        }

        public static string ToSTDMobileNumber(string mobilenumber)
        {
            if (mobilenumber.Substring(0, 2) == "84")
                return mobilenumber;
            if (mobilenumber.Substring(0, 1) == "0")
                return "84" + mobilenumber.Remove(0, 1);
            if (mobilenumber.Substring(0, 1) == "9" || mobilenumber.Substring(0, 1) == "1")
                return "84" + mobilenumber;
            return mobilenumber;
        }

        public static void WriteLogCharging(string cipher)
        {
            string msisdn = string.Empty;
            string cpid = string.Empty;
            string transaction_oldid = string.Empty;
            string transaction_newid = string.Empty;
            string content_id = string.Empty;
            string content_price = string.Empty;
            string debit_status = string.Empty;
            string plaintext = string.Empty;
            if (!string.IsNullOrEmpty(msisdn))
            {
                string useragent = HttpContext.Current.Request.UserAgent;
                ILog logger = log4net.LogManager.GetLogger("File");
                logger.Info("----------------------------------");
                logger.Info("Cipher: " + cipher);
                logger.Info("URL: " + HttpContext.Current.Request.RawUrl);
                logger.Info("UserAgent: " + useragent);
                logger.Info("MSISDN: " + msisdn);
                logger.Info("CPID: " + cpid + " -- Transaction_oldid: " + transaction_oldid + "-- Transaction_newid: " + transaction_newid);
                logger.Info("Gia: " + content_price + " -- ContentID: " + content_id + "-- Trang thai charg: " + debit_status);
                logger.Info("----------------------------------");
            }
        }

        public static string MobileDeviceDetect(string redirectLink, string other)
        {
            //if (CheckBrowser.isMobile())
            //{
            return MobileDeviceDetect(redirectLink, redirectLink, redirectLink, redirectLink, redirectLink, redirectLink, redirectLink, other);
            //}
            //else
            //{
            //    return "/Warning.htm";
            //}

        }

        public static void GetPaymentDetailUrl(string plaintext, ref string msisdn, ref string transactionid, ref string partnerid)
        {
            try
            {
                if (!string.IsNullOrEmpty(plaintext))
                {
                    string[] arr = plaintext.Split('|');
                    msisdn = arr[0];
                    transactionid = arr[1];
                    partnerid = arr[2];
                }
                else
                {
                    msisdn = string.Empty;
                    transactionid = string.Empty;
                    partnerid = string.Empty;
                }
            }
            catch
            {
                msisdn = string.Empty;
                transactionid = string.Empty;
                partnerid = string.Empty;
            }

        }

        public static void GetDetailAppUrl(string plaintext, ref string partnerid, ref string price, ref string itemid, ref string itemtype, ref string itemdetail)
        {
            try
            {
                if (!string.IsNullOrEmpty(plaintext))
                {
                    string[] arr = plaintext.Split('|');
                    partnerid = arr[0];
                    price = arr[1];
                    itemid = arr[2];
                    itemtype = arr[3];
                    itemdetail = arr[4];
                }
                else
                {
                    partnerid = "0";
                    price = string.Empty;
                    itemid = string.Empty;
                    itemtype = string.Empty;
                    itemdetail = string.Empty;
                }
            }
            catch
            {
                partnerid = "0";
                price = string.Empty;
                itemid = string.Empty;
                itemtype = string.Empty;
                itemdetail = string.Empty;
            }
        }

        public static bool IsIphone(string useragent)
        {
            return useragent.IndexOf("ipod") > -1 || useragent.IndexOf("iphone") > -1;
        }

        public static bool IsAndroid(string useragent)
        {
            return useragent.IndexOf("android") > -1;
        }

        public static bool IsOperaMini(string useragent)
        {
            return useragent.IndexOf("opera mini") > -1 || HttpContext.Current.Request.ServerVariables["ALL_HTTP"].IndexOf("OperaMini") >= 0;
        }

        public static bool IsPalm(string useragent)
        {
            return Regex.IsMatch(useragent, regularPalm, RegexOptions.IgnoreCase);
        }

        public static bool IsBlackBerry(string useragent)
        {
            return useragent.IndexOf("blackberry") > -1;
        }
        public static bool IsMobileBrowser()
        {
            string url = ConfigurationSettings.AppSettings.Get("WapDefault");
            return MobileDeviceDetect(url, url) != "unknown";
        }
        public static bool IsWindowsMobile(string useragent)
        {
            return Regex.IsMatch(useragent, regularWindows, RegexOptions.IgnoreCase);
        }
        public static string MobileDeviceDetect(string iphone, string android, string opera, string blackberry,
                                            string palm, string windows, string urldefault, string other)
        {
            bool mobileBrowser = false;
            string redirectLink = "";

            string useragent = HttpContext.Current.Request.UserAgent;
            string filename = @"C:\Projects\VNMobileWap\" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + ".txt";
            //if (!Directory.Exists(@"C:\Projects\VNMobileWap"))
            //{
            //    Directory.CreateDirectory(filename);
            //}
            string check = useragent;
            if (string.IsNullOrEmpty(useragent)) return "";

            //useragent = "Mozilla/5.0 (SymbianOS/9.2; U; Series60/3.1 Nokia6120c/5.11; Profile/MIDP-2.0 Configuration/CLDC-1.1 ) AppleWebKit/413 (KHTML, like Gecko) Safari/413";// useragent.ToLower();
            useragent = useragent.ToLower();
            string accept = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT"];
            if (IsIphone(useragent))
            {
                mobileBrowser = true;
                if (iphone.IndexOf("http:") > -1)
                {
                    redirectLink = iphone;
                }
            }
            else if (IsAndroid(useragent))
            {
                mobileBrowser = true;
                if (android.IndexOf("http:") > -1)
                {
                    redirectLink = android;
                }
            }
            else if (IsOperaMini(useragent))
            {
                mobileBrowser = true;
                if (opera.IndexOf("http:") > -1)
                {
                    redirectLink = opera;
                }
            }
            else if (IsBlackBerry(useragent))
            {
                mobileBrowser = true;
                if (blackberry.IndexOf("http:") > -1)
                {
                    redirectLink = blackberry;
                }
            }
            else if (IsPalm(useragent))
            {
                mobileBrowser = true;
                if (palm.IndexOf("http:") > -1)
                {
                    redirectLink = palm;
                }
            }
            else if (IsWindowsMobile(useragent))
            {
                mobileBrowser = true;
                if (windows.IndexOf("http:") > -1)
                {
                    redirectLink = windows;
                }
            }
            else if (Regex.IsMatch(useragent, regularismobileform, RegexOptions.IgnoreCase))
            {
                mobileBrowser = true;
                if (other.IndexOf("http:") > -1)
                {
                    redirectLink = other;
                }

            }
            else if (Regex.IsMatch(useragent, regularOther, RegexOptions.IgnoreCase))
            {
                mobileBrowser = true;
                redirectLink = urldefault;
            }
            else if (!string.IsNullOrEmpty(accept) && accept.IndexOf("text/vnd.wap.wml") > -1)
            {
                mobileBrowser = true;
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_WAP_PROFILE"]) ||
                     !string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_PROFILE"]))
            {
                mobileBrowser = true;
            }
            else if (Regex.IsMatch(useragent.Substring(0, 4).ToLower(), regularOther2, RegexOptions.IgnoreCase))
            {
                mobileBrowser = true;
            }
            //WriteLogToFile(check, filename);
            if (mobileBrowser)
                return redirectLink;

            else
                return urldefault;
        }
        public static void WriteLogToFile(string content, string path)
        {
            FileStream fs = null;
            if (!File.Exists(path))
            {
                fs = File.Create(path);
                fs.Dispose();
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(content);
                sw.Write(sw.NewLine);
            }
        }

        public static bool CheckValidModel(string modelsupport, User_AgentInfo _info)
        {
            int check = 0;
            string[] model = _info.model_name.Split(' ');
            for (int i = 0; i < model.Length; i++)
            {
                if (modelsupport.ToLower().IndexOf(model[i].ToLower()) > -1)
                    check++;
            }
            if (check == model.Length)
            {
                return true;
            }
            return false;
        }

    }
}
