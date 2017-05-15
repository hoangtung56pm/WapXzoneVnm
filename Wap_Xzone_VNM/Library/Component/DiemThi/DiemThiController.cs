using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.Configuration;
using WapXzone_VNM.Library.SQLHelper;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.DiemThi
{
    public class DiemThiController
    {
        public DiemThiController()
        {
        }
        
        public static DataTable GetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "DiemThi_MaTruong_GetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //Tăng số lần download
        public static void Update(string TenTruong_KD, int ID)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "DiemThi_MaTruong_Update", TenTruong_KD, ID);
        } 
        //Lay thong tin chuyen muc
        public static DataTable TimKiem(string keyWord)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "DiemThi_MaTruong_TimKiem", keyWord);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;            
        }

        //Lay dap an
        public static DataTable TSDH_Dapans_GetData(string khoi, string mon, string de)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "TSDH_Dapans_GetData", khoi, mon, de);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }   
    }
}
