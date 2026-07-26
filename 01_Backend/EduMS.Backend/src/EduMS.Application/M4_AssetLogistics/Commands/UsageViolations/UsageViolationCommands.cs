using EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.UsageViolations;

public class CreateUsageViolationCommand : IRequest<long>
{
    public CreateUsageViolationDto Dto { get; set; } = new();
}

public class UpdateUsageViolationCommand : IRequest<bool>
{
    public UpdateUsageViolationDto Dto { get; set; } = new();
}

public class DeleteUsageViolationCommand : IRequest<bool>
{
    public long Id { get; set; }
}