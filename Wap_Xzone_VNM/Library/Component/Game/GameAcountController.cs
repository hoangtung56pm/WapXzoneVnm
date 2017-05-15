using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WapXzone_VNM.Library.Component.Game
{
    public class GameAcountController
    {       
        public bool Login(string _username, int _service_id)
        {

            //Logout();
            DataTable dtuser = GameController.Getuserinfo(_username, _service_id);

            if (dtuser != null && dtuser.Rows.Count > 0)
            { 
                return true;
            }

            return false;
        }
       
    }
}