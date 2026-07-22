using EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.GradeCapacities;

public class CreateGradeCapacityCommand : IRequest<long>
{
    public CreateGradeCapacityDto Dto { get; set; } = new();
}

public class UpdateGradeCapacityCommand : IRequest<bool>
{
    public UpdateGradeCapacityDto Dto { get; set; } = new();
}

public class DeleteGradeCapacityCommand : IRequest<bool>
{
    public long Id { get; set; }
}