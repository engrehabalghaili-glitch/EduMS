using EduMS.Application.M2_StudentAffairs.DTOs.AttendanceDetails;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.AttendanceDetails;

public class GetAttendanceDetailByIdQuery : IRequest<AttendanceDetailDto>
{
    public long Id { get; set; }
}

public class GetAllAttendanceDetailsQuery : IRequest<IEnumerable<AttendanceDetailDto>>
{
}