using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Interfaces;

public interface IMeasurementConversionService
{
    Measurement Convert(double distanceInKm);
}