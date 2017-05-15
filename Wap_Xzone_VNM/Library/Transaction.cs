using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using log4net;
using System.Text;
using WapXzone_VNM.Library.Component.Transaction;
using WapXzone_VNM.Library.Utilities;
namespace WapXzone_VNM.Library
{
    public class Transaction
    {
        public static void Success(string telCo, string msisdn, string price, string link, string content_id, string detail, int type)
        {


            //luu giao dich
            TransactionInfo trans = new TransactionInfo();
            trans.Wap_Transaction_Link = link;
            trans.Wap_Transaction_Mobile = msisdn;
            trans.Wap_Transaction_Operator = telCo;
            trans.Wap_Transaction_Portal = telCo;
            trans.Wap_TransactionDetail = detail;
            trans.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            trans.Wap_TransactionName = content_id;
            trans.Wap_TransactionOn = DateTime.Now;
            trans.Wap_TransactionType = type;
            trans.Is3g = 0;
            TransactionController.Insert_Transaction(trans);
            //end luu giao dich 
        }

        public static void SuccessNew(string telCo, string msisdn, string price, string link, string content_id, string detail, int type)
        {


            //luu giao dich
            TransactionInfo trans = new TransactionInfo();
            trans.Wap_Transaction_Link = link;
            trans.Wap_Transaction_Mobile = msisdn;
            trans.Wap_Transaction_Operator = telCo;
            trans.Wap_Transaction_Portal = telCo;
            trans.Wap_TransactionDetail = detail;
            trans.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            trans.Wap_TransactionName = content_id;
            trans.Wap_TransactionOn = DateTime.Now;
            trans.Wap_TransactionType = type;
            trans.Is3g = ConvertUtility.ToInt32(HttpContext.Current.Session["is3g"]);
            TransactionController.Insert_Transaction_New(trans);
            //end luu giao dich 
        }
        public static void Failure(string telCo, string msisdn, string price, string link, string content_id, string detail, int type, string ErrorDetail)
        {
            TransactionLogInfo _log = new TransactionLogInfo();
            //Luu vao bang transaction log truong hop giao dich that bai
            _log.Wap_Transaction_Link = link;
            _log.Wap_Transaction_Mobile = msisdn;
            _log.Wap_Transaction_Operator = telCo;
            _log.Wap_Transaction_Portal = telCo;
            _log.Wap_TransactionDetail = detail;
            _log.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            _log.Wap_TransactionName = content_id;
            _log.Wap_TransactionOn = DateTime.Now;
            _log.Wap_TransactionType = type;
            _log.ErrorCode = 1;//That bai
            _log.ErrorDetail = ErrorDetail;
            _log.Is3g = 0;
            TransactionController.Insert_TransactionLog(_log);
        }

        public static void FailureNew(string telCo, string msisdn, string price, string link, string content_id, string detail, int type, string ErrorDetail)
        {
            TransactionLogInfo _log = new TransactionLogInfo();
            //Luu vao bang transaction log truong hop giao dich that bai
            _log.Wap_Transaction_Link = link;
            _log.Wap_Transaction_Mobile = msisdn;
            _log.Wap_Transaction_Operator = telCo;
            _log.Wap_Transaction_Portal = telCo;
            _log.Wap_TransactionDetail = detail;
            _log.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
            _log.Wap_TransactionName = content_id;
            _log.Wap_TransactionOn = DateTime.Now;
            _log.Wap_TransactionType = type;
            _log.ErrorCode = 1;//That bai
            _log.ErrorDetail = ErrorDetail;
            _log.Is3g = ConvertUtility.ToInt32(HttpContext.Current.Session["is3g"]);
            TransactionController.Insert_TransactionLog_New(_log);
        }
    }
}
