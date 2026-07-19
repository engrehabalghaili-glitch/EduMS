using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolSurpluses;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolSurpluses;

public class CreateSchoolSurplusCommand : IRequest<long>
{
    public CreateSchoolSurplusDto Dto { get; set; } = new();
}

public class UpdateSchoolSurplusCommand : IRequest<bool>
{
    public UpdateSchoolSurplusDto Dto { get; set; } = new();
}

public class DeleteSchoolSurplusCommand : IRequest<bool>
{
    public long Id { get; set; }
}