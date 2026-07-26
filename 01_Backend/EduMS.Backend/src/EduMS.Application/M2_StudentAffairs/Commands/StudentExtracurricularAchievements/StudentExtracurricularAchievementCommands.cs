using EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExtracurricularAchievements;

public class CreateStudentExtracurricularAchievementCommand : IRequest<long>
{
    public CreateStudentExtracurricularAchievementDto Dto { get; set; } = new();
}

public class UpdateStudentExtracurricularAchievementCommand : IRequest<bool>
{
    public UpdateStudentExtracurricularAchievementDto Dto { get; set; } = new();
}

public class DeleteStudentExtracurricularAchievementCommand : IRequest<bool>
{
    public long Id { get; set; }
}