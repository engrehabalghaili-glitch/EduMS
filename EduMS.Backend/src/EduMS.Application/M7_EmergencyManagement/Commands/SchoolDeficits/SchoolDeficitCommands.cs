using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolDeficits;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolDeficits;

public class CreateSchoolDeficitCommand : IRequest<long>
{
    public CreateSchoolDeficitDto Dto { get; set; } = new();
}

public class UpdateSchoolDeficitCommand : IRequest<bool>
{
    public UpdateSchoolDeficitDto Dto { get; set; } = new();
}

public class DeleteSchoolDeficitCommand : IRequest<bool>
{
    public long Id { get; set; }
}