﻿using TwoPointsDistance.API.Controllers;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Application.Models;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.API.UnitTests.Controllers;

[TestFixture]
public class DistanceCalculationControllerTests
{
    private IDistanceCalculationService _distanceCalculationService = null!;
    private IMeasurementConversionService _measurementConversionService = null!;
    private DistanceCalculationController _sut = null!;

    [SetUp]
    public void Setup()
    {
        _distanceCalculationService = Substitute.For<IDistanceCalculationService>();
        _measurementConversionService = Substitute.For<IMeasurementConversionService>();

        _sut = new DistanceCalculationController(_distanceCalculationService, _measurementConversionService);
    }

    [Test]
    public void GivenDistanceCalculationRequest_WhenGet_ThenShouldReturnTheExpectedResponse()
    {
        // Arrange
        const int distanceInKm = 5536;
        var request = new DistanceCalculationRequest
        {
            LatitudeA = 53.297975,
            LongitudeA = -6.372663,
            LatitudeB = 41.385101,
            LongitudeB = -81.440440
        };
        var expectedResponse = new DistanceCalculationResponse
        {
            Distance = distanceInKm,
            Unit = "km"
        };
        Point? pointA = null, pointB = null;
        _distanceCalculationService.Calculate(Arg.Do<Point>(x => pointA = x), Arg.Do<Point>(x => pointB = x))
            .Returns(expectedResponse.Distance);
        _measurementConversionService.Convert(distanceInKm)
            .Returns(new Measurement
            {
                Value = distanceInKm,
                Unit = "km"
            });

        // Act
        var actualResponse = _sut.Get(request);

        // Assert
        actualResponse.Should().BeEquivalentTo(expectedResponse);
        pointA!.Latitude.Should().Be(request.LatitudeA);
        pointA!.Longitude.Should().Be(request.LongitudeA);
        pointB!.Latitude.Should().Be(request.LatitudeB);
        pointB!.Longitude.Should().Be(request.LongitudeB);
    }
}