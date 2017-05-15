using System.Data;
using VmgPortal.Modules.Adsvertising.Lib.DataAccess;

namespace VmgPortal.Modules.Adsvertising.Lib.Distributor
{	
	public class AdvertiseDistributor
	{
        //private static double GetExpire()
        //{
        //    return Constants.CacheExpire;
        //}
        public static DataSet GetAvailables(string positionId, int paramId, string channel)
		{
            //DataCaching dataCaching = new DataCaching();
            //string _cacheKey = "Advertise.GetAvailables";		
            //string _param = _positionID.ToString() + "_" + _paramID.ToString() + "Lang=" + AppEnv.GetLanguage();
            //DataTable _retVal = (DataTable) dataCaching.GetHashCache(_cacheKey,_param);
            //if (_retVal == null)
            //{
            //    _retVal = AdvertiseDB.GetAvailables(_positionID,_paramID);
            //    dataCaching.SetHashCache(_cacheKey,_param,GetExpire(),_retVal);
            //}
            //return _retVal;

            DataSet retVal = AdvertiseDB.GetAvailables(positionId, paramId, channel);
            return retVal;
		}
	}
}
