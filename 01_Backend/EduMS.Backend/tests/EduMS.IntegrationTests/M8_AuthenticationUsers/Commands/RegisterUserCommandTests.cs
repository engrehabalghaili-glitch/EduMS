using System;
using System.Threading.Tasks;
using EduMS.Application.Common.Validation;
using EduMS.Application.M8_AuthenticationUsers.Commands.Auth;
using EduMS.Domain.Entities;
using EduMS.IntegrationTests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EduMS.IntegrationTests.M8_AuthenticationUsers.Commands
{
    [Collection("Sequential")]
    public class RegisterUserCommandTests : IntegrationTestBase<Program, EduMS.Infrastructure.Common.Persistence.EduMSDbContext>
    {
        public RegisterUserCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Handle_Should_RegisterUser_WhenDataIsValid()
        {
            // Arrange
            var command = new RegisterUserCommand
            {
                Username = "new_user_1",
                Password = "Password123!",
                Email = "newuser1@school.edu",
                SchoolId = 1,
                RoleId = 1
            };

            // Act
            var result = await Mediator.Send(command);

            // Assert
            result.Should().BeGreaterThan(0);

            var user = await DbContext.Set<SystemUser>().FirstOrDefaultAsync(u => u.Username == "new_user_1");
            user.Should().NotBeNull();
            user.Email.Should().Be("newuser1@school.edu");

            var assignment = await DbContext.Set<UserRoleAssignment>().FirstOrDefaultAsync(a => a.UserId == user.Id);
            assignment.Should().NotBeNull();
            assignment.RoleId.Should().Be(1);
        }

        [Fact]
        public async Task Handle_Should_ThrowValidationException_WhenUsernameExists()
        {
            // Arrange
            var firstCommand = new RegisterUserCommand
            {
                Username = "existing_user",
                Password = "Password123!",
                Email = "user1@school.edu",
                SchoolId = 1,
                RoleId = 1
            };
            await Mediator.Send(firstCommand);

            var secondCommand = new RegisterUserCommand
            {
                Username = "existing_user",
                Password = "Password123!",
                Email = "user2@school.edu",
                SchoolId = 1,
                RoleId = 1
            };

            // Act
            Func<Task> action = async () => await Mediator.Send(secondCommand);

            // Assert
            await action.Should().ThrowAsync<ValidationException>()
                .Where(e => e.Errors.ContainsKey("Username") && e.Errors["Username"][0] == "Username is already taken.");
        }
    }
}
