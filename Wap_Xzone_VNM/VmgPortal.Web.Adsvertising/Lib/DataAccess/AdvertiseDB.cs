using System.Data;
using System.Data.SqlClient;

namespace VmgPortal.Modules.Adsvertising.Lib.DataAccess
{
	public class AdvertiseDB
	{
        public static DataSet GetAvailables(string positionName, int paramId, string channel)
        {
            DataSet retVal;
            var dbConn = new SqlConnection(AppEnv.ConnectionString);

            var dbCmd = new SqlCommand("Wap_Adv_Advertises_GetAvailables", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@PositionName", positionName);
            dbCmd.Parameters.AddWithValue("@AttachID", paramId);
            dbCmd.Parameters.AddWithValue("@Channel", channel);
            try
            {
                retVal = new DataSet();
                var da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
	}
}

