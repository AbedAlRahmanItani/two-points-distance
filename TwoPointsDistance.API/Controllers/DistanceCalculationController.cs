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
        private readonly IMeasurementConversionService _measurementConversionService;

        public DistanceCalculationController(
            IDistanceCalculationService distanceCalculationService,
            IMeasurementConversionService measurementConversionService)
        {
            _distanceCalculationService = distanceCalculationService;
            _measurementConversionService = measurementConversionService;
        }

        [HttpGet]
        public DistanceCalculationResponse Get(DistanceCalculationRequest request)
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

            var distanceInKm = _distanceCalculationService.Calculate(pointA, pointB);
            var measurement = _measurementConversionService.Convert(distanceInKm);

            return new DistanceCalculationResponse
            {
                Distance = measurement.Value,
                Unit = measurement.Unit
            };
        }
    }
}