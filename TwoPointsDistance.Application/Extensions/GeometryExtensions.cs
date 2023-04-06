namespace TwoPointsDistance.Application.Extensions;

public static class GeometryExtensions
{
    public static double ToRadians(this double degrees)
    {
        return degrees * Math.PI / 180;
    }
}