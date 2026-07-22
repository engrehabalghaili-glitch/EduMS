using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransportationSubscriptions;

public class GetStudentTransportationSubscriptionByIdQuery : IRequest<StudentTransportationSubscriptionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentTransportationSubscriptionsQuery : IRequest<IEnumerable<StudentTransportationSubscriptionDto>>
{
}