using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels
{
    public class FlightSearchRequest
    {
        [JsonProperty("originLocationCode")]
        public string OriginLocationCode { get; set; }
        [JsonProperty("destinationLocationCode")]
        public string DestinationLocationCode { get; set; }
        [JsonProperty("departureDate")]
        public string DepartureDate { get; set; }
        [JsonProperty("returnDate")]
        public string ReturnDate { get; set; }
        [JsonProperty("adults")]
        public int Adults { get; set; }
        [JsonProperty("children")]
        public int? Children { get; set; }
        [JsonProperty("infants")]
        public int? Infants { get; set; }
        [JsonProperty("travelClass")]
        public TravelClass? TravelClass { get; set; }
        [JsonProperty("includedAirlineCodes")]
        public string IncludedAirlineCodes { get; set; }
        [JsonProperty("excludedAirlineCodes")]
        public string ExcludedAirlineCodes { get; set; }
        [JsonProperty("nonStop")]
        public bool NonStop { get; set; }
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
        [JsonProperty("maxPrice")]
        public int? MaxPrice { get; set; }
        [JsonProperty("max")]
        public int? Max { get; set; }

    }
}
