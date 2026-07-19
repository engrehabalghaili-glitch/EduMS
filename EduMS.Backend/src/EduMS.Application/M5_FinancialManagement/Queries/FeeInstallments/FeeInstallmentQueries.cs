using EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeInstallments;

public class GetFeeInstallmentByIdQuery : IRequest<FeeInstallmentDto>
{
    public long Id { get; set; }
}

public class GetAllFeeInstallmentsQuery : IRequest<IEnumerable<FeeInstallmentDto>>
{
}