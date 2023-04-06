namespace TwoPointsDistance.Application.Models;

public class DistanceCalculationRequest
{
    public double LatitudeA { get; set; }
    public double LongitudeA { get; set; }
    public double LatitudeB { get; set; }
    public double LongitudeB { get; set; }
}