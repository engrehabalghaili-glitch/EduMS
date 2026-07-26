using System;
using System.Linq;
using System.Threading.Tasks;
using EduMS.Application.Common.Validation;
using EduMS.Application.M1_SchoolAdmin.Commands.AcademicYears;
using EduMS.Domain.Entities;
using EduMS.IntegrationTests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
namespace EduMS.IntegrationTests.M1_SchoolAdmin.Commands.AcademicYears
{
    [Collection("Sequential")]
    public class CloseAcademicYearCommandTests : IntegrationTestBase<Program, EduMS.Infrastructure.Common.Persistence.EduMSDbContext>
    {
        public CloseAcademicYearCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_CloseAcademicYear_WhenNoIntegrityViolations()
        {
            // Arrange
            var school = new School { SchoolNameAr = "Test School", SchoolNameEn = "Test School", SchoolCode = "TS-01", PostalAddress = "123 Main St" };
            DbContext.Set<School>().Add(school);
            await DbContext.SaveChangesAsync();

            var academicYear = new SchoolAcademicYear
            {
                SchoolId = school.Id,
                YearCode = "2030-2031",
                YearNameAr = "2030-2031",
                StartDate = new DateTime(2030, 9, 1),
                EndDate = new DateTime(2031, 6, 30),
                RegistrationStartDate = new DateTime(2030, 8, 1),
                RegistrationEndDate = new DateTime(2030, 8, 30),
                YearStatus = 1,
                IsCurrentYear = true
            };
            DbContext.Set<SchoolAcademicYear>().Add(academicYear);
            await DbContext.SaveChangesAsync();

            var command = new CloseAcademicYearCommand { AcademicYearId = academicYear.Id };

            // Act
            var result = await Mediator.Send(command);

            // Assert
            result.Should().BeTrue();
            var updatedYear = await DbContext.Set<SchoolAcademicYear>().FindAsync(academicYear.Id);
            updatedYear.Should().NotBeNull();
            updatedYear!.YearStatus.Should().Be(3);
            updatedYear.IsCurrentYear.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ThrowValidationException_WhenIncompleteGradesExist()
        {
            // Arrange
            var school = new School { SchoolNameAr = "Test School 2", SchoolNameEn = "Test School 2", SchoolCode = "TS-02", PostalAddress = "123 Main St" };
            DbContext.Set<School>().Add(school);
            await DbContext.SaveChangesAsync();

            var academicYear = new SchoolAcademicYear
            {
                SchoolId = school.Id,
                YearCode = "2031-2032",
                YearNameAr = "2031-2032",
                StartDate = new DateTime(2031, 9, 1),
                EndDate = new DateTime(2032, 6, 30),
                RegistrationStartDate = new DateTime(2031, 8, 1),
                RegistrationEndDate = new DateTime(2031, 8, 30),
                YearStatus = 1,
                IsCurrentYear = true
            };
            var mockIntegrityChecker = new Moq.Mock<EduMS.Application.Interfaces.CrossModule.IAcademicIntegrityChecker>();
            mockIntegrityChecker.Setup(x => x.HasIncompleteGradesAsync(Moq.It.IsAny<long>(), Moq.It.IsAny<CancellationToken>())).ReturnsAsync(true);
            mockIntegrityChecker.Setup(x => x.HasOutstandingDuesAsync(Moq.It.IsAny<long>(), Moq.It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var customFactory = Factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(EduMS.Application.Interfaces.CrossModule.IAcademicIntegrityChecker));
                    if (descriptor != null) services.Remove(descriptor);
                    services.AddScoped(sp => mockIntegrityChecker.Object);
                });
            });

            var scope = customFactory.Services.CreateScope();
            var customDb = scope.ServiceProvider.GetRequiredService<EduMS.Infrastructure.Common.Persistence.EduMSDbContext>();
            
            // Re-attach to custom factory's DbContext
            school.Id = 0;
            customDb.Set<School>().Add(school);
            await customDb.SaveChangesAsync();

            academicYear.Id = 0; // reset to generate new
            academicYear.SchoolId = school.Id;
            customDb.Set<SchoolAcademicYear>().Add(academicYear);
            await customDb.SaveChangesAsync();

            var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

            var command = new CloseAcademicYearCommand { AcademicYearId = academicYear.Id };

            // Act
            Func<Task> action = async () => await mediator.Send(command);

            // Assert
            var ex = await action.Should().ThrowAsync<ValidationException>();
            ex.Which.Errors.Should().ContainKey("Integrity")
                .WhoseValue.Should().ContainSingle(e => e.Contains("incomplete grades"));
        }

        [Fact]
        public async Task Handle_Should_ThrowValidationException_WhenOutstandingDuesExist()
        {
            // Arrange
            var school = new School { SchoolNameAr = "Test School 3", SchoolNameEn = "Test School 3", SchoolCode = "TS-03", PostalAddress = "123 Main St" };
            DbContext.Set<School>().Add(school);
            await DbContext.SaveChangesAsync();

            var academicYear = new SchoolAcademicYear
            {
                SchoolId = school.Id,
                YearCode = "2032-2033",
                YearNameAr = "2032-2033",
                StartDate = new DateTime(2032, 9, 1),
                EndDate = new DateTime(2033, 6, 30),
                RegistrationStartDate = new DateTime(2032, 8, 1),
                RegistrationEndDate = new DateTime(2032, 8, 30),
                YearStatus = 1,
                IsCurrentYear = true
            };
            var mockIntegrityChecker = new Moq.Mock<EduMS.Application.Interfaces.CrossModule.IAcademicIntegrityChecker>();
            mockIntegrityChecker.Setup(x => x.HasIncompleteGradesAsync(Moq.It.IsAny<long>(), Moq.It.IsAny<CancellationToken>())).ReturnsAsync(false);
            mockIntegrityChecker.Setup(x => x.HasOutstandingDuesAsync(Moq.It.IsAny<long>(), Moq.It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var customFactory = Factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(EduMS.Application.Interfaces.CrossModule.IAcademicIntegrityChecker));
                    if (descriptor != null) services.Remove(descriptor);
                    services.AddScoped(sp => mockIntegrityChecker.Object);
                });
            });

            var scope = customFactory.Services.CreateScope();
            var customDb = scope.ServiceProvider.GetRequiredService<EduMS.Infrastructure.Common.Persistence.EduMSDbContext>();
            
            // Re-attach to custom factory's DbContext
            school.Id = 0;
            customDb.Set<School>().Add(school);
            await customDb.SaveChangesAsync();

            academicYear.Id = 0; // reset to generate new
            academicYear.SchoolId = school.Id;
            customDb.Set<SchoolAcademicYear>().Add(academicYear);
            await customDb.SaveChangesAsync();

            var mediator = scope.ServiceProvider.GetRequiredService<MediatR.IMediator>();

            var command = new CloseAcademicYearCommand { AcademicYearId = academicYear.Id };

            // Act
            Func<Task> action = async () => await mediator.Send(command);

            // Assert
            var ex = await action.Should().ThrowAsync<ValidationException>();
            ex.Which.Errors.Should().ContainKey("Integrity")
                .WhoseValue.Should().ContainSingle(e => e.Contains("outstanding fee invoices"));
        }
    }
}
