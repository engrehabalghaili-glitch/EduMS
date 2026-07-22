using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolMergers;

public class CreateSchoolMergerCommand : IRequest<long>
{
    public CreateSchoolMergerDto Dto { get; set; } = new();
}

public class UpdateSchoolMergerCommand : IRequest<bool>
{
    public UpdateSchoolMergerDto Dto { get; set; } = new();
}

public class DeleteSchoolMergerCommand : IRequest<bool>
{
    public long Id { get; set; }
}