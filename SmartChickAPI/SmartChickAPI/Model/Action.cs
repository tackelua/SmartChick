using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartChickAPI.Model
{
    [DataContract]
    public class wsAction
    {
        [DataMember]
        public string HubID { get; set; }

        [DataMember]
        public bool Feed_Status { get; set; }

        [DataMember]
        public bool Active_Status { get; set; }

        [DataMember]
        public int Active_Speed { get; set; }

        [DataMember]
        public bool Gate_Status { get; set; }

        [DataMember]
        public bool Clean_Status { get; set; }

        [DataMember]
        public bool Sterilise_Status { get; set; }
        [DataMember]
        public bool Light_Status { get; set; }
    }
}