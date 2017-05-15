
namespace VmgPortal.Modules.Adsvertising.Lib
{
	public class Constants
	{
		public static string UploadPath
		{
            get { return "/Upload/Ads/WapAdsvertising/"; }
		}

		public static double CacheExpire
		{
            get
            {
                return 3;
            }
		}
		public static bool InZone
		{
			get
			{
			    return true;
			}
		}
	}
}