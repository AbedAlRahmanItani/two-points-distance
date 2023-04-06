using System.Globalization;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Services;

public class MeasurementConversionService : IMeasurementConversionService
{
    private const double KmToMile = 0.621371;

    public Measurement Convert(double distanceInKm)
    {
        var distance = distanceInKm;
        var unit = "km";
        var cultureInfo = CultureInfo.CurrentCulture;
        if (cultureInfo.Name.Equals("en-US", StringComparison.InvariantCultureIgnoreCase))
        {
            distance =  distanceInKm * KmToMile;
            unit = "mile";
        }

        return new Measurement
        {
            Value = Math.Round(distance),
            Unit = unit
        };
    }
}