using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Events;

public class PaymentReceivedEvent : IDomainEvent
{
    public long FeePaymentId { get; }
    public long StudentId { get; }
    public decimal Amount { get; }
    public DateTime PaymentDate { get; }
    public DateTimeOffset OccurredOn { get; }

    public PaymentReceivedEvent(long feePaymentId, long studentId, decimal amount, DateTime paymentDate)
    {
        FeePaymentId = feePaymentId;
        StudentId = studentId;
        Amount = amount;
        PaymentDate = paymentDate;
        OccurredOn = DateTimeOffset.UtcNow;
    }
}
