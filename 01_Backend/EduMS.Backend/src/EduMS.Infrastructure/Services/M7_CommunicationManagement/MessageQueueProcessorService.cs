using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.Services.M7_CommunicationManagement;

public class MessageQueueProcessorService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<MessageQueueProcessorService> _logger;
    private readonly TimeSpan _pollingInterval = TimeSpan.FromSeconds(10); // Poll every 10 seconds

    public MessageQueueProcessorService(
        IServiceProvider serviceProvider,
        ILogger<MessageQueueProcessorService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("MessageQueueProcessorService is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessPendingMessagesAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred processing the message queue.");
            }

            await Task.Delay(_pollingInterval, stoppingToken);
        }

        _logger.LogInformation("MessageQueueProcessorService is stopping.");
    }

    private async Task ProcessPendingMessagesAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EduMSDbContext>();

        // Fetch up to 50 pending messages to process in a batch
        var pendingMessages = await dbContext.Set<MessageQueue>()
            .Where(m => m.Status == "Pending")
            .OrderBy(m => m.Id)
            .Take(50)
            .ToListAsync(stoppingToken);

        if (!pendingMessages.Any()) return;

        foreach (var message in pendingMessages)
        {
            try
            {
                _logger.LogInformation($"Sending {message.MessageType} to {message.RecipientAddress} - Subject: {message.Subject}");
                
                // Simulate network delay for sending email/SMS
                await Task.Delay(500, stoppingToken);

                // Assuming successful
                message.Status = "Sent";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send message {message.Id} to {message.RecipientAddress}");
                message.RetryCount++;
                if (message.RetryCount >= 3)
                {
                    message.Status = "Failed";
                }
            }
        }

        await dbContext.SaveChangesAsync(stoppingToken);
    }
}
