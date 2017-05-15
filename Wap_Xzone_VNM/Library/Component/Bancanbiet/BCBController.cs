using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Library.Component.Bancanbiet
{
    public class BCBController
    {
        public BCBController() { 
        }
        //Lay tat ca ngan hang
        public static DataTable GetAllBankName()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_ATM_BankGetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca Location
        public static DataTable GetAllLocation()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_ATM_LocationGetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca Zone
        public static DataTable GetAllZone()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_ATM_ZoneGetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca ngan hang lien minh
        public static DataTable GetAllBankNameRelation(int linkid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_ATM_BankRelationGetAll",linkid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca Thanh pho co taxi
        public static DataTable GetAllCity()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_City_TaxiGetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca taxi theo Thanh pho 
        public static DataTable GetAllTaxyByCity(int cityid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_City_TaxiGetAllByCity", cityid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
       //Lay thanh pho cua ATM
        public static DataTable GetAllCityOfATM()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_City_BankGetAll");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin ngan hang
        public static DataTable GetBankNameByID(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_ATM_BankGetInfo",id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra cac phuong xa trong thanh pho
        public static DataTable GetAllByCityID(int cityid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_GetByCity_Bank",cityid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra cac di chi cu the theo bankid va zoneid
        public static DataTable GetAllDetailByBankIDAndZoneID(int bankid,int zoneid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "VNM_Wap_GetAllDetailByBankIDAndZoneID", bankid,zoneid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //cap nhat lai du lieu
        public static void Update_BankName(int bankid,string banknamekd)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "Update_ATM_Bank_NameKDByBankID", bankid, banknamekd);
        }
        public static void Update_LocationName(int localtionid, string addresskd)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "Update_ATM_Location_AddressKDByLocationID", localtionid, addresskd);
        }
        public static void Update_ZoneName(int zoneid, string namekd)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString, "Update_ATM_ZoneByZoneID", zoneid, namekd);
        }
        //Search ATM
        public static DataTable GetAllWap_ATMLocation_ItemByKey(string strKeySearch,int bankid, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionXzone"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Vnm_ATM_Location_SearchByKey", dbConn);
            dbCmd.Parameters.AddWithValue("@KeySeach", strKeySearch);
            dbCmd.Parameters.AddWithValue("@BankID", bankid);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalRecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
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
    }
}
