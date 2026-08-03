using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeCommittees;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeCommittees;

public class CreateEmployeeCommitteeCommand : IRequest<long>
{
    public CreateEmployeeCommitteeDto Dto { get; set; } = new();
}

public class UpdateEmployeeCommitteeCommand : IRequest<bool>
{
    public UpdateEmployeeCommitteeDto Dto { get; set; } = new();
}

public class DeleteEmployeeCommitteeCommand : IRequest<bool>
{
    public long Id { get; set; }
}