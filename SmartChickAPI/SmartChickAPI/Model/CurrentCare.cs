using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChickAPI.Model
{
    public class wsCurrentCare
    {
        public string HubID;

        public string SpeciesID;

        public string Name;

        public string Picture;

        public int Temperature_Value;
        public int Temperature_Min;
        public int Temperature_Max;

        public int Humidity_Value;
        public int Humidity_Min;
        public int Humidity_Max;

        public string Lighting_Duration;

        public double Food_Amount;

        public int Food_Eat_No;

        public double Weight;

    }
}