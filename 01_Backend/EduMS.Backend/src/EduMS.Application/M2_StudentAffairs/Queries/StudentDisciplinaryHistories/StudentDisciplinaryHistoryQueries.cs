using EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentDisciplinaryHistories;

public class GetStudentDisciplinaryHistoryByIdQuery : IRequest<StudentDisciplinaryHistoryDto>
{
    public long Id { get; set; }
}

public class GetAllStudentDisciplinaryHistoriesQuery : IRequest<IEnumerable<StudentDisciplinaryHistoryDto>>
{
}