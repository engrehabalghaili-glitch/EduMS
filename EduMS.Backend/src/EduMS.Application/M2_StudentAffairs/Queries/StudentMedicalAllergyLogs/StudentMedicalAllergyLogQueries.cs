using EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentMedicalAllergyLogs;

public class GetStudentMedicalAllergyLogByIdQuery : IRequest<StudentMedicalAllergyLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentMedicalAllergyLogsQuery : IRequest<IEnumerable<StudentMedicalAllergyLogDto>>
{
}