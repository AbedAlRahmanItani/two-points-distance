using System.Net.Mime;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TwoPointsDistance.Application.Models;
using Xunit;
using Newtonsoft.Json;

namespace TwoPointsDistance.API.IntegrationTests.Controllers;

public class DistanceCalculationControllerTests
{
    private readonly HttpClient _httpClient;

    public DistanceCalculationControllerTests()
    {
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateDefaultClient();
    }

    [Fact]
    public async Task GivenAValidDistanceCalculationRequest_WhenGet_ThenShouldReturnExpectedSuccessResponse()
    {
        // Arrange
        var request = new DistanceCalculationRequest
        {
            LatitudeA = 53.297975,
            LongitudeA = -6.372663,
            LatitudeB = 41.385101,
            LongitudeB = -81.440440
        };
        var expectedResponse = new DistanceCalculationResponse
        {
            Distance = 3440,
            Unit = "mile"
        };
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("/api/DistanceCalculation", UriKind.Relative),
            Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json)
        };
        httpRequestMessage.Headers.Add("Accept-Language", "en-US");

        // Act
        var response = await _httpClient.SendAsync(httpRequestMessage);

        // Assert
        var responseString = await response.Content.ReadAsStringAsync();
        var actualResponse = JsonConvert.DeserializeObject<DistanceCalculationResponse>(responseString);
        response.IsSuccessStatusCode.Should().BeTrue();
        actualResponse.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task GivenAnInvalidDistanceCalculationRequest_WhenGet_ThenShouldReturnExpectedErrorResponse()
    {
        // Arrange
        var request = new DistanceCalculationRequest
        {
            LatitudeA = 90.00001,
            LongitudeA = 180.00001,
            LatitudeB = 90.00001,
            LongitudeB = 180.00001
        };
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("/api/DistanceCalculation", UriKind.Relative),
            Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, MediaTypeNames.Application.Json)
        };
        httpRequestMessage.Headers.Add("Accept-Language", "en-US");

        // Act
        var response = await _httpClient.SendAsync(httpRequestMessage);

        // Assert
        var responseString = await response.Content.ReadAsStringAsync();
        response.IsSuccessStatusCode.Should().BeFalse();
        responseString.Should().Contain("errors");
    }
}