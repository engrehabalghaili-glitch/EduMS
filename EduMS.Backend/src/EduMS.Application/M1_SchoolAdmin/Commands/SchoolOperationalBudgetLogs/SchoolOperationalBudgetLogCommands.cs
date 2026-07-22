using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolOperationalBudgetLogs;

public class CreateSchoolOperationalBudgetLogCommand : IRequest<long>
{
    public CreateSchoolOperationalBudgetLogDto Dto { get; set; } = new();
}

public class UpdateSchoolOperationalBudgetLogCommand : IRequest<bool>
{
    public UpdateSchoolOperationalBudgetLogDto Dto { get; set; } = new();
}

public class DeleteSchoolOperationalBudgetLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}