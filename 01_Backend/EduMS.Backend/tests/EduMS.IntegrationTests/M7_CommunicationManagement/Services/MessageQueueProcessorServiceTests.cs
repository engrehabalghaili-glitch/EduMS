using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using EduMS.Infrastructure.Services.M7_CommunicationManagement;
using System.Linq;

namespace EduMS.IntegrationTests.M7_CommunicationManagement.Services;

public class MessageQueueProcessorServiceTests : IntegrationTestBase<Program, EduMSDbContext>
{
    public MessageQueueProcessorServiceTests(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task ProcessPendingMessages_ShouldUpdateStatusToSent()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        var message = new MessageQueue
        {
            MessageType = "Email",
            RecipientAddress = "test@processor.com",
            Subject = "Test Background Processing",
            Body = "This is a test message to ensure the background processor works.",
            Status = "Pending"
        };

        dbContext.Set<MessageQueue>().Add(message);
        await dbContext.SaveChangesAsync();

        // In tests we can create the service directly to test its internal logic via reflection
        // Or we can just invoke a test-specific accessor. Since the method is private, we can use reflection.
        var processorService = new MessageQueueProcessorService(Factory.Services, new NullLogger<MessageQueueProcessorService>());
        var methodInfo = typeof(MessageQueueProcessorService).GetMethod("ProcessPendingMessagesAsync", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        // Act
        await (Task)methodInfo!.Invoke(processorService, new object[] { CancellationToken.None })!;

        // Assert
        using var assertScope = Factory.Services.CreateScope();
        var assertDbContext = assertScope.ServiceProvider.GetRequiredService<EduMSDbContext>();
        
        var processedMessage = await assertDbContext.Set<MessageQueue>().FindAsync(message.Id);
        processedMessage.Should().NotBeNull();
        processedMessage!.Status.Should().Be("Sent");
    }
}
