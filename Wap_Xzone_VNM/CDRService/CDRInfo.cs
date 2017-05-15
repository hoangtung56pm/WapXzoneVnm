using System;
using System.Collections.Generic;
using System.Text;

namespace CDRService
{
    class CDRInfo
    {
        private string _Datetime;
        private string _A_Number;
        private string _B_Number;
        private string _EventID;
        private string _CPID;
        private string _ContentID;
        private string _Status;
        private string _Cost;
        private string _ChannelType;
        private string _Information;

        public string Datetime
        {
            get;
            set;
        }
        public string A_Number
        {
            get;
            set;
        }
        public string B_Number
        {
            get;
            set;
        }
        public string EventID
        {
            get;
            set;
        }
        public string CPID
        {
            get;
            set;
        }
        public string ContentID
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string Cost
        {
            get;
            set;
        }
        public string ChannelType
        {
            get;
            set;
        }
        public string Information
        {
            get;
            set;
        }
    }
}
