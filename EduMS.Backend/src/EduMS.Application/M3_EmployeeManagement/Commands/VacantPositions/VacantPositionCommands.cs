using EduMS.Application.M3_EmployeeManagement.DTOs.VacantPositions;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.VacantPositions;

public class CreateVacantPositionCommand : IRequest<long>
{
    public CreateVacantPositionDto Dto { get; set; } = new();
}

public class UpdateVacantPositionCommand : IRequest<bool>
{
    public UpdateVacantPositionDto Dto { get; set; } = new();
}

public class DeleteVacantPositionCommand : IRequest<bool>
{
    public long Id { get; set; }
}