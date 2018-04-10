using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsLogs
    {
        public string HubID { get; set; }
        public string Time { get; set; }
        public string Action { get; set; }
        public string Account { get; set; }
    }
}