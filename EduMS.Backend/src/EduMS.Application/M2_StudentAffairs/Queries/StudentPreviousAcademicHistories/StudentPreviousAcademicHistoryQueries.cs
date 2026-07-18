using EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentPreviousAcademicHistories;

public class GetStudentPreviousAcademicHistoryByIdQuery : IRequest<StudentPreviousAcademicHistoryDto>
{
    public long Id { get; set; }
}

public class GetAllStudentPreviousAcademicHistoriesQuery : IRequest<IEnumerable<StudentPreviousAcademicHistoryDto>>
{
}