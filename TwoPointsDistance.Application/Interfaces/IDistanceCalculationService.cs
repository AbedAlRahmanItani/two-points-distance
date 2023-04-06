using TwoPointsDistance.Domain.Models;

namespace TwoPointsDistance.Application.Interfaces;

public interface IDistanceCalculationService
{
    double Calculate(Point pointA, Point pointB);
}