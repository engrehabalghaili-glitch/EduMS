using System;
using System.Threading.Tasks;
using EduMS.Application.Common.Validation;
using EduMS.Application.Schools.Commands;
using EduMS.Domain.Entities;
using EduMS.IntegrationTests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EduMS.IntegrationTests.M1_SchoolAdmin.Commands
{
    [Collection("Sequential")]
    public class RegisterSchoolCommandTests : IntegrationTestBase<Program, EduMS.Infrastructure.Common.Persistence.EduMSDbContext>
    {
        public RegisterSchoolCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_RegisterSchool_WhenDataIsValid()
        {
            // Arrange
            var command = new RegisterSchoolCommand(
                "مدرسة جديدة",
                "New School",
                "SCH-NEW-01",
                "الرياض",
                "الرياض"
            );

            // Act
            var result = await Mediator.Send(command);

            // Assert
            result.Should().BeGreaterThan(0);

            var school = await DbContext.Set<School>().FirstOrDefaultAsync(s => s.SchoolCode == "SCH-NEW-01");
            school.Should().NotBeNull();
            school.SchoolNameEn.Should().Be("New School");
        }

        [Fact]
        public async Task Handle_Should_ThrowValidationException_WhenSchoolCodeExists()
        {
            // Arrange
            var firstCommand = new RegisterSchoolCommand(
                "مدرسة أولى",
                "First School",
                "SCH-DUPLICATE",
                "الرياض",
                "الرياض"
            );
            await Mediator.Send(firstCommand);

            var secondCommand = new RegisterSchoolCommand(
                "مدرسة ثانية",
                "Second School",
                "SCH-DUPLICATE",
                "الرياض",
                "الرياض"
            );

            // Act
            Func<Task> action = async () => await Mediator.Send(secondCommand);

            // Assert
            await action.Should().ThrowAsync<ValidationException>();
        }
    }
}
