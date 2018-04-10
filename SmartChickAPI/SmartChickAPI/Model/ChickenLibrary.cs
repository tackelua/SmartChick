using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsChickenLibrary
    {
        public string TypeID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string SpeciesID{ get; set; }

        public int DayOld_Min { get; set; }
        public int DayOld_Max { get; set; }
        public int Temperature_Min { get; set; }
        public int Temperature_Max { get; set; }

        public int Humidity_Min { get; set; }
        public int Humidity_Max { get; set; }

        public string Lighting_Duration { get; set; }

        public double Food_Amount { get; set; }
        public int Food_Eat_No { get; set; }
        public double Weight { get; set; }


    }
}