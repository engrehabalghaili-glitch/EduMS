using EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.GradingScaleBounds;

public class CreateGradingScaleBoundCommand : IRequest<long>
{
    public CreateGradingScaleBoundDto Dto { get; set; } = new();
}

public class UpdateGradingScaleBoundCommand : IRequest<bool>
{
    public UpdateGradingScaleBoundDto Dto { get; set; } = new();
}

public class DeleteGradingScaleBoundCommand : IRequest<bool>
{
    public long Id { get; set; }
}