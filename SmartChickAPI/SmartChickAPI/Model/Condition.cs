using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsCondition
    {
        public string HubID { get; set; }
        public int Temperature_Outside { get; set; }
        public int Temperature_Inside { get; set; }
        public int Temperature_Heater { get; set; }
        public int Humidity_Outside { get; set; }
        public int Humidity_Inside { get; set; }
        public bool Humidity_MistingStatus { get; set; }
        public int Light_Outside { get; set; }
        public int Light_Inside { get; set; }
        public bool Light_Lamp_Status { get; set; }
    }
}