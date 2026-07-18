using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolCurriculumPlans;

public class CreateSchoolCurriculumPlanCommand : IRequest<long>
{
    public CreateSchoolCurriculumPlanDto Dto { get; set; } = new();
}

public class UpdateSchoolCurriculumPlanCommand : IRequest<bool>
{
    public UpdateSchoolCurriculumPlanDto Dto { get; set; } = new();
}

public class DeleteSchoolCurriculumPlanCommand : IRequest<bool>
{
    public long Id { get; set; }
}