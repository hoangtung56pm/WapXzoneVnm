using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.SQLHelper;

namespace WapXzone_VNM.Library.Component.Nhaccho
{
    public class NhacchoController
    {
        public NhacchoController() { }
        //Lay thong tin ring  back tone
        public static DataTable GetRingBackToneDetailByID(int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_RBT_Item_GetInfo", ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatID(int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_RBT_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca chuyen muc nhac chuong va order theo thu tu
        public static DataTable GetAllCategoryExeptCatID(int portalID, int displayType, int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_RingBackTone_CategoryAll", portalID, displayType, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ringbacktone theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllRingBackToneByCategoryAndDisplayType(int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_RingBackTone_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
            dbCmd.Parameters.AddWithValue("@DisplayType", displayType);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
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

        //Search RingBackTone

        public static DataTable GetAllWap_RingTone_ItemByKey(string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Vnm_RingBackTone_Item_SearchByKey", dbConn);
            dbCmd.Parameters.AddWithValue("@KeySeach", strKeySearch);
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
