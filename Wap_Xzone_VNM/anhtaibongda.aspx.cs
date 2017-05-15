using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.SQLHelper;

namespace WapXzone_VNM
{
    public partial class anhtaibongda : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                    }
                }

                if (Session["msisdn"] != null)
                {
                    
                    var entity = new ViSport_S2_Registered_UsersInfo();
                    entity.User_ID = Session["msisdn"].ToString();
                    entity.Request_ID = "0";
                    entity.Service_ID = "979";
                    entity.Command_Code = "BD";
                    entity.Service_Type = 1;
                    entity.Charging_Count = 0;
                    entity.FailedChargingTimes = 0;
                    entity.RegisteredTime = DateTime.Now;
                    entity.ExpiredTime = DateTime.Now.AddDays(1);
                    entity.Registration_Channel = "WAP";
                    entity.Status = 1;
                    entity.Operator = "vnmobile";
                    entity.Point = 100;

                    InsertSportGameHeroRegisterUser(entity);

                }

                Response.Redirect("http://visport.vn");
            }
        }

        public DataTable InsertSportGameHeroRegisterUser(ViSport_S2_Registered_UsersInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_Registered_Users_Insert"

                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTimes
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Point

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

    }



    public class ViSport_S2_Registered_UsersInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _user_ID;
        public string User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private string _request_ID;
        public string Request_ID
        {
            get { return _request_ID; }
            set { _request_ID = value; }
        }

        private string _service_ID;
        public string Service_ID
        {
            get { return _service_ID; }
            set { _service_ID = value; }
        }

        private string _command_Code;
        public string Command_Code
        {
            get { return _command_Code; }
            set { _command_Code = value; }
        }

        private int _service_Type;
        public int Service_Type
        {
            get { return _service_Type; }
            set { _service_Type = value; }
        }

        private int _charging_Count;
        public int Charging_Count
        {
            get { return _charging_Count; }
            set { _charging_Count = value; }
        }

        private int _failedChargingTimes;
        public int FailedChargingTimes
        {
            get { return _failedChargingTimes; }
            set { _failedChargingTimes = value; }
        }

        private DateTime _registeredTime;
        public DateTime RegisteredTime
        {
            get { return _registeredTime; }
            set { _registeredTime = value; }
        }

        private DateTime _expiredTime;
        public DateTime ExpiredTime
        {
            get { return _expiredTime; }
            set { _expiredTime = value; }
        }

        private string _registration_Channel;
        public string Registration_Channel
        {
            get { return _registration_Channel; }
            set { _registration_Channel = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _operator;
        public string Operator
        {
            get { return _operator; }
            set { _operator = value; }
        }

        public int IsLock { get; set; }

        public int Point { get; set; }


    }

}