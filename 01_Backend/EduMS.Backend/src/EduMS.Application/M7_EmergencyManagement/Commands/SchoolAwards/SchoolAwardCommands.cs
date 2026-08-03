using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolAwards;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolAwards;

public class CreateSchoolAwardCommand : IRequest<long>
{
    public CreateSchoolAwardDto Dto { get; set; } = new();
}

public class UpdateSchoolAwardCommand : IRequest<bool>
{
    public UpdateSchoolAwardDto Dto { get; set; } = new();
}

public class DeleteSchoolAwardCommand : IRequest<bool>
{
    public long Id { get; set; }
}