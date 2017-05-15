using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising.Lib;
using VmgPortal.Modules.Adsvertising.Lib.DataAccess;
using VmgPortal.Modules.Adsvertising.Lib.Distributor;

namespace VmgPortal.Modules.Adsvertising
{
	public class Advertisement
	{	
		private string _position = string.Empty;
		public string Position
		{
			get { return _position;}
			set {_position = value;}
		}

	    public HorizontalAlign Align { get; set; }

	    public int Param { get; set; }

	    private string _channel = "";
        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        private Literal _content;
        public Literal Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _lang = "";
        public string Lang
        {
            get { return _lang; }
            set { _lang = value; }
        }

        private string _width = "";
        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Literal GetNewAds(DataRow curData)
		{
		    using (var retVal = new Literal())
		    {
                string width = curData["Advertise_Width"].ToString();
                string height = curData["Advertise_Height"].ToString();
                if (ConvertUtility.ToInt32(width) == -1)
                    width = "99%";

                string path = AppEnv.GetSetting("urldata") + "/" + curData["Advertise_Path"];
                switch (curData["Advertise_Type"].ToString())
                {
                    case "image":
                        {
                            string link = curData["Advertise_RedirectURL"].ToString();
                            if (link.IndexOf("?") > 0)
                                link += "&lang=" + Lang + "&w=" + Width;
                            else
                                link += "?lang=" + Lang + "&w=" + Width;

                            retVal.Text = "<a href=\"" + link + "\"><img border=0 ";
                            retVal.Text += "src=\"" + path + "\" ";
                            retVal.Text += "width=\"" + width + "\" ";
                            if (width != "99%")
                            {
                                retVal.Text += "height=\"" + height + "\">";
                            }
                            retVal.Text += "</img></a>";
                        }
                        break;
                }                
                return retVal;
		    }
		}

        public string GetAds()
        {
            DataSet ds = AdvertiseDistributor.GetAvailables(Position, Param, Channel);
            if (ds.Tables.Count < 2)
            {
                return "";
            }

            DataTable source = ds.Tables[0];
            DataTable dtPosition = ds.Tables[1];
            if (source != null && source.Rows.Count > 0)
            {
                string lit = "";

                foreach (DataRow row in source.Rows)
                {                    
                    Literal newLit = GetNewAds(row);
                    lit += "<div style=\"padding: 0; text-align: center;\">" + newLit.Text;
                    if (ConvertUtility.ToString(dtPosition.Rows[0]["Pos_SeparateCode"]) != "")
                    {
                        var litSeparate = new Literal { Text = "<div class=\"clear" + ConvertUtility.ToInt32(dtPosition.Rows[0]["Pos_SeparateCode"])  + "px\"></div>" };
                        lit += litSeparate;
                    }
                    lit += "</div>";
                }
                
                return lit;
            }

            return "";
        }
	}
}
