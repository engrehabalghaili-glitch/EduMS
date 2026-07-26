using System.Net;
using System.Net.Http.Json;
using EduMS.Application.M1_SchoolAdmin.DTOs.Schools;
using FluentAssertions;
using EduMS.Application.Common.Responses;

namespace EduMS.IntegrationTests.ApiEndpoints.M1_SchoolAdmin;

[Collection("IntegrationTests")]
public class SchoolsEndpointTests : ApiIntegrationTestBase
{
    public SchoolsEndpointTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetSchools_WithoutToken_Returns401Unauthorized()
    {
        // Arrange
        ClearAuthentication();

        // Act
        var response = await Client.GetAsync("/api/v1/schools");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetSchools_WithValidToken_Returns200OK()
    {
        // Arrange
        AuthenticateAsAdmin();

        // Act
        var response = await Client.GetAsync("/api/v1/schools");

        // Assert
        response.EnsureSuccessStatusCode(); // 200-299
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<SchoolDto>>>();
        
        result.Should().NotBeNull();
        result!.Succeeded.Should().BeTrue();
    }

    [Fact]
    public async Task CreateSchool_WithInvalidData_Returns400BadRequest()
    {
        // Arrange
        AuthenticateAsAdmin();
        var invalidCommand = new CreateSchoolDto
        {
            // Missing required fields like SchoolNameAr, SchoolCode, etc.
            SchoolNameEn = "Invalid School"
        };

        // Act
        var response = await Client.PostAsJsonAsync("/api/v1/schools", invalidCommand);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var result = await response.Content.ReadFromJsonAsync<ApiResponse<object>>();
        result.Should().NotBeNull();
        result!.Succeeded.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
}
