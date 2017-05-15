using System;
using System.Collections.Generic;
using System.Web;

namespace WapXzone_VNM.Library.Component.Transaction
{
    public class Transaction_LogInfo
    {
        private int _wap_TransactionID;
        public int Wap_TransactionID
        {
            get { return _wap_TransactionID; }
            set { _wap_TransactionID = value; }
        }

        private string _wap_TransactionName;
        public string Wap_TransactionName
        {
            get { return _wap_TransactionName; }
            set { _wap_TransactionName = value; }
        }

        private int _wap_TransactionType;
        public int Wap_TransactionType
        {
            get { return _wap_TransactionType; }
            set { _wap_TransactionType = value; }
        }

        private string _wap_TransactionDetail;
        public string Wap_TransactionDetail
        {
            get { return _wap_TransactionDetail; }
            set { _wap_TransactionDetail = value; }
        }

        private DateTime _wap_TransactionOn;
        public DateTime Wap_TransactionOn
        {
            get { return _wap_TransactionOn; }
            set { _wap_TransactionOn = value; }
        }

        private string _wap_Transaction_Mobile;
        public string Wap_Transaction_Mobile
        {
            get { return _wap_Transaction_Mobile; }
            set { _wap_Transaction_Mobile = value; }
        }

        private string _wap_Transaction_Portal;
        public string Wap_Transaction_Portal
        {
            get { return _wap_Transaction_Portal; }
            set { _wap_Transaction_Portal = value; }
        }

        private string _wap_Transaction_Operator;
        public string Wap_Transaction_Operator
        {
            get { return _wap_Transaction_Operator; }
            set { _wap_Transaction_Operator = value; }
        }

        private string _wap_Transaction_Link;
        public string Wap_Transaction_Link
        {
            get { return _wap_Transaction_Link; }
            set { _wap_Transaction_Link = value; }
        }
        private double _wap_Transaction_Amount;
        public double Wap_Transaction_Amount
        {
            get;
            set;
        }
        private int _errorCode;
        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
        private string _ErrorDetail;
        public string ErrorDetail
        {
            get { return _ErrorDetail; }
            set { _ErrorDetail = value; }
        }
        
    }
}
