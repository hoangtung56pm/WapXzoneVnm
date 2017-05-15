using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.IO;
using System.Data;

namespace VmgPortal.Modules.Adsvertising.Lib.DataAccess
{
	public class AppEnv
	{
        public static string ConnectionString
		{
            get
		    {
                return WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		    }
		}

        public static string GetSetting(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }
	}
}
