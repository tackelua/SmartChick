using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsInoculationList
    {
        public string HubID { get; set; }
        public string DaysOld { get; set; }
        public string Medicine { get; set; }
        public string Method { get; set; }
        public string SpeciesID { get; set; }
        public string TypeID { get; set; }


    }
}