using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsChicken
    {
        public string HubID { get; set; }
        public string SpeciesID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Outside { get; set; }
        public int Inside { get; set; }
        public string DayOld { get; set; }
        public double Weight { get; set; }
        public double BodyTemp { get; set; }
    }
}