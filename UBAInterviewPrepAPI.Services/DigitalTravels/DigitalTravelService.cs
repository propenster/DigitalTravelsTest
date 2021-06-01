using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels;
using UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels.DigitalTravelsHotel;
using UBAInterviewPrepAPI.Services.Utility;

namespace UBAInterviewPrepAPI.Services.DigitalTravels
{
    public class DigitalTravelService : IDigitalTravelService   
    {
        
        public FlightSearchResponse SearchFlight(string originLocationCode, string detinationLocationCode, string departureDate, int adults = 1, string returnDate = null, int children = 0, int infants = 0, string travelClass = null, string includedAirlineCodes = null, string excludedAirlineCodes = null, bool nonStop = false, string currencyCode = "USD", int maxPrice = 5000, int max = 100)
        {
            //return RestUtility.Get<FlightSearchResponse>("/shopping/flight-offers");
            return RestUtility.GetWithParameters<FlightSearchResponse>("/shopping/flight-offers", 
                new Dictionary<string, object>() {
                    {"originLocationCode", originLocationCode },
                    {"detinationLocationCode", detinationLocationCode },
                    {"departureDate", departureDate },
                    {"adults", adults },
                    {"returnDate", returnDate },
                    {"children", children },
                    {"infants", infants },
                    {"travelClass", travelClass },
                    {"includedAirlineCodes", includedAirlineCodes },
                    {"excludedAirlineCodes", excludedAirlineCodes },
                    {"nonStop", nonStop },
                    {"currencyCode", currencyCode },
                    {"maxPrice", maxPrice },
                    {"max", max }
                });
        }

        public FlightSearchResponse SearchFlight(FlightSearchRequest request) => SearchFlight(request.OriginLocationCode, 
            request.DestinationLocationCode, request.DepartureDate, request.Adults, request.ReturnDate, request.Children ?? 0, 
            request.Infants ?? 0, request.TravelClass.ToString(), request.IncludedAirlineCodes, request.ExcludedAirlineCodes, request.NonStop, request.CurrencyCode, request.MaxPrice ?? 5000, request.Max ?? 100);

        public HotelSearchResponse SearchHotelOffers(string cityCode, double latitude, double longitude, string[] hotelIds, string checkInDate, int roomQuantity, int adults, int radius, string radiusUnit, string hotelName, string[] chains, string[] rateCodes, string[] amenities, int[] ratings, string priceRange, string currency, string paymentPolicy, string boardType, bool includeClosed, bool bestRateOnly, string view, string sort, int pageLimit, string pageOffset, string lang, string cacheControl)
        {
            return RestUtility.GetWithParameters<HotelSearchResponse>("/shopping/hotel-offers", new Dictionary<string, object>() {
                {"cityCode", cityCode},
                {"checkInDate", checkInDate ?? DateTime.Now.ToString("yyyy-MM-dd")},
                {"checkOutDate", checkOutDate ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}

                });
        }

        //search by longitude and latitude
        public HotelSearchResponse SearchHotelOffers(double latitude, double longitude, string checkInDate, string checkOutDate, int radius, string radiusUnit){
        return RestUtility.GetWithParameters<HotelSearchResponse>("/shopping/hotel-offers", new Dictionary<string, object>() {
                        {"latitude", latitude},
                        {"longitude", longitude},
                        {"radius", radius},
                        {"radiusUnit", radiusUnit},
                        {"checkInDate", checkInDate ?? DateTime.Now.ToString("yyyy-MM-dd")},
                        {"checkOutDate", checkOutDate ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}

                        });
        }

        public HotelSearchResponse SearchHotelOffers(string cityCode, int radius, string radiusUnit){
            return RestUtility.GetWithParameters<HotelSearchResponse>("/shopping/hotel-offers", new Dictionary<string, object>() {
                        {"cityCode", cityCode},
                        {"radius", radius},
                        {"radiusUnit", radiusUnit},
                        {"checkInDate", checkInDate ?? DateTime.Now.ToString("yyyy-MM-dd")},
                        {"checkOutDate", checkOutDate ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}

                        });
        }

        //Still confirm availability of Rooms in that / offers in that Hotel...    
        public HotelOfferResponse SearchSpeicifcHotelOffer(string hotelId, string checkInDate, string checkOutDate){
            //https://test.api.amadeus.com/v2/shopping/hotel-offers/by-hotel?hotelId=HIPARC12

            return RestUtility.GetWithParameters<HotelOfferResponse>("/shopping/hotel-offers/by-hotel", new Dictionary<string, object>() {
                {"hotelId", hotelId},
                {"checkInDate", checkInDate ?? DateTime.Now.ToString("yyyy-MM-dd")},
                {"checkOutDate", checkOutDate ?? DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")}

                });
        }




        //        new Dictionary<string, object>() {
        //                    {"originLocationCode", request.OriginLocationCode
        //    },
        //                    {"detinationLocationCode", request.DestinationLocationCode
        //},
        //                    { "departureDate", request.DepartureDate },
        //                    { "adults", request.Adults },
        //                    { "returnDate", request.ReturnDate },
        //                    { "children", request.Children },
        //                    { "infants", request.Infants },
        //                    { "travelClass", request.TravelClass },
        //                    { "includedAirlineCodes", request.IncludedAirlineCodes },
        //                    { "excludedAirlineCodes", request.ExcludedAirlineCodes },
        //                    { "nonStop", request.NonStop },
        //                    { "currencyCode", request.CurrencyCode },
        //                    { "maxPrice", request.MaxPrice },
        //                    { "max", request.Max }
        //                }

    }
}
