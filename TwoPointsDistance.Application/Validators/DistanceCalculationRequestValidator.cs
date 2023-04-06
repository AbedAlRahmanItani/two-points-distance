using FluentValidation;
using TwoPointsDistance.Application.Models;

namespace TwoPointsDistance.Application.Validators;

public class DistanceCalculationRequestValidator : AbstractValidator<DistanceCalculationRequest>
{
    private const double MinimumLatitude = -90;
    private const double MaximumLatitude = 90;
    private const double MinimumLongitude = -180;
    private const double MaximumLongitude = 180;

    public DistanceCalculationRequestValidator()
    {
        RuleFor(x => x.LatitudeA)
            .Must(x => x is >= MinimumLatitude and <= MaximumLatitude)
            .WithMessage($"Latitude of Point A must be between {MinimumLatitude} and {MaximumLatitude}");

        RuleFor(x => x.LongitudeA)
            .Must(x => x is >= MinimumLongitude and <= MaximumLongitude)
            .WithMessage($"Longitude of Point A must be between {MinimumLongitude} and {MaximumLongitude}");

        RuleFor(x => x.LatitudeB)
            .Must(x => x is >= MinimumLatitude and <= MaximumLatitude)
            .WithMessage($"Latitude of Point B must be between {MinimumLatitude} and {MaximumLatitude}");

        RuleFor(x => x.LongitudeB)
            .Must(x => x is >= MinimumLongitude and <= MaximumLongitude)
            .WithMessage($"Longitude of Point B must be between {MinimumLongitude} and {MaximumLongitude}");
    }
}