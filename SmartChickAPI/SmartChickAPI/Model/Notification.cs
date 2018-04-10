using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI
{
    public class wsNotifications
    {
        public int ID { get; set; }
        public int Noti_Code { get; set; }
        public bool Noti_Action { get; set; }
        public bool Noti_Read { get; set; }
        public string HubId { get; set; }
        public string Date_Time{ get; set; }


    }
}