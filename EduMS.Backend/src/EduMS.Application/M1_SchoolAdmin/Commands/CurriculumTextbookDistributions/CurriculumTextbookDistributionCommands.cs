using EduMS.Application.M1_SchoolAdmin.DTOs.CurriculumTextbookDistributions;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.CurriculumTextbookDistributions;

public class CreateCurriculumTextbookDistributionCommand : IRequest<long>
{
    public CreateCurriculumTextbookDistributionDto Dto { get; set; } = new();
}

public class UpdateCurriculumTextbookDistributionCommand : IRequest<bool>
{
    public UpdateCurriculumTextbookDistributionDto Dto { get; set; } = new();
}

public class DeleteCurriculumTextbookDistributionCommand : IRequest<bool>
{
    public long Id { get; set; }
}