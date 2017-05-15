using VmgPortal.Modules.Adsvertising.Lib.Data;
using VmgPortal.Modules.Adsvertising.Lib.DataAccess;

namespace VmgPortal.Modules.Adsvertising.Lib.Distributor
{
	public class PositionDistributor
	{
		private static double GetExpire()
		{
			return Constants.CacheExpire;
		}
        public static PositionInfo GetInfoByPosition(string position, string channel)
        {
            var dataCaching = new DataCaching();
            const string cacheKey = "WapAdvertisePositions.GetInfoByPosition";
            var retVal = (PositionInfo)dataCaching.GetHashCache(cacheKey, position + "_" + channel);
            if (retVal == null)
            {
                retVal = PositionDB.GetInfoByPosition(position, channel);
                dataCaching.SetHashCache(cacheKey, position + "_" + channel, GetExpire(), retVal);
            }
            return retVal;
        }
	}
}
