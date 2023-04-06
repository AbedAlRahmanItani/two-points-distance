using FluentValidation;
using TwoPointsDistance.Application.Constants;
using TwoPointsDistance.Application.Models;

namespace TwoPointsDistance.Application.Validators;

public class DistanceCalculationRequestValidator : AbstractValidator<DistanceCalculationRequest>
{
    public DistanceCalculationRequestValidator()
    {
        RuleFor(x => x.LatitudeA)
            .Must(x => x is >= AppConstants.MinimumLatitude and <= AppConstants.MaximumLatitude)
            .WithMessage($"Latitude of Point A must be between {AppConstants.MinimumLatitude} and {AppConstants.MaximumLatitude}");

        RuleFor(x => x.LongitudeA)
            .Must(x => x is >= AppConstants.MinimumLongitude and <= AppConstants.MaximumLongitude)
            .WithMessage($"Longitude of Point A must be between {AppConstants.MinimumLongitude} and {AppConstants.MaximumLongitude}");

        RuleFor(x => x.LatitudeB)
            .Must(x => x is >= AppConstants.MinimumLatitude and <= AppConstants.MaximumLatitude)
            .WithMessage($"Latitude of Point B must be between {AppConstants.MinimumLatitude} and {AppConstants.MaximumLatitude}");

        RuleFor(x => x.LongitudeB)
            .Must(x => x is >= AppConstants.MinimumLongitude and <= AppConstants.MaximumLongitude)
            .WithMessage($"Longitude of Point B must be between {AppConstants.MinimumLongitude} and {AppConstants.MaximumLongitude}");
    }
}