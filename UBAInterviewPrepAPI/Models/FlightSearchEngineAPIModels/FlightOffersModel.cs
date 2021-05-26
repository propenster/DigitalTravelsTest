using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Models.FlightSearchEngineAPIModels
{
    public class FlightOffersModel
    {
        public string OriginLocationCode { get; set; }
        public string DestinationLocationCode { get; set; }
        public string DepartureDate { get; set; } //req
        public string ReturnDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public TravelClass TravelClass { get; set; } 
        public string IncludedAirlineCodes { get; set; }
        public string ExcludedAirlineCodes { get; set; }

    }
}
