using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class Meta
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public class Departure
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }

        [JsonProperty("at")]
        public DateTime At { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }

        [JsonProperty("at")]
        public DateTime At { get; set; }
    }

    public class Aircraft
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("320")]
        public string _320 { get; set; }

        [JsonProperty("321")]
        public string _321 { get; set; }

        [JsonProperty("333")]
        public string _333 { get; set; }

        [JsonProperty("351")]
        public string _351 { get; set; }

        [JsonProperty("359")]
        public string _359 { get; set; }

        [JsonProperty("388")]
        public string _388 { get; set; }

        [JsonProperty("738")]
        public string _738 { get; set; }

        [JsonProperty("773")]
        public string _773 { get; set; }

        [JsonProperty("787")]
        public string _787 { get; set; }

        [JsonProperty("789")]
        public string _789 { get; set; }

        [JsonProperty("77W")]
        public string _77W { get; set; }
    }

    public class Operating
    {
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }
    }

    public class Segment
    {
        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("operating")]
        public Operating Operating { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("numberOfStops")]
        public int NumberOfStops { get; set; }

        [JsonProperty("blacklistedInEU")]
        public bool BlacklistedInEU { get; set; }
    }

    public class Itinerary
    {
        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }
    }

    public class Fee
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }

        [JsonProperty("grandTotal")]
        public string GrandTotal { get; set; }
    }

    public class PricingOptions
    {
        [JsonProperty("fareType")]
        public List<string> FareType { get; set; }

        [JsonProperty("includedCheckedBagsOnly")]
        public bool IncludedCheckedBagsOnly { get; set; }
    }

    public class IncludedCheckedBags
    {
        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }

        [JsonProperty("quantity")]
        public int? Quantity { get; set; }
    }

    public class FareDetailsBySegment
    {
        [JsonProperty("segmentId")]
        public string SegmentId { get; set; }

        [JsonProperty("cabin")]
        public string Cabin { get; set; }

        [JsonProperty("fareBasis")]
        public string FareBasis { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("includedCheckedBags")]
        public IncludedCheckedBags IncludedCheckedBags { get; set; }

        [JsonProperty("brandedFare")]
        public string BrandedFare { get; set; }
    }

    public class TravelerPricing
    {
        [JsonProperty("travelerId")]
        public string TravelerId { get; set; }

        [JsonProperty("fareOption")]
        public string FareOption { get; set; }

        [JsonProperty("travelerType")]
        public string TravelerType { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("fareDetailsBySegment")]
        public List<FareDetailsBySegment> FareDetailsBySegment { get; set; }
    }

    public class Datum
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("instantTicketingRequired")]
        public bool InstantTicketingRequired { get; set; }

        [JsonProperty("nonHomogeneous")]
        public bool NonHomogeneous { get; set; }

        [JsonProperty("oneWay")]
        public bool OneWay { get; set; }

        [JsonProperty("lastTicketingDate")]
        public string LastTicketingDate { get; set; }

        [JsonProperty("numberOfBookableSeats")]
        public int NumberOfBookableSeats { get; set; }

        [JsonProperty("itineraries")]
        public List<Itinerary> Itineraries { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("pricingOptions")]
        public PricingOptions PricingOptions { get; set; }

        [JsonProperty("validatingAirlineCodes")]
        public List<string> ValidatingAirlineCodes { get; set; }

        [JsonProperty("travelerPricings")]
        public List<TravelerPricing> TravelerPricings { get; set; }
    }

    public class PVG
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class BKK
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class KUL
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class HKG
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class TPE
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class MNL
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class NRT
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class AUH
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class HAN
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class SIN
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class SGN
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class DOH
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class SYD
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class HND
    {
        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class Locations
    {
        [JsonProperty("PVG")]
        public PVG PVG { get; set; }

        [JsonProperty("BKK")]
        public BKK BKK { get; set; }

        [JsonProperty("KUL")]
        public KUL KUL { get; set; }

        [JsonProperty("HKG")]
        public HKG HKG { get; set; }

        [JsonProperty("TPE")]
        public TPE TPE { get; set; }

        [JsonProperty("MNL")]
        public MNL MNL { get; set; }

        [JsonProperty("NRT")]
        public NRT NRT { get; set; }

        [JsonProperty("AUH")]
        public AUH AUH { get; set; }

        [JsonProperty("HAN")]
        public HAN HAN { get; set; }

        [JsonProperty("SIN")]
        public SIN SIN { get; set; }

        [JsonProperty("SGN")]
        public SGN SGN { get; set; }

        [JsonProperty("DOH")]
        public DOH DOH { get; set; }

        [JsonProperty("SYD")]
        public SYD SYD { get; set; }

        [JsonProperty("HND")]
        public HND HND { get; set; }
    }

    public class Currencies
    {
        [JsonProperty("EUR")]
        public string EUR { get; set; }
    }

    public class Carriers
    {
        [JsonProperty("QR")]
        public string QR { get; set; }

        [JsonProperty("PR")]
        public string PR { get; set; }

        [JsonProperty("CI")]
        public string CI { get; set; }

        [JsonProperty("EK")]
        public string EK { get; set; }

        [JsonProperty("MU")]
        public string MU { get; set; }

        [JsonProperty("TG")]
        public string TG { get; set; }

        [JsonProperty("EY")]
        public string EY { get; set; }

        [JsonProperty("CX")]
        public string CX { get; set; }

        [JsonProperty("QF")]
        public string QF { get; set; }

        [JsonProperty("VN")]
        public string VN { get; set; }

        [JsonProperty("NH")]
        public string NH { get; set; }

        [JsonProperty("MH")]
        public string MH { get; set; }

        [JsonProperty("SQ")]
        public string SQ { get; set; }
    }

    public class Dictionaries
    {
        [JsonProperty("locations")]
        public Locations Locations { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("currencies")]
        public Currencies Currencies { get; set; }

        [JsonProperty("carriers")]
        public Carriers Carriers { get; set; }
    }

    public class FlightSearchResponse
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("dictionaries")]
        public Dictionaries Dictionaries { get; set; }
    }

}
