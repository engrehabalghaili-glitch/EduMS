using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransportationSubscriptions;

public class CreateStudentTransportationSubscriptionCommand : IRequest<long>
{
    public CreateStudentTransportationSubscriptionDto Dto { get; set; } = new();
}

public class UpdateStudentTransportationSubscriptionCommand : IRequest<bool>
{
    public UpdateStudentTransportationSubscriptionDto Dto { get; set; } = new();
}

public class DeleteStudentTransportationSubscriptionCommand : IRequest<bool>
{
    public long Id { get; set; }
}