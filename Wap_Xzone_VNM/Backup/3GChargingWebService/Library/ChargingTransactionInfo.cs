using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3GChargingWebService.Library
{
    public class ChargingTransactionInfo
    {
        private string userId;
        private string serviceId;
        private string contentCode;
        private string contentType;
        private string cpName;
        private string cpId;
        private string userName;
        private string userPass;
        private string serviceState;
        private string desc;
        private DateTime transDate;

        public ChargingTransactionInfo()
        {
            cpName = "HTC";
            cpId = "0000";
            contentCode = "1";
            contentType = "1";
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }
        public string ContentCode
        {
            get { return contentCode; }
            set { contentCode = value; }
        }
        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }
        public string CpName
        {
            get { return cpName; }
            set { cpName = value; }
        }
        public string CpId
        {
            get { return cpId; }
            set { cpId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string UserPass
        {
            get { return userPass; }
            set { userPass = value; }
        }
        public string ServiceState
        {
            get { return serviceState; }
            set { serviceState = value; }
        }
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }
        public DateTime TransDate
        {
            get { return transDate; }
            set { transDate = value; }
        }
    }
}