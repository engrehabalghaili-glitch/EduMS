using EduMS.Application.M1_SchoolAdmin.DTOs.CurriculumTextbookDistributions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.CurriculumTextbookDistributions;

public class GetCurriculumTextbookDistributionByIdQuery : IRequest<CurriculumTextbookDistributionDto>
{
    public long Id { get; set; }
}

public class GetAllCurriculumTextbookDistributionsQuery : IRequest<IEnumerable<CurriculumTextbookDistributionDto>>
{
}