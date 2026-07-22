using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicWarningPolicies;

public class CreateAcademicWarningPolicyCommand : IRequest<long>
{
    public CreateAcademicWarningPolicyDto Dto { get; set; } = new();
}

public class UpdateAcademicWarningPolicyCommand : IRequest<bool>
{
    public UpdateAcademicWarningPolicyDto Dto { get; set; } = new();
}

public class DeleteAcademicWarningPolicyCommand : IRequest<bool>
{
    public long Id { get; set; }
}