using System;
using System.Data;
using System.Data.SqlClient;
using VmgPortal.Modules.Adsvertising.Lib.Data;

namespace VmgPortal.Modules.Adsvertising.Lib.DataAccess
{
	public class PositionDB
	{
        public static int GetIdByPosition(string position, string channel)
        {
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Wap_Adv_Positions_GetIDByPosition", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Position", position);
            dbCmd.Parameters.AddWithValue("@Channel", channel);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read()) return dr.GetInt32(0);
                else return 0;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static PositionInfo GetInfoByPosition(string position, string channel)
        {
            return GetInfo(GetIdByPosition(position, channel));
        }
 
        public static PositionInfo GetInfo(int posId)
        {
            PositionInfo retVal = null;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);
            var dbCmd = new SqlCommand("Wap_Adv_Positions_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Pos_ID", posId);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new PositionInfo();
                    retVal.Pos_ID = Convert.ToInt32(dr["Pos_ID"]);
                    retVal.Pos_Name = Convert.ToString(dr["Pos_Name"]);
                    retVal.Pos_Position = Convert.ToString(dr["Pos_Position"]);
                    retVal.Pos_Type = Convert.ToString(dr["Pos_Type"]);
                    retVal.Pos_Width = Convert.ToInt32(dr["Pos_Width"]);
                    retVal.Pos_Height = Convert.ToInt32(dr["Pos_Height"]);
                    retVal.Pos_SeparateCode = Convert.ToString(dr["Pos_SeparateCode"]);
                }
                dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
 
	}
}

