using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using EduMS.Application.M3_EmployeeManagement.Commands.Employees;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using System.Linq;

namespace EduMS.IntegrationTests.M3_EmployeeManagement.Commands.Employees;

public class CreateEmployeeCommandTests : IntegrationTestBase<Program, EduMSDbContext>
{
    public CreateEmployeeCommandTests(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreateEmployee_WithValidData_ShouldPersistInDatabase()
    {
        // Arrange
        using var setupScope = Factory.Services.CreateScope();
        var setupDbContext = setupScope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        var department = setupDbContext.Set<Department>().First();

        var command = new CreateEmployeeCommand
        {
            Dto = new EduMS.Application.M3_EmployeeManagement.DTOs.Employees.CreateEmployeeDto
            {
                EmployeeCode = "EMP-2026-0001",
                FirstNameAr = "موظف",
                FamilyNameAr = "جديد",
                NationalIdNumber = "1234567891",
                DepartmentId = department.Id,
                IsActive = true
            }
        };

        // Act
        var resultId = await Mediator.Send(command);

        // Assert
        resultId.Should().BeGreaterThan(0);

        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        var employee = await dbContext.Set<Employee>().FindAsync(resultId);

        employee.Should().NotBeNull();
        employee!.EmployeeCode.Should().Be("EMP-2026-0001");
        employee.IsActive.Should().BeTrue();
    }
}
