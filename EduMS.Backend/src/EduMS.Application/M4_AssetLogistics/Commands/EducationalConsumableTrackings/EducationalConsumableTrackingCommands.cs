using EduMS.Application.M4_AssetLogistics.DTOs.EducationalConsumableTrackings;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.EducationalConsumableTrackings;

public class CreateEducationalConsumableTrackingCommand : IRequest<long>
{
    public CreateEducationalConsumableTrackingDto Dto { get; set; } = new();
}

public class UpdateEducationalConsumableTrackingCommand : IRequest<bool>
{
    public UpdateEducationalConsumableTrackingDto Dto { get; set; } = new();
}

public class DeleteEducationalConsumableTrackingCommand : IRequest<bool>
{
    public long Id { get; set; }
}