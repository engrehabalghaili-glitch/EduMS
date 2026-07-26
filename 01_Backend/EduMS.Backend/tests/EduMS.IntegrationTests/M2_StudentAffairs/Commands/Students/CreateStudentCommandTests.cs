using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using EduMS.Application.M2_StudentAffairs.Commands.Students;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using System.Linq;

namespace EduMS.IntegrationTests.M2_StudentAffairs.Commands.Students;

public class CreateStudentCommandTests : IntegrationTestBase<Program, EduMSDbContext>
{
    public CreateStudentCommandTests(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreateStudent_WithValidData_ShouldPersistInDatabase()
    {
        using var setupScope = Factory.Services.CreateScope();
        var setupDbContext = setupScope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        System.Console.WriteLine($"Is Guardian empty? {!setupDbContext.Set<Guardian>().Any()}");
        var guardian = setupDbContext.Set<Guardian>().First();

        var command = new CreateStudentCommand
        {
            Dto = new EduMS.Application.M2_StudentAffairs.DTOs.Students.CreateStudentDto
            {
                EnrollmentNumber = "STU-2026-0001",
                FullNameAr = "طالب جديد",
                FullNameEn = "New Student",
                NationalId = "1234567890",
                Gender = 1,
                DateOfBirth = new System.DateTime(2010, 1, 1),
                NationalityCode = "YEM",
                AdmissionGradeLevel = 10,
                EnrollmentDate = System.DateTime.UtcNow,
                GuardianId = guardian.Id
            }
        };

        // Act
        var resultId = await Mediator.Send(command);

        // Assert
        resultId.Should().BeGreaterThan(0);

        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        var student = await dbContext.Set<Student>().FindAsync(resultId);

        student.Should().NotBeNull();
    }
}
