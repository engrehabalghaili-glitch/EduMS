using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAccreditationLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAccreditationLogs;

public class CreateSchoolAccreditationLogCommand : IRequest<long>
{
    public CreateSchoolAccreditationLogDto Dto { get; set; } = new();
}

public class UpdateSchoolAccreditationLogCommand : IRequest<bool>
{
    public UpdateSchoolAccreditationLogDto Dto { get; set; } = new();
}

public class DeleteSchoolAccreditationLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}