using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WapXzone_VNM.Hinhnen.UserControlHigh
{
    public partial class Download : System.Web.UI.UserControl
    {
        private int width;
        private string lang;
        private int id;
        private int catID;
        private string chitietGiaodich = string.Empty;
        private string price;

        private string logPrice;

        private string linkStr, linkStr_KD;
        private string telCo;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                
            }
        }
    }
}