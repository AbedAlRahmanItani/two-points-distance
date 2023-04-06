using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Services;

public class DistanceCalculationService : IDistanceCalculationService
{
    private const double EarthRadius = 6371;

    public double Calculate(Point pointA, Point pointB)
    {
        var cosA = Math.Cos(Radians(pointA.Latitude));
        var cosB = Math.Cos(Radians(pointB.Latitude));
        var sinA = Math.Sin(Radians(pointA.Latitude));
        var sinB = Math.Sin(Radians(pointB.Latitude));
        var phi = Radians(pointA.Longitude) - Radians(pointB.Longitude);
        var cosPhi = Math.Cos(phi);

        var cosP = sinA * sinB + cosA * cosB * cosPhi;

        var distance = EarthRadius * Math.Acos(cosP);

        return Math.Round(distance);
    }

    private static double Radians(double angle)
    {
        return angle * Math.PI / 180;
    }
}