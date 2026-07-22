using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomOperationalRules;

public class CreateClassroomOperationalRuleCommand : IRequest<long>
{
    public CreateClassroomOperationalRuleDto Dto { get; set; } = new();
}

public class UpdateClassroomOperationalRuleCommand : IRequest<bool>
{
    public UpdateClassroomOperationalRuleDto Dto { get; set; } = new();
}

public class DeleteClassroomOperationalRuleCommand : IRequest<bool>
{
    public long Id { get; set; }
}