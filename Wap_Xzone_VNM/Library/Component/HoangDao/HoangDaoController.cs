using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.Configuration;
using WapXzone_VNM.Library.SQLHelper;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;

using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.HoangDao
{
    public class HoangdaoController
    {
        public HoangdaoController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }        
        //Lay noi dung hoang dao theo ngay
        public static DataTable GetByTypeAndDateHasCache(int Type, string ActionDate)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.GetByTypeAndDate";
            string param = "Type=" + Type + "&ActionDate=" + ActionDate;            
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetByTypeAndDate(Type, ActionDate);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetByTypeAndDate(int Type, string ActionDate)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_Hodas_GetByTypeAndDate]", dbConn);
            dbCmd.Parameters.AddWithValue("@Type", Type);
            dbCmd.Parameters.AddWithValue("@ActionDate", ActionDate);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        //Lay noi dung hoang dao ngay theo ID
        public static DataTable GetHodaDateByIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.GetHodaDateByID";
            string param = "ID=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetHodaDateByID(ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetHodaDateByID(int ID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_Hodas_GetAllById]", dbConn);
            dbCmd.Parameters.AddWithValue("@ID", ID);            
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        //Lay noi dung hoang dao theo tuan
        public static DataTable GetByTypeAndMonthAndWeekHasCache(int Type, string Month, string Week)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.GetByTypeAndMonthAndWeek";
            string param = "Type=" + Type + "&Month=" + Month + "&Week=" + Week;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetByTypeAndMonthAndWeek(Type, Month, Week);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetByTypeAndMonthAndWeek(int Type, string Month, string Week)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_HodaWs_GetByTypeAndMonthAndWeek]", dbConn);
            dbCmd.Parameters.AddWithValue("@Type", Type);
            dbCmd.Parameters.AddWithValue("@Month", Month);
            dbCmd.Parameters.AddWithValue("@Week", Week);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        //Lay noi dung hoang dao TUAN theo ID
        public static DataTable GetHodaWeekByIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.Stk_HodaWs_GetAllById";
            string param = "ID=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetHodaWeekByID(ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetHodaWeekByID(int ID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_HodaWs_GetAllById]", dbConn);
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        //Lay noi dung hoang dao theo thang
        public static DataTable GetByTypeAndMonthHasCache(int Type, string Month)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.GetByTypeAndMonth";
            string param = "Type=" + Type + "&Month=" + Month;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetByTypeAndMonth(Type, Month);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetByTypeAndMonth(int Type, string Month)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_HodaMs_GetByTypeAndMonth]", dbConn);
            dbCmd.Parameters.AddWithValue("@Type", Type);
            dbCmd.Parameters.AddWithValue("@Month", Month);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        //Lay noi dung hoang dao THANG theo ID
        public static DataTable GetHodaMonthByIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_Hoangdao.Stk_HodaMs_GetAllById";
            string param = "ID=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetHodaMonthByID(ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        private static DataTable GetHodaMonthByID(int ID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[Stk_HodaMs_GetAllById]", dbConn);
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static readonly string[,] CungHoangdao = new string[13, 3]
        {
            {"Title","Title_Unicode","DateTime"},                                    
            {"Duong Cuu","Dương Cưu","21/3-19/4"},
            {"Kim Nguu","Kim Ngưu","20/4-20/5"},
            {"Song Sinh","Song Sinh","21/5-21/6"},
            {"Cu Giai","Cự Giải","22/6-22/7"},
            {"Su Tu","Sư Tử","23/7-22/8"},
            {"Xu Nu","Xử Nữ","23/8-22/9"},
            {"Thien Binh","Thiên Bình","23/9-22/10"},
            {"Bo Cap","Bò Cạp","23/10-21/11"},
            {"Nhan Ma","Nhân Mã","22/11-21/12"}, 
            {"Ma Ket","Ma Kết","22/12-19/1"},
            {"Bao Binh","Bảo Bình","20/1-18/2"},
            {"Song Ngu","Song Ngư","19/2-20/3"},
        };        
    }
}
