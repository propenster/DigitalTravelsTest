using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels;
using UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels.DigitalTravelsHotel;

namespace UBAInterviewPrepAPI.Services.DigitalTravels
{
    public interface IDigitalTravelService
    { 
        FlightSearchResponse SearchFlight(string originLocationCode, string detinationLocationCode, string departureDate, int adults = 1, string returnDate = null, int children = 0, int infants = 0, string travelClass = null, string includedAirlineCodes = null, string excludedAirlineCodes = null, bool nonStop = false, string currencyCode = "USD", int maxPrice = 5000, int max = 100);
        FlightSearchResponse SearchFlight(FlightSearchRequest request);


        //hotels
        HotelSearchResponse SearchHotelOffers(string cityCode, double latitude, double longitude, string[] hotelIds, string checkInDate, string checkOutDate, int roomQuantity, int adults, int radius, string radiusUnit, string hotelName, string[] chains, string[] rateCodes, string[] amenities, int[] ratings, string priceRange, string currency, string paymentPolicy, string boardType, bool includeClosed, bool bestRateOnly, string view, string sort, int pageLimit, string pageOffset, string lang, string cacheControl);

        //search by longitude and latitude
        HotelSearchResponse SearchHotelOffers(double latitude, double longitude, string checkInDate, string checkOutDate, int radius, string radiusUnit);
        HotelSearchResponse SearchHotelOffers(string cityCode, int radius, string radiusUnit);




        HotelOfferResponse SearchSpeicifcHotelOffer(string hotelId, string checkInDate, string checkOutDate);

    }


}
