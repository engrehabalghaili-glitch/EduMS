using EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeTypes;

public class GetFeeTypeByIdQuery : IRequest<FeeTypeDto>
{
    public long Id { get; set; }
}

public class GetAllFeeTypesQuery : IRequest<IEnumerable<FeeTypeDto>>
{
}