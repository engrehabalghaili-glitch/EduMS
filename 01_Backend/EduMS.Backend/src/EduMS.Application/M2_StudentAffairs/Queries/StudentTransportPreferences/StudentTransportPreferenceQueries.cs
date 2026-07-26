using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransportPreferences;

public class GetStudentTransportPreferenceByIdQuery : IRequest<StudentTransportPreferenceDto>
{
    public long Id { get; set; }
}

public class GetAllStudentTransportPreferencesQuery : IRequest<IEnumerable<StudentTransportPreferenceDto>>
{
}