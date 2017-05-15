using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Xml.XPath;
using HtmlAgilityPack;
using WapJavaGame.Library.Utilities;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.VNMCharging;
using WapXzone_VNM.PM;
using log4net;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.SQLHelper;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.S2VNM;
using WapXzone_VNM.WsDvTet;
using WapXzone_VNM.VMgame;
using WapXzone_VNM.POD;
using WapXzone_VNM.RingTone;
using System.Data.SqlClient;

namespace WapXzone_VNM.Library
{
    public class AppEnv
    {
        static readonly S2Vnm S2Vnm = new S2Vnm();

        public static string GetConnectionString(string name)
        {
            return WebConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        #region DANG KY DK1

        public static string Dk1RegisterService(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
            if (ConvertUtility.ToInt32(GetSetting("TestFlag")) == 1)
            {
                return "1";
            }

            string reString = S2Vnm.SyncSubWapVnmData(shortCode, requestId, msisdn, commandcode, message);
            string[] res = reString.Split('|');
            if (res.Length > 0)
            {
                if (res[0] == "1")
                {
                    return "1"; //DK1 THANH CONG
                }
            }
            return "0";//DK1 THAT BAI
        }

        public static DataTable GetExistUser(string userId, string subCode)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_S2_Registered_Users_CheckExist", userId,subCode);
            if (ds != null)
            {
                return ds.Tables[0];
            }

            return null;
        }

        public static void InsertVnmRegisterUser(VnmS2RegisterUserInfo entity)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_S2_Registered_Users_Insert",
                entity.UserId,
                entity.RequestId,
                entity.ServiceId,
                entity.CommandCode,
                entity.SubCode,
                entity.Operator,
                entity.RegisteredChannel,
                entity.Status);
        }


        #endregion

        #region Chum DV TET
        
        public static string DangKyDinhVuTet(string msisdn,string message,string commandCode)
        {
            message = UnicodeUtility.UnicodeToKoDau(message);
            var logger = LogManager.GetLogger("File");
            string reString = "";
            try
            {
                var dvTet = new S2Vnm1119Service();

                string requestId = SecurityMethod.RandomStringNumber(7);

                //log charging     

               
                logger.Debug(" ");
                logger.Debug(" ");

                logger.Debug("-------------------- DK DV TET ------------------------------");
                logger.Debug("MSISDN : " + msisdn);
                logger.Debug("Message : " + message);
                logger.Debug("CommandCode : " + commandCode);
                logger.Debug("RequestId : " + requestId);

                logger.Debug(" ");
                logger.Debug(" ");

                //end log

                reString = dvTet.SubscribeFromWap(commandCode, "1119", msisdn, message, requestId);
                string[] arr = reString.Split('|');
                string strReturn = reString;

                if (arr.Length > 0)
                {
                    strReturn = arr[0];
                }

                logger.Debug(" ");
                logger.Debug(" ");
                logger.Debug("-------------------- DK DV TET KETQUA------------------------------");
                logger.Debug("Result : " + strReturn);
                logger.Debug(" ");
                logger.Debug(" ");

                return strReturn;
            }
            catch (Exception ex)
            {
                logger.Debug("-------------------- DK DV TET Error------------------------------");
                logger.Debug("Exception : " + ex.Message);
            }

            return reString;
        }

        public static string DangKyVmGame(string msisdn)
        {
            var logger = LogManager.GetLogger("File");
            string reString = "";
            //try
            //{
            //    var vmGame = new Service_RegisS2();
            //    DateTime ResponseTime = Get_Time_MTTraCham();
            //    //DateTime ResponseTime =new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 45, 0);
            //    string value = vmGame.RegisterS2New(msisdn, ResponseTime);

            //    logger.Debug(" ");
            //    logger.Debug(" ");
            //    logger.Debug("-------------------- DK DV VMgame------------------------------");
            //    logger.Debug("Msisdn registered VmGame : " + msisdn);
            //    logger.Debug("Result VmGame : " + value);
            //    logger.Debug(" ");
            //    logger.Debug(" ");

            //    return value;
            //}
            //catch (Exception ex)
            //{
            //    logger.Debug("-------------------- DK DV VMgame Error------------------------------");
            //    logger.Debug("Exception : " + ex.Message);
            //}

            return reString; 
        }

        public static string DangKyPod(string msisdn)
        {
            var logger = LogManager.GetLogger("File");
            string reString = "";
            try
            {
                var podRegis = new S2Process();

                string requestId = SecurityMethod.RandomStringNumber(10);
                string value = podRegis.Register(msisdn, requestId, "Wap_VNM", "1", "WAP");

                logger.Debug(" ");
                logger.Debug(" ");
                logger.Debug("-------------------- DK DV POD------------------------------");
                logger.Debug("Msisdn registered POD : " + msisdn);
                logger.Debug("Result POD : " + value);
                logger.Debug(" ");
                logger.Debug(" ");

                return value;
            }
            catch (Exception ex)
            {
                logger.Debug("-------------------- DK DV POD Error------------------------------");
                logger.Debug("Exception : " + ex.Message);
            }

            return reString;
        }

        #endregion

        public static string VnmChargingSystemOverload(string msisdn, string productId, string productKey, string serviceId, string serviceState, string cnttype, string path)
        {
            var charging = new VNMCharging.VNMChargingGW();

            string msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, serviceId, serviceState, cnttype, path);//LAN 1
            if (msgReturn == GetSetting("SystemOverload"))
            {
                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, serviceId, serviceState, cnttype, path); //LAN 2
            }

            return msgReturn;
        }

        public static string VnmChargingOptimizeNotEnoughMoney(string msisdn, string productId, string productKey, string serviceId, string serviceState, string cnttype, string path, out string price)
        {
            string msgReturn = GetSetting("NotEnoughMoney");
            var charging = new VNMCharging.VNMChargingGW();

            price = serviceId;

            if(serviceId == "15000")
            {
                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "10000", serviceState, cnttype, path);
                price = "10000";

                if (msgReturn == GetSetting("NotEnoughMoney"))
                {
                    msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "5000", serviceState, cnttype, path);
                    price = "5000";

                    if (msgReturn == GetSetting("NotEnoughMoney"))
                    {
                        msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "3000", serviceState, cnttype, path);
                        price = "3000";

                        if (msgReturn == GetSetting("NotEnoughMoney"))
                        {
                            msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "2000", serviceState, cnttype, path);
                            price = "2000";

                            if (msgReturn == GetSetting("NotEnoughMoney"))
                            {
                                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "1000", serviceState, cnttype, path);
                                price = "1000";
                            }
                        }
                    }
                }
            }
            else if(serviceId == "5000")
            {
                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "3000", serviceState, cnttype, path);
                price = "3000";

                if (msgReturn == GetSetting("NotEnoughMoney"))
                {
                    msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "2000", serviceState, cnttype, path);
                    price = "2000";

                    if (msgReturn == GetSetting("NotEnoughMoney"))
                    {
                        msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "1000", serviceState, cnttype, path);
                        price = "1000";
                    }
                }
            }
            else if(serviceId == "3000")
            {
                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "2000", serviceState, cnttype, path);
                price = "2000";

                if (msgReturn == GetSetting("NotEnoughMoney"))
                {
                    msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "1000", serviceState, cnttype, path);
                    price = "1000";
                }
            }
            else if(serviceId == "2000")
            {
                msgReturn = charging.NavigatePaymentVnm(msisdn, productId, productKey, "1000", serviceState, cnttype, path);
                price = "1000";
            }

            return msgReturn;
        }

        public static bool isMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
                context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                    "NEC", "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone","lumia","windows phone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].
                                                        ToLower().Contains(s.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string CheckRegistration(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
            if (GetSetting("TestFlag") == "1")
            {
                return "1|ThanhCong";
            }

            string reString = S2Vnm.CheckRegistration(shortCode, requestId, msisdn, commandcode, message);

            return reString;
        }

        public static string RegisterService(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
            //Sửa bỏi Bình Trần - 25/11/2016 
            //if (GetSetting("TestFlag") == "1")
            //{
            //    return "1|ThanhCong";
            //    //return "0|DoubleRegister";
            //    //return "-1|SystaxError";
            //}
            string reString = "";
            if (GetSetting("trachamMT") == "0")
            {
                reString = S2Vnm.RegisterServiceTrachamMT(shortCode, requestId, msisdn, commandcode, message);
            }
            else
            {
                reString = S2Vnm.RegisterService(shortCode, requestId, msisdn, commandcode, message);
            }

            return reString;
        }


        public static string RegisterService1119(string shortCode, string requestId, string msisdn, string commandcode, string message)
        {
            return "";
            //WsDvTet.S2Vnm1119Service sv = new WsDvTet.S2Vnm1119Service();
            //string reString = sv.SubscribeFromWap(commandcode, shortCode, msisdn, message, requestId);

            //return reString;
        }

        public static string GetRegionName(string regionCode)
        {
            string str = string.Empty;

            if (regionCode == "TD")
                str = "Thủ Đô";
            else if (regionCode == "DBB")
                str = "Đông Bắc Bộ";
            else if (regionCode == "TBB")
                str = "Tây Bắc Bộ";
            else if (regionCode == "BTB")
                str = "Bắc Trung Bộ";
            else if (regionCode == "NTB")
                str = "Nam Trung Bộ";
            else if (regionCode == "TN")
                str = "Tây Nguyên";
            else if (regionCode == "NB")
                str = "Nam Bộ";


            return str;
        }

        public static string GetRegisterService(string msisdn,string s2Dk)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                return "0";
            }
            //Sửa bởi Bình Trần - 25/11/2016  
            //S2Vnm s2Vnm = new S2Vnm();
            //string[] array = s2Vnm.GetRegisteredServices(msisdn);

            //string str = "0";

            //if(array.Length > 0)
            //{
            //    foreach (var item in array)
            //    {
            //        if(item == s2Dk)
            //        {
            //            str = "1";
            //        }
            //    }
            //}

            //return str;
            return "0";
        }

        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        public static string CheckLang(string input)
        {
            int lang = ConvertUtility.ToInt32(HttpContext.Current.Request.QueryString["lang"]);
            if (lang != 1)
            {
                input = UnicodeUtility.UnicodeToKoDau(input);
            }

            return input;
        }

        public static string GetAvatar(string avatar,int width,int height)
        {
            if(!string.IsNullOrEmpty(avatar))
            {
                avatar = avatar.Replace(GetSetting("urldata"), "");

                var ws = new CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(avatar, width, height);

                string urlData = GetSetting("urldata");
                string img = MultimediaUtility.GetAvatarThumnail(avatar, width, height).Replace("~", "");

                return urlData + img;
            }

            return "/Images/icon_app52.png";
        }

        #region GET AVATAR FROM TheThaoSo

        static readonly vn.xzone.media.TinTucTheThaoSo.GetAvatarThumb TinTucService = new vn.xzone.media.TinTucTheThaoSo.GetAvatarThumb();

        public static string GetAvatarTheThaoSo(object avatar, int width, int height)
        {
            //if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            //{
            //    return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            //}

            //string ext = avatar.ToString().Substring(avatar.ToString().LastIndexOf('.') + 1);
            //if (ext == "gif")
            //{
            //    return GetAvatarGif(avatar.ToString(), width, height);
            //}

            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

            try
            {
                if (!string.IsNullOrEmpty(avatar.ToString()))
                {
                    return TinTucService.GetAvatarByCrop(avatar.ToString().Replace("~/", "/"), width, height);
                }
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
            catch
            {
                return GetSetting("urldata") + "/layout/images/avartar-default.jpg";
            }
        }

        public static string GetAvatarWaterMark(object avatar, int Width)
        {
            if (ConvertUtility.ToInt32(GetSetting("NoGetAvatarWebservice")) == 1)
            {
                return GetSetting("WapDefault") + "/layout/images/avartar-default.jpg";
            }

            if (!string.IsNullOrEmpty(avatar.ToString()))
            {
                return GetSetting("urldata_thethaoso") + TinTucService.GetAvatarWithTextWaterMarkWithResize(avatar.ToString().Replace("~/", "/"), "", "arial", 11, true, 2, 1, Width);
            }
            return GetSetting("urldata_thethaoso") +
                      TinTucService.GetAvatar("/layout/images/avartar-default.jpg", 100, 100);

        }

        public static List<string> GetSrc(string htmlText)
        {
            List<string> imgScrs = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
            var nodes = doc.DocumentNode.SelectNodes(@"//img[@src]");
            if (nodes != null)
            {
                foreach (var img in nodes)
                {
                    HtmlAttribute att = img.Attributes["src"];
                    imgScrs.Add(att.Value);
                }
            }

            return imgScrs;
        }


        #endregion

        public static string GetPartnerName(string key)
        {
            string strReturn = "";

            string[] partnerKeys = GetSetting("Partner_Key").Split(',');
            foreach (var partnerKey in partnerKeys)
            {
                string[] values = partnerKey.Split('-');
                if(values[0].Trim() == key.Trim())
                {
                    strReturn = values[1];

                    return strReturn;
                }
            }

            return strReturn;
        }

        public static string GetPartnerSub(string partnerName,string magoi)
        {
            string strReturn = "";

            string partnerSubs = partnerName.ToUpper() + "_CommandCode";

            string[] subs = GetSetting(partnerSubs).Split(',');
            foreach (var sub in subs)
            {
                if(sub.Trim().ToUpper() == magoi.ToUpper())
                {
                    strReturn = "1";

                    return strReturn;
                }
            }

            return strReturn;
        }

        public static string GetTrueAvatarPath(string avtar)
        {
            if (!string.IsNullOrEmpty(avtar))
            {
                return GetSetting("urldata") + avtar.Replace("~/Upload","/Upload");
            }
            return "/Images/icon_app52.png";
        }

        public static string GetAvatarByPath(string avatar, int width, int height)
        {
            if (!string.IsNullOrEmpty(avatar))
            {
                avatar = avatar.Replace(".50x50", "");
                avatar = avatar.Replace(GetSetting("urldata"), "");

                var ws = new CreateAvatar.MOReceiver();
                ws.GenerateAvatarThumnail(avatar, width, height);

                string urlData = GetSetting("urldata");
                string img = MultimediaUtility.GetAvatarThumnail(avatar, width, height).Replace("~", "");

                return urlData + img;
            }
            return "/Images/icon_app52.png";
        }

        public static string NavigateGetAvatar(string avatar, int width, int height,int catId)
        {
            if (catId == 129)
            {
                return GetAvatarTheThaoSo(avatar, width, height);
            }

            return GetAvatarByPath(avatar, width, height);
        }

        public static string TrimLength(string headline, int length)
        {
            if (headline.Trim().Length > 0)
            {
                if (headline.Trim().Length > length)
                {
                    headline = headline.Trim();
                    headline = headline.Substring(0, length);

                    headline = headline.Substring(0, headline.Length);

                    return headline.Substring(0, headline.LastIndexOf(" ", StringComparison.Ordinal)) + "...";
                }
                return headline;
            }

            return "";
        }

        public static string CheckSessionTelco()
        {
            //if (HttpContext.Current.Session["telco"] != null)
            //    return HttpContext.Current.Session["telco"].ToString();

            return Constant.Constant.T_Vietnamobile;
        }

        public static string CheckSessionTelcoUndefine()
        {
            if (HttpContext.Current.Session["telco"] != null)
                return HttpContext.Current.Session["telco"].ToString();

            return Constant.Constant.T_Undefined;
        }

        public static string CheckMsisdn()
        {
            if (HttpContext.Current.Session["msisdn"] != null)
                return HttpContext.Current.Session["msisdn"].ToString();

            return "";
        }

        public static string CheckFreeContentMsisdn()
        {
            if (HttpContext.Current.Session["msisdn"] != null)
                return HttpContext.Current.Session["msisdn"].ToString();

            return "84929004805";
        }

        public static string CheckFreeContentTelco()
        {
            //if (HttpContext.Current.Session["telco"] != null)
            //    return HttpContext.Current.Session["telco"].ToString();

            return Constant.Constant.T_Vietnamobile;
        }

        public static string NavigateUrlHigh(string input)
        {
            string url = input;
            if (input.Contains("Default.aspx"))
            {
                if (input.Contains("Video/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.VideoHome();
                }
                else if(input.Contains("Phanmem/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.PhanMemHome();
                }
                else if (input.Contains("Music/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.AmNhacHome();
                }
                else if (input.Contains("Hoangdao/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.HoangDaoHome();
                }
                else if (input.Contains("Hinhnen/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.HinhNenHome();
                }
                else if (input.Contains("Thugian/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.ThuGianHome();
                }
                else if (input.Contains("Xoso/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.XoSoHome();
                }
                else if (input.Contains("Thethao/Default.aspx"))
                {
                    url = UrlProcess.UrlProcess.TheThaoHome();
                }

            }
            return url;
        }

        public static void RegisterAllSubConfig()
        {
            //HttpContext.Current.Session["msisdn"] = "841883980154";
            //HttpContext.Current.Session["msisdn"] = "841882406279";
            if (HttpContext.Current.Session["msisdn"] != null)
            {
                string msisdn = HttpContext.Current.Session["msisdn"].ToString();

                DataTable dtBackList = WapController.VnmCheckBlackList(HttpContext.Current.Session["msisdn"].ToString());

                if (dtBackList.Rows.Count == 0)
                {
                    string mtContent;

                    //if (msisdn == "841882406279" || msisdn == "841864950687" || msisdn == "841883980154")  
                    //{

                        #region S2 94x


                        string s294xdk = WapController.PortalSettingGetbyKey("waps294xhomereg");
                        if (s294xdk != "")
                        {
                            string value1 = RegisterService(GetSetting("S2ShortCode"), "0", HttpContext.Current.Session["msisdn"].ToString(), "DK", s294xdk);//Andy Service S2_94x
                            string[] values1 = value1.Split('|');
                            if (values1[0].Trim() == "1")
                            {
                                SendMt(msisdn, "949", "DK", WapController.PortalSettingGetbyKey("waps294xhomeregmt"));
                            }
                        }
                        else
                        {
                            DataTable dtSub = WapController.VnmS294XConfigGetByStatus();
                            if (dtSub != null && dtSub.Rows.Count > 0)
                            {
                                string message = dtSub.Rows[0]["Definition_Value"].ToString().Trim();
                                string value = RegisterService(GetSetting("S2ShortCode"), "0", HttpContext.Current.Session["msisdn"].ToString(), "DK", message);//Andy Service S2_94x
                                //string[] values = value.Split('|');
                                //if (values[0].Trim() == "1")
                                //{
                                //    mtContent = UnicodeUtility.UnicodeToKoDau(dtSub.Rows[0]["Definition_Description"].ToString().Trim());
                                //    SendMt_tracham(msisdn, "949", "DK", mtContent);
                                //    HttpContext.Current.Session["S2_94x"] = message;
                                //}
                            }
                        }

                        #endregion

                        #region Advance service

                        DataTable dtSubAdcance = WapController.VnmAdvanceConfigGetByStatus();
                        if (dtSubAdcance != null && dtSubAdcance.Rows.Count > 0)
                        {
                            string id = dtSubAdcance.Rows[0]["DefinitionId"].ToString();
                            if (id == "77")//DV Anh Tai Bong Da
                            {
                                #region Insert MO Anh Tai Bong Da
                                var moInfo = new MTInfo();
                                var random = new Random();
                                    moInfo.User_ID = msisdn;
                                    moInfo.Service_ID = "979";
                                    moInfo.Command_Code = "TP";
                                    moInfo.Message = "DK TP";
                                    moInfo.Request_ID = "0"; 
                                    moInfo.Operator = "vnmobile";
                                    InsertSportGameHeroMo(moInfo);
                                #endregion
                                #region DK USER ANH TAI BONG DA

                                    var entity = new ViSport_S2_Registered_UsersInfo();
                                    entity.User_ID = HttpContext.Current.Session["msisdn"].ToString();
                                    entity.Request_ID = "0";
                                    entity.Service_ID = "979";
                                    entity.Command_Code = "TP";
                                    entity.Service_Type = 1;
                                    entity.Charging_Count = 0;
                                    entity.FailedChargingTimes = 0;
                                    entity.RegisteredTime = DateTime.Now;
                                    entity.ExpiredTime = DateTime.Now.AddDays(1);
                                    entity.Registration_Channel = "WAP";
                                    entity.Status = 1;
                                    entity.Operator = "vnmobile";
                                    entity.Point = 2;

                                    DataTable dt = InsertSportGameHeroRegisterUser(entity);

                                //if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                                //{
                                //    string code1 = RandomActiveCode.Generate(8);
                                //    string code2 = RandomActiveCode.Generate(8);
                                //    SportGameHeroLotteryCodeInsert(msisdn, code1);
                                //    SportGameHeroLotteryCodeInsert(msisdn, code2);

                                //    mtContent = "Chuc mung ban da tham gia CTKM Chuyen gia bong da cua Vietnamobile de co co hoi trung thuong 1 dien thoai Samsung Galaxy S4. Moi ngay ban se duoc tra loi cau hoi de  nang cao co hoi trung thuong (5000d/ngay). Truy cap: http://visport.vn de su dung dvu. De huy dvu soan: HUY TP gui 979. HT: 19001255";
                                //    SendMt(msisdn, "979", "TP", mtContent);
                                //}

                                #endregion
                                #region Send MT trả chậm
                                    if (dt.Rows[0]["RETURN_ID"].ToString() == "0")
                                    {
                                        #region Log MT DVKH
                                        var objMt = new ViSport_S2_SMS_MTInfo();
                                        objMt.User_ID = msisdn;
                                        objMt.Message = "Chuc mung ban da dang ky thanh cong dich vu Visport cua Vietnamobile. Mien phi ngay dau tien cho thue bao lan dau dang ky. Dang ky dich vu, ban duoc xem, nghe, tai toan bo noi dung mien phi. Truy cap bang 3g vao dia chi http://visport.vn de su dung (5000d/ngay, dvu duoc tu dong gia han). Huy dvu soan: HUY TP gui 979. HT: 19001255";
                                        objMt.Service_ID = "979";
                                        objMt.Command_Code = "TP";
                                        objMt.Message_Type = 1;
                                        objMt.Request_ID = "0";
                                        objMt.Total_Message = 1;
                                        objMt.Message_Index = 0;
                                        objMt.IsMore = 0;
                                        objMt.Content_Type = 0;
                                        objMt.ServiceType = 0;
                                        objMt.ResponseTime = Get_Time_MTTraCham();
                                        objMt.isLock = false;
                                        objMt.PartnerID = "VNM";
                                        objMt.Operator = "vnmobile";
                                        objMt.IsQuestion = 0;

                                        InsertSportGameHeroMt(objMt);
                                        #endregion

                                        #region Insert to MTSending 949
                                        Vmg_MT_Info mtInfo = new Vmg_MT_Info();
                                        mtInfo.User_ID = msisdn;
                                        mtInfo.Message = "Chuc mung ban da dang ky thanh cong dich vu Visport cua Vietnamobile. Mien phi ngay dau tien cho thue bao lan dau dang ky. Dang ky dich vu, ban duoc xem, nghe, tai toan bo noi dung mien phi. Truy cap bang 3g vao dia chi http://visport.vn de su dung (5000d/ngay, dvu duoc tu dong gia han). Huy dvu soan: HUY TP gui 979. HT: 19001255";
                                        mtInfo.Short_Code = "979";
                                        mtInfo.Command_Code = "TP";
                                        mtInfo.Message_Type = 1;
                                        mtInfo.Request_ID = "0";
                                        mtInfo.Total_Message = 0;
                                        mtInfo.Message_Index = 0;
                                        mtInfo.IsMore = 0;
                                        mtInfo.Content_Type = 0;
                                        mtInfo.MT_Price = 0;
                                        mtInfo.Service_Type = 0;
                                        mtInfo.Service_ID = 0;
                                        mtInfo.Partner_ID = "VNM";
                                        mtInfo.Operator = "vnmobile";
                                        mtInfo.Response_Time = Get_Time_MTTraCham();
                                        int result = InsertWithResponseTime(mtInfo);
                                        #endregion

                                    }
                                    
                                #endregion
                            }
                            else if (id == "78") //DK Sub VmGame
                            {
                                #region MyRegion

                                string value = DangKyVmGame(HttpContext.Current.Session["msisdn"].ToString());
                                //if (value == "1")
                                //{
                                //    mtContent = "Ban duoc tang 10.000 diem va  ghi ten vao danh sach nhan thuong giai thuong 9.000.000d. Soan HD gui 2288 de biet chi tiet chuong trinh, DIEM gui 2288 de biet so diem hien tai. Truy cap http://vmgame.vn.";
                                //    SendMt(msisdn, "2288", "DK", mtContent);
                                //    mtContent = "Chuc mung QK da dang ky thanh cong dich vu Game portal cua Vietnamobile, (phi dich vu 10.000 d/tuan,dvu se duoc tu dong gia han). Moi ban truy cap de tai game : http://vmgame.vn. Hang tuan ban se duoc tai 2 game MIEN PHI khi truy cap vao link. De huy dich vu soan HUY gui 2288";
                                //    HttpContext.Current.Session["VmGame"] = "1";
                                //}

                                #endregion
                            }
                        }
                        //    else if (id == "90")//DK Sub VClip
                        //    {
                        //        #region DK SUB Vclip

                        //        var regObject = new ViSport_S2_Registered_UsersInfo();

                        //        regObject.User_ID = HttpContext.Current.Session["msisdn"].ToString();
                        //        regObject.Request_ID = "0";
                        //        regObject.Service_ID = "949";
                        //        regObject.Command_Code = "CLIP";
                        //        regObject.Service_Type = 1;
                        //        regObject.Charging_Count = 0;
                        //        regObject.FailedChargingTimes = 0;
                        //        regObject.RegisteredTime = DateTime.Now;
                        //        regObject.ExpiredTime = DateTime.Now.AddDays(3);
                        //        regObject.Registration_Channel = "WAP";
                        //        regObject.Status = 1;
                        //        regObject.Operator = "vnmobile";

                        //        DataTable value = InsertVClip(regObject);
                        //        if (value.Rows[0]["RETURN_ID"].ToString() == "0")
                        //        {
                        //            mtContent = "DV VMclip cua Vietnamobile tang ban MIEN PHI 1 ngay su dung dich vu.Truy cap http://kho-clip.com/ de su dung dv.De huy dv soan tin CLIP OFF gui 949 HT 19001255";
                        //            SendMt(msisdn,"949","CLIP",mtContent);
                        //            HttpContext.Current.Session["VClip"] = "1";
                        //        }

                        //        #endregion
                        //    }
                        //    else if(id == "94")
                        //    {
                        //        #region DK SUB World Cup 2014 VTV Digital

                        //        var entity = new ViSport_S2_Registered_UsersInfo();
                        //        entity.User_ID = HttpContext.Current.Session["msisdn"].ToString();
                        //        entity.Request_ID = "0";
                        //        entity.Service_ID = "979";
                        //        entity.Command_Code = "VTV";
                        //        entity.Service_Type = 1;
                        //        entity.Charging_Count = 0;
                        //        entity.FailedChargingTimes = 0;
                        //        entity.RegisteredTime = DateTime.Now;
                        //        entity.ExpiredTime = DateTime.Now.AddDays(1);
                        //        entity.Registration_Channel = "VTV_WAP";
                        //        entity.Status = 1;
                        //        entity.Operator = "vnmobile";
                        //        entity.Point = 0;

                        //        DataTable dtUser = WorldCupRegisterUserVtv6(entity);

                        //        if (dtUser.Rows[0]["RETURN_ID"].ToString() == "0")
                        //        {
                        //            //GOI API lay PASS ben DOITAC
                        //            var post = new PostSubmitter();
                        //            post.Url = "http://worldcup.visport.vn/TelcoApi/service.php?action=VMGsms&command=VMG&message=" + "dang-ky-vtv6-wc" + "&msisdn=" + msisdn + "&short_code=dau-SMS-VMG";
                        //            post.Type = PostSubmitter.PostTypeEnum.Get;
                        //            string result = post.Post();

                        //            mtContent = result;

                        //            SendMt(msisdn, "979", "VTV", mtContent);
                        //        }


                        //        #endregion
                        //    }
                        //    else if(id == "96")
                        //    {
                        //        #region DK SUB DV POD

                        //        DangKyPod(HttpContext.Current.Session["msisdn"].ToString());

                        //        #endregion
                        //    }
                        //    else if(id == "97")
                        //    {
                        //        #region DK SUB BIG PROMOTION

                        //        BigPromotionRegistered();

                        //        #endregion
                        //    }
                        //    else if(id == "98")
                        //    {
                        //        #region DK VoiceChat1515

                        //        VoiceChat1515SmsRegistered(msisdn);

                        //        #endregion
                        //    }
                        //}

                        #endregion
                    //}
                }
            }
        }

        

        public static void SendMt(string userId,string serviceId,string commandCode,string message)
        {
            var mtInfo = new MTInfo();
            var random = new Random();
            mtInfo.User_ID = userId;
            mtInfo.Service_ID = serviceId;
            mtInfo.Command_Code = commandCode;
            mtInfo.Message_Type = (int)Constant.Constant.MessageType.FREE;
            mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
            mtInfo.Total_Message = 1;
            mtInfo.Message_Index = 0;
            mtInfo.IsMore = 0;
            mtInfo.Content_Type = 0;
            mtInfo.Message_Type = (int)Constant.Constant.MessageType.FREE;
            mtInfo.Message = message;
            MTController.SmsMtInsertNew(mtInfo);
        }

        public static void SendMt_tracham(string userId, string serviceId, string commandCode, string message)
        {
            var mtInfo = new MTInfo();
            var random = new Random();
            mtInfo.User_ID = userId;
            mtInfo.Service_ID = serviceId;
            mtInfo.Command_Code = commandCode;
            mtInfo.Message_Type = (int)Constant.Constant.MessageType.FREE;
            mtInfo.Request_ID = random.Next(100000000, 999999999).ToString();
            mtInfo.Total_Message = 1;
            mtInfo.Message_Index = 0;
            mtInfo.IsMore = 0;
            mtInfo.Content_Type = 0;
            mtInfo.Message_Type = (int)Constant.Constant.MessageType.FREE;
            mtInfo.Message = message;
            DateTime ResponseTime;
            if (DateTime.Now.Hour < 20)
            {
                ResponseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            }
            else
            {
                ResponseTime = DateTime.Now;
            }
            MTController.SmsMtInsertNew_tracham(mtInfo, ResponseTime);
        }

        public static DateTime Get_Time_MTTraCham()
        {
            
            if (DateTime.Now.Hour < 20)
            {
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            }
            else
            {
                return DateTime.Now;
            }
        }
        
        public static void PartnerService()
        {
            if (HttpContext.Current.Session["msisdn"] != null)
            {
                string msisdn = HttpContext.Current.Session["msisdn"].ToString();

                DataTable dtBackList = WapController.VnmCheckBlackList(HttpContext.Current.Session["msisdn"].ToString());
                if (dtBackList.Rows.Count == 0)
                {
                    string mtContent;

                    #region PartnerService

                    DataTable dtP = WapController.VnmPartnerConfigGetByStatus();
                    if (dtP != null && dtP.Rows.Count > 0)
                    {
                        bool val = true;
                        int id = ConvertUtility.ToInt32(dtP.Rows[0]["Definition_Value"]);
                        DataTable tblServices = WapController.S2_94xGetServiceInfo(id);
                        if (tblServices == null || tblServices.Rows.Count < 1)
                        {
                            val = false;
                        }
                        if (tblServices != null && tblServices.Rows[0]["status"].ToString() != "3")
                        {
                            val = false;
                        }

                        if (val)
                        {
                            string regisSystax = tblServices.Rows[0]["Register_Syntax"].ToString().Split('|')[0];
                            string result = RegisterService(GetSetting("S2ShortCode"), "0", msisdn, "DK", regisSystax);//Andy Service S2_94x   
                        }

                    }

                    #endregion

                }
            }
        }

        public static string GetUserAgent()
        {
            string model = string.Empty;
            if (HttpContext.Current.Request.UserAgent != null)
            {
                string userAgent = HttpContext.Current.Request.UserAgent.ToLower();

                //if (userAgent.Contains("ios") || userAgent.Contains("iphone") || userAgent.Contains("ipad"))
                //{
                //    model = "ios";
                //}
                //else if (userAgent.Contains("android"))
                //{
                //    model = "android";
                //}
                //else
                //{
                //    model = "java";
                //}

                if (userAgent.Contains("ios") || userAgent.Contains("iphone") || userAgent.Contains("ipad") || userAgent.Contains("android") || userAgent.Contains("windows phone") || userAgent.Contains("window phone"))
                {
                    model = "high";
                }
                else
                {
                    model = "low";
                }

            }

            return model;
        }

        public static string NavigateUrlHighHeader(string input)
        {
            string url = string.Empty;
            string model = string.Empty;

            if(input.ToLower() == "game")
            {

                if(isMobileBrowser())
                {
                    model = GetUserAgent();
                    if (model == "high")
                    {
                        url = UrlProcess.UrlProcess.GameHome();
                    }
                    else
                    {
                        url = UrlProcess.UrlProcess.GetGameHomeUrl("1", "320", "1");
                    }
                }
                else
                {
                    url = UrlProcess.UrlProcess.GameHome();
                }
                
            }

            return url;
        }

        public static void BigPromotionRegistered()
        {
            int is3G;
            string msisdn = MobileUtils.GetMSISDN(out is3G);

            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
            {

                ILog log = LogManager.GetLogger("File");

                var entity = new ThanhNuRegisteredUsers();
                entity.UserId = msisdn;
                entity.RequestId = "0";
                entity.ServiceId = "949";
                entity.CommandCode = "GOI";
                entity.ServiceType = 1;
                entity.ChargingCount = 0;
                entity.FailedChargingTimes = 0;
                entity.RegisteredTime = DateTime.Now;
                entity.ExpiredTime = DateTime.Now.AddDays(5);
                entity.RegistrationChannel = "WAP";
                entity.Status = 1;
                entity.Operator = "vnmobile";

                DataTable value = ThanhNuRegisterUserInsert(entity);
                if (value.Rows[0]["RETURN_ID"].ToString() == "0")
                {

                    string code1 = RandomActiveCode.Generate(8);
                    string code2 = RandomActiveCode.Generate(8);

                    string messageReturn = "Chuc mung quy khach da dang ky CTKM trai nghiem dich vu GTGT, trung thuong SH sanh dieu va nhieu ipad mini. Qkhach duoc su dung mien phi 5 ngay goi dich vu ( bao gom game portal, shot and print, nhac chuong) va nhan 2 MDT: " + code1 + ", " + code2 + " de tham gia quay thuonng vao cuoi chuong trinh. Sau khi het khuyen mai 15 ngay, he thong se tu dong huy toan bo dich vu cho khach hang. De huy dich vu soan HUY GOI gui 949 ";
                    

                    ThanhNuRegisterUserCodeInsert(msisdn, code1, "WAP");
                    ThanhNuRegisterUserCodeInsert(msisdn, code2, "WAP");

                    #region VMGame

                    var vmgame = new Service_RegisS2();
                    string vmGameResult = vmgame.BigPromotionRegis(msisdn, "BigPro123!@#Tqscd");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION VmGameResult REGIS -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("vmGameResult: " + vmGameResult);
                    log.Debug(" ");
                    log.Debug(" ");

                    #endregion

                    #region Shot And Print

                    var shot = new S2Process();
                    string shotResult = shot.BPRegister(msisdn, RandomActiveCode.Generate(10), "VNM_WAP", "4", "VNM_WAP");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION shotResult REGIS -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("shotResult: " + shotResult);
                    log.Debug(" ");
                    log.Debug(" ");

                    #endregion

                    #region NC1

                    var ringTone = new NC1_Handler();
                    string ringToneRes = ringTone.SyncSubscriptionData("949", "DK", msisdn, "GOI", RandomActiveCode.Generate(10), "472", "0", "1", "DK GOI");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION ringToneRes REGIS -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("ringToneRes: " + ringToneRes);
                    log.Debug(" ");
                    log.Debug(" ");

                    #endregion

                    SendMt(msisdn, "949", "GOI", messageReturn);

                }
                else if (value.Rows[0]["RETURN_ID"].ToString() == "2")
                {

                    #region DK VMGAME

                    var vmgame = new Service_RegisS2();
                    string vmGameResult = vmgame.BigPromotionRegis(msisdn, "BigPro123!@#Tqscd");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION VmGameResult (Already) -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("vmGameResult: " + vmGameResult);
                    log.Debug(" ");
                    log.Debug(" ");


                    #endregion

                    #region Shot And Print

                    var shot = new S2Process();
                    string shotResult = shot.BPRegister(msisdn, RandomActiveCode.Generate(10), "VNM_WAP", "4", "VNM_WAP");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION shotResult (Already) -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("shotResult: " + shotResult);
                    log.Debug(" ");
                    log.Debug(" ");

                    #endregion

                    #region DK NC1

                    var ringTone = new NC1_Handler();
                    string ringToneRes = ringTone.SyncSubscriptionData("949", "DK", msisdn, "GOI", RandomActiveCode.Generate(10), "472", "0", "2", "DK GOI");

                    log.Debug(" ");
                    log.Debug(" ");
                    log.Debug("-------------------- BIG PROMOTION ringToneRes REGIS (Already) -------------------------");
                    log.Debug("User_ID: " + msisdn);
                    log.Debug("ringToneRes: " + ringToneRes);
                    log.Debug(" ");
                    log.Debug(" ");

                    #endregion

                }

            }

        }

        #region INSERT METHOD

        public static void VnmTransactionLog(string msisdn)
        {
            try
            {
                string partnerId = "39";
                string price = "1000";

                int status = 1;
                string debit_status = string.Empty;

                //DataTable dt = TintucController.GetRandomForNews();

                var charging = new VNMChargingGW();
                debit_status = charging.NavigatePaymentVnm(msisdn, "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Dich vu thu gian sexy");
                if (!string.IsNullOrEmpty(debit_status) && debit_status == "1")
                {
                    // Thanh toán thành công >> trả nội dung                                    
                    status = 0;
                }

                //Tạo Transaction_Online mới
                string vTransactionID = DBController.Transaction_Online_Insert(msisdn, 4, ConvertUtility.ToInt32(partnerId), "", "");

                //Ghi Transaction, Transaction_Log, xoá Transaction_Online cũ
                DBController.Transaction_Insert_New(
                    "68",
                    "Dich vu thu gian sexy",
                    13,
                    msisdn,
                    4,
                    0,
                    ConvertUtility.ToInt32(price),
                    ConvertUtility.ToInt32(partnerId),
                    ConvertUtility.ToDecimal(vTransactionID),
                    ConvertUtility.ToDateTime(DateTime.Now),
                    "debit_status: " + debit_status,
                    status);

                WapController.Transaction_Online_Delete(msisdn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable InsertSportGameHeroRegisterUser(ViSport_S2_Registered_UsersInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_Registered_Users_Insert"

                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTimes
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Point

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        public static DataTable ThanhNuRegisterUserInsert(ThanhNuRegisteredUsers entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Thanh_Nu_Registered_Users_Insert"

                , entity.UserId
                , entity.RequestId
                , entity.ServiceId
                , entity.CommandCode
                , entity.ServiceType
                , entity.ChargingCount
                , entity.FailedChargingTimes
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.RegistrationChannel
                , entity.Status
                , entity.Operator

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        public static bool ThanhNuRegisterUserCodeInsert(string userId, string code, string channel)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Thanh_Nu_Registered_User_Code_Insert", userId, code, channel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public static DataTable InsertVClip(ViSport_S2_Registered_UsersInfo viSportS2RegisteredUsersInfo)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VClip_S2_Registered_Users_Insert", viSportS2RegisteredUsersInfo.User_ID
            , viSportS2RegisteredUsersInfo.Request_ID
           , viSportS2RegisteredUsersInfo.Service_ID
           , viSportS2RegisteredUsersInfo.Command_Code
            , viSportS2RegisteredUsersInfo.Service_Type
            , viSportS2RegisteredUsersInfo.Charging_Count
            , viSportS2RegisteredUsersInfo.FailedChargingTimes
            , viSportS2RegisteredUsersInfo.RegisteredTime
           , viSportS2RegisteredUsersInfo.ExpiredTime
            , viSportS2RegisteredUsersInfo.Registration_Channel
           , viSportS2RegisteredUsersInfo.Status
            , viSportS2RegisteredUsersInfo.Operator);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable WorldCupRegisterUserVtv6(ViSport_S2_Registered_UsersInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "World_Cup_Registered_Users_Insert_Vtv"

                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTimes
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Point

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        public static void SportGameHeroLotteryCodeInsert(string userId, string code)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_Lottery_Code_Insert"
                                        , userId
                                        , code
                                    );
        }

        //public static void InsertSportGameHeroMo(string User_ID, string Request_ID, string Service_ID, string Command_Code, string Message, string Operator)
        //{
        //    SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_SMS_MO_Insert"
        //                               , User_ID, Request_ID, Service_ID, Command_Code, Message, Operator);
                                       
                                   
        //}
        public static void InsertSportGameHeroMo(MTInfo entity)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Sport_Game_Hero_SMS_MO_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", entity.User_ID);
            dbCmd.Parameters.Add("@Request_ID", entity.Request_ID);
            dbCmd.Parameters.Add("@Service_ID", entity.Service_ID);
            dbCmd.Parameters.Add("@Command_Code", entity.Command_Code);
            dbCmd.Parameters.Add("@Message", entity.Message);
            dbCmd.Parameters.Add("@Operator", entity.Operator);

            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static int InsertSportGameHeroMt(ViSport_S2_SMS_MTInfo entity)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Sport_Game_Hero_SMS_MT_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", entity.User_ID);
            dbCmd.Parameters.Add("@Message", entity.Message);
            dbCmd.Parameters.Add("@Service_ID", entity.Service_ID);
            dbCmd.Parameters.Add("@Command_Code", entity.Command_Code);
            dbCmd.Parameters.Add("@Message_Type", entity.Message_Type);
            dbCmd.Parameters.Add("@Request_ID", entity.Request_ID);
            dbCmd.Parameters.Add("@Total_Message", entity.Total_Message);
            dbCmd.Parameters.Add("@Message_Index", entity.Message_Index);
            dbCmd.Parameters.Add("@IsMore", entity.IsMore);
            dbCmd.Parameters.Add("@Content_Type", entity.Content_Type);
            dbCmd.Parameters.Add("@ServiceType", entity.ServiceType);
            dbCmd.Parameters.Add("@ResponseTime", entity.ResponseTime);
            dbCmd.Parameters.Add("@isLock", entity.isLock);
            dbCmd.Parameters.Add("@PartnerID", entity.PartnerID);
            dbCmd.Parameters.Add("@Operator", entity.Operator);
            dbCmd.Parameters.Add("@IsQuestion", entity.IsQuestion);


            dbCmd.Parameters.Add("@RETURN_ID", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_ID"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static int InsertWithResponseTime(Vmg_MT_Info mt_info)
        {
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VMG_MT_Sending_InsertSchedule", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@User_ID", mt_info.User_ID);
            dbCmd.Parameters.Add("@Message", mt_info.Message);
            dbCmd.Parameters.Add("@Short_Code", mt_info.Short_Code);
            dbCmd.Parameters.Add("@Command_Code", mt_info.Command_Code);
            dbCmd.Parameters.Add("@Message_Type", mt_info.Message_Type);
            dbCmd.Parameters.Add("@Request_ID", mt_info.Request_ID);
            dbCmd.Parameters.Add("@Total_Message", mt_info.Total_Message);
            dbCmd.Parameters.Add("@Message_Index", mt_info.Message_Index);
            dbCmd.Parameters.Add("@IsMore", mt_info.IsMore);
            dbCmd.Parameters.Add("@Content_Type", mt_info.Content_Type);
            dbCmd.Parameters.Add("@MT_Price", mt_info.MT_Price);
            dbCmd.Parameters.Add("@Service_Type", mt_info.Service_Type);
            dbCmd.Parameters.Add("@Service_ID", mt_info.Service_ID);
            dbCmd.Parameters.Add("@Partner_ID", mt_info.Partner_ID);
            dbCmd.Parameters.Add("@Operator", mt_info.Operator);
            dbCmd.Parameters.Add("@Response_Time", mt_info.Response_Time);
            dbCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }
        #endregion

        #region VoiChat1515

        public static string[] WriteOutData(string xmlString)
        {
            string message = "";
            string status_code = "";
            string[] kq = new string[2];

            // Create xml document
            XmlReader oXmlReader = XmlReader.Create(new StringReader(xmlString));
            XPathDocument doc = new XPathDocument(oXmlReader);
            // Create navigator  
            XPathNavigator navigator = doc.CreateNavigator();
            // Read Node
            XPathNodeIterator iterator = navigator.Select("register/result");
            while (iterator.MoveNext())
            {
                XPathNavigator navigator2 = iterator.Current.Clone();
                status_code = navigator2.Value;
            }
            iterator = navigator.Select("register/message");
            while (iterator.MoveNext())
            {
                XPathNavigator navigator2 = iterator.Current.Clone();
                message = navigator2.Value;
            }
            kq[0] = status_code;
            kq[1] = message;
            return kq;
        }

        public static void VoiceChat1515SmsRegistered(string msisdn)
        {
            //int revalue = 0;
            string userID = msisdn;
            if (userID == "")
                return;

            ILog log = LogManager.GetLogger("VoiceChat1515SmsRegistered");

            string url = string.Format("http://123.29.67.21:8081/smschat/register?msisdn={0}&key=43A0F553EF6F12A746A9AF9DB9AB9205", userID.Substring(2, userID.Length - 2));
            try
            {
                string text;
                using (var client = new WebClient())
                {
                    text = client.DownloadString(url);
                }
                string[] kq = WriteOutData(text);

                log.Debug(" ");
                log.Debug("****** VoiceChat1515 ******");
                log.Debug(string.Format("msisdn = {0}, errorcode = {1}, errormessage = {2}", msisdn, kq[0], kq[1]));
                log.Debug(" ");
                log.Debug(" ");
            }
            catch (Exception ex)
            {
                log.Error(" ");
                log.Error(" ");
                log.Error(string.Format("ChatSMSRegis1515 -  Register Fail, Exception, URL= {0}, Exception = {1}", url, ex.Message));
                log.Error(" ");
                log.Error(" ");
            }

        }

        #endregion

    }

    public class ThanhNuRegisteredUsers
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RequestId { get; set; }

        public string ServiceId { get; set; }

        public string CommandCode { get; set; }

        public int ServiceType { get; set; }

        public int ChargingCount { get; set; }

        public int FailedChargingTimes { get; set; }

        public DateTime RegisteredTime { get; set; }

        public DateTime ExpiredTime { get; set; }

        public string RegistrationChannel { get; set; }

        public int Status { get; set; }

        public string Operator { get; set; }

        public int IsLock { get; set; }
    }
}