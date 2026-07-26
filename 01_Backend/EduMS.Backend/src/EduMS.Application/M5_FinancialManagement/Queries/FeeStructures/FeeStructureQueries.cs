using EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeStructures;

public class GetFeeStructureByIdQuery : IRequest<FeeStructureDto>
{
    public long Id { get; set; }
}

public class GetAllFeeStructuresQuery : IRequest<IEnumerable<FeeStructureDto>>
{
}