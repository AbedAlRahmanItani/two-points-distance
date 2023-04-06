using Microsoft.AspNetCore.Mvc;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Application.Models;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceCalculationController : ControllerBase
    {
        private readonly IDistanceCalculationService _distanceCalculationService;

        public DistanceCalculationController(IDistanceCalculationService distanceCalculationService)
        {
            _distanceCalculationService = distanceCalculationService;
        }

        [HttpGet]
        public ActionResult<DistanceCalculationResponse> Get(DistanceCalculationRequest request)
        {
            var pointA = new Point
            {
                Latitude = request.LatitudeA,
                Longitude = request.LongitudeA
            };
            var pointB = new Point
            {
                Latitude = request.LatitudeB,
                Longitude = request.LongitudeB
            };

            var distance = _distanceCalculationService.Calculate(pointA, pointB);

            return new DistanceCalculationResponse
            {
                Distance = distance,
                Unit = "km"
            };
        }
    }
}