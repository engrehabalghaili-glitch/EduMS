using EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.DetailedAcademicWarningLogs;

public class CreateDetailedAcademicWarningLogCommand : IRequest<long>
{
    public CreateDetailedAcademicWarningLogDto Dto { get; set; } = new();
}

public class UpdateDetailedAcademicWarningLogCommand : IRequest<bool>
{
    public UpdateDetailedAcademicWarningLogDto Dto { get; set; } = new();
}

public class DeleteDetailedAcademicWarningLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}