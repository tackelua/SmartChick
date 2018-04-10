using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartChickAPI.Model
{
    [DataContract]
    public class wsActionSetting
    {
        [DataMember]
        public string HubID { get; set; }

        [DataMember]
        public string Feed_Moment { get; set; }

        [DataMember]
        public bool Feed_Mode { get; set; }

        [DataMember]
        public string Active_Moment { get; set; }

        [DataMember]
        public string Active_Speed { get; set; }

        [DataMember]
        public string Active_Time { get; set; }

        [DataMember]
        public bool Active_Mode { get; set; }

        [DataMember]
        public string Open_Gate { get; set; }

        [DataMember]
        public string Close_Gate { get; set; }

        [DataMember]
        public bool Gate_Mode { get; set; }

        [DataMember]
        public string Clean_Moment { get; set; }

        [DataMember]
        public bool Clean_Mode { get; set; }

        [DataMember]
        public string Sterilise_Moment_Day { get; set; }
        [DataMember]
        public string Sterilise_Moment_Time { get; set; }
        [DataMember]
        public bool Sterilise_Mode { get; set; }

        [DataMember]
        public bool Light_Mode { get; set; }
        [DataMember]
        public string Light_On_Time{ get; set; }
        [DataMember]
        public string Light_Off_Time { get; set; }

    }
}