using System;
using System.Configuration;
using System.Threading;
using System.Web.Configuration;
using _3GChargingWebService.WebReference;
using log4net;

namespace _3GChargingWebService.Library
{
    public class VNMChargingGW2G
    {
        static ILog log = LogManager.GetLogger("File");
        private const int REQUEST_TIMEOUT = 50;
        private const string BALANCE_NAME = "core";


        public static string PaymentVNM(string msisdn, string serviceId, string serviceState, string content, string servicename)
        {
            var info = new ChargingTransactionInfo();
            info.ServiceId = serviceId;
            info.UserName = ConfigurationManager.AppSettings["user"];
            info.UserPass = ConfigurationManager.AppSettings["pass"];
            info.CpId = ConfigurationManager.AppSettings["userid"];
            info.UserId = msisdn;
            info.ServiceState = serviceState;

            string returnValue = string.Empty;

            try
            {
                log.Info("---------- Dich vu ket noi : " + servicename + " ----------------");
                log.Info(string.Format(" Begin Charging Request: userID:{0}; serviceID:{1}", msisdn, serviceId));

                returnValue = exDebit(info, content,servicename);
                if (returnValue == "1")
                    return "1";
            }
            catch (Exception ex)
            {
                log.Info(" == Error PaymentVNM: " + ex.Message);
                log.Info(" == Error PaymentVNM: " + ex.StackTrace);
                log.Error(" ");
                log.Error(" ");
            }
            return returnValue;
        }

        public static string PaymentVnmWithAccount(string msisdn, string serviceId, string serviceState, string content, string servicename,string userName,string userPass,string cpId)
        {
            var info = new ChargingTransactionInfo();
            info.ServiceId = serviceId;
            info.UserName = userName;
            info.UserPass = userPass;
            info.CpId = cpId;
            info.UserId = msisdn;
            info.ServiceState = serviceState;

            string returnValue = string.Empty;

            if (userName == WebConfigurationManager.AppSettings["user"] && servicename == "ViSport")
            {
                servicename = "VClip Charging Service";
            }

            try
            {
                log.Info(" ");
                log.Info(" ");
                log.Info("---------- Dich vu ket noi : " + servicename + " ----------------");
                log.Info(string.Format(" Begin Charging Request: userID:{0}; serviceID:{1}", msisdn, serviceId));

                returnValue = exDebit(info, content,servicename);
                if (returnValue == "1")
                    return "1";
            }
            catch (Exception ex)
            {
                log.Info(" == Error PaymentVNM: " + ex.Message);
                log.Info(" == Error PaymentVNM: " + ex.StackTrace);
                log.Error(" ");
                log.Error(" ");
            }
            return returnValue;
        }

        public static string exDebit(ChargingTransactionInfo info, string content,string servicename)
        {
            string success;
            string resp = string.Empty;
            try
            {
                CHARGING wsCgw = new CHARGING();
                log.Info("Call Deduct method: " + info.UserId + " | " + info.ServiceId + " | " + info.UserName + " | " + info.UserPass + " | " + info.CpId + " | " + content);
                content = TrimLength(content, 30);
                resp = wsCgw.extDebit2(info.UserName, info.UserPass, info.CpId, info.UserId, info.ServiceId, REQUEST_TIMEOUT, content);
                log.Info("resp: " + resp);

                string[] arrResult = resp.Split(',');
                
                int sResult = int.Parse(arrResult[0].Replace("Result:", ""));
                string sDetail = arrResult[1].Replace("Detail:", "");

                log.Info("Response Result (VNM Result Code): " + resp);
                log.Info("Action: " + content);
                log.Error(" ");
                log.Error(" ");

                if (sResult == Constant.E_OK)
                    success = "1";
                else
                    success = resp;

            }
            catch (Exception ex)
            {
                try
                {
                    Thread.Sleep(2000);

                    CHARGING wsCgw = new CHARGING();
                    log.Info("Call Deduct method: " + info.UserId + " | " + info.ServiceId + " | " + info.UserName + " | " + info.UserPass + " | " + info.CpId + " | " + content);
                    resp = wsCgw.extDebit2(info.UserName, info.UserPass, info.CpId, info.UserId, info.ServiceId, REQUEST_TIMEOUT, content);
                    log.Info("resp: " + resp);
                    string[] arrResult = resp.Split(',');
                    int sResult = int.Parse(arrResult[0].Replace("Result:", ""));
                    string sDetail = arrResult[1].Replace("Detail:", "");
                    log.Info("Response Result (VNM Result Code): " + resp);
                    log.Info("Action: " + content);
                    log.Error(" ");
                    log.Error(" ");

                    if (sResult == Constant.E_OK)
                        success = "1";
                    else
                        success = resp;
                }
                catch (Exception ex1)
                {
                    //throw ex;
                    log.Info("Error exDebit 3G: " + ex.Message);
                    log.Error(" ");
                    log.Error(" ");

                    AlertVnmCharging(info.UserId, "Loi ket noi Webservice VNM Charging 2G | Error:" + ex1.Message, "0", "0", "0", "0", 0, 0, 0, 0, 0, "0", "0");

                    success = resp;
                }
            }

            try
            {
                //Log Transaction 4A
                var entity = new WapTransactionLog4AEntity();
                entity.WapTransactionName = servicename;
                entity.WapTransactionType = 0;
                entity.WapTransactionDetail = content;
                entity.WapTransactionOn = DateTime.Now;
                entity.WapTransactionMobile = info.UserId;
                entity.WapTransactionOperator = "Vietnamobile";
                entity.WapTransactionAmount = ConvertUtility.ToInt32(info.ServiceId);
                entity.ErrorCode = ConvertUtility.ToInt32(success);
                entity.ErrorDetail = resp;
                entity.WapTransactionUserName = info.UserName;
                entity.WapTransactionPassword = info.UserPass;
                entity.WapTransactionCpId = info.CpId;

                WapTransactionLog4AInSert(entity);
                //End Log Transaction 4A
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Info("Error inSert log 4A " + ex.Message);
                log.Error(" ");
                log.Error(" ");
            }

            return success;
        }

        public static void AlertVnmCharging(string userId, string message, string serviceId, string commandCode, string messageType, string requestId, int totalMessage, int messageIndex, int isMore, int contentType, int serviceType, string partnerId, string opera)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Insert_AlertVNMCharging", userId, message, serviceId, commandCode,
                                                                messageType, requestId, totalMessage, messageIndex, isMore, contentType, serviceType, partnerId, opera);
        }

        public static string TrimLength(string headline, int length)
        {
            if (headline.Trim().Length > 0)
            {
                if (headline.Trim().Length > length)
                {
                    headline = headline.Trim();
                    headline = headline.Substring(0, length);
                    return headline.Substring(0, headline.LastIndexOf(" ")) + "...";
                }
                return headline;
            }

            return "";
        }

        public static void WapTransactionLog4AInSert(WapTransactionLog4AEntity entity)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString139"].ConnectionString, "Wap_Transaction_Log_4A_Insert"
                                        ,entity.WapTransactionName
                                        ,entity.WapTransactionType
                                        ,entity.WapTransactionDetail
                                        ,entity.WapTransactionOn
                                        ,entity.WapTransactionMobile
                                        ,entity.WapTransactionOperator
                                        ,entity.WapTransactionAmount
                                        ,entity.ErrorCode
                                        ,entity.ErrorDetail
                                        ,entity.WapTransactionUserName
                                        ,entity.WapTransactionPassword
                                        ,entity.WapTransactionCpId
                                    );
        }

    }

    public class WapTransactionLog4AEntity
    {
        public int Id { get; set; }

        public string WapTransactionName { get; set; }

        public int WapTransactionType { get; set; }

        public string WapTransactionDetail { get; set; }

        public DateTime WapTransactionOn { get; set; }

        public string WapTransactionMobile { get; set; }

        public string WapTransactionOperator { get; set; }

        public int WapTransactionAmount { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorDetail { get; set; }

        public string WapTransactionUserName { get; set; }

        public string WapTransactionPassword { get; set; }

        public string WapTransactionCpId { get; set; }

    }
}