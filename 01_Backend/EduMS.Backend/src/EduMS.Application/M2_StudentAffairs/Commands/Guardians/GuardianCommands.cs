using EduMS.Application.M2_StudentAffairs.DTOs.Guardians;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.Guardians;

public class CreateGuardianCommand : IRequest<long>
{
    public CreateGuardianDto Dto { get; set; } = new();
}

public class UpdateGuardianCommand : IRequest<bool>
{
    public UpdateGuardianDto Dto { get; set; } = new();
}

public class DeleteGuardianCommand : IRequest<bool>
{
    public long Id { get; set; }
}