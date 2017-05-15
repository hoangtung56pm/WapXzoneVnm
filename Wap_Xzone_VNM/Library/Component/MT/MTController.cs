using System;
using System.Collections.Generic;
using System.Web;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;

namespace WapXzone_VNM.Library.Component.MT
{
    public class MTController
    {
        public MTController() { }

        public static void SmsMtInsertNew(MTInfo obj)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Insert", obj.User_ID, obj.Message, obj.Service_ID, obj.Command_Code, obj.Message_Type, obj.Request_ID, obj.Total_Message, obj.Message_Index, obj.IsMore, obj.Content_Type, obj.ServiceType, obj.PartnerID, obj.Operator);
        }

        public static void SmsMtInsertNew_tracham(MTInfo obj, DateTime ResponseTime)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Insert_tracham", obj.User_ID, obj.Message, obj.Service_ID, obj.Command_Code, obj.Message_Type, obj.Request_ID, obj.Total_Message, obj.Message_Index, obj.IsMore, obj.Content_Type, obj.ServiceType, obj.PartnerID, obj.Operator, ResponseTime);
        }

        public static void SmsMtInsert(MTInfo obj)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Insert", obj.User_ID, obj.Message, obj.Service_ID, obj.Command_Code, obj.Message_Type, obj.Request_ID, obj.Total_Message, obj.Message_Index, obj.IsMore, obj.Content_Type, obj.ServiceType, obj.PartnerID, obj.Operator);
        }

        public static int SMS_MTWaittingInsert(MTWaittingInfo obj)
        {
            return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Waiting_Insert", obj.User_ID, obj.Message, obj.Service_ID, obj.Command_Code, obj.Message_Type, obj.Request_ID, obj.Total_Message, obj.Message_Index, obj.IsMore, obj.Content_Type, obj.ServiceType, obj.UniqueId, obj.ExpiredDate,obj.PartnerID, obj.Operator);
        }

        public static int SMS_MTXSWaittingInsert(MTWaittingInfo obj)
        {
            return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MTXS_Waiting_Insert", obj.User_ID, obj.Message, obj.Service_ID, obj.Command_Code, obj.Message_Type, obj.Request_ID, obj.Total_Message, obj.Message_Index, obj.IsMore, obj.Content_Type, obj.ServiceType, obj.UniqueId, obj.ExpiredDate, obj.PartnerID, obj.Operator);
        }
    }
}
