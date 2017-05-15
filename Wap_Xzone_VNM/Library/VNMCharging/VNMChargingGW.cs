using System;
using System.Configuration;
using System.Threading;
using log4net;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.WS_VNMCGW;

namespace WapXzone_VNM.Library.VNMCharging
{
    public class VNMChargingGW
    {
        ILog log = log4net.LogManager.GetLogger("File");
        private const int REQUEST_TIMEOUT = 50;
        private const string BALANCE_NAME = "core";

        public string NavigatePaymentVnm(string msisdn,string productId,string productKey,string serviceId,string serviceState,string cnttype,string path)
        {
            //string returnValue;
            //if (AppEnv.GetSetting("3G_Charging") == "1")
            //{
            //    returnValue = PaymentVNM(msisdn, productId, productKey);

            //    return returnValue;
            //}
            //else
            //{
            //if (AppEnv.GetSetting("2G_Charging_Test") == "1")
            //{
            //    string phones = AppEnv.GetSetting("PhoneNumber");
            //    string[] arrPhones = phones.Split(',');
            //    if (arrPhones.Length > 0)
            //    {
            //        foreach (var item in arrPhones)
            //        {
            //            if (item == msisdn)
            //            {
            //                return PaymentVNM2G(msisdn, serviceId, serviceState, cnttype, path);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //Chỉ on dòng này lên Sửa bởi Bình Trần  25/11/2016  
            // return PaymentVNM2G(msisdn, serviceId, serviceState, cnttype, path); 
            //}

            //return PaymentVNM(msisdn, productId, productKey);
            //}
            //Bình Trần thêm dòng này 25/11/2016 Cho dùng free luôn luôn return -1 
              
            return "1";

        }

        //#region Payment 3G

        //public string PaymentVNM(string msisdn, string productId,string productKey)
        //{
        //    ChargingTransactionInfo info = new ChargingTransactionInfo();
        //    info.UserId = msisdn;
        //    string error = "";
        //    try
        //    {
        //        log.Info(string.Format(" Begin Charging Request: userID:{0}; productId:{1}; productKey:{2}", msisdn, productId, productKey));
        //        //CheckBalance(msisdn);
                
        //        if (exDebit(info,productId,productKey,out error))
        //        {                   
        //            return "1";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Info(" == Error: " + ex.Message);
        //        log.Info(" == Error: " + ex.StackTrace);
        //    }
        //    return error + " productId=" + productId + ",productKey=" + productKey;
        //}

        //public bool exDebit(ChargingTransactionInfo info, string productId, string keyword, out string strError)
        //{
        //    bool success = false;

        //    try
        //    {
        //        ChargingService wsCgw = new ChargingService();
        //        log.Info("Call Deduct method: " + info.UserId + " | " + productId + "|" + keyword);

        //        string resp = wsCgw.CallCharging(info.UserId, productId, keyword);

        //        log.Info("**********************");
        //        log.Info("ket qua tra ve:" + resp);
        //        log.Info("**********************");
        //        int count = resp.LastIndexOf("|");
        //        string messageReturn;
        //        if (count < 1)
        //        {
        //            messageReturn = resp;
        //            strError = "count < 1";
        //        }
        //        else
        //        {
        //            string[] resultarray = resp.Split('|');
        //            log.Info("***** Response code: " + resultarray[0]);
        //            log.Info("***** Detail: " + resultarray[1]);
        //            messageReturn = resultarray[0];
        //            strError = resultarray[1];
        //        }    
     
        //        if(messageReturn == "1")
        //        {
        //            success = true;
        //        }
              
        //        return success;

        //    }
        //    catch (Exception ex)
        //    {
        //        try
        //        {
        //            Thread.Sleep(2000);

        //            ChargingService wsCgw = new ChargingService();
        //            log.Info("Call Deduct method: " + info.UserId + " | " + productId + "|" + keyword);

        //            string resp = wsCgw.CallCharging(info.UserId, productId, keyword);

        //            log.Info("**********************");
        //            log.Info("ket qua tra ve:" + resp);
        //            log.Info("**********************");
        //            int count = resp.LastIndexOf("|");
        //            string messageReturn;
        //            if (count < 1)
        //            {
        //                messageReturn = resp;
        //                strError = "count < 1";
        //            }
        //            else
        //            {
        //                string[] resultarray = resp.Split('|');
        //                log.Info("***** Response code: " + resultarray[0]);
        //                log.Info("***** Detail: " + resultarray[1]);
        //                messageReturn = resultarray[0];
        //                strError = resultarray[1];
        //            }

        //            if (messageReturn == "1")
        //            {
        //                success = true;
        //            }

        //            return success;
        //        }
        //        catch (Exception ex1)
        //        {
        //            log.Debug("----------Loi Ket Noi Web Service----------------------");
        //            log.Debug("Error: " + ex1.Message);
        //            log.Debug("Error StackTrace :" + ex1.StackTrace);

        //            strError = "Loi ket noi Webservice | Error:" + ex1.Message + "| Error StackTrace: " + ex1.StackTrace;

        //            WapController.AlertVnmCharging(info.UserId, "Loi ket noi Webservice | Error:" + ex1.Message, "0", "0", "0", "0", 0, 0, 0, 0, 0, "0", "0");

        //            return false;
        //        }
        //    }
        //}

        //#endregion


        #region Payment 2G

        public string PaymentVNM2G(string msisdn, string serviceId, string serviceState, string cnttype, string path)
        {
            return VNMChargingGW2G.PaymentVNM(msisdn, serviceId, serviceState, cnttype, path);
           
        }

        #endregion

    }
}
