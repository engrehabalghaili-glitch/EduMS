using EduMS.Application.Common.Models;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Domain.Events;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_CommunicationManagement.EventHandlers;

public class PaymentReceivedEventHandler : INotificationHandler<DomainEventNotification<PaymentReceivedEvent>>
{
    private readonly IGenericRepository<MessageQueue> _messageQueueRepository;
    private readonly IGenericRepository<CommunicationTemplate> _templateRepository;
    private readonly IGenericRepository<Student> _studentRepository;
    private readonly IGenericRepository<Guardian> _guardianRepository;

    public PaymentReceivedEventHandler(
        IGenericRepository<MessageQueue> messageQueueRepository,
        IGenericRepository<CommunicationTemplate> templateRepository,
        IGenericRepository<Student> studentRepository,
        IGenericRepository<Guardian> guardianRepository)
    {
        _messageQueueRepository = messageQueueRepository;
        _templateRepository = templateRepository;
        _studentRepository = studentRepository;
        _guardianRepository = guardianRepository;
    }

    public async Task Handle(DomainEventNotification<PaymentReceivedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        // Fetch Student and Guardian
        var student = await _studentRepository.GetByIdAsync(domainEvent.StudentId, cancellationToken);
        if (student == null || student.GuardianId == null) return;

        var guardian = await _guardianRepository.GetByIdAsync(student.GuardianId.Value, cancellationToken);
        if (guardian == null || string.IsNullOrWhiteSpace(guardian.EmailAddress)) return;

        // Fetch Payment Receipt Template
        var templates = await _templateRepository.FindAsync(t => t.TemplateCode == "PAYMENT_RECEIPT", cancellationToken);
        var template = templates.FirstOrDefault();

        if (template == null) return;

        // Simple string replacement (in a real app, use a templating engine like SmartFormat or Scriban)
        string subject = template.SubjectTemplate.Replace("{StudentName}", student.FullNameEn);
        string body = template.BodyTemplate
            .Replace("{StudentName}", student.FullNameEn)
            .Replace("{Amount}", domainEvent.Amount.ToString("C"))
            .Replace("{Date}", domainEvent.PaymentDate.ToString("yyyy-MM-dd"));

        var messageQueue = new MessageQueue
        {
            MessageType = template.Type,
            RecipientAddress = guardian.EmailAddress,
            Subject = subject,
            Body = body,
            Status = "Pending",
            RetryCount = 0
        };

        await _messageQueueRepository.AddAsync(messageQueue, cancellationToken);
        // Note: UnitOfWork.SaveChangesAsync is already in progress when this is called.
        // The newly added MessageQueue entity will be included in the same transaction!
    }
}
