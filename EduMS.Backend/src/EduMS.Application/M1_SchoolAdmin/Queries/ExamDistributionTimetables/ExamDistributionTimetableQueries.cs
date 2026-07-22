using EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ExamDistributionTimetables;

public class GetExamDistributionTimetableByIdQuery : IRequest<ExamDistributionTimetableDto>
{
    public long Id { get; set; }
}

public class GetAllExamDistributionTimetablesQuery : IRequest<IEnumerable<ExamDistributionTimetableDto>>
{
}