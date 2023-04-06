using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Application.Services;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.UnitTests.Services;

[TestFixture]
public class DistanceCalculationServiceTests
{
    private IDistanceCalculationService _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new DistanceCalculationService();
    }

    [TestCase(53.297975, -6.372663, 41.385101, -81.440440, 5536.3386822666853)]
    public void GivenTwoPoints_WhenCalculate_ThenShouldReturnTheExpectedDistance(double latitudeA, double longitudeA,
        double latitudeB, double longitudeB, double expectedDistance)
    {
        // Arrange
        var pointA = new Point
        {
            Latitude = latitudeA,
            Longitude = longitudeA
        };
        var pointB = new Point
        {
            Latitude = latitudeB,
            Longitude = longitudeB
        };

        // Act
        var actualDistance = _sut.Calculate(pointA, pointB);

        // Assert
        actualDistance.Should().Be(expectedDistance);
    }
}