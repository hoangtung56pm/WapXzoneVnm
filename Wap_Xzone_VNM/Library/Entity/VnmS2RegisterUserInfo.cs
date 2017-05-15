using System;

namespace WapXzone_VNM.Library.Entity
{
    public class VnmS2RegisterUserInfo
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RequestId { get; set; }

        public string ServiceId { get; set; }

        public string CommandCode { get; set; }

        public string SubCode { get; set; }

        public string Operator { get; set; }

        public string RegisteredChannel { get; set; }

        public int Status { get; set; }

        public DateTime RegisteredTime { get; set; }
    }
}