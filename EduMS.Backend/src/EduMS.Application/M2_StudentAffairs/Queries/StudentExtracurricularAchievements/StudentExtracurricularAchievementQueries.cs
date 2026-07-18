using EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExtracurricularAchievements;

public class GetStudentExtracurricularAchievementByIdQuery : IRequest<StudentExtracurricularAchievementDto>
{
    public long Id { get; set; }
}

public class GetAllStudentExtracurricularAchievementsQuery : IRequest<IEnumerable<StudentExtracurricularAchievementDto>>
{
}