﻿using TwoPointsDistance.Application.Constants;
using TwoPointsDistance.Application.Extensions;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Services;

public class DistanceCalculationService : IDistanceCalculationService
{
    public double Calculate(Point pointA, Point pointB)
    {
        var cosA = Math.Cos(pointA.Latitude.ToRadians());
        var cosB = Math.Cos(pointB.Latitude.ToRadians());
        var sinA = Math.Sin(pointA.Latitude.ToRadians());
        var sinB = Math.Sin(pointB.Latitude.ToRadians());
        var phi = pointA.Longitude.ToRadians() - pointB.Longitude.ToRadians();
        var cosPhi = Math.Cos(phi);

        var cosP = sinA * sinB + cosA * cosB * cosPhi;

        var distance = AppConstants.EarthRadius * Math.Acos(cosP);

        return distance;
    }
}