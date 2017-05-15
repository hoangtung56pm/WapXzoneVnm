using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace CDRService
{
    public class Controller
    {
        private static string connectString = System.Configuration.ConfigurationSettings.AppSettings["connectionString"];
      
        public static DataTable GetAllTransaction(DateTime fromTime, DateTime toTime)
        {
            DataSet ds = SqlHelper.ExecuteDataset(connectString, "CDR_Mobifone_Wap_Transaction_GetAllNew", fromTime, toTime);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}
