using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using EduMS.Application.M4_AssetLogistics.Commands.AssetAssignments;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace EduMS.IntegrationTests.M4_AssetLogistics.Commands;

public class CreateAssetAssignmentCommandTests : IntegrationTestBase<Program, EduMSDbContext>
{
    public CreateAssetAssignmentCommandTests(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreateAssetAssignment_ShouldEmitDomainEventAndCreateAuditLog()
    {
        // Arrange
        using var setupScope = Factory.Services.CreateScope();
        var setupDbContext = setupScope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        var school = setupDbContext.Set<School>().First();

        var asset = new SchoolAsset 
        { 
            SchoolId = school.Id,
            AssetUniqueCode = "AST-TEST-001",
            AssetNameAr = "لابتوب اختبار",
            AssetStatusId = 1 // New/Unassigned
        };
        setupDbContext.Set<SchoolAsset>().Add(asset);
        await setupDbContext.SaveChangesAsync();

        var command = new CreateAssetAssignmentCommand
        {
            Dto = new EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments.CreateAssetAssignmentDto
            {
                AssetId = asset.Id,
                SchoolId = school.Id,
                AssigneeType = 1, // Employee
                AssigneeId = 999,
                AssigneeName = "John Doe",
                AssignmentDate = DateTime.UtcNow,
                AssignmentStatus = 1
            }
        };

        // Act
        var resultId = await Mediator.Send(command);

        // Assert
        resultId.Should().BeGreaterThan(0);

        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        // Verify assignment created
        var savedAssignment = await dbContext.Set<AssetAssignment>().FindAsync(resultId);
        savedAssignment.Should().NotBeNull();
        savedAssignment!.AssetId.Should().Be(asset.Id);

        // Verify asset status updated
        var savedAsset = await dbContext.Set<SchoolAsset>().FindAsync(asset.Id);
        savedAsset.Should().NotBeNull();
        savedAsset!.AssetStatusId.Should().Be(2); // Assigned

        // Verify Domain Event dispatch triggered the Audit Log (M6/M8 logic)
        var auditLogs = await dbContext.Set<SystemAuditLog>()
            .Where(x => x.EntityType == "SchoolAsset" && x.EntityId == asset.Id && x.ActionType == "AssetAssigned")
            .ToListAsync();
            
        auditLogs.Should().NotBeEmpty();
        auditLogs.First().ChangeSummary.Should().Contain("assigned to John Doe");
    }
}
