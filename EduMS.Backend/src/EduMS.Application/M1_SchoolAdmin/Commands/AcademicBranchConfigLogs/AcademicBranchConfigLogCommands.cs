using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicBranchConfigLogs;

public class CreateAcademicBranchConfigLogCommand : IRequest<long>
{
    public CreateAcademicBranchConfigLogDto Dto { get; set; } = new();
}

public class UpdateAcademicBranchConfigLogCommand : IRequest<bool>
{
    public UpdateAcademicBranchConfigLogDto Dto { get; set; } = new();
}

public class DeleteAcademicBranchConfigLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}