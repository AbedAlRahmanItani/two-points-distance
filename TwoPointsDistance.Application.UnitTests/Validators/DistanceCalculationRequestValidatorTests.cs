using System.Collections;
using FluentValidation.Results;
using TwoPointsDistance.Application.Models;
using TwoPointsDistance.Application.Validators;

namespace TwoPointsDistance.Application.UnitTests.Validators;

[TestFixture]
public class DistanceCalculationRequestValidatorTests
{
    private DistanceCalculationRequestValidator _sut = null!;

    [SetUp]

    public void Setup()
    {
        _sut = new DistanceCalculationRequestValidator();
    }

    [TestCaseSource(nameof(GetInvalidDistanceCalculationRequestsTestSource))]
    public void GivenAnInvalidDistanceCalculationRequest_WhenValidate_ThenShouldFailValidation(
        DistanceCalculationRequest distanceCalculationRequest, ValidationResult expectedValidationResult)
    {
        // Act
        var actualValidationResult = _sut.Validate(distanceCalculationRequest);

        // Assert
        actualValidationResult.IsValid.Should().BeFalse();
        actualValidationResult.Errors.Count.Should().Be(expectedValidationResult.Errors.Count);
        foreach (var error in actualValidationResult.Errors)
        {
            error.ErrorMessage.Should()
                .Be(expectedValidationResult.Errors
                    .First(x => x.PropertyName.Equals(error.PropertyName)).ErrorMessage);
        }
    }

    private static IEnumerable GetInvalidDistanceCalculationRequestsTestSource()
    {
        yield return new object[]
        {
            new DistanceCalculationRequest
            {
                LatitudeA = 90.00001,
                LongitudeA = 180.00001,
                LatitudeB = 90.00001,
                LongitudeB = 180.00001
            },
            new ValidationResult
            {
                Errors = new List<ValidationFailure>
                {
                    new()
                    {
                        PropertyName = "LatitudeA",
                        ErrorMessage = "Latitude of Point A must be between -90 and 90"
                    },
                    new()
                    {
                        PropertyName = "LongitudeA",
                        ErrorMessage = "Longitude of Point A must be between -180 and 180"
                    },
                    new()
                    {
                        PropertyName = "LatitudeB",
                        ErrorMessage = "Latitude of Point B must be between -90 and 90"
                    },
                    new()
                    {
                        PropertyName = "LongitudeB",
                        ErrorMessage = "Longitude of Point B must be between -180 and 180"
                    }
                }
            }
        };
        yield return new object[]
        {
            new DistanceCalculationRequest
            {
                LatitudeA = -90.00001,
                LongitudeA = -180.00001,
                LatitudeB = -90.00001,
                LongitudeB = -180.00001
            },
            new ValidationResult
            {
                Errors = new List<ValidationFailure>
                {
                    new()
                    {
                        PropertyName = "LatitudeA",
                        ErrorMessage = "Latitude of Point A must be between -90 and 90"
                    },
                    new()
                    {
                        PropertyName = "LongitudeA",
                        ErrorMessage = "Longitude of Point A must be between -180 and 180"
                    },
                    new()
                    {
                        PropertyName = "LatitudeB",
                        ErrorMessage = "Latitude of Point B must be between -90 and 90"
                    },
                    new()
                    {
                        PropertyName = "LongitudeB",
                        ErrorMessage = "Longitude of Point B must be between -180 and 180"
                    }
                }
            }
        };
    }
}