using EduMS.Application.M5_FinancialManagement.DTOs.PayrollRuns;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.PayrollRuns;

public class GetPayrollRunByIdQuery : IRequest<PayrollRunDto>
{
    public long Id { get; set; }
}

public class GetAllPayrollRunsQuery : IRequest<IEnumerable<PayrollRunDto>>
{
}