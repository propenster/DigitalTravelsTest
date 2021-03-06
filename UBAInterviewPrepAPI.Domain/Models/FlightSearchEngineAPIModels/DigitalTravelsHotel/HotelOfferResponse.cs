// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Address
    {
        [JsonProperty("lines")]
        public List<string> Lines { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class Contact
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }

    public class Description
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Medium
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }

    public class Hotel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("hotelId")]
        public string HotelId { get; set; }

        [JsonProperty("chainCode")]
        public string ChainCode { get; set; }

        [JsonProperty("dupeId")]
        public string DupeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("amenities")]
        public List<string> Amenities { get; set; }

        [JsonProperty("media")]
        public List<Medium> Media { get; set; }
    }

    public class RateFamilyEstimated
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class TypeEstimated
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("beds")]
        public int? Beds { get; set; }

        [JsonProperty("bedType")]
        public string BedType { get; set; }
    }

    public class Room
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeEstimated")]
        public TypeEstimated TypeEstimated { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public class Guests
    {
        [JsonProperty("adults")]
        public int Adults { get; set; }
    }

    public class Tax
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("pricingFrequency")]
        public string PricingFrequency { get; set; }

        [JsonProperty("pricingMode")]
        public string PricingMode { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("included")]
        public bool Included { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Average
    {
        [JsonProperty("base")]
        public string Base { get; set; }
    }

    public class Change
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }

    public class Variations
    {
        [JsonProperty("average")]
        public Average Average { get; set; }

        [JsonProperty("changes")]
        public List<Change> Changes { get; set; }
    }

    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonProperty("variations")]
        public Variations Variations { get; set; }
    }

    public class HoldTime
    {
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }
    }

    public class AcceptedPayments
    {
        [JsonProperty("creditCards")]
        public List<string> CreditCards { get; set; }

        [JsonProperty("methods")]
        public List<string> Methods { get; set; }
    }

    public class Guarantee
    {
        [JsonProperty("acceptedPayments")]
        public AcceptedPayments AcceptedPayments { get; set; }
    }

    public class Cancellation
    {
        [JsonProperty("numberOfNights")]
        public int NumberOfNights { get; set; }

        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }
    }

    public class Policies
    {
        [JsonProperty("holdTime")]
        public HoldTime HoldTime { get; set; }

        [JsonProperty("guarantee")]
        public Guarantee Guarantee { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("cancellation")]
        public Cancellation Cancellation { get; set; }
    }

    public class Offer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("checkInDate")]
        public string CheckInDate { get; set; }

        [JsonProperty("checkOutDate")]
        public string CheckOutDate { get; set; }

        [JsonProperty("rateCode")]
        public string RateCode { get; set; }

        [JsonProperty("rateFamilyEstimated")]
        public RateFamilyEstimated RateFamilyEstimated { get; set; }

        [JsonProperty("boardType")]
        public string BoardType { get; set; }

        [JsonProperty("room")]
        public Room Room { get; set; }

        [JsonProperty("guests")]
        public Guests Guests { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("policies")]
        public Policies Policies { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }
    }

    public class HotelOfferResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

