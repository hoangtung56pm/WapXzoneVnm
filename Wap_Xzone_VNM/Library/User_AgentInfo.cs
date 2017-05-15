using System;
using System.Collections.Generic;

using System.Web;

namespace WapXzone_VNM.Library
{
    public class User_AgentInfo
    {
        private string _device_os;
        public string device_os
        {
            get { return _device_os; }
            set { _device_os = value; }
        }

        private string _mobile_browser;
        public string mobile_browser
        {
            get { return _mobile_browser; }
            set { _mobile_browser = value; }
        }

        private string _resolution_width;
        public string resolution_width
        {
            get { return _resolution_width; }
            set { _resolution_width = value; }
        }

        private string _resolution_height;
        public string resolution_height
        {
            get { return _resolution_height; }
            set { _resolution_height = value; }
        }

        private string _model_name;
        public string model_name
        {
            get { return _model_name; }
            set { _model_name = value; }
        }
        private string _brand_name;
        public string brand_name
        {
            get { return _brand_name; }
            set { _brand_name = value; }
        }
    }
}
