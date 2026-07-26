using EduMS.Application.M2_StudentAffairs.DTOs.StudentParentConferenceReservations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentParentConferenceReservations;

public class GetStudentParentConferenceReservationByIdQuery : IRequest<StudentParentConferenceReservationDto>
{
    public long Id { get; set; }
}

public class GetAllStudentParentConferenceReservationsQuery : IRequest<IEnumerable<StudentParentConferenceReservationDto>>
{
}