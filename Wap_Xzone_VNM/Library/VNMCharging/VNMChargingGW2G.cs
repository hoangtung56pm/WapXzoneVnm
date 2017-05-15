using System;
using System.Configuration;
using log4net;

namespace WapXzone_VNM.Library.VNMCharging
{
    public class VNMChargingGW2G
    {
        static ILog log = LogManager.GetLogger("File");
        private const int REQUEST_TIMEOUT = 50;
        private const string BALANCE_NAME = "core";

        public static string PaymentVNM(string msisdn, string serviceId, string serviceState, string cnttype, string path)
        {
            var info = new ChargingTransactionInfo();
            info.ServiceId = serviceId;
            info.UserId = msisdn;

            //info.UserName = ConfigurationManager.AppSettings["user_3g"];
            //info.UserPass = ConfigurationManager.AppSettings["pass_3g"];
            //info.CpId = ConfigurationManager.AppSettings["userid_3g"];
            //info.ServiceState = serviceState;

            try
            {
                log.Info("------ 2G Charging ---------");
                log.Info(string.Format("2G Begin Charging Request: userID:{0}; serviceID:{1}; servicestate:{2}; cnttype:{3}; path:{4}", msisdn, serviceId, serviceState, cnttype, path));

                string strReturn = ExDebitNew(info, path);

                return strReturn;

                //if (ExDebit(info, path))
                //{
                //    return "1";
                //}

            }
            catch (Exception ex)
            {
                log.Info(" == 2G Error: " + ex.Message);
                log.Info(" == 2G Error: " + ex.StackTrace);
                log.Info(" ");
                log.Info(" ");
            }
            return "-1";
        }

        public static bool ExDebit(ChargingTransactionInfo info, string content)
        {
            bool success = false;
            try
            {
                var wsCgw = new WS_VNMCGW2G.WebServiceCharging3g();
                log.Info("2G Call Deduct method: " + info.UserId + " | " + info.ServiceId);
                string resp = wsCgw.PaymentVnm(info.UserId, info.ServiceId, content, "Wap VNM");

                log.Info("2G Ket qua tra ve: " + resp);

                if (resp == "1")
                {
                    success = true;
                }
                return success;
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Info("2G Error: " + ex.Message);
                log.Info(" ");
                log.Info(" ");
                return false;
            }
        }

        public static string ExDebitNew(ChargingTransactionInfo info, string content)
        {
            string success = "-1";
            try
            {
                var wsCgw = new WS_VNMCGW2G.WebServiceCharging3g();
                log.Info("2G Call Deduct method: " + info.UserId + " | " + info.ServiceId);
                string resp = wsCgw.PaymentVnm(info.UserId, info.ServiceId, content, "Wap VNM");

                log.Info("2G Ket qua tra ve: " + resp);

                if (resp == "1")
                {
                   return success = "1";
                }

                //if (resp == "Result:12,Detail:Not enough money.")
                //{
                //    return success = "12";
                //}

                //if (resp == "Result:4,Detail:System overload")
                //{
                //    return success = "4";
                //}

                return resp;
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Info("2G Error: " + ex.Message);
                log.Info(" ");
                log.Info(" ");
                return success;
            }
        }
    }
}
