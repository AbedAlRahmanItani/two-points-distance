using System.Globalization;
using TwoPointsDistance.Application.Constants;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Services;

public class MeasurementConversionService : IMeasurementConversionService
{
    public Measurement Convert(double distanceInKm)
    {
        var distance = distanceInKm;
        var unit = AppConstants.Units.Kilometer;
        var cultureInfo = CultureInfo.CurrentCulture;

        if (cultureInfo.Name.Equals("en-US", StringComparison.InvariantCultureIgnoreCase))
        {
            distance =  distanceInKm * AppConstants.KmToMile;
            unit = AppConstants.Units.Mile;
        }

        return new Measurement
        {
            Value = Math.Round(distance),
            Unit = unit
        };
    }
}