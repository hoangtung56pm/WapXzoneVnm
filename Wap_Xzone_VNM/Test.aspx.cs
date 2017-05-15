using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jsonObj = new
            {
                Name = "test",
                Avatar = "Upload/Game/2998/Avatar/1.JPG&size=60x60"
            };
            var jScriptSerializer = new JavaScriptSerializer();
            string jsonClient = jScriptSerializer.Serialize(jsonObj);
        }
    }
}