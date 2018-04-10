using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartChickAPI.Model
{
    [DataContract]
    public class wsUser
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Sexual { get; set; }

        [DataMember]
        public int YearOld { get; set; }

        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}