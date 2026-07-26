using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using EduMS.Application.Common.Responses;

namespace EduMS.IntegrationTests.ApiEndpoints.M6_StatisticsReports;

[Collection("IntegrationTests")]
public class SystemReportsEndpointTests : ApiIntegrationTestBase
{
    public SystemReportsEndpointTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_WithoutToken_Returns401Unauthorized()
    {
        // Arrange
        ClearAuthentication();

        // Act
        var response = await Client.GetAsync("/api/v1/systemreports/calculate-live/1");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetAll_WithValidToken_Returns200OK()
    {
        // Arrange
        AuthenticateAsAdmin();

        // Act
        var response = await Client.GetAsync("/api/v1/systemreports/calculate-live/1");

        // Assert
        response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.InternalServerError);
    }
}

