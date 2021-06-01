using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.FlightSearchEngineAPIModels;
using UBAInterviewPrepAPI.Services.DigitalTravels;

namespace UBAInterviewPrepAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DigitalTravelsController : ControllerBase
    {


        protected readonly IDigitalTravelService _digitalTravelService;

        public DigitalTravelsController(IDigitalTravelService digitalTravelService)
        {
            _digitalTravelService = digitalTravelService;
        }


        [HttpGet("flight-search/search-offers")]
        public IActionResult SearchFlightOffers(string originLocationCode, string detinationLocationCode, string departureDate, int adults = 1, string returnDate = null, int children = 0, int infants = 0, string travelClass = null, string includedAirlineCodes = null, string excludedAirlineCodes = null, bool nonStop = false, string currencyCode = "USD", int maxPrice = 5000, int max = 100)
        {
            return Ok(_digitalTravelService.SearchFlight(originLocationCode, detinationLocationCode, departureDate, adults, returnDate, children, infants, travelClass, includedAirlineCodes, excludedAirlineCodes, nonStop, currencyCode, maxPrice, max));
        }
        
        [HttpGet("flight-search/search-offers")]
        public IActionResult SearchFlightOffers(FlightSearchRequest request)
        {
            return Ok(_digitalTravelService.SearchFlight(request));
        }
    }
}
