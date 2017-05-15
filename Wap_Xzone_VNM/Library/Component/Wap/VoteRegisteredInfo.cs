﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WapXzone_VNM.Library.Component.Wap
{
    public class VoteRegisteredInfo
    {
        public int ID { get; set; }

        public string User_ID { get; set; }

        public string Request_ID { get; set; }

        public string Service_ID { get; set; }

        public string Command_Code { get; set; }

        public int Service_Type { get; set; }

        public int Charging_Count { get; set; }

        public int FailedChargingTime { get; set; }

        public DateTime RegisteredTime { get; set; }

        public DateTime ExpiredTime { get; set; }

        public string Registration_Channel { get; set; }

        public int Status { get; set; }

        public string Operator { get; set; }

        public int IsLock { get; set; }

        public int Vote_Count { get; set; }

        public int Vote_PersonId { get; set; }

        public int IsDislike { get; set; }

        public int Dislike_Count { get; set; }

        public int Dislike_PersonId { get; set; }

    }
}